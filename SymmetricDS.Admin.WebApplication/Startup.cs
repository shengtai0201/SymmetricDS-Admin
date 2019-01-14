using CommonServiceLocator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Shengtai.Data;
using Shengtai.Web.Telerik.Mvc;
using SymmetricDS.Admin.Server;
using SymmetricDS.Admin.Server.Service;
using SymmetricDS.Admin.WebApplication.Models;
using System.Reflection;
using System.Security.Principal;

namespace SymmetricDS.Admin.WebApplication
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            var assemblyName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<ServerDbContext>(options =>
                options.UseNpgsql(connectionString, o => o.MigrationsAssembly(assemblyName)));

            services.AddMvc()
                .AddJsonOptions(o => o.SerializerSettings.ContractResolver = new DefaultContractResolver { NamingStrategy = null })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddOptions().Configure<AppSettings>(this.Configuration);
            services.AddScoped<IClient, Shengtai.Data.Core.Client<AppSettings, ConnectionStrings>>();

            services.AddScoped<IApiService<int, ProjectViewModel, Project, IPrincipal>, ProjectService>().AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IApiService<int, NodeGroupViewModel, NodeGroup, IPrincipal>, NodeGroupService>().AddScoped<INodeGroupService, NodeGroupService>();
            services.AddScoped<IApiService<int, NodeViewModel, Node, IPrincipal>, NodeService>().AddScoped<INodeService, NodeService>();
            services.AddScoped<IApiService<int, ChannelViewModel, Channel, IPrincipal>, ChannelService>().AddScoped<IChannelService, ChannelService>();
            services.AddScoped<IApiService<int, TriggerViewModel, Trigger, IPrincipal>, TriggerService>().AddScoped<ITriggerService, TriggerService>();
            services.AddScoped<IApiService<int, RouterViewModel, Router, IPrincipal>, RouterService>();
            services.AddScoped<IApiService<string, TriggerRouterViewModel, TriggerRouter, IPrincipal>, TriggerRouterService>();

            ServiceLocator.SetLocatorProvider(() => new Shengtai.ServiceLocator(services.BuildServiceProvider()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}