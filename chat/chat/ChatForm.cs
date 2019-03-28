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

namespace chat
{
    public partial class ChatForm : Form
    {
        public ChatForm(string name)
        {
            InitializeComponent();
            this.username = name;
            lblHeader.Text = "Teilnehmer: " + username + ", " + "user2";
        }

        private static string responseString;
        private static readonly HttpClient client = new HttpClient();
        Dictionary<string, string> values = new Dictionary<string, string> { };
        private string username;
        private string publicKey = Program.publicKey;

        private void btnSend_Click(object sender, EventArgs e)
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

            txbOutput.Text += txbInput.Text;
            txbInput.Clear();
        }

        private void btnGameSelection_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txbOutput.Text += responseString;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Program.logOut();
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(Program.PostUserContent(values));
            if (response.ContainsKey("error"))
            {
                MessageBox.Show(response["error"]);
            }
            else if (response.ContainsKey("response"))
            {
                MessageBox.Show(response["response"]);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Program.logOut();
            this.Close();
        }


    }
}
