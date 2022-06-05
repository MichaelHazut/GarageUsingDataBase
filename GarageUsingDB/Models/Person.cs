using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageUsingDB.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public Person(int id, string firstName, string lastName)
        {
            this.Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public static Person GetPerson(int id)
        {
            using (var context = new GarageContext())
            {
                var person = context.peoples.Where(x => x.Id == id).FirstOrDefault();
                if (person == null) return null;
                return person;
            }
        }
        public static void NewPerson()
        {
            Console.WriteLine("|Registration System|\nPlease Enter Your Full Name");
            var name = Console.ReadLine().Split(' ');

            Console.WriteLine("Please Enter Your Id Number");

            Program.SetPerson(new Person(int.Parse(Console.ReadLine()), name[0], name[1]));

            Console.WriteLine($"Great {name[0]} {name[1]} Has Been Added To The Database" +
                $"\nPress ENTR To Continue");
            Console.ReadLine();
        }
        public static void GeneratePersons()
        {
            Console.Clear();
            Console.WriteLine("|Car Generator|");
            Console.WriteLine("\nHow Many Pepole You Want To Genarate Into The Database");
            string[] _firstName = new string[] { "Adam", "Alex", "Aaron", "Ben", "Carl", "Dan", "David", "Edward", "Fred", "Frank", "George", "Hal", "Hank",
                "Ike", "John", "Jack", "Joe", "Larry", "Monte", "Matthew", "Mark", "Nathan", "Otto", "Paul", "Peter", "Roger", "Roger", "Steve", "Thomas", "Tim", "Ty", "Victor", "Walter" };
            string[] _lastName = new string[] { "Anderson", "Ashwoon", "Aikin", "Bateman", "Bongard", "Bowers", "Boyd", "Cannon", "Cast",
                "Deitz", "Dewalt", "Ebner", "Frick", "Hancock", "Haworth", "Hesch", "Hoffman", "Kassing", "Knutson", "Lawless", "Lawicki",
                "Mccord", "McCormack", "Miller", "Myers", "Nugent", "Ortiz", "Orwig", "Ory", "Paiser", "Pak", "Pettigrew", "Quinn", "Quizoz",
                "Ramachandran", "Resnick", "Sagar", "Schickowski", "Schiebel", "Sellon", "Severson", "Shaffer", "Solberg", "Soloman", "Sonderling",
                "Soukup", "Soulis", "Stahl", "Sweeney", "Tandy", "Trebil", "Trusela", "Trussel", "Turco", "Uddin", "Uflan", "Ulrich", "Upson", "Vader"
                , "Vail", "Valente", "Van Zandt", "Vanderpoel", "Ventotla", "Vogal", "Wagle", "Wagner", "Wakefield", "Weinstein", "Weiss", "Woo", "Yang",
                "Yates", "Yocum", "Zeaser", "Zeller", "Ziegler", "Bauer", "Baxster", "Casal", "Cataldi", "Caswell", "Celedon", "Chambers", "Chapman",
                "Christensen", "Darnell", "Davidson", "Davis", "DeLorenzo", "Dinkins", "Doran", "Dugelman", "Dugan", "Duffman", "Eastman", "Ferro", "Ferry",
                "Fletcher", "Fietzer", "Hylan", "Hydinger", "Illingsworth", "Ingram", "Irwin", "Jagtap", "Jenson", "Johnson", "Johnsen", "Jones",
                "Jurgenson", "Kalleg", "Kaskel", "Keller", "Leisinger", "LePage", "Lewis", "Linde", "Lulloff", "Maki", "Martin", "McGinnis",
                "Mills", "Moody", "Moore", "Napier", "Nelson", "Norquist", "Nuttle", "Olson", "Ostrander", "Reamer", "Reardon", "Reyes", "Rice",
                "Ripka", "Roberts", "Rogers", "Root", "Sandstrom", "Sawyer", "Schlicht", "Schmitt", "Schwager", "Schutz", "Schuster", "Tapia", "Thompson", "Tiernan", "Tisler" };

            List<Person> persons = new List<Person>();
            int amount = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                persons.Add(new Person(new Random().Next(201254362, 987666666), _firstName[rnd.Next(_firstName.Length)], _lastName[rnd.Next(_lastName.Length)]));
            }
            Program.SetPerson(persons);
            Console.WriteLine("Successfully Added " + amount + " To The Database" +
                        "\nPress ENTR To Continue");
            Console.ReadLine();
        }
    }
}
