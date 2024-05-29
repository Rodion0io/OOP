using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulation;
class Bear : Animals
{
    protected override int defaultHungerThreshold => 65;

    public Bear(string name) : base(name) { }
    public override void voiceCommand()
    {
        Console.WriteLine("Мхмр");
    }
}