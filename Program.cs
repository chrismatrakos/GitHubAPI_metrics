using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

// using Newtonsoft.Json;

namespace GitHubAPI_metrics {
    public class Program {
        public static void Main(string[] args) {
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
		    client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
		    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		    // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);
		    var response = await client.GetAsync("/rate_limit");
		    Console.WriteLine("====================================================");
            Console.WriteLine(response);
            
            if (response.IsSuccessStatusCode) {
                var result  = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine(result);
                // dynamic obj = JsonConvert.DeserializeObject<dynamic>(result);
				// Console.WriteLine("limit: " + obj.rate.limit);
                // Console.WriteLine("remaining: " + obj.rate.remaining);
				// Console.WriteLine("used: " + obj.rate.used);
                // WORKING THE ABOVE......... 
                
                Response obj = JsonSerializer.Deserialize<Response>(result);
                Console.WriteLine("rate limit: " + obj.rate.limit);
                Console.WriteLine("rate reset: " + obj.rate.reset);
                // var s = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                // Console.WriteLine(s);
                Console.WriteLine("SUCCESS");
            }
            else {
                Console.WriteLine("FAILED");
                // return "Fail";
            }
            // response.EnsureSuccessStatusCode();
    
            // string data = await response.Content.ReadAsStringAsync();
            // Console.WriteLine(JsonSerializer.Deserialize<User>(data));
            // User user = JsonSerializer.Deserialize<User>(data);
            // Console.WriteLine(user.Limit);
		    
	    }
    }


     public class Response
    {
        public Resources resources {get; set;}
        public Property rate { get; set; }
    }
    public class Resources {
        public Property core {get; set; }
        public  Property graphql {get; set; }
        public Property integration_manifest {get; set; }
        public Property search {get; set; }
    }
    public class Property {
        public int limit { get; set; }
        public int used { get; set;}
        public int remaining { get; set; }
        public long reset { get; set; }
        public string resource { get; set; }
    }
}
