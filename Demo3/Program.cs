using Demo3.Commons;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Demo3
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");

            //builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton(typeof(Common));

            await builder.Build().RunAsync();

        }
    }
}


