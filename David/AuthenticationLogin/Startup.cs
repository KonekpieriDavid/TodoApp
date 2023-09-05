/*
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AuthenticationLogin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        //This method get called by the runtime.Use this method to add service to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }
        // Use this method to configure http request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
                app.UseDeveloperExceptionPage();

        }
          App.UseRouting();
            app.UseAuthorization();

       .MapControllers();

       app.Run();

    }
}
*/