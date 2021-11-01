using System;
using System.Threading.Tasks;
using System.Net.Http;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Enter access token key!");
        string input = Console.ReadLine();
        Console.WriteLine("User entered " + input);
        Console.WriteLine("Making API Call...");
        Console.ReadLine();
        Task.WaitAll(ExecuteAsyn());
    }
        
	public static async Task ExecuteAsync() {
		HttpClient client = new HttpClient();
		client.BaseAddress = new Uri("https://api.github.com");
		var token = "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";
		client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
		client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);
		var response = await client.GetAsync("/rate_limit");
		Console.WriteLine("====================================================");
		Console.WriteLine(response);
	}
}