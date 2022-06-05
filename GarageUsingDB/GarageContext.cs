using GarageUsingDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageUsingDB
{
    public class GarageContext : DbContext
    {
        public DbSet<Car> cars { get; set; }
        public DbSet<Person> peoples { get; set; }
        public DbSet<Garage> Garage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Enter_Server_Name_Here;Database=GarageDB;Trusted_Connection=True;");
        }
    }
}
