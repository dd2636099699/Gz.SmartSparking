
using Microsoft.Extensions.Configuration;
using Gz.SmartParking.Server.ICommon;
using System.IO;
namespace Gz.SmartParking.Server.Common
{
    public class AppConfiguration : IAppConfiguration
    {
        private static IConfigurationRoot _iConfiguration;
        static AppConfiguration()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

            _iConfiguration = builder.Build();
        }
        public string Read(string key)
        {
            return _iConfiguration[key];
        }
    }


 
    
}
