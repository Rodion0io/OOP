using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulation;

class Tiger : Animals
{
    protected override int defaultHungerThreshold => 70;

    public Tiger(string name) : base(name) { }
    public override void voiceCommand()
    {
        Console.WriteLine("Раар");
    }
}