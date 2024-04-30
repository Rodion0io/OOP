using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1;

class Visitor : Human
{
    public Visitor(string name, Gender gender, string id) : base(name, gender, id)
    {
        this.name = name;
        this.gender = gender;
        this.id = id;
    }
    public override void status()
    {
        Console.WriteLine($"Name:{name}, Gender:{gender}");
    }
}