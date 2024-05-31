using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using ZooSimulation;
abstract class Humans : Entity
{
    public enum Gender
    {
        Male,
        Female
    }

    public string name;
    public Gender sex;
    
    
    public Humans(string name, Gender sex)
    {
        this.name = name;
        this.sex = sex;
    }

    public abstract void status();
}