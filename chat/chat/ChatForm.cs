﻿using System;
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

namespace chat
{
    public partial class ChatForm : Form
    {
        public static ChatForm openChatForm;
        public static Thread messageThread;

        public ChatForm(string name)
        {
            openChatForm = this;
            InitializeComponent();
            this.username = name;
            lblHeader.Text = "Teilnehmer: " + username;
            GetMessages();
            // set the current caret position to the end
            txbOutput.SelectionStart = txbOutput.Text.Length;
            messageThread = new Thread(FetchMessages.Messages);
            messageThread.IsBackground = true;
            messageThread.Start();
        }


        private static readonly HttpClient client = new HttpClient();
        Dictionary<string, string> values = new Dictionary<string, string> { };
        private string username;
        private string publicKey = Program.publicKey;

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
                Program.PostUserContent(values);
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
            Program.neededForm = "logOut";
            Environment.Exit(0);
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            messageThread.Abort();
            Program.LogOut();
            Environment.Exit(0);
        }

        private static void WriteMessages(string values)
        {
            var response = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(values);
            txbOutput.Text = "";

            foreach (var kvp in response)
            {
                var innerDict = kvp.Value;
                if (innerDict["autogenerated"] == "true")
                {
                    txbOutput.Text += "============\r\n";
                    txbOutput.Text += innerDict["timestamp"].Substring(11, 8) + " - " + innerDict["username"] + ": " + innerDict["content"] + "\r\n";
                    txbOutput.Text += "============\r\n";
                }
                else
                {
                    txbOutput.Text += innerDict["timestamp"].Substring(11, 8) + " - " + innerDict["username"] + ": " + innerDict["content"] + "\r\n";
                }
            }
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
            WriteMessages(Program.PostUserContent(values));
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
            var response = Program.PostUserContent(values);
            lblHeader.Text = response;
        }

        public void AddText(string text)
        {
            if (txbOutput.InvokeRequired)
            {
                MethodInvoker del = delegate { AddText(text); };
                txbOutput.Invoke(del);
            }
            else
            {
                var response = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(text);

                foreach (var kvp in response)
                {
                    var innerDict = kvp.Value;
                    if (innerDict["autogenerated"] == "true")
                    {
                        txbOutput.Text += "============\r\n";
                        txbOutput.Text += innerDict["timestamp"].Substring(11, 8) + " - " + innerDict["username"] + ": " + innerDict["content"] + "\r\n";
                        txbOutput.Text += "============\r\n";
                    }
                    else
                    {
                        txbOutput.Text += innerDict["timestamp"].Substring(11, 8) + " - " + innerDict["username"] + ": " + innerDict["content"] + "\r\n";
                    }
                }
                // scroll it automatically
                txbOutput.ScrollToCaret();
            }
        }

        private void txbOutput_TextChanged(object sender, EventArgs e)
        {
            txbOutput.ScrollToCaret();
        }
    }
}