namespace ConsoleApp1;

class Kapibara : Animal
{
    protected override int defaultHungerThreshold => 20;

    public Kapibara(string name) : base(name)
    {
        this.name = name;
    }
    public override void voiceCommand()
    {
        Console.WriteLine("ъуъ");
    }
}