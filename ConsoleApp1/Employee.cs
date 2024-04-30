namespace ConsoleApp1;

class Employee : Human
{
    public string post;
    public List<Animal>animalList;
    public Employee(string name, Gender gender,string id, string post) : base(name, gender, id )
    {
        // this.name = name;
        // this.gender = gender;
        // this.id = id;
        this.post = post;
        animalList = new List<Animal>();
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