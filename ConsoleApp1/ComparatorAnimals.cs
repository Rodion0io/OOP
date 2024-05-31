namespace ConsoleApp1;

public class ComparatorAnimals : IComparer<Animals>
{
    public int Compare(Animals x, Animals y)
    {
        return string.Compare(x.name, y.name);
    }
}