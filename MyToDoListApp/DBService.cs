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
            //optionsBuilder.UseSqlServer("Server=(localdb)\\\\mssqllocaldb;Database=;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server=MSI;Database=MyToDoList;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
