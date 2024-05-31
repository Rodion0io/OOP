using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulation;


class Kapibara : Animals
{
    protected override int defaultHungerThreshold => 50;
    public Kapibara(string name) : base(name) { }

    public override void voiceCommand()
    {
        Console.WriteLine("ъыъ");
    }
}