namespace ConsoleApp1;

class Cat : Animal
{
    protected override int defaultHungerThreshold => 30;

    public Cat(string name) : base(name)
    {
        this.name = name;
    }

    public override void voiceCommand()
    {
        Console.WriteLine("Chipi chipi chapa");
    }
}