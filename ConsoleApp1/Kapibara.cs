using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulation;


class Monkey : Animals
{
    protected override int defaultHungerThreshold => 50;
    public Monkey(string name) : base(name) { }

    public override void voiceCommand()
    {
        Console.WriteLine("Уу Аа уа");
    }
}