
using Microsoft.EntityFrameworkCore;

namespace Gz.SmartSparking.Server.EFCore
{
    public class EFCoreContext : DbContext
    {
        private string strConn = string.Empty;

        public EFCoreContext()
        {
            strConn = "Server=LAPTOP-7RAV79T8;Database=gz_sp;Trusted_Connection=True;";
        }

        public EFCoreContext(string connectionStr)
        {
            strConn = connectionStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(strConn);
        }
    }

}
