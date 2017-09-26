using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Test
{
    public partial class APIFrm : Form
    {
        private string _serverPath = "http://test.moocapi.boolongo.com";
        //private string _serverPath  = "http://192.168.1.3:8002";

        private string _accessKey = "0f874c58c4234c679dfff3059d6a2def";
        private string _secretKey = "3595d1124a0d42f1afa1d277ccd29ecb";

        private string _uri_loginPath = "/api/home/user/login";
        private string _uri_Upload = "/api/home/network_disk/upload";

        private string _uri_captcha              = "/api/home/common/captcha";
        private string _uri_findpwd_sendcaptcha  = "/api/home/user/findpwd_sendcaptcha";
        private string _uri_findpwd_checkcaptcha = "/api/home/user/findpwd_checkcaptcha";

        private string _accessToken = "";

        public APIFrm()
        {           
            InitializeComponent();
        }

        /// <summary>
        ///  数字签名
        ///  Authorization: HACFINCLOUD AccessKey:Signature
        /// </summary>
        /// <param name="uri">请求地址</param>
        private string Generate_Auth_Info(string uri)
        {
            HMACSHA1 hmacsha = new HMACSHA1();

            hmacsha.Key = Encoding.UTF8.GetBytes(this._secretKey);
            byte[] dataBuffer = Encoding.UTF8.GetBytes(uri);
            byte[] hashBytes = hmacsha.ComputeHash(dataBuffer);

            string digest = Convert.ToBase64String(hashBytes);
            digest = digest.Replace('+', '-');
            digest = digest.Replace('/', '_');
            digest = string.Join("", digest.Split('=')); 
            return "HACFINCLOUD " + this._accessKey +  ':' + digest;
        }

        private void upload_btn_Click(object sender, EventArgs e)
        {
            var client = new RestClient(this._serverPath);

            //1.0 登录平台
            var request = new RestRequest(this._uri_loginPath, Method.GET);
            request.AddParameter("name", "admin");
            request.AddParameter("pwd", "123456");
            request.AddHeader("Authorization", this.Generate_Auth_Info(this._uri_loginPath));

            IRestResponse response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<ReqLogin>(response.Content);

            this._accessToken = content.result.ACCESS_TOKEN;

            //2.0 上传文件
            string filepath = "D:\\TestSource\\Audio\\夜的钢琴曲(I)\\1981.mp3";
            long totalLen = new FileInfo(filepath).Length;
            int  pieceLen = Math.Min(1 * 1024 * 1024, (int)totalLen);

            FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            int pieceCnt = (int)Math.Ceiling(fileStream.Length * 1.0 / pieceLen);

            BinaryReader reader = new BinaryReader(fileStream);
            byte[] buffer = new byte[pieceLen];
            int size = reader.Read(buffer, 0, pieceLen);
            int _filePieceIndex = -1;
            string _strGUID = string.Join("", Guid.NewGuid().ToString().Split('-')); //32!!!
            while (size > 0)
            {
                _filePieceIndex++;

                var requestFilewrite = new RestRequest(this._uri_Upload, Method.POST);
                requestFilewrite.AddParameter("fid", _strGUID);
                requestFilewrite.AddParameter("name", "1981.mp3");
                requestFilewrite.AddParameter("chunk", _filePieceIndex);
                requestFilewrite.AddParameter("chunks", pieceCnt);
                requestFilewrite.AddParameter("ACCESS-TOKEN", this._accessToken);
                requestFilewrite.AddHeader("Authorization", this.Generate_Auth_Info(this._uri_Upload));

                if(size == pieceLen)
                    requestFilewrite.AddFile("file", buffer, "1981.mp3");
                else
                {
                    byte[] tmp = new byte[size];
                    Buffer.BlockCopy(buffer, 0, tmp, 0, size);
                    requestFilewrite.AddFile("file", tmp, "1981.mp3");
                }

                IRestResponse responseFilewrite = client.Execute(requestFilewrite);
               
                if (responseFilewrite.StatusCode == HttpStatusCode.OK)
                {
                    size = reader.Read(buffer, 0, pieceLen);
                }
            }

            reader.Close();
            fileStream.Close();
        }

        private void check_btn_Click(object sender, EventArgs e)
        {
            var client = new RestClient(this._serverPath);           

            //1.0 发送验证码
            var request = new RestRequest(this._uri_findpwd_sendcaptcha, Method.GET);
            request.AddParameter("email", "1032030048@qq.com");
            request.AddHeader("Authorization", this.Generate_Auth_Info(this._uri_findpwd_sendcaptcha));

            IRestResponse response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<ReqBase>(response.Content);

            //1.0 验证码
            //request = new RestRequest(this._uri_captcha, Method.GET);
            //request.AddHeader("Authorization", this.Generate_Auth_Info(this._uri_findpwd_sendcaptcha));

            //response = client.Execute(request);

            //2.0 检测验证码
            request = new RestRequest(this._uri_findpwd_checkcaptcha, Method.GET);
            request.AddParameter("email", "1032030048@qq.com");
            request.AddParameter("code", "157789");

            //传入cookie
            foreach(RestResponseCookie cookie in response.Cookies)
            {
                request.AddParameter(cookie.Name, cookie.Value, ParameterType.Cookie);
            } 
                       
            request.AddHeader("Authorization", this.Generate_Auth_Info(this._uri_findpwd_sendcaptcha));

            response = client.Execute(request);
            content = JsonConvert.DeserializeObject<ReqBase>(response.Content);
        }
    }

    //--------------------------------------------------- 返回值类封装 ---------------------------------------------------//
    public class ReqBase
    {
        public string code { get; set; }
        public string msg { get; set; }
    }

    public class ReqLoginResult
    {
        [JsonProperty(PropertyName = "ACCESS-TOKEN")]
        public string ACCESS_TOKEN { get; set; }
    }

    //--------------------------------------------------- 返回值 封装 ---------------------------------------------------//
    public class ReqLogin : ReqBase
    {
        public ReqLoginResult result { get; set; }      
    }
}
