using System;
using System.Linq;
using System.Collections.Generic;
namespace ZOO
{
	class ZOO
	{
		private List<Animal> Animals;
		private List<Employee> Employees;
		public ZOO()
		{
			this.Animals = new List<Animal>();
			this.Employees = new List<Employee>();
		}
		public void Statistics()
		{
			Console.WriteLine("Total number of animals in the records: " + this.Animals.Count<Animal>().ToString());
			Console.WriteLine("Total number of employees in the records " + this.Employees.Count<Employee>().ToString());
			decimal sumOfWage = 0m;
			foreach (Employee employee in this.Employees)
			{
				sumOfWage += employee.Wage;
			}
			Console.WriteLine("Total sum of employees salaries: " + sumOfWage.ToString());
		}
		//ANIMALS
		public void AddAnimal()
		{
			Console.WriteLine("Creating a slot for a new animal");
			Console.Write("Name: ");
			string name = Console.ReadLine();
			int age;
			for (; ; )
			{
				Console.Write("Age: ");
				if (int.TryParse(Console.ReadLine(), out age))
				{
					break;
				}
				Console.WriteLine("You entered an incorrect value.");
			}
			double weight;
			for (; ; )
			{
				Console.Write("Weight: ");
				if (double.TryParse(Console.ReadLine(), out weight))
				{
					break;
				}
				Console.WriteLine("You entered an incorrect value.");
			}
			Animal animal = new Animal(name, age, weight);
			this.Animals.Add(animal);
		}
		public void RemoveAnimal()
		{
			if (this.Animals.Count <= 0)
			{
				Console.WriteLine("We don't have any animals in the records.");
				return;
			}
			for (int i = 0; i < this.Animals.Count; i++)
			{
				Console.WriteLine("{0}.{1}", i + 1, this.Animals[i].Name);
			}
			Console.WriteLine("Which animal do you want to delete (enter the number): ");
			int indexRemove;
			if (!int.TryParse(Console.ReadLine(), out indexRemove))
			{
				Console.WriteLine("You entered an invalid choice. Please select a valid option.");
				return;
			}
			indexRemove--;
			if (indexRemove >= 0 && indexRemove <= this.Animals.Count - 1)
			{
				Console.WriteLine("You have deleted the animal {0}.", this.Animals[indexRemove].Name);
				this.Animals.RemoveAt(indexRemove);
				return;
			}
			Console.WriteLine("You entered the wrong number");
		}
		public void ListAnimals()
		{
			if (this.Animals.Count > 0)
			{
				Console.WriteLine("List of Animals: ");
				using (List<Animal>.Enumerator enumerator = this.Animals.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Animal animal = enumerator.Current;
						animal.DisplayDescription();
					}
					return;
				}
			}
			Console.WriteLine("We don't have any animals in the records.");
		}
		public void ModifyAnimals()
		{
			if (this.Animals.Count > 0)
			{
				for (int i = 0; i < this.Animals.Count; i++)
				{
					Console.WriteLine("{0}.{1}", i + 1, this.Animals[i].Name);
				}
				Console.WriteLine("Which animal do you want to modify (enter the number): ");
				int indexUpravit;
				if (!int.TryParse(Console.ReadLine(), out indexUpravit))
				{
					Console.WriteLine("You entered an invalid choice. Please select a valid option.");
					return;
				}
				indexUpravit--;
				if (indexUpravit < 0 || indexUpravit > this.Animals.Count - 1)
				{
					Console.WriteLine("You entered the wrong number");
					return;
				}
				Console.WriteLine("Modifying animal {0}", this.Animals[indexUpravit].Name);
				Console.WriteLine("Do you want to change the current name of the animal? ({0}) 'Y/N'", this.Animals[indexUpravit].Name);
				if (Console.ReadLine().ToLower() == "y")
				{
					Console.Write("New name: ");
					this.Animals[indexUpravit].Name = Console.ReadLine();
				}
				Console.WriteLine
				  ("Do you want to change the current age of the animal? ({0}) 'Y/N'",
				   this.Animals[indexUpravit].Age);
				if (Console.ReadLine().ToLower() == "y")
				{
					int newAge;
					for (; ; )
					{
						Console.Write("New age: ");
						if (int.TryParse(Console.ReadLine(), out newAge))
						{
							break;
						}
						Console.WriteLine
						  ("You entered an incorrect format for age. Please enter a number.");
					}
					this.Animals[indexUpravit].Age = newAge;
				}
				Console.WriteLine
				  ("Do you want to change the current wieght of the animal? ({0}) 'Y/N'",
				   this.Animals[indexUpravit].Weight);
				if (Console.ReadLine().ToLower() == "y")
				{
					double newWeight;
					for (; ; )
					{
						Console.Write("New weight: ");
						if (double.TryParse(Console.ReadLine(), out newWeight))
						{
							break;
						}
						Console.WriteLine
						  ("You entered an incorrect format for weight. Please enter a number.");
					}
					this.Animals[indexUpravit].Weight = newWeight;
					return;
				}
			}
			else
			{
				Console.WriteLine("We don't have any animals in the records.");
			}
		}
		public void FindAnimals()
		{
			if (this.Animals.Count > 0)
			{
				Console.WriteLine("Search engine for Animals");
				Console.Write("\tInput the name: ");
				string find = Console.ReadLine();
				int checker = 0;
				foreach (Animal animal in this.Animals)
				{
					if (animal.Name.Contains(find))
					{
						Console.WriteLine(animal.Name);
						checker++;
					}
				}
				if (checker == 0)
				{
					Console.WriteLine
				  ("In the records, we don't have any animals with this name.");
					return;
				}
			}
			else
			{
				Console.WriteLine("We don't have any animals in the records.");
			}
		}
		public void MenuAnimals(ZOO zoo)
		{
			char volbaMenu = '0';
			while (volbaMenu != '6')
			{
				Console.WriteLine("ANIMAL MENU:");
				Console.WriteLine("\t 1. Add animal");
				Console.WriteLine("\t 2. Lists animals");
				Console.WriteLine("\t 3. Modify animal");
				Console.WriteLine("\t 4. Find animal");
				Console.WriteLine("\t 5. Remove animal");
				Console.WriteLine("\t 6. Back");
				volbaMenu = Console.ReadKey().KeyChar;
				switch (volbaMenu)
				{
					case '1':
						Console.Clear();
						zoo.AddAnimal();
						break;
					case '2':
						Console.Clear();
						zoo.ListAnimals();
						break;
					case '3':
						Console.Clear();
						zoo.ModifyAnimals();
						break;
					case '4':
						Console.Clear();
						zoo.FindAnimals();
						break;
					case '5':
						Console.Clear();
						zoo.RemoveAnimal();
						break;
					case '6':
						Console.Clear();
						break;
					default:
						Console.Clear();
						Console.WriteLine("You entered an invalid choice. Please select a valid option.");
						break;
				}
			}
		}
		//EMPLOYEES
		public void AddEmployee()
		{
			Console.WriteLine("Creating a slot for a new employee");
			Console.Write("First name: ");
			string firstName = Console.ReadLine();
			Console.Write("Surname: ");
			string surname = Console.ReadLine();
			DateTime dateOfBirth;
			for (; ; )
			{
				Console.Write("Date of birth (yyyy-MM-dd): ");
				if (DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
				{
					break;
				}
				Console.WriteLine
				  ("You entered the wrong format for the date of birth. Please enter a valid format.");
			}
			Console.Write("Work position: ");
			string workPosition = Console.ReadLine();
			decimal wage;
			for (; ; )
			{
				Console.Write("Wage: ");
				if (decimal.TryParse(Console.ReadLine(), out wage))
				{
					break;
				}
				Console.WriteLine
				  ("You entered the wrong format for the wage. Please enter a valid format.");
			}
			Employee employee =
			  new Employee(firstName, surname, dateOfBirth, workPosition, wage);
			this.Employees.Add(employee);
		}
		public void RemoveEmployee()
		{
			if (this.Employees.Count <= 0)
			{
				Console.WriteLine("In the records, we don't have any employees.");
				return;
			}
			for (int i = 0; i < this.Employees.Count; i++)
			{
				Console.WriteLine("{0}.{1} {2}", i + 1, this.Employees[i].Name,
						   this.Employees[i].Surname);
			}
			Console.WriteLine
		  ("Which employee do you want to delete (enter the number): ");
			int indexSmazat;
			while (!int.TryParse(Console.ReadLine(), out indexSmazat))
			{
				Console.WriteLine
				  ("Zadali ste neplatnu hodnotu. Prosim, zadajte platnu hodnotu.");
			}
			indexSmazat--;
			if (indexSmazat >= 0 && indexSmazat <= this.Employees.Count - 1)
			{
				Console.WriteLine("Vymazali ste zamestnanca {0} {1}.",
						   this.Employees[indexSmazat].Name,
						   this.Employees[indexSmazat].Surname);
				this.Employees.RemoveAt(indexSmazat);
				return;
			}
			Console.WriteLine("You entered the wrong number.");
		}
		public void ListOfEmployees()
		{
			if (this.Employees.Count > 0)
			{
				Console.WriteLine("List of employees: ");
				using (List<Employee>.Enumerator enumerator =
				   this.Employees.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Employee employee = enumerator.Current;
						employee.DisplayDescription();
					}
					return;
				}
			}
			Console.WriteLine("In the records, we don't have any employees.");
		}
		public void ModifyEmployee()
		{
			if (this.Employees.Count > 0)
			{
				for (int i = 0; i < this.Employees.Count; i++)
				{
					Console.WriteLine("{0}.{1} {2}", i + 1,
						   this.Employees[i].Name,
						   this.Employees[i].Surname);
				}
				Console.WriteLine
				  ("Which employee do you want to modify (enter the number): ");
				int indexUpravit;
				while (!int.TryParse(Console.ReadLine(), out indexUpravit))
				{
					Console.WriteLine
				  ("You entered an invalid choice. Please select a valid option");
				}
				indexUpravit--;
				if (indexUpravit < 0 || indexUpravit > this.Employees.Count - 1)
				{
					Console.WriteLine("You entered the wrong number.");
					return;
				}
				Console.WriteLine("Modifying employee {0} {1}",
						   this.Employees[indexUpravit].Name,
						   this.Employees[indexUpravit].Surname);
				Console.WriteLine
				  ("Do you want to change the current first name and last name of the employee? ({0} {1}) 'Y/N'",
				   this.Employees[indexUpravit].Name,
				   this.Employees[indexUpravit].Surname);
				if (Console.ReadLine().ToLower() == "y")
				{
					Console.Write("New name: ");
					this.Employees[indexUpravit].Name = Console.ReadLine();
					Console.Write("New surname: ");
					this.Employees[indexUpravit].Surname = Console.ReadLine();
				}
				Console.WriteLine
				  ("Do you want to change the current date of birth of the employee? ({0}) 'Y/N'",
				   this.Employees[indexUpravit].
				   DateOfBirth.ToString("dd.MM.yyyy"));
				if (Console.ReadLine().ToLower() == "y")
				{
					DateTime newDate;
					for (; ; )
					{
						Console.Write("New date of birth (yyyy-MM-dd): ");
						if (DateTime.TryParse(Console.ReadLine(), out newDate))
						{
							break;
						}
						Console.WriteLine
						  ("You entered the wrong format for the date. Please enter the correct format.");
					}
					this.Employees[indexUpravit].DateOfBirth = newDate;
				}
				Console.WriteLine
				  ("Do you want to change the current salary of the employee? ({0}) 'Y/N'",
				   this.Employees[indexUpravit].Wage);
				if (Console.ReadLine().ToLower() == "y")
				{
					decimal newWage;
					for (; ; )
					{
						Console.Write("New wage: ");
						if (decimal.TryParse(Console.ReadLine(), out newWage))
						{
							break;
						}
						Console.WriteLine
						  ("You entered the wrong format for the wage. Please enter the correct format.");
					}
					this.Employees[indexUpravit].Wage = newWage;
				}
				Console.WriteLine
				  ("Do you want to change the current work position of the employee? ({0}) 'Y/N'",
				   this.Employees[indexUpravit].WorkPosition);
				if (Console.ReadLine().ToLower() == "y")
				{
					Console.Write("New work position: ");
					this.Employees[indexUpravit].WorkPosition = Console.ReadLine();
					return;
				}
			}
			else
			{
				Console.WriteLine("In the records, we don't have any employees.");
			}
		}
		public void MenuEmployees(ZOO zoo)
		{
			char volbaMenu = '0';
			while(!volbaMenu = '5')
			{
				Console.WriteLine("EMPLOYEE MENU");
				Console.WriteLine("\t 1. Add employee");
				Console.WriteLine("\t 2. List of employees");
				Console.WriteLine("\t 3. Modify employee");
				Console.WriteLine("\t 4. Remove employee");
				Console.WriteLine("\t 5. Back");
				volbaMenu = Console.ReadKey().KeyChar;
					switch (volbaMenu)
					{
						case '1':
							Console.Clear();
							zoo.AddEmployee();
							break;
						case '2':
							Console.Clear();
							zoo.ListOfEmployees();
							break;
						case '3':
							Console.Clear();
							zoo.ModifyEmployee();
							break;
						case '4':
							Console.Clear();
							zoo.RemoveEmployee();
							break;
						case '5':
							Console.Clear();
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
