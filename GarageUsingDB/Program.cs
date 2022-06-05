using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using GarageUsingDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GarageUsingDB
{
    //Before Staring The Program Go To GarageContext.cs And
    //Enter Your SQL Server Name Inside OnConfiguring Function
    //Insted Of 'Enter_Server_Name_Here' And Type 
    //'dotnet ef database update' Inside PowerShell
    internal class Program
    {
        static void Main(string[] args)
        {
            
            GarageViewer.OpenGarageView();

 
           
        }
        public static Car SetCar(Car car)
        {
            using (var context = new GarageContext())
            {
                context.cars.Add(car);
                context.SaveChanges();
            }
            return car;
        }
        public static void SetCar(List<Car> cars)
        {
            using (var context = new GarageContext())
            {
                cars.ForEach(x => context.cars.Add(x));
                context.SaveChanges();
            }
        }
        public static Person SetPerson(Person person)
        {
            using (var context = new GarageContext())
            {
                context.peoples.Add(person);
                context.SaveChanges();
            }
            return person;
        }
        public static void SetPerson(List<Person> persons)
        {
            using (var context = new GarageContext())
            {
                persons.ForEach(x => context.peoples.Add(x));
                context.SaveChanges();
            }
        }


        
    }

}

