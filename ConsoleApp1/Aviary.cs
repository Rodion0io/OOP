namespace ConsoleApp1;

interface IOperations
{
    void Status();
    void AddAnimal(Animal animal);
    void DeleteAnimal(Animal animal);
    void ClearAviary();
    void FeedAnimal();
    void changeAttached();
    void maxFeedLevel();
    
}

public class Aviary: IOperations
{
    public string typeAnimal;
    public int animalLimit;
    public int feedLevel;
    public int aviaryNumber;
    public bool attached;
    public List<Animal> openPart;
    public List<Animal> closePart;
    public List<Animal> aviary;
    private Zoo zoo;
    

    public Aviary(string typeAnimal, int animalLimit, int aviaryNumber, bool attached, List<Animal> openPart,
        List<Animal> closePart, List<Animal> aviary)
    {
        this.typeAnimal = typeAnimal;
        this.animalLimit = animalLimit;
        feedLevel = 250;
        this.aviaryNumber = aviaryNumber;
        this.attached = false;
        this.openPart = new List<Animal>();
        this.closePart = new List<Animal>();
        this.aviary = new List<Animal>();
        this.zoo = zoo;
    }

    
    public void Status()
    {
        Console.WriteLine($"This aviary {typeAnimal} is inhabiting. Current feed level: {feedLevel}");
    }

    public void AddAnimal(Animal animal)
    {
        if (aviary.Count < animalLimit && aviary.Count != 0)
        {
            if (aviary[0].GetType().Name == animal.GetType().Name)
            {
                aviary.Add(animal);
                // zoo.ListAnimals.Add(animal); Здесь под вопросом.
            }
        }
        else if (aviary.Count > animalLimit)
        {
            Console.WriteLine("Error! Add new aviary");
        }
    }

    public void DeleteAnimal(Animal animal)
    {
        aviary.Remove(animal);
        // zoo.ListAnimals.Remove(animal); Здесь под вопросом.
    }

    public void ClearAviary()
    {
        // zoo.ListAnimals.RemoveAll(item => aviary.Contains(item)); Под вопросом
        openPart.Clear();
        closePart.Clear();
        aviary.Clear();
    }

    public void FeedAnimal()
    {
        throw new NotImplementedException();
    }

    public void changeAttached()
    {
        attached = true;
    }

    public void maxFeedLevel()
    {
        feedLevel = 250;
    }
}