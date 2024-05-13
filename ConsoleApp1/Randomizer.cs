namespace ConsoleApp1;

class Randomizer
{
    private Random rnd = new Random();

    public int RandomValue(int minValue, int maxValue)
    {
        return rnd.Next(minValue, maxValue);
    }

    public int RandomPartOfAviary()
    {
        return rnd.Next(0, 2);
    }

    public int RandomNameNumber()
    {
        return rnd.Next(0, 20);
    }

    public int RandomTypeAnimal()
    {
        return rnd.Next(1, 4);
    }

    public int RandomVal()
    {
        return rnd.Next(1, 51);
    }
}