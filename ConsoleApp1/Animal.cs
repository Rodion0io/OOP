using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using  ZooSimulation;

abstract class Animals : Entity
{
    public int saturation;
    public int hungerThreshold;
    public string name;
    public Guid id;
    public IAviary aviary;
    public enum hungerStatus
    {
        Сытый,
        Голодный
    }

    public hungerStatus currentStatus;

    protected abstract int defaultHungerThreshold { get; }
    public Animals(string name)
    {
        currentStatus = hungerStatus.Сытый;
        saturation = 100;
        this.name = name;
        hungerThreshold = defaultHungerThreshold;
    }
    public abstract void voiceCommand();
    public void feed()
    {
        saturation = 100;
    }

    public void updateStatus()
    {
        currentStatus = (saturation > hungerThreshold ? hungerStatus.Сытый : hungerStatus.Голодный);
    }
    
    public void status()
    {
        Console.WriteLine($"Вид :{GetType().Name}  Имя : {name} Сытость : {saturation}  Статус : {currentStatus}  Номер вольера:{aviary.getAviaryId()}");
    }


}