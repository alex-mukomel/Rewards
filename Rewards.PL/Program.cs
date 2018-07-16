using Ninject;
using Rewards.BLL.Interface;
using Rewards.Container;
using System;
using System.Linq;
using System.Threading;

namespace Rewards.PL
{
    class Program
    {
        private static IMedalsLogic medalLogic;
        private static IPeopleLogic personLogic;
        private static IRewardsLogic rewardLogic;

        static void Main(string[] args)
        {
            NinjectCommon.Registration();

            medalLogic = NinjectCommon.Kernel.Get<IMedalsLogic>();
            personLogic = NinjectCommon.Kernel.Get<IPeopleLogic>();
            rewardLogic = NinjectCommon.Kernel.Get<IRewardsLogic>();

            Start();
        }

        private static void Start()
        {
            Console.Clear();
            Console.WriteLine("Choice of action:\n" +
                "1. Add\n" +
                "2. Update\n" +
                "3. Delete\n" +
                "4. Show\n" +
                "5. Exit");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    {
                        Add();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        Update();
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        Delete();
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        Show();
                        break;
                    }
                case ConsoleKey.D5:
                    {
                        Console.WriteLine("\n\nGood Luck!");
                        return;
                    }
                default:
                    {
                        Console.WriteLine("\n\nInvalid input. Try again.");
                        Thread.Sleep(2500);
                        Start();
                        break;
                    }
            }
        }

