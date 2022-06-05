using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageUsingDB.Models
{
    public class Car
    {
        [Key, MaxLength(8)]
        public int LicensePlate { get; set; }
        [ForeignKey("Person")]
        public int OwnerId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }


        public Car(int licensePlate, int ownerId, string manufacturer, string model, string color)
        {
            this.LicensePlate = licensePlate;
            this.OwnerId = ownerId;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Color = color;
        }
        public static Car GetCar(int licensePlate)
        {
            using (var context = new GarageContext())
            {
                return context.cars.Where(x => x.LicensePlate == licensePlate).First();
            }
        }
        public static Car CreateCar(Person person)
        {
            Console.WriteLine("Enter Car License Plate Number");
            int licensePlate = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Car Manufacturer");
            string manufacturer = Console.ReadLine();

            Console.WriteLine("Enter Car Model");
            string model = Console.ReadLine();

            Console.WriteLine("Enter Car Color");
            string color = Console.ReadLine();

            Console.Clear();

            return new Car(licensePlate, person.Id, manufacturer, model, color);
        }
        public static void DeleteCar()
        {
            Console.Clear();
            Console.WriteLine("|Delete Car|\n");
            Console.WriteLine("To Delete Your Car Please Enter You're Id");
            int id = int.Parse(Console.ReadLine());

            using (var context = new GarageContext())
            {
                List<Car> cars = context.cars.Where(x => x.OwnerId == id).ToList();
                int count = 0;

                Console.WriteLine($"\nWe Found {cars.Count()} Car Of Yours:");
                cars.ForEach(x => Console.WriteLine($"\n{++count}) " + x));

                Console.WriteLine("\nWhich Car Would You Like To Delete?");
                int index = int.Parse(Console.ReadLine()) - 1;
                context.cars.Remove(cars[index]);
                context.Garage.RemoveRange(context.Garage.Where(x => x.LicensePlate == cars[index].LicensePlate).ToList());
                context.SaveChanges();

            }
        }
        public static void GenerateCars()
        {
            Console.Clear();
            Console.WriteLine("|Car Generator|");
            Random rnd = new Random();
            string[] carManufacturers = new string[]{
                "Abarth",
                "Alfa Romeo",
                "Aston Martin",
                "Audi",
                "Bentley",
                "BMW",
                "Bugatti",
                "Cadillac",
                "Chevrolet",
                "Chrysler",
                "Citroën",
                "Dacia",
                "Daewoo",
                "Daihatsu",
                "Dodge",
                "Donkervoort",
                "DS",
                "Ferrari",
                "Fiat",
                "Fisker",
                "Ford",
                "Honda",
                "Hummer",
                "Hyundai",
                "Infiniti",
                "Iveco",
                "Jaguar",
                "Jeep",
                "Kia",
                "KTM",
                "Lada",
                "Lamborghini",
                "Lancia",
                "Land Rover",
                "Landwind",
                "Lexus",
                "Lotus",
                "Maserati",
                "Maybach",
                "Mazda",
                "McLaren",
                "Mercedes-Benz",
                "MG",
                "Mini",
                "Mitsubishi",
                "Morgan",
                "Nissan",
                "Opel",
                "Peugeot",
                "Porsche",
                "Renault",
                "Rolls-Royce",
                "Rover",
                "Saab",
                "Seat",
                "Skoda",
                "Smart",
                "SsangYong",
                "Subaru",
                "Suzuki",
                "Tesla",
                "Toyota",
                "Volkswagen",
                "Volvo"
                };
            string[] colors = new string[] {
                "Black",
                "Blue",
                "Yellow",
                "Red",
                "Green",
                "Pink",
                "White",
                "Silver",
                "Teal",
                "Brown",
                "Cyan",
                "Indigo",
                "Gold",
            };
            string[] models = new string[] { "Urus", "Trax", "Suburban", "Sentra", "Santa Fe Hybrid", "S-Class", "RS 3", "Q3", "Phantom", "Acadia", "A8", "Clubman", "CLS",
                                "Niro EV","Odyssey","NX","Outlander","Panamera","3 Series","Yukon XL","XC90","X4","Wraith","Voyager","Versa","Vantage"};
            List<Car> cars = new List<Car>();

            Console.WriteLine("\nHow Many Random Cars Would You Like To Add To The Database");
            using (var context = new GarageContext())
            {
                List<Person> persons = context.peoples.Where(x => x.Id != null).ToList();
                int count = int.Parse(Console.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    cars.Add(new Car(rnd.Next(11111111, 99999999),
                        persons[rnd.Next(persons.Count())].Id,
                        carManufacturers[rnd.Next(carManufacturers.Count())],
                        models[rnd.Next(models.Count())],
                        colors[rnd.Next(colors.Count())]));
                }
                Program.SetCar(cars);
                Console.WriteLine($"{count} Cars Has Been Successfully Added To The Database" +
                    $"\nPress ENTR To Continue");
                Console.ReadLine();
            }
        }
        public override string ToString()
        {
            return $"{Color} |{Manufacturer} /{Model} Owned by {OwnerId}";
        }
    }
}
