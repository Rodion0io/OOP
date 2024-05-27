namespace ConsoleApp1;

class Randomizer
{
    private Random rnd = new Random();

    public int RandomValue(int minValue, int maxValue)
    {
        return rnd.Next(minValue, maxValue);
    }

    public int RandomPartAviary()
    {
        return rnd.Next(0, 1);
    }

    public int RandovNumberForAviary()
    {
        return rnd.Next(0, 100);
    }

    public int RandomNameNumber()
    {
        return rnd.Next(1, 20);
    }

    public int RandomTypeAnimal()
    {
        return rnd.Next(1, 4);
    }
    
    
}