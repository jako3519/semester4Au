using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyCSharpDockerApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "http://127.0.0.1:1234/v1/chat/completions"; 

            while (true)
            {
                Console.Write("Enter your question (or type 'exit' to quit): ");
                string userQuestion = Console.ReadLine();

                if (userQuestion.ToLower() == "exit")
                {
                    break;
                }

                if (userQuestion.ToLower() == "run test")
                {
                    funktioner.Test();
                    continue;
                }

                if (userQuestion.ToLower() == "muligheder")
                {
                    funktioner.Muligheder();
                    continue;
                }

                var requestData = new
                {
                    model = "llama-3.2-1b-instruct", // LLM Model 
                    messages = new[]
                    {
                        new { role = "system", content = "Du er en Ai chatbot" },
                        new { role = "user", content = userQuestion }
                    },
                    
                };

                string jsonRequest = JsonConvert.SerializeObject(requestData);

                using HttpClient client = new HttpClient();
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                string responseBody = await response.Content.ReadAsStringAsync();

                var jsonResponse = JObject.Parse(responseBody);
                string assistantContent = jsonResponse["choices"][0]["message"]["content"].ToString();

                Console.WriteLine("Assistant: " + assistantContent);
            }
        }
    }

    class funktioner
    {
        public static List<string> Options = new List<string> { "test", "muligheder" };

        public static void Muligheder()
        {
            foreach (string option in Options)
            {
                Console.WriteLine(option);
            }
        }

        public static void Test()
        {
            Console.WriteLine("Hello World");
        }
    }
}
