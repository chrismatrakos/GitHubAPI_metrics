﻿using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace GitHubAPI_metrics {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter access token key!");
            // string token = Console.ReadLine();
            var token = "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";
            Console.WriteLine("User entered " + token);
            Console.WriteLine("Making API Call...");
            Task.WaitAll(ExecuteAsync(token));
            Console.ReadLine();
        }
        
	    public static async Task ExecuteAsync(string token) {
		    HttpClient client = new HttpClient();
		    client.BaseAddress = new Uri("https://api.github.com");
		    client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "2.0"));
		    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);
		    var response = await client.GetAsync("/rate_limit");
		    Console.WriteLine("====================================================");
            Console.WriteLine(response);
            // response.EnsureSuccessStatusCode();
    
            string data = await response.Content.ReadAsStringAsync();
            Console.WriteLine(JsonSerializer.Deserialize<User>(data));
            User user = JsonSerializer.Deserialize<User>(data);
            Console.WriteLine(user.Limit);
		    
	    }
    }

    class User {
        public string Limit { get; set; }
        public string Used { get; set;}

    }
}