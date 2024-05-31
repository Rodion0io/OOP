using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using ZooSimulation;

public abstract class Humans : Entity
{
    public enum Gender
    {
        Male,
        Female
    }

    public string name;
    public Gender gender;
    
    
    public Humans(string name, Gender gender)
    {
        this.name = name;
        this.gender = gender;
    }

    public abstract void status();
}