using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class SocketMsg
    {
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private object _msg;
        public object Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
    }
}
