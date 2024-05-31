using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZooSimulation;

class Visitors : Humans
{
    public int money;
    public Visitors(string name, Gender sex, string id,int money) : base(name, sex) {
        this.money = money;
    }
    public override void status()
    {
        Console.WriteLine($"Имя:{name}, Пол:{sex} Деньги:{money}");
    }
    public void giveTreat(IPublicPart openPart,Animals animal)
    {
        if (money-50 >= 0) {
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