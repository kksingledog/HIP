using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
namespace hospital
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(options => {  
            options.IdleTimeout = TimeSpan.FromMinutes(1);//可以設定session的時間   
            });  
            services.AddMvc();
            
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSession();
        }
    }
}
