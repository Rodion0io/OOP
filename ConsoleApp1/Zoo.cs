using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1;

class Zoo
{

    public List<Animal> ListAnimals;
    public List<Employee> ListEmployees;
    public List<Visitor> ListVisitors;
    public List<Aviary> ListAviaries;

    public Zoo()
    {
        ListAnimals = new List<Animal>() ;
        ListEmployees = new List<Employee>();
        ListVisitors = new List<Visitor>();
        ListAviaries = new List<Aviary>();
    }

    public List<Animal> GetListAnimals()
    {
        return new List<Animal>(ListAnimals) ;
    }
    
    public List<Employee> GetListEmployees()
    {
        return new List<Employee>(ListEmployees) ;
    }
    
    public List<Visitor> GetListVisitors()
    {
        return new List<Visitor>(ListVisitors) ;
    }

    public List<Aviary> GetListAviary()
    {
        return new List<Aviary>(ListAviaries);
    }

    public void addAnimal(Animal animal)
    {
        ListAnimals.Add(animal);
    }

    public void addEmployee(Employee employee)
    {
        ListEmployees.Add(employee);
    }

    public void addVisitor(Visitor visitor)
    {
        ListVisitors.Add(visitor);
    }
    
    public void addAviaries(Aviary aviary)
    {
        ListAviaries.Add(aviary);
    }

    public void status()
    {
        Console.WriteLine($"Count Emplyees:{ListEmployees.Count()}");
        Console.WriteLine($"Count Visiters:{ListVisitors.Count()}");
        Console.WriteLine($"Count Animals:{ListAnimals.Count()}");
    }

}