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

namespace chat
{
    public partial class ChatForm : Form
    {
        public ChatForm(string name)
        {
            InitializeComponent();
            this.username = name;
            lblHeader.Text = "Teilnehmer: " + username + ", " + "user2";
            //Program.childThread.Start();
        }

        
        private static readonly HttpClient client = new HttpClient();
        Dictionary<string, string> values = new Dictionary<string, string> { };
        private string username;
        private string publicKey = Program.publicKey;

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txbInput.Text == "")
            {
               
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

                txbOutput.Text += username + ": " + txbInput.Text + "\r\n";
                txbInput.Clear();
            }
        }

        private void btnGameSelection_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented!", "Notice");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(Program.LogOut());
            if (response.ContainsKey("error"))
            {
                MessageBox.Show(response["error"]);
            }
            else if (response.ContainsKey("response"))
            {
                MessageBox.Show(response["response"]);
                this.Hide();
                Program.NeueLogin();
                this.Close();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            //Program.childThread.Abort();
            Program.LogOut();
            Environment.Exit(0);
        }

        private static void WriteMessages(string values)
        {
            var response = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(values);
            ChatForm.txbOutput.Text = "";

            foreach (var kvp in response)
            {
                var innerDict = kvp.Value;

                foreach (var innerKvp in innerDict)
                {
                    try
                    {
                        ChatForm.txbOutput.Text += innerKvp.Key + " " + innerKvp.Value + "\r\n";
                    }
                    catch (Exception exx)
                    {
                        Console.WriteLine(exx.ToString());
                    }
                }
            }
        }
    }
}
