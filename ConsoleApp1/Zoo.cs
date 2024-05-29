using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ZooSimulation;

class Zoo
{
    private List<Animals> Animals;
    private List<Employee> Employees;
    private List<Visitors> Visitors;
    private List<IAviary> Aviarys;
    private RandomNumberGenerator generator;
    private int Id;
    public Zoo()
    {
        Animals = new List<Animals>();
        Employees = new List<Employee>();
        Visitors = new List<Visitors>();
        Aviarys = new List<IAviary>();
        generator = new RandomNumberGenerator();
        createZoo();
        Id = 1;
    }

    private void createZoo()
    {
        Random random = new Random();
        Aviary newAviary = new Aviary((Aviarys.Count() + generator.GenerateRandomNumber(1, 50)).ToString());
        Aviarys.Add(newAviary);

        List<string> types = new List<string> { "Monkey","Tiger","Bear" };
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

            if (animalType == "Tiger")
            {
                animal = new Tiger(animalName);
            }

            if (animalType == "Bear")
            {
                animal = new Bear(animalName);
            }
            attachAnimalToAviary(animal, (Aviarys.Count() +
                    generator.GenerateRandomNumber(1, 50)).ToString());

        }
        

    }

    private void attachAnimalToAviary(Animals animal, string aviaryId)
    {
        foreach (var aviary in Aviarys)
        {
            if (aviary.available(animal))
            {
                aviary.addAnimal(animal);
                Animals.Add(animal);
                break;
            }
        }

        if (animal.aviary == null)
        {
            IAviary aviaryForNew = new Aviary(aviaryId);
            Aviarys.Add(aviaryForNew);
            Animals.Add(animal);
            aviaryForNew.addAnimal(animal);
        }

    }

    public void AddAnimal()
    {
        Console.WriteLine("Кличка животного:");
        string animalName = Console.ReadLine();

        Console.WriteLine("Вид животного (Monkey/Tiger/Bear):");
        string animalType = Console.ReadLine();
        Animals newAnimal;
        switch (animalType.ToLower())
        {
            case "monkey":
                newAnimal = new Monkey(animalName);
                Animals.Add(newAnimal);
                attachAnimalToAviary(newAnimal,(Aviarys.Count() +
                generator.GenerateRandomNumber(1, 50)).ToString());

                break;
            case "tiger":
                newAnimal = new Tiger(animalName);
                Animals.Add(newAnimal);
                attachAnimalToAviary(newAnimal, (Aviarys.Count() +
               generator.GenerateRandomNumber(1, 50)).ToString());
                break;
            case "bear":
                newAnimal = new Bear(animalName);
                Animals.Add(newAnimal);
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

        foreach (Animals animals in Animals)
        {
            if (animalName == animals.name && animalType == animals.GetType().Name)
            {
                Animals.Remove(animals);
                return;
            }
        }

        Console.WriteLine("Животное не найдено");
    }
    public void AddAviary()
    {
        IAviary aviary;
        Console.WriteLine("Введите номер вольера:");
        string aviaryNum = Console.ReadLine();

        foreach (Aviary aviarys in Aviarys)
        {
            if (aviaryNum == aviarys.aviaryId)
            {
                Console.WriteLine("Вольер с таким номером уже существует");
                return;
            }
        }
        aviary = new Aviary(aviaryNum);

    }

    public void RemoveAviary()
    {

        IAviary aviary;
        Console.WriteLine("Введите номер вольера : ");
        string aviaryNum = Console.ReadLine();
        List<Animals> animalsToDelete = new List<Animals>();
        foreach (IAviary aviarys in Aviarys)
        {
            if (aviarys.getAviaryId() == aviaryNum)
            {
                animalsToDelete = aviarys.getAnimals();
                Aviarys.Remove(aviarys);

                for (int i = 0; i < animalsToDelete.Count; i++)
                {

                    Animals.RemoveAll(a => a == animalsToDelete[i]);
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
            Employees.Add(employee);
        }
        else
        {
            Console.WriteLine("Неверное значение пола, установлено значение по умолчанию");
            employee = new Employee(employeeName, Employee.Gender.Male, generator.GenerateRandomNumber(1, 100).ToString(), employeePosition);
            Employees.Add(employee);
        }
    }

    public void RemoveEmployee()
    {
        Console.WriteLine("Введите персональный номер сотрудника : ");
        string employeeId = Console.ReadLine();

        foreach (Employee employees in Employees)
        {
            if (employees.id == employeeId)
            {
                Employees.Remove(employees);
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
            Visitors.Add(visitor);
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
        string visitorId = Console.ReadLine();
        foreach (Visitors visitors in Visitors)
        {
            if (visitors.id == visitorId)
            {
                Visitors.Remove(visitors);
                return;
            }
        }
        Console.WriteLine("Посетитель не найден");
    }
    public void status()
    {
        Console.WriteLine($"Количество сотрудников:{Employees.Count()}");
        Console.WriteLine($"Количество посетителей:{Visitors.Count()}");
        Console.WriteLine($"Количество животных:{Animals.Count()}");
        Console.WriteLine($"Количество вольеров:{Aviarys.Count()}");
    }

    public List<Visitors> getVisitors()
    {
        return Visitors;
    }

    public List<Animals> getAnimals()
    {
        return Animals;
    }

    public List<Employee> getEmployee()
    {
        return Employees;
    }

    public List<IAviary>getAviarys()
    {
        return Aviarys;
    }
}
