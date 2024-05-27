namespace ConsoleApp1;

public interface IOpen
{
    void AddAnimalInOpenAviary(Animal animal);
    void DeleteAnimalOpenAviary(Animal animal);
    List<Animal> ReturnOpenAviary();
}

public class OpenAviary : IOpen
{
    public List<Animal> ListOpenAviary;

    public OpenAviary()
    {
        ListOpenAviary = new List<Animal>();
    }

    public void AddAnimalInOpenAviary(Animal animal)
    {
        ListOpenAviary.Add(animal);
    }

    public void DeleteAnimalOpenAviary(Animal animal)
    {
        ListOpenAviary.Remove(animal);
    }

    public List<Animal> ReturnOpenAviary()
    {
        return ListOpenAviary;
    }
}