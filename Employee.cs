using System;
using System.Linq;

namespace ZOO
{
  class Employee
  {
    public string Name{get;set;}
    public string Surname{get;set;}
    public decimal Wage{get;set;}
    public DateTime DateOfBirth{get;set;}
    public string WorkPosition{get;set;}
    public Employee (string name, string surname, DateTime dateOfBirth,string workPosition, decimal wage)
    {
      this.Name = name;
      this.Surname = surname;
      this.Wage = wage;
      this.DateOfBirth = dateOfBirth;
      this.WorkPosition = workPosition;
    }
    public void DisplayDescription ()
    {
      Console.WriteLine ("Employee: {0} {1}", this.Name, this.Surname);
      Console.WriteLine ("\tDate of birth: {0}",this.DateOfBirth.ToString ("dd.MM.yyyy"));
      Console.WriteLine ("\tWork position: {0}", this.WorkPosition);
      Console.WriteLine ("\tWage: {0}", this.Wage);
    }
  }
}
