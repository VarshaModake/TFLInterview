
using System.Configuration;
using System.Linq;

using TFLRoadStatus.Interfaces;

namespace TFLRoadStatus
{
   public class AppConfigWrapper:IConfigurationWrapper
    {//read value from app.config
        public string GetValue(string key)
        {
            return ConfigurationSettings.AppSettings.Get(key);
        }

        public bool HasKey(string key)
        {
            return ConfigurationSettings.AppSettings.AllKeys.Select((string x) => x.ToUpperInvariant()).Contains(key.ToUpperInvariant());
        }
    }
}
