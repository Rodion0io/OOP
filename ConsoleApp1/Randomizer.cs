namespace ConsoleApp1;

class Randomizer
{
    private Random rnd = new Random();

    public int RandomValue(int minValue, int maxValue)
    {
        return rnd.Next(minValue, maxValue);
    }

    public int RandomTypeAnimal()
    {
        return rnd.Next(1, 3);
    }

    public int RandomNameAnimal()
    {
        return rnd.Next(0, 20);
    }

    public int RandomOpenOrClose()
    {
        return rnd.Next(0, 1);
    }
}