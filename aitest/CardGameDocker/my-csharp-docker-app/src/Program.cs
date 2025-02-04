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
        static double omsaetning = 0;

        static async Task Main(string[] args)
        {
            string url = "http://127.0.0.1:1234/v1/chat/completions"; // Correct API endpoint

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

                if (userQuestion.ToLower() == "omsaetning")
                {
                    funktioner.Omsaetning(ref omsaetning);
                    continue;
                }

                var requestData = new
                {
                    model = "llama-3.2-1b-instruct", // Model ID from API response
                    messages = new[]
                    {
                        new { role = "system", content = "You are an AI assistant." },
                        new { role = "user", content = $"{userQuestion}. Current omsaetning: {omsaetning}" }
                    },
                    temperature = 0.7
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
        public static List<string> Options = new List<string> { "test", "muligheder", "omsaetning" };

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

        public static void Omsaetning(ref double omsaetning)
        {
            omsaetning = 1000;
            Console.WriteLine($"Omsaetning sat til {omsaetning}kr");
        }
    }
}
