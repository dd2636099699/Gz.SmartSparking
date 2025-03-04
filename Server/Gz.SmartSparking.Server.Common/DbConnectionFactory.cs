
using Gz.SmartSparking.Server.EFCore;
using Gz.SmartSparking.Server.ICommon;
using Microsoft.Extensions.Configuration;
using System;

namespace Gz.SmartSparking.Server.Common
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        IConfiguration _configuration;
        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EFCoreContext CreateDbContext()
        {
            return new EFCoreContext(_configuration.Read("DbConnectStr"));// ÷ª «’Î∂‘SqlServer
        }

        EFCoreContext IDbConnectionFactory.CreateDbContext()
        {
            throw new NotImplementedException();
        }
    }

}
