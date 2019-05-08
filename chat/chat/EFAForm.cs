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
    public partial class EFAForm : Form
    {
        public EFAForm()
        {
            InitializeComponent();
        }

        private static readonly HttpClient client = new HttpClient();
        int statId = 0;

        private void combBoxStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            switch (combBoxStation.SelectedItem)
            {
                case "Feuerbach":
                    statId = 5006157;
                    break;
                case "Hauptbahnhof":
                    statId = 5006118;
                    break;
                case "Wallgraben":
                    statId = 5000355;
                    break;
            }

            DateTime hour = DateTime.Now;

            var values = new Dictionary<string, string>
                {
                    { "method", "vvs" },
                    { "key", Program.publicKey },
                    { "username", Program.username },
                    { "usersecret", Program.secret },
                    { "stationID", statId.ToString() },
                    { "hour", DateTime.Now.Hour.ToString()},
                    { "minute", DateTime.Now.Minute.ToString()},
                };
            var response = Program.PostUserContent(values, "commands");
            //var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(Program.PostUserContent(values, "commands"));

            MessageBox.Show(response.ToString());
            foreach (var kvp in response)
            {
                rtbOutput.Text += response.ToString();
            }
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            Program.neededForm = "";
            Program.LogOut();
            this.Close();
        }
    }
}
