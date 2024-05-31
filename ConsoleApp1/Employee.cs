using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulation;

public class Employee : Humans, IComparable<Employee>
{
    public string post;
    public List<IAviary>aviaryList;
    public Employee(string name, Gender gender, string post) : base(name, gender)
    {
        this.post = post;
        aviaryList = new List<IAviary>();
    }
    
    public Guid getId()
    {
        return id;
    }
    
    public override void status()
    {
        Console.WriteLine($"Имя:{name}, Пол:{gender}, Должность:{post}");
    }

    public void feedAviarys(Zoo zoo)
    {
        foreach (var aviary in aviaryList)
        {
            if (aviary.getFirstContainer() == 0 || aviary.getSecondContainer() == 0) {
                aviary.replenishFirstSupplies();
                Console.WriteLine($"\n{name} возобновил(а) запасы в первом контейнере {aviary.getAviaryId()}.");
                break;
            }
        }
    }


    public int CompareTo(Employee? other)
    {
        throw new NotImplementedException();
    }
}