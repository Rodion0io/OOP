namespace ConsoleApp1;

public class ComporatorAviary : IComparer<IAviary>
{
    public int Compare(IAviary x, IAviary y)
    {
        return string.Compare(x.getFirstContainer().ToString(), y.getFirstContainer().ToString());
    }
}