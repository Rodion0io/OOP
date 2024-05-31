namespace ConsoleApp1;

public class ComporatorVisitor : IComparer<Visitors>
{
    public int Compare(Visitors x, Visitors y)
    {
        return string.Compare(x.name, y.name);
    }
}