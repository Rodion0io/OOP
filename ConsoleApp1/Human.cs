namespace ConsoleApp1;

public abstract class Human
{
    public enum Gender
    {
        Male,
        Female
    }

    public string name;
    public Gender gender;
    public string id;
    
    public Human(string name, Gender gender,string id)
    {
        this.name = name;
        this.gender = gender;
        this.id = id; 
    }

    public abstract void status();
}