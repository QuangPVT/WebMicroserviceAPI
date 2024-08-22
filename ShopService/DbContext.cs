using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ShopService.Models;

namespace ShopService
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Staffs> Staffs { get; set; }

        public DbSet<ShopWarehouse> ShopWarehouse { get; set; }

        public DbSet<ShopInfo> ShopInfo { get; set; }

        public DbContext(DbContextOptions<DbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var databaseCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreater != null)
                {
                    // Create Database if cannot connect
                    if (!databaseCreater.CanConnect()) databaseCreater.Create();

                    // Create Table if no tables exist
                    if (!databaseCreater.HasTables())
                    {
                        databaseCreater.CreateTables();

                        AddConstraints();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void AddConstraints()
        {
            // Add foreign key constraint from BlogInfo to Blogs
            Database.ExecuteSqlRaw(@"
            USE dms_shop;
            ALTER TABLE Staffs
            ADD CONSTRAINT FK_Staffs_ShopInfo
            FOREIGN KEY (shop_id) REFERENCES Shop_Info(shop_id);");

            // Add foreign key constraint from BlogInfo to BlogType
            Database.ExecuteSqlRaw(@"
            USE dms_shop;
            ALTER TABLE Shop_Warehouse
            ADD CONSTRAINT FK_ShopWarehouse_ShopInfo
            FOREIGN KEY (shop_id) REFERENCES Shop_Info(shop_id);");
        }
    }
}
