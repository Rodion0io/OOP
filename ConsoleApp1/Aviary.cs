namespace ConsoleApp1;

public interface IOperationsWithAviary
{
    void AddInAviary(Animal animal);
    void DeleteFromAviary(Animal animal);
    void GoToOpen(Animal animal);
    void GoToClose(Animal animal);
    void AviaryStatus(int aviaryNumber);
    void FeedAnimal(Animal animal);
    void RecoveryFeed();
    void VisitorFeed(Animal animal);
}

public class Aviary : IOperationsWithAviary
{
    public int aviaryNumber;
    private Randomizer random;
    public int limitAnimal;
    public int feedContainer;
    public bool attached;
    public List<Animal> ListAviary;
    public IOpen openAviary;
    public IClose closeAviary;
    private Zoo zoo;
    

    public Aviary(int aviaryNumber)
    {
        this.aviaryNumber = aviaryNumber;
        limitAnimal = 8;
        feedContainer = 1000;
        attached = false;
        ListAviary = new List<Animal>();
        zoo = zoo;
        random = random;
        
    }

    public void AddInAviary(Animal animal)
    {
        if (ListAviary.Count == 0)
        {
            int generationNumber = random.RandomPartOfAviary();
            ListAviary.Add(animal);
            zoo.ListAnimals.Add(animal);
            if (generationNumber == 1)
            {
                
                openAviary.AddAnimalInOpenAviary(animal);
            }
            else
            {
                closeAviary.AddAnimalInCloseAviary(animal);
            }
        }
        else if (ListAviary[0].GetType().Name == animal.GetType().Name && ListAviary.Count != limitAnimal)
        {
            int generationNumber = random.RandomPartOfAviary();
            ListAviary.Add(animal);
            zoo.ListAnimals.Add(animal);
            if (generationNumber == 1)
            {
                
                openAviary.AddAnimalInOpenAviary(animal);
            }
            else
            {
                closeAviary.AddAnimalInCloseAviary(animal);
            }
        }
        else if (ListAviary.Count == limitAnimal)
        {
            Console.WriteLine("Error! Add new aviary");
        }
        else
        {
            Console.WriteLine("This animal don't add");
        }
    }

    public void DeleteFromAviary(Animal animal)
    {
        if (ListAviary.Count != 0)
        {
            ListAviary.Remove(animal);
            zoo.ListAnimals.Remove(animal);
            if (openAviary.ReturnOpenAviary().Contains(animal))
            {
                openAviary.DeleteAnimalOpenAviary(animal);
            }
            else
            {
                closeAviary.DeleteAnimalCloseAviary(animal);
            }
        }
        else
        {
            Console.WriteLine("Aviary is empty");
        }
    }

    public void GoToClose(Animal animal)
    {
        if (openAviary.ReturnOpenAviary().Contains(animal))
        {
            closeAviary.AddAnimalInCloseAviary(animal);
            openAviary.DeleteAnimalOpenAviary(animal);
            Console.WriteLine($"{animal.name} has been go to close aviary");
        }
        else
        {
            Console.WriteLine("Animal not found");
        }
    }

    public void GoToOpen(Animal animal)
    {
        if (closeAviary.ReturnCloseAviary().Contains(animal))
        {
            openAviary.AddAnimalInOpenAviary(animal);
            closeAviary.DeleteAnimalCloseAviary(animal);
            Console.WriteLine($"{animal.name} has been go to close aviary");
        }
        else
        {
            Console.WriteLine("Animal not found");
        }
    }

    public void AviaryStatus(int aviaryNumber)
    {
        Console.WriteLine($"In this aviary there are {ListAviary[0].GetType().Name}s. Current feed container is {feedContainer}");
    }

    public void FeedAnimal(Animal animal)
    {
        if (animal.currentStatus == Animal.hungerStatus.hungry)
        {
            feedContainer -= (100 - animal.satiety);
            animal.feed();
            animal.updateStatus();
        }
    }

    public void RecoveryFeed()
    {
        feedContainer = 1000;
    }

    public void VisitorFeed(Animal animal)
    {
        if (animal.currentStatus == Animal.hungerStatus.hungry)
        {
            animal.feed();
            animal.updateStatus();
        }
    }
}