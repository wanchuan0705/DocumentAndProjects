using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace CoreCms.Net.Configuration
{
    internal class AppSettingsHelper
    {
        private static IConfiguration Configuration { get; set; }

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