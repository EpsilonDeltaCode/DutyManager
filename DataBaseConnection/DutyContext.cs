using System.Data.Entity;
using DutyFramework.Implementations;
using DutyFramework.Implementations.Statements;

namespace DataBaseConnection
{
    public class DutyContext : DbContext
    {
        public DutyContext(string dataBaseName) : base(dataBaseName)
        {
            Database.Connection.ConnectionString =
                "Data Source=(localDb)\\mssqllocaldb;Initial Catalog=TestDataBaseFileProgrammatically;Integrated Security=true";
        }


        public DbSet<Duty> Duties { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<DirectoryStatement> DirectoryStatements { get; set; }
        public DbSet<TextStatement> TextStatements { get; set; }
        public DbSet<UrlStatement> UrlStatements { get; set; }
    }
}
