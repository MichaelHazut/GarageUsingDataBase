using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GarageUsingDB.Models
{
    public class Garage
    {
        [Key, MaxLength(8)]
        public int ReferenceNumber { get; set; }
        [ForeignKey("Car")]
        public int LicensePlate { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public bool IsFixed { get; set; }
        public double CostToFix { get; set; }
        public DateTime EnteredGarage { get; set; }

        private Garage(string ownerName, int ownerId, int licensePlate)
        {
            this.OwnerId = ownerId;
            this.OwnerName = ownerName;
            this.LicensePlate = licensePlate;
            this.IsFixed = false;
            this.EnteredGarage = DateTime.Now;
        }
        public void FixCar()
        {
            this.IsFixed = true;
        }
        public static void InsertCar(Person person, Car car)
        {
            using (var context = new GarageContext())
            {
                context.Garage.Add(new Garage($"{person.FirstName} {person.LastName}", person.Id, car.LicensePlate));
                context.SaveChanges();
            }
        }
        public static void DeleteRecord()
        {
            Console.WriteLine("To Delete Please Enter You're Id");
            int id = int.Parse(Console.ReadLine());

            using (var context = new GarageContext())
            {
                List<Garage> quary = context.Garage.Where(
                    x => x.OwnerId == id).ToList();
                Console.Clear();
                if (quary.Count() > 1)
                {
                    Console.WriteLine($"Hello We Found " + quary.Count() + " Cars Recoreds Of Yours");

                    int count = 0;
                    foreach (var car in quary)
                    {//Print Cars On Record
                        count++;
                        Console.WriteLine($"\n{count}) " + car);
                    }
                    Console.WriteLine($"\n{quary.Count() + 1}) Delete all\n\n" +
                        "Please Enter The Number You Wish do Delete");


                    int choice = int.Parse(Console.ReadLine());
                    if (choice == quary.Count() + 1)
                        context.Garage.RemoveRange(quary);
                    else
                    {
                        context.Garage.Remove(quary[choice - 1]);
                    }

                    context.SaveChanges();
                }
                if (quary.Count() == 1)
                {
                    Console.WriteLine("Hello We Found 1 Cars That Belong To You\n");
                    Console.WriteLine(quary[0]);
                    Console.WriteLine("\nWould you Like To Delete it?" +
                        "\n1) Yes" +
                        "\n2) No");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            context.Garage.Remove(quary[0]);
                            context.SaveChanges();
                            break;
                        default:
                            break;
                    }

                }
                Console.WriteLine("\nDeleted Was Successful!" +
                                "\nPress ENTR To Continue");
                Console.ReadLine();
            }

        }
        public static void SelectRecord()
        {
            Console.WriteLine("To View Cars Enter You're Id");
            Person person = Person.GetPerson(int.Parse(Console.ReadLine()));
            if (person == null)
            {
                Console.WriteLine("It Appears That You Id Dose Not Exist in Our System");
                return;
            }

            Console.WriteLine($"|Welcome {person.FirstName}|");
            using (var context = new GarageContext())
            {
                var quary = context.Garage.Where(
                    x => x.OwnerId == person.Id);

                if (!quary.Any())
                {
                    Console.WriteLine("We Didnt Found Any Car Under Your Name..");
                    return;
                }

                int count = 0;
                foreach (var car in quary)
                {
                    count++;
                    Console.WriteLine($"\n{count}) " + car);
                }
            }
            Console.WriteLine("\nPress ENTR To Continue");
            Console.ReadLine();
        }

        public static void SetGarage()
        {
            using (var context = new GarageContext())
            {
                Person person;
                Car car = new Car(0, 0, null, null, null);

                //First Find Or Create The Person
                Console.WriteLine("To Register Your Car Please Enter Your Id");
                int id = int.Parse(Console.ReadLine());

                //If person dosnt exist
                if (context.peoples.Find(id) == null)
                {
                    Console.WriteLine("We Did Not Find You In Our Records" +
                        "\nPlease Enter Your Full Name");
                    var name = Console.ReadLine().Split(' ');
                    person = Program.SetPerson(new Person(id, name[0], name[1]));
                }
                else
                {//If He Dose Exist
                    person = context.peoples.Find(id);
                }

                //Get List Of The Persons Cars
                List<Car> quary = context.cars.Where(x => x.OwnerId == id).ToList();

                //If The Persons Has No Cars
                if (!quary.Any())
                {
                    Console.Clear();
                    Console.WriteLine("We Haven't Found A Car Under Your Name" +
                        "\nEntring Car Creation");

                    car = Program.SetCar(Car.CreateCar(person));
                    Console.WriteLine("Car Created Successfully:\n" + car);
                    InsertCar(person, car);//Enters The Car To The Garage
                }
                //If 1 Or More Cars Is Available
                else
                {
                    Console.WriteLine($"{quary.Count()} Cars Found Under Your Name");
                    int count = 0;
                    quary.ForEach(x => Console.WriteLine($"{count++}) " + x));


                    Console.WriteLine("Which Car Would You Like To Enter The Garage");
                    int choice = int.Parse(Console.ReadLine()) - 1;

                    InsertCar(person, quary[choice]);
                }

                Console.WriteLine("\n^^ Has Successfully Added To The Garage" +
                    "\n Press ENTR To Continue");

            }
        }
        public static void UpdateRecord()
        {
            Console.WriteLine("To Update record Please Enter You're Id");
            Person person = Person.GetPerson(int.Parse(Console.ReadLine()));
            if (person == null)
            {
                Console.WriteLine("It Appears That You Id Dose Not Exist in Our System");
                return;
            }
            Console.Clear();
            Console.WriteLine($"|Welcome {person.FirstName}| ");
            using (var context = new GarageContext())
            {
                List<Garage> cars = context.Garage.Where(x => x.OwnerId == person.Id).ToList();
                Console.Write(cars.Count() + " Cars Found\n");
                int count = 0;
                cars.ForEach(x => Console.WriteLine($"\n{++count}) " + x));

                Console.WriteLine("\nChoose Which Car To Update");
                context.Garage.Update(cars[count = int.Parse(Console.ReadLine())]);
                Console.Clear();
                Console.WriteLine(cars[count - 1]);

                Console.WriteLine($"\nWhat Do You Want To Update?" +
                    $"\n1) Owner Name" +
                    $"\n2) Owner Id" +
                    $"\n3) If The Car Is Fixed" +
                    $"\n4) Quit");
                int choice = int.Parse(Console.ReadLine());

                Console.WriteLine("What Will Be The New Value To Be?");
                switch (choice)
                {
                    case 1:
                        cars[count - 1].OwnerName = Console.ReadLine();
                        break;
                    case 2:
                        cars[count - 1].OwnerId = int.Parse(Console.ReadLine());
                        break;
                    case 3:
                        cars[count - 1].IsFixed = true;
                        Console.WriteLine("Car Fixed");
                        break;
                    default:
                        break;
                }
                context.SaveChanges();
            }

        }
        public static void SelectAllCars()
        {
            using (var context = new GarageContext())
            {
                List<Garage> garages = new List<Garage>();
                garages = context.Garage.Where(x => x.ReferenceNumber != null).ToList();
                int count = 0;
                garages.ForEach(x => Console.WriteLine($"{++count}) " + x));
                Console.WriteLine("\nPress ENTR To Continue");
                Console.ReadLine();
            }
        }
        public static void GenerateGarages()
        {
            using (var context = new GarageContext())
            {
                Console.Clear();
                Console.WriteLine("|Garage Generator|");
                Random rnd = new Random();
                List<Car> cars = context.cars.Where(x => x.LicensePlate != null).ToList();
                List<Person> persons = context.peoples.Where(x => x.Id != null).ToList();
                Console.WriteLine("How Many Car Do You Want To Enter To The Garage?");
                int num = int.Parse(Console.ReadLine());
                for (int i = 0; i < num; i++)
                {
                    Car car = cars[rnd.Next(persons.Count())];
                    InsertCar(context.peoples.Where(x => x.Id == car.OwnerId).FirstOrDefault(), car);
                }
                Console.WriteLine($"{num} New Garage Entries" +
                    $"\nPress Enter To Countinue");
                Console.ReadLine();
            }
        }
        public override string ToString()
        {
            using (var context = new GarageContext())
            {
                Car car = context.cars.Where(x => x.LicensePlate == this.LicensePlate).FirstOrDefault();
                return $"{car.Color} |{car.Manufacturer} /{car.Model} Number:{car.LicensePlate}" +
                    $"  \nEntered Garage On {this.EnteredGarage.ToShortDateString()}\n" +
                    $"Reference Number: {this.ReferenceNumber}";
            }
        }


    }
}
