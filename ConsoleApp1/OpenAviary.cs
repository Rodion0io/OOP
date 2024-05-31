using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZooSimulation;

public interface IPublicPart
{
    void getPublicStatus();

    void removeAnimal(Animals animal);

    void addAnimal(Animals animal);

    bool checkAnimal(Animals animal);

    List<Animals> getAnimals();
}

class PublicPart : IPublicPart
{

    private List<Animals> publicPartList { get; }
    
    public PublicPart()
    {
        publicPartList = new List<Animals>();
    }

    public void getPublicStatus()
    {
        Console.WriteLine($"Количество животных в открытой части вольера : {publicPartList.Count}");

        foreach (Animals animal in publicPartList)
        {
            animal.status();
        }
    }

    public void addAnimal(Animals animal)
    {
        publicPartList.Add(animal);
    }

    public void removeAnimal(Animals animal)
    {
        publicPartList.Remove(animal);
    }
    public bool checkAnimal(Animals animal)
    {
        return publicPartList.Contains(animal) ? true : false;
    }

    public List<Animals> getAnimals()
    {
        return publicPartList;
    }
}