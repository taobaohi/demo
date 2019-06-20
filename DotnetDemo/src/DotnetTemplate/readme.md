
## 读取配置
1.实体注入
 - AppSettings.cs
 - Dependency Injection
	```c#
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		// 配置文件映射
		services.Configure<AppSettings>(Configuration);
	}
  	```
	```
	    private readonly AppSettings _settings;
        public UserImpl(IOptionsSnapshot<AppSettings> settings)
        {
            _settings = settings.Value;
        }
	```
## GlobalException统一错误处理
