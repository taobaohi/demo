## 命名
https://blog.csdn.net/bob_dadoudou/article/details/79476612
文件夹名参考了golang，包名用小写。

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
