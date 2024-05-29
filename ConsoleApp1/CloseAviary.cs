namespace ConsoleApp1;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulation;
interface IPrivatePart
{
    void addAnimal(Animals animal);

    void removeAnimal(Animals animal);
    void getPrivateStatus();

    bool checkAnimal(Animals animal);

    List<Animals> getAllAnimals();
}

class PrivatePart:IPrivatePart
{
    private List<Animals> privatePartList;

    public PrivatePart()
    {
        privatePartList = new List<Animals>();
    }

    public void getPrivateStatus()
    {
        Console.WriteLine($"Количество животных в закрытой части вольера : {privatePartList.Count}");
        foreach (Animals animal in privatePartList)
        {
            animal.status();
        }
    }

    public void removeAnimal(Animals animal)
    {
        privatePartList.Remove( animal );
    }

    public void addAnimal(Animals animal)
    {
        privatePartList.Add( animal );
    }

    public bool checkAnimal(Animals animal)
    {
        return privatePartList.Contains( animal )?true:false;
    }

    public List<Animals>getAllAnimals()
    {
        return privatePartList;
    }

}