using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;

namespace chat
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (neededForm != "logOut")
            {
                if (neededForm == "")
                {
                    Application.Run(new LoginForm());
                }
                else if(neededForm == "chat")
                {
                    Application.Run(new ChatForm(username));
                }
                else if(neededForm == "vvs")
                {
                    Application.Run(new EFAForm());
                }
            }
        }

        public static string neededForm = "";
        public static string username;
        public static string before = "";
        public static string secret;
        public static string publicKey = "NU7JpQk4jfYzffNtkph5aWmYXWWY49Yj8c9cCNr7atfwRBHv7g";
        public static string messages;

        public static string PostUserContent(Dictionary<string, string> dict, string com)
        {
            JsonHandler jsonHandler = new JsonHandler();

            string request = JsonConvert.SerializeObject(dict);
            string requrl = "http://109.192.39.111:1337/" + com;
            Uri url = new Uri(requrl);
            Console.WriteLine(request);

            string response = jsonHandler.Post(url, request);

            Console.WriteLine(response);

            if (response != null)
            {
                return response;
            }
            else
            {
                return "Fehler!";
            }
        }

        public static string LogOut()
        {
            var values = new Dictionary<string, string>
                {
                    { "method", "logout"   },
                    { "key", publicKey     },
                    { "username", username },
                    { "usersecret", secret }
                };
            string response = Program.PostUserContent(values, "chat");

            return response;
        }
    }
}
