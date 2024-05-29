using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulation;
abstract class Humans
{
    public enum Gender
    {
        Male,
        Female
    }

    public string name;
    public Gender sex;
    public string id;
    
    public Humans(string name, Gender sex,string id)
    {
        this.name = name;
        this.sex = sex;
        this.id = id; 
    }

    public abstract void status();
}