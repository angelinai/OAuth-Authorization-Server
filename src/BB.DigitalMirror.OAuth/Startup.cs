using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BB.DigitalMirror.OAuth.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BB.DigitalMirror.OAuth
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // registers the IdentityServer services in DI and
            // it registers In-memory store for runtime state
            // for production scenarios you need a persistent or shared store
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(InMemoryConfiguration.ApiResources())
                .AddInMemoryClients(InMemoryConfiguration.Clients())
                .AddTestUsers(InMemoryConfiguration.TestUsers().ToList());

            // TODO: remove InMemory configs for production release :)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole();
                app.UseDeveloperExceptionPage();
            } 
        }
    }
}
