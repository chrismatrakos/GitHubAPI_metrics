using System;
using System.Threading.Tasks;
using System.Net.Http;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Enter access token key!");
        // string token = Console.ReadLine();
        var token = "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";
        Console.WriteLine("User entered " + token);
        Console.WriteLine("Making API Call...");
        Task.WaitAll(ExecuteAsyn(token));
        Console.ReadLine();
    }
        
	public static async Task ExecuteAsync(string token) {
		HttpClient client = new HttpClient();
		client.BaseAddress = new Uri("https://api.github.com");
		client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
		client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);
		var response = await client.GetAsync("/rate_limit");
		Console.WriteLine("====================================================");
		Console.WriteLine(response);
	}
}