namespace ConsoleApp1;

public interface IClose
{
    void AddAnimalInCloseAviary(Animal animal);
    void DeleteAnimalCloseAviary(Animal animal);
    List<Animal> ReturnCloseAviary();
}

public class CloseAviary : IClose
{
    public List<Animal> ListCloseAviary;

    public CloseAviary(List<Animal> ListCloseAviary)
    {
        ListCloseAviary = new List<Animal>();
    }

    public void AddAnimalInCloseAviary(Animal animal)
    {
        ListCloseAviary.Add(animal);
    }

    public void DeleteAnimalCloseAviary(Animal animal)
    {
        ListCloseAviary.Remove(animal);
    }

    public List<Animal> ReturnCloseAviary()
    {
        return ListCloseAviary;
    }
}