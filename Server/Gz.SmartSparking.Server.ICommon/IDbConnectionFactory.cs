
using Gz.Smartparking.Server.EFCore;
namespace Gz.SmartParking.Server.ICommon
{
    public interface IDbConnectionFactory
    {
        EFCoreContext CreateDbContext();
    }

}
