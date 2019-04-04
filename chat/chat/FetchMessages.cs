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
    public class FetchMessages
    {
        public static void Messages()
        {
            while (Program.username != "")
            {
                var values = new Dictionary<string, string>
                    {
                        { "method", "getmessages"   },
                        { "key", Program.publicKey     },
                        { "username", Program.username },
                        { "usersecret", Program.secret }
                    };

                JsonHandler jsonHandler = new JsonHandler();

                string request = JsonConvert.SerializeObject(values);

                Uri url = new Uri("http://109.192.39.111:1337/chat");

                Console.WriteLine(request);

                string response = jsonHandler.Post(url, request);

                ChatForm.openChatForm.AddText(response);

                Thread.Sleep(1000);
            }
        }
    }
}
