namespace ConsoleApp1;

abstract public class Food
{
    public string name;
    public int weight;

    public Food(string name, int weight)
    {
        this.name = name;
        this.weight = weight;
    }
}