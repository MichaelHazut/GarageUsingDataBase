using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageUsingDB.Models;

namespace GarageUsingDB
{
    public static class GarageViewer
    {
        public static void OpenGarageView()
        {
            Console.Clear();
            Console.WriteLine("|Welcome To The Garage|" +
                "\nPress (1) For Management View" +
                "\nPress (2) For Costumer View" +
                "\nPress (3) To Fill Database With Random Data");


            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    ManagementView();
                    break;

                case 2:
                    CostumerView();
                    break;

                case 3:
                    DataGenerator();
                    break;
                default:
                    Console.WriteLine("Invalid Input  Press ENTR To Continue");
                    Console.ReadLine();
                    OpenGarageView();
                    break;
            }

        }
        private static void ManagementView()
        {
            Console.Clear();
            Console.WriteLine("|Management Window|" +
                        "\n1) Enter new Car To The Garage" +
                        "\n2) Delete Car Record" +
                        "\n3) View Cars Records Of A Peson" +
                        "\n4) View All Cars Records Of The Garage" +
                        "\n5) Update A Car Record" +
                        "\n6) Go Back");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Clear();
                    Garage.SetGarage();
                    ManagementView();
                    break;

                case 2:
                    Console.Clear();
                    Garage.DeleteRecord();
                    ManagementView();
                    break;

                case 3:
                    Console.Clear();
                    Garage.SelectRecord();
                    ManagementView();
                    break;

                case 4:
                    Console.Clear();
                    Garage.SelectAllCars();
                    ManagementView();
                    break;

                case 5:
                    Console.Clear();
                    Garage.UpdateRecord();
                    ManagementView();
                    break;

                case 6:
                    OpenGarageView();
                    break;

                default:
                    Console.WriteLine("Invalid Input  Press ENTR To Continue");
                    Console.ReadLine();
                    ManagementView();
                    break;
            }
        }
        private static void CostumerView()
        {
            Console.Clear();
            Console.WriteLine("|Costumer Window|" +
                        "\n1) Register To The Datebase" +
                        "\n2) Register A Car The Datebase" +
                        "\n3) Delete A Car From The Database");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Clear();
                    Person.NewPerson();
                    CostumerView();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("To Register A Car Please Enter Your Id Number");
                    Person person = Person.GetPerson(int.Parse(Console.ReadLine()));

                    if (person == null)
                    {
                        Console.WriteLine("Id Has Not Been Found In The Database" +
                            "\nPress ENTR To Go Back");
                        Console.ReadLine();
                        CostumerView();
                        break;
                    }
                    Car car = Car.CreateCar(person);
                    Program.SetCar(car);
                    Console.WriteLine("\nCar Creation Was Successful!" +
                "\nPress ENTR To Continue");
                    Console.ReadLine();
                    CostumerView();
                    break;
                case 3:
                    Car.DeleteCar();
                    CostumerView();
                    break;
                default:
                    OpenGarageView();
                    break;

            }
        }
        private static void DataGenerator()
        {
            Console.Clear();
            Console.WriteLine("|Data Generator|" +
            "\n1) Generate Random People" +
            "\n2) Generate Random Cars" +
            "\n3) Generate Random Garages" +
            "\n4) Go Back");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Person.GeneratePersons();
                    DataGenerator();
                    break;

                case 2:
                    Car.GenerateCars();
                    DataGenerator();
                    break;

                case 3:
                    Garage.GenerateGarages();
                    DataGenerator();
                    break;
                default:
                    OpenGarageView();
                    break;
            }
        }

    }
}
