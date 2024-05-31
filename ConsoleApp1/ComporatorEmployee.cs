namespace ConsoleApp1;

public class ComporatorEmployee : IComparer<Employee>
{
    public int Compare(Employee x, Employee y)
    {
        return string.Compare(x.name, y.name);
    }
}