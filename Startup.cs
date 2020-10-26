using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.Extensions;
namespace Finalproject
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
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        /*
        
        options=>
            {
                options.IdleTimeout=TimeSpan.FromSeconds(10);
            }
        */

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }


    }

//         public static class SessionExtensions
// {
//     public static void SetObjectAsJson(this ISession session, string key, object value)
//     {
//         session.SetString(key, JsonConvert.SerializeObject(value));
//     }

//     public static T GetObjectFromJson<T>(this ISession session, string key)
//     {
//         var value = session.GetString(key);

//         return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
//     }
// }

}


//         public static class SessionExtensions
// {
//     public static void SetObjectAsJson(this ISession session, string key, object value)
//     {
//         session.SetString(key, JsonConvert.SerializeObject(value));
//     }

//     public static T GetObjectFromJson<T>(this ISession session, string key)
//     {
//         var value = session.GetString(key);

//         return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
//     }
// }