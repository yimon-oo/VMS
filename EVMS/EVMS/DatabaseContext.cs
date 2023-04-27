using EVMS.Entities;
using EVMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EVMS
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Voucher> Voucher { get; set; }

        //protected readonly IConfiguration Configuration;

        //public DatabaseContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to mysql with connection string from app settings
        //    var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        //    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //}
    }
}
