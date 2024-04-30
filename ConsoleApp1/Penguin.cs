namespace ConsoleApp1;

class Penguin : Animal
{
    protected override int defaultHungerThreshold => 40;

    public Penguin(string name) : base(name) { }
    public override void voiceCommand()
    {
        Console.WriteLine("Kawasakiiii");
    }
}