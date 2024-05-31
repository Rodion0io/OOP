using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using ZooSimulation;

class Zoo
{
    public List<Entity> Registry;
    // private List<Animals> Animals;
    // private List<Employee> Employees;
    // private List<Visitors> Visitors;
    // private List<IAviary> Aviarys;
    private RandomNumberGenerator generator;
    private int Id;
    public Zoo()
    {
        // Animals = new List<Animals>();
        // Employees = new List<Employee>();
        // Visitors = new List<Visitors>();
        // Aviarys = new List<IAviary>();
        generator = new RandomNumberGenerator();
        Registry = new List<Entity>();
        createZoo();
    }

    private void createZoo()
    {
        Random random = new Random();
        Aviary newAviary = new Aviary();
        // Aviarys.Add(newAviary);
        Registry.Add(newAviary);

        List<string> types = new List<string> { "Monkey","Cat","Bear" };
        List<string> animalNames = new List<string>
        {
            "Max", "Charlie", "Buddy", "Daisy", "Molly",
            "Jack", "Sadie", "Bear", "Lucky", "Oliver",
            "Bella", "Lucy", "Luna", "Duke", "Zoe",
            "Cooper", "Stella", "Milo", "Bailey", "Lola",
            "Maggie", "Rocky", "Sophie", "Penny", "Tucker",
            "Winston", "Abby", "Rosie", "Jasper", "Sasha",
            "Sadie", "Gus", "Murphy", "Minnie", "Lacey",
            "Oscar", "Sam", "Chloe", "Princess", "Cleo",
            "Izzy", "Harley", "Ziggy", "Lily", "Ollie",
            "Sophia", "Pepper", "Sandy", "Roxy", "Casey",
            "Ruby", "Bentley", "Baxter", "Ginger", "Rusty",
            "Boots", "Roscoe", "Moose", "Blue", "Lucky",
            "Bella", "Luna", "Daisy", "Molly", "Lucy",
            "Zoe", "Sophie", "Stella", "Maggie", "Chloe"
        };

        for (int i = 0; i < 15 ; i++)
        {
            Animals animal = null;
            string animalName = animalNames[random.Next(animalNames.Count)];
            string animalType = types[random.Next(types.Count)];

            if (animalType == "Monkey")
            {
                animal = new Monkey(animalName);
            }

            if (animalType == "Cat")
            {
                animal = new Cat(animalName);
            }

            if (animalType == "Bear")
            {
                animal = new Bear(animalName);
            }
            attachAnimalToAviary(animal, (Aviarys.Count() +
                    generator.GenerateRandomNumber(1, 50)).ToString());

        }
        

    }

    private void attachAnimalToAviary(Animals animal, Guid aviaryId)
    {
        foreach (var aviary in Aviarys)
        {
            if (aviary.available(animal))
            {
                aviary.addAnimal(animal);
                Registry.Add(animal);
                break;
            }
        }

        if (animal.aviary == null)
        {
            IAviary aviaryForNew = new Aviary();
            Registry.Add(aviaryForNew);
            Registry.Add(animal);
            aviaryForNew.addAnimal(animal);
        }

    }

    public void AddAnimal()
    {
        Console.WriteLine("Кличка животного:");
        string animalName = Console.ReadLine();

        Console.WriteLine("Вид животного (Monkey/Cat/Bear):");
        string animalType = Console.ReadLine();
        Animals newAnimal;
        switch (animalType.ToLower())
        {
            case "monkey":
                newAnimal = new Monkey(animalName);
                Registry.Add(newAnimal);
                attachAnimalToAviary(newAnimal,(Aviarys.Count() +
                generator.GenerateRandomNumber(1, 50)).ToString());

                break;
            case "cat":
                newAnimal = new Cat(animalName);
                Registry.Add(newAnimal);
                attachAnimalToAviary(newAnimal, (Aviarys.Count() +
               generator.GenerateRandomNumber(1, 50)).ToString());
                break;
            case "bear":
                newAnimal = new Bear(animalName);
                Registry.Add(newAnimal);
                attachAnimalToAviary(newAnimal,(Aviarys.Count() +
               generator.GenerateRandomNumber(1, 50)).ToString());
                break;
            default: throw new ArgumentException("Неизвестный вид");
        }
    }
    public void RemoveAnimal()
    {
        Animals animal;
        Console.WriteLine("Имя животного:");
        string animalName = Console.ReadLine();

        Console.WriteLine("Вид животного:");
        string animalType = Console.ReadLine();

        foreach (Animals animals in Registry)
        {
            if (animalName == animals.name && animalType == animals.GetType().Name)
            {
                Registry.Remove(animals);
                return;
            }
        }

        Console.WriteLine("Животное не найдено");
    }
    public void AddAviary()
    {
        IAviary aviary;
        Console.WriteLine("Введите номер вольера:");
        Guid aviaryNum = Guid.Parse(Console.ReadLine());

        foreach (Aviary aviarys in Registry)
        {
            if (aviaryNum == aviarys.getAviaryId())
            {
                Console.WriteLine("Вольер с таким номером уже существует");
                return;
            }
        }
        aviary = new Aviary();

    }

