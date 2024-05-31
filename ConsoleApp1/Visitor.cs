using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZooSimulation;

public class Visitors : Humans
{
    public int money;
    public Visitors(string name, Gender gender,int money) : base(name, gender) {
        this.money = money;
    }

    public Guid getId()
    {
        return id;
    }
    
    public override void status()
    {
        Console.WriteLine($"Имя:{name}, Пол:{gender} Деньги:{money}");
    }
    public void giveTreat(IPublicPart openPart,Animals animal)
    {
        if (money - 50 >= 0) {
            if (openPart.checkAnimal(animal))
            {
                
                if (animal.currentStatus == Animals.hungerStatus.Голодный)
                {
                    money -= 50;
                    animal.feed();
                    animal.updateStatus();
                }
            }
        }
    }
}