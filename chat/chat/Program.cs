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
            Application.Run(new LoginForm());
            Application.Run(new ChatForm(username));
        }


        //public static Thread childThread = new Thread(new ThreadStart(CallChild.CallToChildThread));
        public static string username;
        public static string secret;
        public static string publicKey = "NU7JpQk4jfYzffNtkph5aWmYXWWY49Yj8c9cCNr7atfwRBHv7g";
        public static string messages;

        public static string PostUserContent(Dictionary<string, string> dict)
        {
            JsonHandler jsonHandler = new JsonHandler();

            string request = JsonConvert.SerializeObject(dict);

            Uri url = new Uri("http://109.192.39.111:1337/chat");

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
            string response = Program.PostUserContent(values);

            return response;
        }

        public static void NeueLogin()
        {
            //Application.Run(new LoginForm());
        }
    }
}
