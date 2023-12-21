using System;
using System.Linq;

namespace ZOO
{
class Animal
  {
    public string Name{get;set;}
    public int Age{get;set;}
    public double Weight{get;set;}
    public Animal (string name, int age, double weight)
    {
      this.Name = name;
      this.Age = age;
      this.Weight = weight;
    }
    public void DisplayDescription ()
    {
      Console.WriteLine ("Name: {0}", this.Name);
      Console.WriteLine ("\tAge: {0}", this.Age);
      Console.WriteLine ("\tWeight: {0}", this.Weight);
    }
  }
}
