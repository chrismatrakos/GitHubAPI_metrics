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
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri("https://api.stackexchange.com/2.2/");
                HttpResponseMessage response = client.GetAsync("answers?order=desc&sort=activity&site=stackoverflow").Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Result: " + result);
            }
            Console.ReadLine();
        }
    }
}