using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulation;
class RandomNumberGenerator
{
    private Random rnd = new Random();

    public int GenerateRandomNumber(int minValue, int maxValue)
    {
        return rnd.Next(minValue, maxValue);
    }
    
    public int GenerateRandomValueToFoodContainerAndMove()
    {
        return rnd.Next(0, 2);
    }
}