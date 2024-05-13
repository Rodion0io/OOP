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
    
    
}