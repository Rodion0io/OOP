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
    public List<Aviary> ListAviary;
    

    public Zoo()
    {
        ListAnimals = new List<Animal>() ;
        ListEmployees = new List<Employee>();
        ListVisitors = new List<Visitor>();
        ListAviary = new List<Aviary>();
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

    public void addAviary(Aviary aviary)
    {
        ListAviary.Add(aviary);
    }

    public void status()
    {
        Console.WriteLine($"Count Emplyees:{ListEmployees.Count()}");
        Console.WriteLine($"Count Visiters:{ListVisitors.Count()}");
        Console.WriteLine($"Count Animals:{ListAnimals.Count()}");
    }

}