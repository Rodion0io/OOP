using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulation;
class Penguin : Animals
{
    protected override int defaultHungerThreshold => 65;

    public Penguin(string name) : base(name) { }
    public override void voiceCommand()
    {
        Console.WriteLine("Kawasakiii");
    }
}