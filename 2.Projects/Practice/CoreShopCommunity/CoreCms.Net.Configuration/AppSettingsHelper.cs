﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace CoreCms.Net.Configuration
{
    public class AppSettingsHelper
    {
        private static IConfiguration Configuration { get; set; }

        public AppSettingsHelper(string contentPath)
        {
            string Path = "appsettings.json";
            Configuration = new ConfigurationBuilder().SetBasePath(contentPath).Add(new JsonConfigurationSource
            {
                Path = Path,
                Optional = false,
                ReloadOnChange = true
            }).Build();
        }

        /// <summary>
        /// 封装要操作的字符
        /// AppSettingsHelper.GetContent(new string[] { "JwtConfig", "SecretKey" });
        /// </summary>
        /// <param name="sections">节点配置</param>
        /// <returns></returns>
        public static string GetContent(params string[] sections)
        {
            try
            {
                if (sections.Any())
                {
                    return Configuration[string.Join(":", sections)];
                }
            }
            catch (Exception)
            {
            }
            return "";
        }
    }
}