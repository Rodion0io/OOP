using System.Timers;

namespace ConsoleApp1;

class Timee
{
    public Zoo zoo { get; }
    private System.Timers.Timer timer;
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
        
        bool AnimalsIsHungry = false;
        foreach (var animal in zoo.ListAnimals)
        {
            animal.satiety -= 1;
            animal.updateStatus();
            if (animal.currentStatus == Animal.hungerStatus.hungry)
            {
                AnimalsIsHungry = true;
            }
        }

        if (AnimalsIsHungry)
        {
            foreach (var employee in zoo.ListEmployees)
            {
                employee.FeedAnimals(zoo);

            }
            AnimalsIsHungry = false;
        }
    }

    public void StopTimer()
    {
        timer.Enabled = false;
        
    }

    public void StartTimer()
    {
        timer.Enabled = true;
    }
}