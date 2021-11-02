using System.Runtime.InteropServices;
using System.Net.Http.Headers;
using System.Net;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace GitHubAPI_metrics {

    public class Program {

        public static HttpClient client;

        public static void Main(string[] args) {
            Console.WriteLine("Enter access token key: ");
            string access_token = Console.ReadLine();
            Console.WriteLine("Entered token: " + access_token);
            Console.WriteLine("Making Github API Call...");
            Task.WaitAll(ExecuteAsync(access_token));
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
        
	    public static async Task ExecuteAsync(string token) {
	        client = new HttpClient();
		    client.BaseAddress = new Uri("https://api.github.com");
		    client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
		    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		    // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);
		    var response = await client.GetAsync("/rate_limit");
            Console.WriteLine(response);
            
            if (response.IsSuccessStatusCode) {
                Console.WriteLine("Github Api call succeded with response: " + response.StatusCode);
                var result  = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                
                Response response_object = JsonSerializer.Deserialize<Response>(result);
                Console.WriteLine("rate : " + response_object.rate.get_remaining_api_points());
                compute_api_points_threashold(response_object.rate.get_remaining_api_points());
            }
            else {
                Console.WriteLine("Github Api call failed with response: " + response.StatusCode);
            }		    
	    }
        
        public static void compute_api_points_threashold(float api_points){
            if(api_points < 0.1){
                Console.WriteLine(0);
            }else{
                Console.WriteLine(1);
            }
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
        public float get_remaining_api_points(){
            return (float)remaining / (float)limit;
        }
    }
}
