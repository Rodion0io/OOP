using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        RandomNumberGenerator generator = new RandomNumberGenerator();

        foreach(Aviary aviarys in zoo.getAviarys())
        {
            int randNum = generator.GenerateRandomNumber(1, 20);

            if(aviarys.publicPart.getAnimals().Count>0 && randNum%2==0)
            {
                Animals animal = aviarys.publicPart.getAnimals()[random.Next(aviarys.publicPart.getAnimals().Count)];
                aviarys.moveToPrivatePart(animal);
            }

            if (aviarys.privatePart.getAllAnimals().Count >0 && randNum%2!=0)
            {
                Animals animal = aviarys.privatePart.getAllAnimals()[random.Next(aviarys.privatePart.getAllAnimals().Count)];
                aviarys.moveToPublicPart(animal);
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
        foreach(Visitors visitor in zoo.getVisitors())
        {
            foreach (IAviary aviary in zoo.getAviarys())
            {
                visitor.giveTreat(aviary.getPublicPart(), aviary.getAnimals()[random.Next(aviary.getAnimals().Count)]);
            }
        }
    }
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        foreach(Employee employee in zoo.getEmployee())
        {
            employee.feedAviarys(zoo);
        }

        List<Animals> AnimalsIsHungry = new List<Animals>();

        foreach (var animal in zoo.getAnimals())
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