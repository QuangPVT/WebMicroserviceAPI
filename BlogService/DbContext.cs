using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using BlogService.Models;

namespace BlogService
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Blogs> Blogs { get; set; }

        public DbSet<BlogType> BlogType { get; set; }

        public DbSet<BlogInfo> BlogInfo { get; set; }

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
            USE dms_blog;
            ALTER TABLE Blog_Info
            ADD CONSTRAINT FK_BlogInfo_Blogs
            FOREIGN KEY (blog_id) REFERENCES Blogs(blog_id);");

            // Add foreign key constraint from BlogInfo to BlogType
            Database.ExecuteSqlRaw(@"
            USE dms_blog;
            ALTER TABLE Blog_Info
            ADD CONSTRAINT FK_BlogInfo_BlogType
            FOREIGN KEY (type_id) REFERENCES Blog_Type(type_id);");
        }
    }
}
