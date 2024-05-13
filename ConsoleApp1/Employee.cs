namespace ConsoleApp1;

class Employee : Human
{
    public string post;
    public List<Animal> animalList;
    public List<Aviary> aviaryList;
    public Employee(string name, Gender gender,string id, string post) : base(name, gender, id )
    {
        // this.name = name;
        // this.gender = gender;
        // this.id = id;
        this.post = post;
        animalList = new List<Animal>();
        aviaryList = new List<Aviary>();
    }

    public void AddAnimal(Animal anim)
    {
        animalList.Add(anim);
    }

    public void RemoveAnimal(Animal anim)
    {
        animalList.Remove(anim);
    }
    
    public override void status()
    {
        Console.WriteLine($"Name:{name}, Gender:{gender}, Post:{post}");
    }
    
    public void changeEmployeeName(string newName)
    {
        name = newName;
    }

    public void changeEmployeeGender(string newGender)
    {
        if(Enum.TryParse(newGender,out gender))
        {
            this.gender = gender;
        }
        else
        {
            Console.WriteLine("Error");
            this.gender = Visitor.Gender.Male;
        }
    }

    public void FeedAnimals(Zoo zoo)
    {
        foreach (var animal in animalList)
        {
            if (animal.currentStatus == Animal.hungerStatus.hungry) {
                animal.feed();
                animal.updateStatus();
                Console.WriteLine($"{name} is feeded {animal.name} ({animal.GetType().Name}).");
                break;
            }
        }
    }
    
    
}