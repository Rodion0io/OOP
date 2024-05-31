namespace ConsoleApp1;

public class Entity
{
    public Guid id;

    public Entity()
    {
        this.id = Guid.NewGuid();
    }
}