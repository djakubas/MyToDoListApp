using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using MyToDoListApp.Tables;

namespace MyToDoListApp
{
    public class DBService : DbContext
    {
        public DBService() : base() { }
        public DbSet<TableTask> Tasks { get; set; }
        public DbSet<TableStatuses> Statuses { get; set; }
        public DBService(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //azure sql server
            optionsBuilder.UseSqlServer("Server=tcp:dj.database.windows.net,1433;Initial Catalog=MyToDoListDB;Persist Security Info=False;User ID=azureuser;Password=Ki109ramu$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //optionsBuilder.UseSqlServer("Server=tcp:dj.database.windows.net,1433;Initial Catalog=MyToDoListDB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";");
            
            //local ms sql server
            //optionsBuilder.UseSqlServer("Server=MSI;Database=MyToDoList;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
