using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace GitHubAPI_metrics {

    public class Application {

        public static HttpClient client;
        public static string uri = "https://api.github.com";
        public static string router = "/rate_limit";

        public static void Main(string[] args) {
            Console.WriteLine("Enter personal access token: ");
            string access_token = Console.ReadLine();
            Task.WaitAll(ExecuteAsync(access_token));
        }
        
	    public static async Task ExecuteAsync(string token) {
	        client = new HttpClient();
		    client.BaseAddress = new Uri(uri);
		    client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
		    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);
		    var response = await client.GetAsync(router);
            // Console.WriteLine(response);
            
            if (response.IsSuccessStatusCode) {
                Console.WriteLine("Github Api call succeded with response: {0}\n", response.StatusCode);
                var result  = response.Content.ReadAsStringAsync().Result;
                // Console.WriteLine(result);                
                Response response_object = JsonSerializer.Deserialize<Response>(result);
                int points_threashold = get_api_threashold(response_object.rate.get_remaining_api_points());
                Console.WriteLine(points_threashold);
            }
            else {
                Console.WriteLine("Github Api call failed with response: {0}\n", response.StatusCode);
            }		    
	    }
        
        public static int get_api_threashold(float api_points){
            if(api_points < 0.1){
                return 0;
            }else{
                return 1;
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
