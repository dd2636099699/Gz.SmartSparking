
using Gz.SmartParking.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Globalization;

namespace Gz.Smartparking.Server.EFCore
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
        // <param name = "modelBuilder" ></ param >
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 文件库中时间转换  string<->timespan
            ValueConverter timeValueConverter = new ValueConverter<string, long>(
                v => DateTime.ParseExact(v, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture).Ticks / 10000,
                v => new DateTime(v * 10000).ToString("yyyyMMdd HHmmss"));
            modelBuilder.Entity<UpgradeFile>().Property(p => p.UploadTime).HasConversion(timeValueConverter);
        }


        public DbSet<UpgradeFile> UpgradeFile { get; set; }
    }

}
