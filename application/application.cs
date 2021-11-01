using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application {
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Enter access token key!");
            string input = Console.ReadLine();
            Console.WriteLine("User entered " + input);
            Console.ReadLine();
            Console.WriteLine("Making API Call...");
            
        }
        
        public static async Task ExecuteAsync() {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com");
            var token = "<token>";

            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);

            var response = await client.GetAsync("/user");
        }
    }
}