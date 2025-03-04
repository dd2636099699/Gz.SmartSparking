
using Gz.SmartSparking.Server.EFCore;

namespace Gz.SmartSparking.Server.ICommon
{
    public interface IDbConnectionFactory
    {
        EFCoreContext CreateDbContext();
    }

}
