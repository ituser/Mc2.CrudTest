using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Mc2.CrudTest.Presentation.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            CompositionRoot.RegisterDependencies(services, Configuration);

            //services.AddSwaggerGen(setupAction =>
            //                       {
            //                           setupAction.SwaggerDoc(
            //                                                  "v1",
            //                                                  new OpenApiInfo
            //                                                  {
            //                                                      Title = "CustomerApi",
            //                                                      Version = "1",
            //                                                  });
            //                       });
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseSwagger();
            //app.UseSwaggerUI(setupAction =>
            //                 {
            //                     setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerApi");
            //                     //setupAction.RoutePrefix = "OpenAPI";
            //                     setupAction.DocExpansion(DocExpansion.None);
            //                 });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
