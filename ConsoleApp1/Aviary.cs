namespace ConsoleApp1;

interface IOpenAviary
{
    List<Animal> CreateOpenAviary();
    void AddToOpenAviaryAnim(Animal animal);
    void DeleteOpenAviaryAnim(Animal animal);
}

interface ICloseAviary
{
    List<Animal> CreatCloseAviary();
    void AddToCloseAviaryAnim(Animal animal);
    void DeleteCloseAviaryAnim(Animal animal);
}

interface IOperations
{
    void ClearAviary();
    void Status();
    // void recoveryАoodSupply();
}


public class Aviary : IOpenAviary, ICloseAviary, IOperations
{
    public string typeAnimal;
    public int limit;
    public int foodSupply;
    public bool attached;

    public Aviary(string typeAnimal, int limit, int foodSupply, bool attached)
    {
        this.typeAnimal = typeAnimal;
        this.limit = limit;
        foodSupply = 250;
        attached = false;
    }

    public void Status()
    {
        Console.WriteLine($"This aviary is inhabited by {typeAnimal}. Food supply is composed {foodSupply}");
    }

    public List<Animal> CreateOpenAviary()
    {
        List<Animal> OpenAviary = new List<Animal>();
        return OpenAviary;
    }

    public List<Animal> CreatCloseAviary()
    {
        List<Animal> CloseAviary = new List<Animal>();
        return CloseAviary;
    }

    public void AddToOpenAviaryAnim(Animal animal)
    {
        if (animal.GetType().Name == CreateOpenAviary()[0].GetType().Name)
        {
            CreateOpenAviary().Add(animal);
        }
        else if (CreateOpenAviary().Count == 0)
        {
            CreateOpenAviary().Add(animal);
        }
        else
        {
            Console.WriteLine("We can't add this animal here.");
        }
    }

    public void AddToCloseAviaryAnim(Animal animal)
    {
        if (animal.GetType().Name == CreateOpenAviary()[0].GetType().Name)
        {
            CreateOpenAviary().Add(animal);
        }
        else if (CreateOpenAviary().Count == 0)
        {
            CreateOpenAviary().Add(animal);
        }
        else
        {
            Console.WriteLine("We can't add this animal here.");
        }
    }

    public void DeleteOpenAviaryAnim(Animal animal)
    {
        if (animal.GetType().Name == CreateOpenAviary()[0].GetType().Name)
        {
            CreateOpenAviary().Remove(animal);
        }
        else if (CreateOpenAviary().Count == 0)
        {
            CreateOpenAviary().Remove(animal);
        }
        else
        {
            Console.WriteLine("We can't add this animal here.");
        }
    }

    public void DeleteCloseAviaryAnim(Animal animal)
    {
        if (animal.GetType().Name == CreateOpenAviary()[0].GetType().Name)
        {
            CreateOpenAviary().Remove(animal);
        }
        else if (CreateOpenAviary().Count == 0)
        {
            CreateOpenAviary().Remove(animal);
        }
        else
        {
            Console.WriteLine("We can't add this animal here.");
        }
    }

    public void ClearAviary()
    {
        CreateOpenAviary().Clear();
        CreatCloseAviary().Clear();
    }
}