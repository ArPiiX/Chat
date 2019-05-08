using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace chat
{
    public partial class ChatForm : Form
    {
        public static ChatForm openChatForm;
        public static EFAForm efaForm;
        public static Thread messageThread;
        public static Thread vvsThread;

        public ChatForm(string name)
        {
            openChatForm = this;
            InitializeComponent();
            username = name;
            GetMessages();
            // set the current caret position to the end
            txbOutput.SelectionStart = txbOutput.Text.Length;
            
            messageThread = new Thread(FetchMessages.Messages);
            messageThread.IsBackground = true;
            messageThread.Start();
        }


        private static readonly HttpClient client = new HttpClient();
        Dictionary<string, string> values = new Dictionary<string, string> { };
        public static string username;
        string publicKey = Program.publicKey;
        static int lastMessage;
        static string usernames;

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txbInput.Text == "")
            {
                GetMessages();
            }
            else
            {
                var values = new Dictionary<string, string>
                {
                    { "method", "sendmessage" },
                    { "key", publicKey },
                    { "username", username },
                    { "usersecret", Program.secret },
                    { "message", txbInput.Text },
                };
                Program.PostUserContent(values, "chat");
                GetMessages();
                txbInput.Clear();
            }
        }

        private void btnGameSelection_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented!", "Notice");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetMessages();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            messageThread.Abort();
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(Program.LogOut());
            if (response.ContainsKey("error"))
            {
                MessageBox.Show(response["error"]);
            }
            else if (response.ContainsKey("response"))
            {
                Program.neededForm = "";
                MessageBox.Show(response["response"]);
                this.Hide();
                this.Close();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            messageThread.Abort();
            Program.LogOut();
            Program.neededForm = "logOut";
            Environment.Exit(0);
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            messageThread.Abort();
            Program.LogOut();
            Program.neededForm = "logOut";
            Environment.Exit(0);
        }

        private static void GetMessages()
        {
            var values = new Dictionary<string, string>
                    {
                        { "method", "getmessages"   },
                        { "key", Program.publicKey     },
                        { "username", Program.username },
                        { "usersecret", Program.secret }
                    };
            openChatForm.AddText(Program.PostUserContent(values, "chat"));
        }

        private static void WriteUsers(string values)
        {

        }

        private static void GetUsers()
        {
            var values = new Dictionary<string, string>
                    {
                        { "method", "users"   },
                        { "key", Program.publicKey     },
                        { "username", Program.username },
                        { "usersecret", Program.secret }
                    };
            var response = Program.PostUserContent(values, "chat");

            string json = response;

            JArray a = JArray.Parse(json);
            usernames = "";

            foreach(string name in a)
            {
                usernames += name + ",\r\n";
            }

            lblHeader.Text = "Teilnehmer:\r\n" + usernames;
        }

        public void AddText(string text)
        {
            if (txbOutput.InvokeRequired)
            {
                MethodInvoker del = delegate { AddText(text); };
                txbOutput.Invoke(del);
                MethodInvoker user = delegate { GetUsers(); };
                openChatForm.Invoke(user);
            }
            else
            {
                var response = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(text);

                foreach (var kvp in response)
                {
                    if (Convert.ToInt32(kvp.Key) > lastMessage)
                    {
                        var innerDict = kvp.Value;
                        if (innerDict["autogenerated"] == "true")
                        {
                            txbOutput.AppendText("\r\n" + "============\r\n");
                            txbOutput.AppendText(innerDict["timestamp"].Substring(11, 8) + " - " + innerDict["username"] + ": " + innerDict["content"]);
                            txbOutput.AppendText("\r\n" + "============\r\n");
                        }
                        else
                        {
                            txbOutput.AppendText("\r\n" + innerDict["timestamp"].Substring(11, 8) + " - " + innerDict["username"] + ": " + innerDict["content"]);
                        }
                        lastMessage++;
                    }
                }
                // scroll it automatically
                //txbOutput.ScrollToCaret();
            }
        }

        private void txbOutput_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            txbOutput.SelectionStart = txbOutput.Text.Length;
            // scroll it automatically
            txbOutput.ScrollToCaret();
        }

        private void btnVVS_Click(object sender, EventArgs e)
        {
            Program.neededForm = "vvs";
            messageThread.Abort();
            this.Close();
        }
    }
}
