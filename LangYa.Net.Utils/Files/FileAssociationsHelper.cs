using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Win32;

namespace LangYa.Net.Utils.Files
{
    /// <summary>
    /// 注册文件关联的应用程序的辅助类
    /// </summary>
    public class FileAssociationsHelper
    {
        private static RegistryKey classesRoot;  // 注册表的根目录

        private static void Process(string[] args)
        {
            if (args.Length < 6)
            {
                string error = ("Usage: <ProgId> <Register in HKCU: true|false> <AppId> <OpenWithSwitch> <Unregister: true|false> <Ext1> [Ext2 [Ext3] ...]");
                throw new ArgumentException(error);
            }

            try
            {
                string  progId         = args[0];
                bool    registerInHKCU = bool.Parse(args[1]);
                string  appId          = args[2];
                string  openWith       = args[3];
                bool    unregister     = bool.Parse(args[4]);

                List<string> argList = new List<string>();
                for (int i = 5; i < args.Length; i++)
                {
                    argList.Add(args[i]);
                }
                string[] associationsToRegister = argList.ToArray(); // 文件列表

                if (registerInHKCU)
                {
                    classesRoot = Registry.CurrentUser.OpenSubKey(@"Software\Classes");
                }
                else
                {
                    classesRoot = Registry.ClassesRoot;
                }

                // 注销
                Array.ForEach(associationsToRegister, assoc => UnregisterFileAssociation(progId, assoc));
                UnregisterProgId(progId);

                // 注册
                if (!unregister)
                {
                    RegisterProgId(progId, appId, openWith);
                    Array.ForEach(associationsToRegister, assoc => RegisterFileAssociation(progId, assoc));
                }
            }
            catch (Exception e)
            {
               
            }
        }

        /// <summary>
        /// 注册类标识符
        /// </summary>
        /// <param name="progId">类标识符</param>
        /// <param name="appId">应用程序Id</param>
        /// <param name="openWith">打开文件的进程全路径</param>
        private static void RegisterProgId(string progId, string appId, string openWith)
        {
            RegistryKey progIdKey = classesRoot.CreateSubKey(progId);
            progIdKey.SetValue("FriendlyTypeName", "@shell32.dll,-8975");
            progIdKey.SetValue("DefaultIcon", "@shell32.dll,-47");
            progIdKey.SetValue("CurVer", progId);
            progIdKey.SetValue("AppUserModelID", appId);

            RegistryKey shell = progIdKey.CreateSubKey("shell");
            shell.SetValue(String.Empty, "Open");
            shell = shell.CreateSubKey("Open");
            shell = shell.CreateSubKey("Command");
            shell.SetValue(String.Empty, openWith + " %1"); // " %1"表示将被双击的文件的路径传给目标应用程序 

            shell.Close();
            progIdKey.Close();
        }

        /// <summary>
        /// 注销类标识符
        /// </summary>
        /// <param name="progId">类标识符</param>
        private static void UnregisterProgId(string progId)
        {
            try
            {
                classesRoot.DeleteSubKeyTree(progId);
            }
            catch { }
        }

        /// <summary>
        /// 注册文件关联
        /// </summary>
        private static void RegisterFileAssociation(string progId, string extension)
        {
            RegistryKey openWithKey = classesRoot.CreateSubKey(Path.Combine(extension, "OpenWithProgIds"));
            openWithKey.SetValue(progId, String.Empty);
            openWithKey.Close();
        }

        /// <summary>
        /// 注销文件关联
        /// </summary>
        private static void UnregisterFileAssociation(string progId, string extension)
        {
            try
            {
                RegistryKey openWithKey = classesRoot.CreateSubKey(Path.Combine(extension, "OpenWithProgIds"));
                openWithKey.DeleteValue(progId);
                openWithKey.Close();
            }
            catch (Exception e)
            {
                
            }
        }

        /// <summary>
        /// 类标识符注册操作
        /// </summary>
        /// <param name="unregister">注册或注销</param>
        /// <param name="progId">类标识符</param>
        /// <param name="registerInHKCU">是否在HKCU中注册文件关联 -- false</param>
        /// <param name="appId">应用程序Id</param>
        /// <param name="openWith">打开文件的进程全路径</param>
        /// <param name="extensions">文件关联列表</param>
        private static void InternalRegisterFileAssociations(bool unregister, 
                                                             string progId, bool registerInHKCU,string appId, string openWith, 
                                                             string[] extensions)
        {
            string Arguments = string.Format("{0} {1} {2} \"{3}\" {4} {5}",
                                              progId, // 0
                                              registerInHKCU, // 1 
                                              appId, // 2
                                              openWith,
                                              unregister,
                                              string.Join(" ", extensions));
            try
            {
                Process(Arguments.Split(' '));
            }
            catch (Win32Exception e)
            {
                if (e.NativeErrorCode == 1223) // 1223:用户操作被取消。
                {
                    // 该操作已经被用户取消
                }
            }
        }

        /// <summary>
        /// 判断类标识符是否注册
        /// </summary>
        /// <param name="progId">类标识符</param>
        /// <returns>注册了返回true</returns>
        public static bool IsApplicationRegistered(string progId)
        {
            return (Registry.ClassesRoot.OpenSubKey(progId) != null);
        }

        /// <summary>
        /// 注册类标识符的文件关联
        /// </summary>
        /// <param name="progId">类标识符</param>
        /// <param name="registerInHKCU">是否在HKCU中注册文件关联 -- false
        /// <param name="appId">应用程序Id</param>
        /// <param name="openWith">打开文件的进程全路径</param>
        /// <param name="extensions">文件关联列表</param>
        public static void RegisterFileAssociations(string progId,bool registerInHKCU, string appId, string openWith,
                                                    params string[] extensions)
        {
            InternalRegisterFileAssociations(false, progId, registerInHKCU, appId, openWith, extensions);
        }

        /// <summary>
        /// 注销类标识符的文件关联
        /// </summary>
        /// <param name="progId">类标识符</param>
        /// <param name="registerInHKCU">是否在HKCU中注册文件关联 -- false
        /// <param name="appId">应用程序Id</param>
        /// <param name="openWith">打开文件的进程全路径</param>
        /// <param name="extensions">文件关联列表</param>
        public static void UnregisterFileAssociations(string progId, bool registerInHKCU, string appId, string openWith,
                                                      params string[] extensions)
        {
            InternalRegisterFileAssociations(true, progId, registerInHKCU, appId, openWith, extensions);
        }
    }
}
