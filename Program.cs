using System;
using System.Linq;

namespace ZOO
{
  class Program
  {
    static void Main (string[]args)
    {
      ZOO zoo = new ZOO ();
      char volbaMenu = '0';
      while (volbaMenu != '4')
	    {
	    Console.WriteLine ("MAIN MENU");
	    Console.WriteLine ("\t1. Animal Records");
	    Console.WriteLine ("\t2. Employee Records");
	    Console.WriteLine ("\t3. Statistics of ZOO");
	    Console.WriteLine ("\t4. Exit Program");
	    volbaMenu = Console.ReadKey ().KeyChar;
	    switch (volbaMenu)
	    {
          case '1':
	      Console.Clear ();
	      zoo.MenuAnimals (zoo);
	      break;
	      case '2':Console.Clear ();
	      zoo.MenuEmployees (zoo);
	      break;
	      case '3':
	      Console.Clear ();
	      zoo.Statistics ();
	      break;
	      case '4':
	      Console.Clear ();
	      Console.WriteLine ("Press any key to close program.");
	      Console.ReadKey ();
	      break;
	      default:
	      Console.Clear();
	      Console.WriteLine("You entered an invalid choice. Please select a valid option.");
	      break;
	    }
	  }
    }
  }
}
