using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ConsoleApp1;
using Microsoft.Win32;
using ZooSimulation;

class Timer
{
    private Zoo zoo;
    private System.Timers.Timer starvingTimer;
    private System.Timers.Timer moveTimer;
    private System.Timers.Timer visitorsTimer;
    private Random random;
    public Timer(Zoo zoo)
    {
        random = new Random();
        this.zoo = zoo;
        starvingTimer = new System.Timers.Timer(2000);
        starvingTimer.Elapsed += OnTimedEvent;
        starvingTimer.AutoReset = true;
        starvingTimer.Enabled = true;

        moveTimer = new System.Timers.Timer();
        moveTimer.Elapsed += OnMoveTimedEvent;
        moveTimer.AutoReset = false;
        moveTimer.Enabled = true;
        scheduleNextMove();

        visitorsTimer = new System.Timers.Timer();
        visitorsTimer.Elapsed += OnFeedTimedEvent;
        visitorsTimer.AutoReset = false;
        visitorsTimer.Enabled = true;
        scheduleNextTry();
    }

    public void pause()
    {
        if (starvingTimer.Enabled == false)
        {
            Console.WriteLine("Таймер уже на паузе");
        }
        else
        {
            starvingTimer.Enabled = false;
            visitorsTimer.Enabled = false;
            moveTimer.Enabled = false;
            Console.WriteLine("Таймер был поставлен на паузу");
        }
    }

    public void unpause()
    {
        if (starvingTimer.Enabled == true) {
            Console.WriteLine("Таймер не на паузе");
        }
        else
        {
            starvingTimer.Enabled = true;
            visitorsTimer.Enabled = true;
            moveTimer.Enabled = true;
            Console.WriteLine("Таймер был снят с паузы");
        }
    }

    private void scheduleNextMove()
    {
        int delay = random.Next(1000,3000);
        moveTimer.Interval = delay;
        moveTimer.Start();
    }

    private void OnMoveTimedEvent(Object source, ElapsedEventArgs e)
    {
        moveAnimals();

        scheduleNextMove();
    }

    private void moveAnimals()
    {
        int randNum = new RandomNumberGenerator().GenerateRandomValueToFoodContainerAndMove();
        
        foreach (Entity entity in zoo.Registry.OfType<Aviary>())
        {
            if (entity is Aviary aviary)
            {
                if(aviary.publicPart.getAnimals().Count > 0 && randNum == 1)
                {
                    Animals animal = aviary.publicPart.getAnimals()[random.Next(aviary.publicPart.getAnimals().Count)];
                    aviary.moveToPrivatePart(animal);
                }
                if (aviary.privatePart.getAllAnimals().Count > 0 && randNum == 1)
                {
                    Animals animal = aviary.privatePart.getAllAnimals()[random.Next(aviary.privatePart.getAllAnimals().Count)];
                    aviary.moveToPublicPart(animal);
                }
            }
            
        }
    }
    private void OnFeedTimedEvent(Object source, ElapsedEventArgs e)
    {
        giveTreat();

        scheduleNextTry();
    }

    private void scheduleNextTry()
    {
        int delay = random.Next(10000, 15000);
        visitorsTimer.Interval = delay;
        visitorsTimer.Start();
    }

    private void giveTreat()
    {
        foreach(Visitors visitor in zoo.Registry.OfType<Visitors>())
        {
            foreach (IAviary aviary in zoo.Registry.OfType<Aviary>())
            {
                visitor.giveTreat(aviary.getPublicPart(), aviary.getAnimals()[random.Next(aviary.getAnimals().Count)]);
            }
        }
    }
    
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        foreach(Employee employee in zoo.Registry.OfType<Employee>())
        {
            employee.feedAviarys(zoo);
        }

        List<Animals> AnimalsIsHungry = new List<Animals>();

        foreach (var animal in zoo.Registry.OfType<Animals>())
        {
            if (animal.saturation >= 0)
            {
                animal.saturation -= 1;
                animal.updateStatus();
            }

            if (animal.currentStatus == Animals.hungerStatus.Голодный)
            {
                AnimalsIsHungry.Add(animal);
            }
        }

        if (AnimalsIsHungry.Count > 0)
        {
            foreach(Animals animals in AnimalsIsHungry.ToList())
            {

                animals.aviary.feedAnimal(animals);

                if (animals.currentStatus != Animals.hungerStatus.Голодный)
                {
                    AnimalsIsHungry.Remove(animals);
                }
            }
        }
    }
}