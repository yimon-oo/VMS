using EVMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace EVMS
{
    public partial class DatabaseContext: DbContext
    {
        public DatabaseContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=vms;User ID=sa;Password=Passw0rd; Trusted_Connection=True;");
            }                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Voucher> Voucher => Set<Voucher>();
        public DbSet<UserVoucher> UserVoucher => Set<UserVoucher>();
        public DbSet<UserGoods> UserGoods => Set<UserGoods>();
        public DbSet<Goods> Goods => Set<Goods>();
        public DbSet<PurchaseHistory> PurchaseHistory => Set<PurchaseHistory>();
        public DbSet<User> User=> Set<User>();

    }
}
