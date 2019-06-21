using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace servicedemo
{
    using middleware;

    public class Startup
    {

        // 构造函数注入
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                //options =>
                //{
                //    //MVC统一错误处理
                //     options.Filters.Add<MyExceptionHandler>();
                //}
             )
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // 配置文件映射
            services.Configure<AppSettings>(Configuration);
            // service 注入
            services.AddTransient<services.IUser, services.UserImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            //app.UseHttpsRedirection();

            // 中间件统一错误处理
            app.UseGloablExceptionMiddleware();

            app.UseMvc();
        }
    }
}
