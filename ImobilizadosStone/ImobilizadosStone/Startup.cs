using ImobilizadosStone.Domain.Repository;
using ImobilizadosStone.Domain.Services;
using ImobilizadosStone.Repository;
using ImobilizadosStone.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace ImobilizadosStone.WebAPI
{
    public class Startup
    {
        private Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            IntegrateSimpleInjector(services);

            ConfigureMongoDB(services);
        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        public void ConfigureMongoDB(IServiceCollection services)
        {
            ImobilizadosStone.Repository.RepositoryStartup.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            InitializeContainer(app);
            container.Verify();
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            
            container.Register<IItemService, ItemService>(Lifestyle.Scoped);

            var settings = new Settings
            {
                ConnectionString = Configuration.GetSection("MongoDBConnection:ConnectionString").Value,
                Database = Configuration.GetSection("MongoDBConnection:Database").Value,
            };

            container.RegisterSingleton<Settings>(settings);
            container.Register<IItemRepository, ItemRepository>(Lifestyle.Scoped);
            //container.Register<IItemRepository>(() => new ItemRepository(settings), Lifestyle.Scoped);
        }
    }
}
