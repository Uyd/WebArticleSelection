using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ArticleSelection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        //IWebHostBuilder 知道如何来设置webserver的环境
        //CreateDefaultBuilder 进行默认的设置

        //默认配置
        //使用kestrel web server
        ////.net core 内置的，跨平台服务器

        //IIS集成 两个方法
        ////UseIIS() 性能好
        ////UseIISIntegration() 允许IIS通过Windows的凭证验证去使用kestrel web server
        ////对构建内网的web应用非常有用

        //log 运行时，输出窗口

        //IConfiguration 接口
        //IConfiguration配置信息的来源
        ////appsettings.json
        ////User Secrets
        ////环境变量
        ////命令行参数
    }
}
