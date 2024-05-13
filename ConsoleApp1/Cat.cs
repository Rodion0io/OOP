namespace ConsoleApp1;

class Cat : Animal
{
    protected override int defaultHungerThreshold => 30;

    public Cat(string name, int animalNumber) : base(name, animalNumber)
    {
        
    }
    
    public override void voiceCommand()
    {
        Console.WriteLine("Chipi chipi chapa");
    }
}