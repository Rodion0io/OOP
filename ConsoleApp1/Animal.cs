namespace ConsoleApp1;

abstract partial class Animal
{
    public int satiety;
    public int hungerThreshold;
    public string name;
    public bool attached;
    public enum hungerStatus
    {
        wellFed,
        hungry
    }

    public hungerStatus currentStatus;

    protected abstract int defaultHungerThreshold { get; }
    public Animal(string name)
    {
        currentStatus = hungerStatus.wellFed;
        satiety = 100;
        this.name = name;
        hungerThreshold = defaultHungerThreshold;
        attached = false;
    }
    public abstract void voiceCommand();
    public void feed()
    {
        satiety = 70;
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
}