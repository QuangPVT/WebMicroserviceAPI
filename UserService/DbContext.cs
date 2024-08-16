using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using UserService.Models;

namespace UserService
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }

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
            // Add foreign key constraint from Users to Roles
            Database.ExecuteSqlRaw(@"
            USE dms_user;
            ALTER TABLE Users
            ADD CONSTRAINT FK_Users_Roles
            FOREIGN KEY (role_id) REFERENCES Roles(role_id);");
        }
    }
}
