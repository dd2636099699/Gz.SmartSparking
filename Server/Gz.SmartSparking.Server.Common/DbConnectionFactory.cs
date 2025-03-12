
using Gz.Smartparking.Server.EFCore;
using Gz.SmartParking.Server.ICommon;

namespace Gz.SmartParking.Server.Common
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        IAppConfiguration _configuration;
        public DbConnectionFactory(IAppConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EFCoreContext CreateDbContext()
        {
            return new EFCoreContext(_configuration.Read("DbConnectStr"));// ÷ª «’Î∂‘SqlServer
        }
    }
}
