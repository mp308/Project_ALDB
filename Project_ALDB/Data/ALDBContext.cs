using Microsoft.EntityFrameworkCore;
using Project_ALDB.Models;

namespace Project_ALDB.Data
{
    public class ALDBContext: DbContext

    {
        //Constructor
        public ALDBContext(DbContextOptions<ALDBContext> options) : base(options) { }

        public ALDBContext() { }

        public DbSet<ProductTransfer> ProductTransfer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mapping + จัดการ relations
            modelBuilder.Entity<ProductTransfer>().ToTable("ProductTransfer");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string server = "localhost";
            string database = "ALDB";
            string uid = "root";
            string password = "";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";PORT=3306;SslMode=Required;";
            optionsBuilder.UseMySQL(connectionString);
        }
        public DbSet<Project_ALDB.Models.ProductTransferStatus> ProductTransferStatus { get; set; } = default!;
        public DbSet<Project_ALDB.Models.ProductCategory> ProductCategory { get; set; } = default!;
        public DbSet<Project_ALDB.Models.Customer> Customer { get; set; } = default!;
        public DbSet<Project_ALDB.Models.SaleRespEmployee> SaleRespEmployee { get; set; } = default!;

    }
}
