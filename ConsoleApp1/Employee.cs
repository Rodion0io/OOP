namespace ConsoleApp1;

public class Employee : Human
{
    public string post;
    public List<Animal>animalList;
    public List<IOperationsAviary> aviaryList;
    public Employee(string name, Gender gender,string id, string post) : base(name, gender, id )
    {
        this.post = post;
        animalList = new List<Animal>();
        aviaryList = new List<IOperationsAviary>();
    }

    public void AddAnimal(Animal anim)
    {
        animalList.Add(anim);
    }

    public void RemoveAnimal(Animal anim)
    {
        animalList.Remove(anim);
    }

    public void AddAviary(IOperationsAviary aviar)
    {
        aviaryList.Add(aviar);
    }

    public void RemoveAviary(Aviary aviar)
    {
        aviaryList.Remove(aviar);
    }
    
    public override void status()
    {
        Console.WriteLine($"Name:{name}, Gender:{gender}, Post:{post}, Fix aviary: {aviaryList[0]}");
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

    public void Recover()
    {
        foreach (var avairy in aviaryList)
        {
            if (avairy.GetFeedContiner() != 1000)
            {
                avairy.RecoveryFeedConteiner();
                Console.WriteLine($"{name} replenished his food supply");
                break;
            }
        }
    }
}