    public void RemoveAviary()
    {
        IAviary aviary;
        Console.WriteLine("Введите номер вольера : ");
        Guid aviaryNum = Guid.Parse(Console.ReadLine());
        List<Animals> animalsToDelete = new List<Animals>();
        foreach (IAviary aviarys in Registry)
        {
            if (aviarys.getAviaryId() == aviaryNum)
            {
                animalsToDelete = aviarys.getAnimals();
                Registry.Remove(aviarys);

                for (int i = 0; i < animalsToDelete.Count; i++)
                {

                    Registry.RemoveAll(a => a == animalsToDelete[i]);
                }

                break;
            }
        }
    }

    public void AddEmployee()
    {
        Employee employee;
        Console.WriteLine("Имя сотрудника:");
        string employeeName = Console.ReadLine();

        Console.WriteLine("Должность сотрудника:");
        string employeePosition = Console.ReadLine();

        Console.WriteLine("Пол сотрудника:");
        string employeeSex = Console.ReadLine();
        Humans.Gender sex;
        if (Enum.TryParse(employeeSex, out sex))
        {
            employee = new Employee(employeeName, sex, generator.GenerateRandomNumber(1, 100).ToString(), employeePosition);
            Registry.Add(employee);
        }
        else
        {
            Console.WriteLine("Неверное значение пола, установлено значение по умолчанию");
            employee = new Employee(employeeName, Employee.Gender.Male, generator.GenerateRandomNumber(1, 100).ToString(), employeePosition);
            Registry.Add(employee);
        }
    }

    public void RemoveEmployee()
    {
        Console.WriteLine("Введите персональный номер сотрудника : ");
        Guid employeeId = Guid.Parse(Console.ReadLine());

        foreach (Employee employees in Registry)
        {
            if (employees.id == employeeId)
            {
                Registry.Remove(employees);
                return;
            }
        }
        Console.WriteLine("Сотрудник не найден");
    }

    public void AddVisitor()
    {

        Visitors visitor;
        Console.WriteLine("Имя посетителя:");
        string visitorName = Console.ReadLine();
        Console.WriteLine("Количество денег:");
        string visitorMoney = Console.ReadLine();
        Console.WriteLine("Пол посетителя:");
        string visitorSex = Console.ReadLine();
        Visitors.Gender sex;
        if (Enum.TryParse(visitorSex, out sex))
        {
            visitor = new Visitors(visitorName, sex, (Visitors.Count() +
                generator.GenerateRandomNumber(1, 100)).ToString(), int.Parse(visitorMoney));
            Registry.Add(visitor);
        }
        else
        {
            Console.WriteLine("Вы ввели несуществующее значение пола , установлено значение по умолчанию");
            visitor = new Visitors(visitorName, Humans.Gender.Male, (Visitors.Count() +
                generator.GenerateRandomNumber(1, 100)).ToString(), int.Parse(visitorMoney));
        }
    }

    public void RemoveVisitor()
    {
        Console.WriteLine("Введите номер билета : ");
        Guid visitorId = Guid.Parse(Console.ReadLine());
        foreach (Visitors visitors in Registry)
        {
            if (visitors.id == visitorId)
            {
                Registry.Remove(visitors);
                return;
            }
        }
        Console.WriteLine("Посетитель не найден");
    }
    public void status()
    {
        Console.WriteLine($"Количество сотрудников:{Registry.Count()}");
        Console.WriteLine($"Количество посетителей:{Registry.Count()}");
        Console.WriteLine($"Количество животных:{Registry.Count()}");// Здесь будет метод с linq
        Console.WriteLine($"Количество вольеров:{Registry.Count()}");
    }
    

    // public int countObject()
    // {
    //     List<Object> objects = new List<object>();
    //
    //     return objects.OfType<T>().Count();
    // }
}
