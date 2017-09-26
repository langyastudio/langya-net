using System;
using WebSocketSharp;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Threading;
using RestSharp;
using System.IO;
using System.Net;

namespace Test
{
    public partial class WebSocketFrm : Form
    {
        private string _clientId           = "";
        private bool   _bIsListen          = false;
        private string _strMonitor         = "";
        private string _strStream          = "";
        private string _pptId              = Guid.NewGuid().ToString();

        private static string _strIp       = "live.boolongo.com";
        //private static string _strIp = "192.168.123.3";
        private string _strServer          = "http://" + _strIp + ":8014";
        private RestClient _client         = null;
        private string _uri_startmonitor   = "/api/director/startmonitor";
        private string _uri_stopmonitor    = "/api/director/stopmonitor";
        private string _uri_switchppt      = "/api/director/switchppt";
        private string _uri_setinteract    = "/api/director/setinteract";
        private string _uri_switchinteract = "/api/director/switchinteract";

        private string _uri_startpublish   = "/api/auth/startpublish";

        private string _uri_uploadPPT = "/api/director/uploadppt";

        public WebSocketFrm()
        {
            //禁用了所有的控件合法性检查。
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            _bIsListen  = !chkBox_type.Checked;
            if(!_bIsListen)
                _strMonitor = txtBox_interact.Text;
            _strStream = txtBox_stream.Text;
            _client = new RestClient(_strServer);

            //启动WebSocket连接
            Thread getNewThread = new Thread(new ThreadStart(this.Ws_Start));
            getNewThread.IsBackground = true;   
            getNewThread.Priority = ThreadPriority.Highest;                     
            getNewThread.Start(); 
        }

        private void Ws_Start()
        {
            using (var ws = new WebSocket("ws://" + _strIp + ":2346"))
            {
                ws.OnMessage += Ws_OnMessage;
                ws.Connect();
                Thread.Sleep(100000000);
            }
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                SocketMsg msg = JsonConvert.DeserializeObject<SocketMsg>(e.Data);
                if (msg.Type == "connect")
                {
                    _clientId = (string)msg.Msg;
                }
                else
                { 

                }

                richTextBox1.Text += msg.Type + " : " + msg.Msg + "\r\n";
            }
            catch (Exception exp)
            {
                richTextBox1.Text += exp;
            }
        }

        private void btn_startmonitor_Click(object sender, EventArgs e)
        {
            var request = new RestRequest(_uri_startmonitor, Method.GET);
            request.AddParameter("interact", _strMonitor);
            request.AddParameter("stream", _strStream);
            request.AddParameter("client_id", _clientId);

            IRestResponse response = _client.Execute(request);
            var content = response.Content;
        }

        private void btn_stopmonitor_Click(object sender, EventArgs e)
        {
            var request = new RestRequest(_uri_stopmonitor, Method.GET);
            request.AddParameter("interact", _strMonitor);
            request.AddParameter("stream", _strStream);
            request.AddParameter("client_id", _clientId);

            IRestResponse response = _client.Execute(request);
            var content = response.Content;
        }

        private void btn_switchppt_Click(object sender, EventArgs e)
        {
            var request = new RestRequest(_uri_switchppt, Method.GET);
            request.AddParameter("interact", _strMonitor);
            request.AddParameter("ppt_id", _pptId);
            request.AddParameter("page", new Random().Next(1, 50));

            IRestResponse response = _client.Execute(request);
            var content = response.Content;
        }

        private void btn_setinteract_Click(object sender, EventArgs e)
        {
            var request = new RestRequest(_uri_setinteract, Method.GET);
            request.AddParameter("interact", _strMonitor);
            request.AddParameter("stream", "LB102");
            request.AddParameter("isadd", 1);
            request.AddParameter("monitors", "");
            request.AddParameter("output", "");

            IRestResponse response = _client.Execute(request);
            var content = response.Content;
        }

        private void btn_switchinteract_Click(object sender, EventArgs e)
        {
            var request = new RestRequest(_uri_switchinteract, Method.GET);
            request.AddParameter("interact", _strMonitor);
            request.AddParameter("monitors", Guid.NewGuid().ToString());
            request.AddParameter("output", Guid.NewGuid().ToString());

            IRestResponse response = _client.Execute(request);
            var content = response.Content;
        }

        private void chkBox_type_CheckedChanged(object sender, EventArgs e)
        {
            _bIsListen = !chkBox_type.Checked;
            if (!_bIsListen)
                _strMonitor = txtBox_interact.Text;
            else
                _strMonitor = "";
        }

        private void txtBox_stream_TextChanged(object sender, EventArgs e)
        {
            _strStream = txtBox_stream.Text;
        }

        private void txtBox_interact_TextChanged(object sender, EventArgs e)
        {
            if (!_bIsListen)
                _strMonitor = txtBox_interact.Text;
            else
                _strMonitor = "";
        }

        private void btnstartpublish_Click(object sender, EventArgs e)
        {
            var request = new RestRequest(_uri_startpublish, Method.GET);
            request.AddParameter("stream", _strStream);
            request.AddParameter("client_id", _clientId);

            IRestResponse response = _client.Execute(request);
            var content = response.Content;
        }

        private void btnuploadppt_Click(object sender, EventArgs e)
        {
            string filepath = "D:\\TestSource\\Office\\01 成就自己 感知未来.ppt";

            var requestFilewrite = new RestRequest(this._uri_uploadPPT, Method.POST);
            requestFilewrite.AddParameter("interact", "01_001_111_i");
            requestFilewrite.AddParameter("ppt_id", Guid.NewGuid());
            requestFilewrite.AddFile("01 成就自己 感知未来.ppt", filepath);

            IRestResponse responseFilewrite = _client.Execute(requestFilewrite);

            if (responseFilewrite.StatusCode == HttpStatusCode.OK)
            {

            }
        }
    }
}
