using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DutyFramework.Implementations;
using DutyFramework.Interfaces;

namespace DataBaseConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DutyContext("TestDataBase"))
            {
                // Create and save a new Blog 
                Console.Write("Start");

                
                Duty dutyA = new Duty()
                {
                    Titel = "TestDuty1",
                    Connections = new List<IDutyConnection>(),
                    Created = DateTime.Now,
                    Progress = 22,
                    ProgressDescription = "TestDutyStatusDescription1",
                    DeadLine = DateTime.MaxValue,
                    Id = Guid.NewGuid(),
                    LastChange = DateTime.Now,
                    Reminders = new List<IReminder>(),
                    Statements = new List<IStatement>()
                };

                db.Duties.Add(dutyA);

                
                /*
                TestDBClass testclass = new TestDBClass()
                {
                    Id = 1,
                    Aa = "TestA"
                };

                Console.WriteLine(db.Database.Connection.Database);
                Console.WriteLine(db.Database.Connection.ConnectionString);
                Console.WriteLine(db.Database.Connection.DataSource);
                //Console.WriteLine(db.Database.Connection.ServerVersion);

                

                db.TestDBClasses.Add(testclass);

                var found = db.TestDBClasses.Find(testclass.Id);

                db.Entry(found).Property("Aa").CurrentValue = "YOU KNOW NOTHING";
                */

                db.SaveChanges();

                // Display all Blogs from the database 

                var query = from duty in db.Duties
                    orderby duty.Id
                    select duty;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Titel);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
