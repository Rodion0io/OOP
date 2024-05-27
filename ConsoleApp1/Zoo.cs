using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1;

public class Zoo
{

    public List<Animal> ListAnimals;
    public List<Employee> ListEmployees;
    public List<Visitor> ListVisitors;
    public List<IOperationsAviary> ListAviary;

    public Zoo()
    {
        ListAnimals = new List<Animal>() ;
        ListEmployees = new List<Employee>();
        ListVisitors = new List<Visitor>();
        ListAviary = new List<IOperationsAviary>();
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

    public List<IOperationsAviary> GetListAviary()
    {
        return new List<IOperationsAviary>(ListAviary);
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

    public void status()
    {
        Console.WriteLine($"Count Emplyees:{ListEmployees.Count()}");
        Console.WriteLine($"Count Visiters:{ListVisitors.Count()}");
        Console.WriteLine($"Count Animals:{ListAnimals.Count()}");
    }

}