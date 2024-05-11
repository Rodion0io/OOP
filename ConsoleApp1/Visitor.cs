using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1;

// interface IFeed
// {
//     void FeedVisitorAnimal(List<> openList, int index);
// }

class Visitor : Human
{

    public int cash;

    public Visitor(string name, Gender gender, string id) : base(name, gender, id)
    {
        this.name = name;
        this.gender = gender;
        this.id = id;
        cash = 100;
    }

    public override void status()
    {
        Console.WriteLine($"Name:{name}, Gender:{gender}");
    }

    public void changeName(string newName)
    {
        name = newName;
    }

    public void changeGender(string newGender)
    {
        if (Enum.TryParse(newGender, out gender))
        {
            this.gender = gender;
        }
        else
        {
            Console.WriteLine("Error");
            this.gender = Visitor.Gender.Male;
        }
    }

    // public void FeedVisitorAnimal(List<> openList, int index)
    // {
    //     if ()
    // }
}