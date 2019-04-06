using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThridPartyLogin_AspNetCore;

namespace MvcSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddWeChatLogin(p =>
            {
                p.ClientId = "";
                p.ClientSecret = "";
            });
            services.AddQqLogin(p =>
            {
                p.ClientId = "";
                p.ClientSecret = "";
            });
            services.AddSinaLogin(p =>
            {
                p.ClientId = "";
                p.ClientSecret = "";
            });
            services.AddFackbookLogin(p =>
            {
                p.ClientId = "";
                p.ClientSecret = "";
            });
            services.AddGitHubLogin(p =>
            {
                p.ClientId = "";
                p.ClientSecret = "";
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
           
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Privacy}/{id?}");
            });
        }
    }
}