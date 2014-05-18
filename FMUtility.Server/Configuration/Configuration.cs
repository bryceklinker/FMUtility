using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMUtility.Server.Configuration
{
    public interface IConfiguration
    {
        string GetSetting(string key);
    }

    public class Configuration : IConfiguration
    {
        public static Configuration _instance;

        public static IConfiguration Instance
        {
            get { return _instance ?? (_instance = new Configuration()); }
        }

        private Configuration()
        {
        }

        public string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
