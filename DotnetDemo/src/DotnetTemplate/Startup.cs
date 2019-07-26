using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace servicedemo
{
    using CSRedis;
    using Microsoft.Extensions.Caching.Distributed;
    using middleware;
    public class Startup
    {
        public IConfiguration Configuration { get; }
        // 构造函数注入
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // 初始化RedisHelper
            var residConn = Configuration["ConnectionStrings:RedisConn"].ToString();
            RedisHelper.Initialization(new CSRedisClient(residConn));
        }

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

            #region RedisHelper
            var csredis = new CSRedisClient(Configuration.GetConnectionString("RedisConn"));
            //初始化 RedisHelper
            RedisHelper.Initialization(csredis);
            //注册mvc分布式缓存(eg:把Session存到Redis,kube部署后多台轮询需要统一存储session)
            services.AddSingleton<IDistributedCache>(new Microsoft.Extensions.Caching.Redis.CSRedisCache(RedisHelper.Instance));
            #endregion

            #region service 注入
            services.AddTransient<services.User, services.UserImpl>();
            #endregion
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
            //app.UseGloablExceptionMiddleware();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMvc();
        }
    }
}
