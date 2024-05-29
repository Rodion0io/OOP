using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulation;

class Employee : Humans
{
    public string post;
    public List<IAviary>aviaryList;
    public Employee(string name, Gender sex,string id, string post) : base(name, sex, id )
    {
        this.post = post;
        aviaryList = new List<IAviary>();
    }
    public override void status()
    {
        Console.WriteLine($"Имя:{name}, Пол:{sex}, Должность:{post}");
    }

    public void feedAviarys(Zoo zoo)
    {
        foreach (var aviary in aviaryList)
        {
            if (aviary.getFirstContainer() == 0) {
                aviary.replenishFirstSupplies();
                Console.WriteLine($"\n{name} возобновил(а) запасы в первом контейнере {aviary.getAviaryId()}.");
                break;
            }

            if (aviary.getSecondContainer() == 0)
            {
                aviary.replenishSecondSupplies();
                Console.WriteLine($"\n{name} возобновил(а) запасы во втором контейнере {aviary.getAviaryId()}.");
                break;
            }
        }
    }


}