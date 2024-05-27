using System.Timers;

namespace ConsoleApp1;

class Timee
{
    public Zoo zoo { get; }
    private System.Timers.Timer timer;
    private Employee _employee;
    private IOperationsAviary _operationsAviary;
    public Timee(Zoo zoo)
    {
        this.zoo = zoo;
        timer = new System.Timers.Timer(1000);
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;   
    }

    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        if (timer.Enabled == false)
        {
            return;
        }
        foreach (Animal animal in zoo.ListAnimals)
        {
            if (animal.currentStatus == Animal.hungerStatus.wellFed)
            {
                animal.satiety -= 1;
                animal.updateStatus();
            }
            else
            {
                animal.avair.FeedAnimal(animal);
            }
        }
    }

    public void StartTime()
    {
        timer.Enabled = true;
    }

    public void StopTime()
    {
        timer.Enabled = false;
    }
    
}