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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private static string publicKey = "NU7JpQk4jfYzffNtkph5aWmYXWWY49Yj8c9cCNr7atfwRBHv7g";
        private static readonly HttpClient client = new HttpClient();
        Dictionary<string, string> values = new Dictionary<string, string> { };

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string name = txbInput.Text.ToLower();
            if (name != "system")
            {
                if (name != "chat")
                {
                    if (name.Length < 20)
                    {
                        if (Regex.IsMatch(name, "[a-zA-Z0-9]"))
                        {
                            var values = new Dictionary<string, string>
                                {
                                    { "method", "register" },
                                    { "key", publicKey },
                                    { "username", txbInput.Text }
                                };
                            Program.username = txbInput.Text;
                            
                            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(Program.PostUserContent(values, "chat"));

                            if (response.ContainsKey("error"))
                            {
                                MessageBox.Show(response["error"]);
                            }
                            else
                            {
                                Program.neededForm = "chat";
                                Program.secret = response["secret"];
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falsche Zeichen eingegeben!\r\n Name darf nur Zeichen von a-Z oder 0-9 enthalten.", "Fehler!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Name zu Lang!\r\n Maximale Anzahl an Zeichen: 20", "Fehler!");
                    }
                }
                else
                {
                    MessageBox.Show("Falscher Name!\r\n Name darf nicht 'chat' sein!", "Fehler!");
                }

            }
            else
            {
                MessageBox.Show("Falscher Name!\r\n Name darf nicht 'system' sein!", "Fehler!");
            }
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Program.neededForm = "logOut";
            Environment.Exit(0);
        }
    }
}
