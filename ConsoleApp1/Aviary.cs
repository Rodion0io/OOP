using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

interface IAviary
{
    void addAnimal(Animals newAnimal);
    void removeAnimal(Animals newAnimal);

    void replenishFirstSupplies();

    void feedAnimal(Animals animal);

    void getStatus();

    bool available(Animals newAnimal);

    int getFirstContainer();

    int getSecondContainer();

    string getAviaryId();

    List<Animals> getAnimals();

    void moveToPublicPart(Animals animal);

    void moveToPrivatePart(Animals animal);
    
    IPublicPart getPublicPart();

    IPrivatePart getPrivatePart();

    void addFood<T>(T firstBrand, int container) where T : Food;

    void feedEntity<T>(T entity, int container) where T : Animals;
}

class Aviary: IAviary
{
    public string aviaryId;
    private int maxAnimalAmount;

    public IPublicPart publicPart;
    public IPrivatePart privatePart;

    public int firstContainer;
    public int secondContainer;
    public List<Animals> aviaryAnimals;
    public RandomNumberGenerator randNumber;
    public List<Food> foodList;
 
    public Aviary(string aviaryId)
    {
        this.aviaryId = aviaryId;
        maxAnimalAmount = 5;
        firstContainer = 0;
        secondContainer = 0;
        aviaryAnimals = new List<Animals>();
        privatePart = new PrivatePart();
        publicPart = new PublicPart();
        randNumber = new RandomNumberGenerator();
        foodList = new List<Food>();
    }

    public void moveToPublicPart(Animals animal)
    {
        if (privatePart.checkAnimal(animal))
        {
            privatePart.removeAnimal(animal);
            publicPart.addAnimal(animal);
        }
    }

    public void moveToPrivatePart(Animals animal)
    {
        if (publicPart.checkAnimal(animal))
        {
            publicPart.removeAnimal(animal);
            privatePart.addAnimal(animal);
        }
    }

    public bool available(Animals newAnimal)
    {
        if (aviaryAnimals.Count == 0)
        {
            return true;
        }

        if (aviaryAnimals.Count < maxAnimalAmount)
        {
            if (newAnimal.GetType().Name == aviaryAnimals[0].GetType().Name)
            {
                return true;
            }
        }
        return false;
    }

    public void addAnimal(Animals newAnimal)
    {
        if (available(newAnimal))
        {
            aviaryAnimals.Add(newAnimal);
            privatePart.addAnimal(newAnimal);
            newAnimal.aviary = this;
        }

        if (aviaryAnimals.Count == 1)
        {
            if (aviaryAnimals[0].GetType().Name == "Monkey")
            {
                FirstBrand firstBrand = new FirstBrand();
                SecondBrand secondBrand = new SecondBrand();
                firstContainer = firstBrand.weight;
                secondContainer = secondBrand.weight;
                foodList.Add(firstBrand);
                foodList.Add(secondBrand);
            }
            else if (aviaryAnimals[0].GetType().Name == "Tiger")
            {
                FirstBrand firstBrand = new FirstBrand();
                ThirdBrand thirdBrand = new ThirdBrand();
                firstContainer = firstBrand.weight;
                secondContainer = thirdBrand.weight;
                foodList.Add(firstBrand);
                foodList.Add(thirdBrand);
            }
            else
            {
                SecondBrand secondBrand = new SecondBrand();
                ThirdBrand thirdBrand = new ThirdBrand();
                firstContainer = secondBrand.weight;
                secondContainer = thirdBrand.weight;
                foodList.Add(secondBrand);
                foodList.Add(thirdBrand);
            }
        }
    }

    public void removeAnimal(Animals newAnimal)
    {
        aviaryAnimals.Remove(newAnimal);
        if (aviaryAnimals.Count == 0)
        {
            firstContainer = 0;
            secondContainer = 0;
        }
    }

    public void addFood<T>(T food, int container) where T : Food
    {
        container = food.weight;
    }

    public void replenishFirstSupplies()
    {
        if (firstContainer == 0)
        {
            addFood(foodList[0], firstContainer);
        }
        else if (secondContainer == 0)
        {
            addFood(foodList[1], secondContainer);
        }
    }

    public void feedEntity<T>(T entity, int container) where T : Animals
    {
        if (container != 0)
        {
            if (container - (100 - entity.saturation) >= 0)
            {
                container -= (100 - entity.saturation);
                entity.feed();
                entity.updateStatus();
            }
            else
            {
                entity.saturation += container;
                entity.updateStatus();
                container = 0;
            }
        }
    }

    public void feedAnimal(Animals animal)
    {
        int number = randNumber.GenerateRandomValueToFoodContainer();

        if (number == 0)
        {
            feedEntity(animal, firstContainer);
        }
        else
        {
            feedEntity(animal, secondContainer);
        }
    }

    public void getStatus()
    {
        Console.WriteLine($"Количество животных:{aviaryAnimals.Count}");

        privatePart.getPrivateStatus();

        publicPart.getPublicStatus();

        Console.WriteLine($"Текущий запас первого контейнера:{firstContainer}\n" +
                          $"второго контенера:{secondContainer}");
    }

    public int getFirstContainer()
    {
        return firstContainer;
    }

    public int getSecondContainer()
    {
        return secondContainer;
    }

    public string getAviaryId()
    {
        return aviaryId;
    }

    public List<Animals> getAnimals()
    {
        return aviaryAnimals;
    }

   public IPublicPart getPublicPart()
   {
        return publicPart;
   }

    public IPrivatePart getPrivatePart()
    {
        return privatePart;
    }
}
