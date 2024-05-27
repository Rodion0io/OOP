namespace ConsoleApp1;

public interface IOperationsAviary
{
    void AddAnimal(Animal animal);
    void DeleteAnimal(Animal animal);
    void GoToOpen(Animal animal);
    void GoToClose(Animal animal);
    string GetStatusForLists();
    int GetNumberAviary();
    void generateNum();
    bool getAttachedStatus();
    void chagedAttached();
    void FeedAnimal(Animal animal);
    void RecoveryFeedConteiner();
    int GetFeedContiner();
    List<Animal> ListAviar();
}