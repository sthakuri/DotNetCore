
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseStatusCodePagesWithRedirects("/{0}.html");
            
            app.Map("/mvc", mvcapp =>
            {
                mvcapp.UseMvcWithDefaultRoute();
            });
            app.Run(c => c.Response.WriteAsync("Hello Core in VSCode."));
        }
    }
}