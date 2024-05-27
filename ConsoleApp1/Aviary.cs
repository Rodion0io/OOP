namespace ConsoleApp1;

public class Aviary : IOperationsAviary
{
    public int numberAviary;
    public int limitAnimals;
    public int feedContiner;
    public bool attached;
    public List<Animal> ListAviary;
    public IOpen openPart;
    public IClose closePart;
    private Zoo zoo;
    private Employee employee;
    private Randomizer random;
    
    public Aviary(int numberAviary, Zoo zoo)
    {
        this.numberAviary = numberAviary;
        limitAnimals = 8;
        feedContiner = 1000;
        attached = false;
        ListAviary = new List<Animal>();
        random = new Randomizer();
        this.zoo = zoo;
        openPart = new OpenAviary();
        closePart = new CloseAviary();
    }


    public void generateNum()
    {
        numberAviary = random.RandovNumberForAviary();
    }
    
    public void AddAnimal(Animal animal)
    {
        if (ListAviary.Count == 0)
        {
            int generationNumber = random.RandomPartAviary();
            ListAviary.Add(animal);
            
            if (generationNumber == 1)
            {
                
                openPart.AddAnimalInOpenAviary(animal);
            }
            else
            {
                closePart.AddAnimalInCloseAviary(animal);
            }
        }
        else if (ListAviary[0].GetType().Name == animal.GetType().Name && ListAviary.Count != limitAnimals)
        {
            int generationNumber = random.RandomPartAviary();
            ListAviary.Add(animal);
            
            if (generationNumber == 1)
            {
                
                openPart.AddAnimalInOpenAviary(animal);
            }
            else
            {
                closePart.AddAnimalInCloseAviary(animal);
            }
        }
        else
        {
            Console.WriteLine("Error");
        }
    }

    public void DeleteAnimal(Animal animal)
    {
        if (ListAviary.Count != 0)
        {
            ListAviary.Remove(animal);
            zoo.ListAnimals.Remove(animal);
            if (openPart.ReturnOpenAviary().Contains(animal))
            {
                openPart.DeleteAnimalOpenAviary(animal);
            }
            else
            {
                closePart.DeleteAnimalCloseAviary(animal);
            }
        }
        else
        {
            Console.WriteLine("Aviary is empty");
        }
    }

    public void GoToClose(Animal animal)
    {
        if (openPart.ReturnOpenAviary().Contains(animal))
        {
            closePart.AddAnimalInCloseAviary(animal);
            openPart.DeleteAnimalOpenAviary(animal);
            Console.WriteLine($"{animal.name} has been go to close aviary");
        }
        else
        {
            Console.WriteLine("Animal not found");
        }
    }

    public void GoToOpen(Animal animal)
    {
        if (closePart.ReturnCloseAviary().Contains(animal))
        {
            openPart.AddAnimalInOpenAviary(animal);
            closePart.DeleteAnimalCloseAviary(animal);
            Console.WriteLine($"{animal.name} has been go to close aviary");
        }
        else
        {
            Console.WriteLine("Animal not found");
        }
    }

    public string GetStatusForLists()
    {
        if (ListAviary.Count != 0)
        {
            return $"In this aviary there are {ListAviary[0].GetType().Name}s. Current feed container is {feedContiner}";
        }
        else
        {
            return $"Aviary is empty";
        }
    }

    public int GetNumberAviary()
    {
        return numberAviary;
    }

    public bool getAttachedStatus()
    {
        return attached;
    }
    
    public void chagedAttached()
    {
        attached = true;
    }

    public List<Animal> ListAviar()
    {
        return ListAviary;
    }

    public void FeedAnimal(Animal animal)
    {
        if (feedContiner != 0 && (feedContiner - (100 - animal.satiety)) >= 0)
        {
            feedContiner -= (100 - animal.satiety);
            animal.feed();
            animal.updateStatus();
            Console.WriteLine($"Animal {animal.name} is feded");
        }
    }

    public int GetFeedContiner()
    {
        return feedContiner;
    }

    public void RecoveryFeedConteiner()
    {
        feedContiner = 1000;
    }
}