        private static void Add()
        {
            Console.Clear();
            Console.WriteLine("Add menu:\n" +
                "1. Add new person\n" +
                "2. Add new medal\n" +
                "3. Add new reward\n" +
                "4. Go to the beginning");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine();
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Surname: ");
                        string surname = Console.ReadLine();
                        Console.Write("Date of birth: ");
                        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                        Console.Write("Age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("City's name: ");
                        string city = Console.ReadLine();
                        Console.Write("Street's name: ");
                        string street = Console.ReadLine();
                        Console.Write("Number of house: ");
                        string numberOfHouse = Console.ReadLine();

                        try
                        {
                            personLogic.Add(name, surname, dateOfBirth, age, city, street, numberOfHouse);
                        }
                        catch (ArgumentNullException nullEx)
                        {
                            Console.WriteLine($"\n{nullEx.Message}");
                            Console.WriteLine("Press any key for continue.");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\n{ex.Message}");
                            Console.WriteLine("Press any key for continue.");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        Console.WriteLine();
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Material: ");
                        string material = Console.ReadLine();

                        try
                        {
                            medalLogic.Add(name, material);
                        }
                        catch (ArgumentNullException nullEx)
                        {
                            Console.WriteLine($"\n{nullEx.Message} \n ");
                            Console.WriteLine("Press any key for continue.");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        Console.WriteLine();
                        Console.Write("Person's id: ");
                        int personId = int.Parse(Console.ReadLine());
                        Console.Write("Medal's id: ");
                        int medalId = int.Parse(Console.ReadLine());

                        try
                        {
                            rewardLogic.Add(personId, medalId);
                        }
                        catch (ArgumentNullException nullEx)
                        {
                            Console.WriteLine($"\n{nullEx.Message} \n ");
                            Console.WriteLine("Press any key for continue.");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        Start();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\n\nInvalid input. Try again.");
                        Thread.Sleep(2500);
                        Start();
                        break;
                    }
            }
        }

        private static void Update()
        {
            Console.Clear();
            Console.WriteLine("Update menu:\n" +
                "1. Update person\n" +
                "2. Update medal\n" +
                "3. Go to the beginning");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine();
                        Console.Write("Id: ");
                        int personId = int.Parse(Console.ReadLine());
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Surname: ");
                        string surname = Console.ReadLine();
                        Console.Write("Date of birth: ");
                        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                        Console.Write("Age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("City's name: ");
                        string city = Console.ReadLine();
                        Console.Write("Street's name: ");
                        string street = Console.ReadLine();
                        Console.Write("House number: ");
                        string numberOfHouse = Console.ReadLine();

                        try
                        {
                            personLogic.Update(personId, name, surname, dateOfBirth, age, city, street, numberOfHouse);
                        }
                        catch (ArgumentNullException nullEx)
                        {
                            Console.WriteLine($"\n{nullEx.Message}");
                            Console.WriteLine("Press any key for continue.");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\n{ex.Message}");
                            Console.WriteLine("Press any key for continue.");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Id: ");
                        int medalId = int.Parse(Console.ReadLine());
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Material: ");
                        string material = Console.ReadLine();
                        
                        try
                        {
                            medalLogic.Update(medalId, name, material);
                        }
                        catch (ArgumentNullException nullEx)
                        {
                            Console.WriteLine($"\n{nullEx.Message} \n ");
                            Console.WriteLine("Press any key for continue.");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        Start();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\n\nInvalid input. Try again.");
                        Thread.Sleep(2500);
                        Start();
                        break;
                    }
            }
        }

        private static void Delete()
        {
            Console.Clear();
            Console.WriteLine("Delete menu:\n" +
                "1. Delete person\n" +
                "2. Delete medal\n" +
                "3. Delete reward\n" +
                "4. Go to the beginning.");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine();
                        Console.Write("Id: ");
                        int personId = int.Parse(Console.ReadLine());

                        try
                        {
                            personLogic.Delete(personId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\n{ex.Message}");
                            Console.WriteLine("Press any key for continue.");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D2:
                    {

                        Console.WriteLine();
                        Console.Write("Id: ");
                        int medalId = int.Parse(Console.ReadLine());

                        try
                        {
                            medalLogic.Delete(medalId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\n{ex.Message}");
                            Console.WriteLine("Press any key for continue.");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        Console.WriteLine();
                        Console.Write("Person's id: ");
                        int personId = int.Parse(Console.ReadLine());
                        Console.Write("Medal's id: ");
                        int medalId = int.Parse(Console.ReadLine());

                        try
                        {
                            rewardLogic.Delete(personId, medalId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\n{ex.Message}");
                            Console.WriteLine("Press any key for continue.");
                            Console.ReadKey();
                        }

                        Start();
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        Start();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\n\nInvalid input. Try again.");
                        Thread.Sleep(2500);
                        Start();
                        break;
                    }
            }
        }

        private static void Show()
        {
            Console.Clear();
            Console.WriteLine("Show menu:\n" +
                "1. Show all people\n" +
                "2. Show all medals\n" +
                "3. Show all rewards\n" +
                "4. Show person by id\n" +
                "5. Show medal by id\n" +
                "6. Go to the beginning");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine();
                        var list = personLogic.GetAll();
                        if (list.Count() > 0)
                        {
                            foreach (var item in list)
                            {
                                Console.WriteLine($"{item.Id}: {item.Name}, {item.Surname}, {item.Age}," +
                                    $" {item.DateOfBirth}, {item.City}, {item.Street}, {item.NumberOfHouse}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"List is empty.");
                        }
                        Console.WriteLine("\nPress any key for continue.");
                        Console.ReadKey();

                        Start();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        Console.WriteLine();

                        var list = medalLogic.GetAll();


                        if (list.Count() > 0)
                        {
                            foreach (var item in list)
                            {
                                Console.WriteLine($"{item.Id}: {item.Name} {item.Material}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"List is empty.");
                        }
                        Console.WriteLine("\nPress any key for continue.");
                        Console.ReadKey();

                        Start();
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        Console.WriteLine();

                        var list = rewardLogic.GetAll();


                        if (list.Count() > 0)
                        {
                            foreach (var item in list)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"List is empty.");
                        }
                        Console.WriteLine("\nPress any key for continue.");
                        Console.ReadKey();

                        Start();
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        Console.WriteLine();
                        Console.Write("Id: ");

                        var item = personLogic.GetById(int.Parse(Console.ReadLine()));
                        if (item != null)
                        {

                            Console.WriteLine($"{item.Id}: {item.Name} {item.Surname} {item.Age} {item.DateOfBirth} {item.City} {item.Street} {item.NumberOfHouse}");

                        }
                        else
                        {
                            Console.WriteLine($"This person was not found.");
                        }
                        Console.WriteLine("\nPress any key for continue.");
                        Console.ReadKey();

                        Start();
                        break;
                    }
                case ConsoleKey.D5:
                    {
                        Console.WriteLine();
                        Console.Write("Id: ");

                        var item = medalLogic.GetById(int.Parse(Console.ReadLine()));

                        if (item != null)
                        {
                            Console.WriteLine($"{item.Id}: {item.Name} {item.Material}");
                        }
                        else
                        {
                            Console.WriteLine($"This medal was not found.");
                        }
                        Console.WriteLine("\nPress any key for continue");
                        Console.ReadKey();

                        Start();
                        break;
                    }
                case ConsoleKey.D6:
                    {
                        Start();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\n\nInvalid input. Try again.");
                        Thread.Sleep(2500);
                        Start();
                        break;
                    }

            }
        }
    }
}

