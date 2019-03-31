using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;

namespace chat
{
    class CallChild
    {
        private static void WriteMessages(string values)
        {
            var response = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(values);

            foreach (var kvp in response)
            {
                var innerDict = kvp.Value;

                foreach (var innerKvp in innerDict)
                {
                    try
                    {
                        ChatForm.txbOutput.Text += kvp.Key + " " + innerKvp.Key + " " + innerKvp.Value;
                    }
                    catch(Exception exx)
                    {
                        Console.WriteLine(exx.ToString());
                    }
                }
            }
        }

        public static void CallToChildThread()
        {
            try
            {
                while (true)
                {
                    var values = new Dictionary<string, string>
                    {
                        { "method", "getmessages"   },
                        { "key", Program.publicKey     },
                        { "username", Program.username },
                        { "usersecret", Program.secret }
                    };
                    WriteMessages(Program.PostUserContent(values));

                    Thread.Sleep(1000);
                }
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine("Thread Abort Exception");
            }
        }
    }
}