namespace ConsoleApp1;

public abstract partial class Animal
{
    public int satiety;
    public int hungerThreshold;
    public string name;
    public int animalNumber;
    public bool attached;
    public enum hungerStatus
    {
        wellFed,
        hungry
    }

    public hungerStatus currentStatus;

    protected abstract int defaultHungerThreshold { get; }
    public Animal(string name, int animalNumber)
    {
        currentStatus = hungerStatus.wellFed;
        satiety = 100;
        this.name = name;
        this.animalNumber = animalNumber;
        hungerThreshold = defaultHungerThreshold;
        attached = false;
    }
    public abstract void voiceCommand();
    public void feed()
    {
        satiety = 100;
    }

    public void updateStatus()
    {
        currentStatus = (satiety > hungerThreshold ? hungerStatus.wellFed : hungerStatus.hungry);
    }
    public void status()
    {
        Console.WriteLine($"Name : {name} current satiety : {satiety}");
        Console.WriteLine($"Name : {name} current satiety : {currentStatus}");
    }

    public void changeAttached()
    {
        attached = true;
    }
}