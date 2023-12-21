using System;
using System.Linq;

namespace ZOO
{
    class Program
    {
        static void Main(string[] args)
        {
            ZOO zoo = new ZOO();
            int volbaMenu = 0;
            do
            {
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("\t1. Animal Records");
                Console.WriteLine("\t2. Employee Records");
                Console.WriteLine("\t3. Statistics of ZOO");
                Console.WriteLine("\t4. Exit Program");
                if (int.TryParse(Console.ReadLine(), out volbaMenu))
                {
                    switch (volbaMenu)
                    {
                        case 1:
                            zoo.MenuAnimals(zoo);
                            break;
                        case 2:
                            zoo.MenuEmployees(zoo);
                            break;
                        case 3:
                            zoo.Statistics();
                            break;
                        case 4:
                            Console.WriteLine("Exiting Program.");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("You entered an invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("You entered an invalid choice. Please select a valid option.");
                }
            }
            while (volbaMenu != 4);
        }
    }
}
