namespace ConsoleApp1;

class Kapibara : Animal
{
    protected override int defaultHungerThreshold => 20;

    public Kapibara(string name, int animalNumber) : base(name, animalNumber)
    {
        this.name = name;
    }
    public override void voiceCommand()
    {
        Console.WriteLine("ъуъ");
    }
}