using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using ZooSimulation;

public class Zoo
{
    public List<Entity> Registry;
    private RandomNumberGenerator generator;
    public Zoo()
    {
        generator = new RandomNumberGenerator();
        Registry = new List<Entity>();
        createZoo();
    }

    private void createZoo()
    {
        Random random = new Random();
        Aviary newAviary = new Aviary();
        Registry.Add(newAviary);

        List<string> types = new List<string> { "Kapibara","Cat","Penguin" };
        List<string> animalNames = new List<string>
        {
            "Max", "Charlie", "Buddy", "Daisy", "Molly",
            "Jack", "Sadie", "Bear", "Lucky", "Oliver",
            "Bella", "Lucy", "Luna", "Duke", "Zoe",
            "Cooper", "Stella", "Milo", "Bailey", "Lola",
            "Sophia", "Pepper", "Sandy", "Roxy", "Casey",
            "Ruby", "Bentley", "Baxter", "Ginger", "Rusty",
            "Boots", "Roscoe", "Moose", "Blue", "Lucky",
            "Bella", "Luna", "Daisy", "Molly", "Lucy",
        };

        for (int i = 0; i < 15 ; i++)
        {
            Animals animal = null;
            string animalName = animalNames[random.Next(animalNames.Count)];
            string animalType = types[random.Next(types.Count)];

            if (animalType == "Kapibara")
            {
                animal = new Kapibara(animalName);
            }

            if (animalType == "Cat")
            {
                animal = new Cat(animalName);
            }

            if (animalType == "Penguin")
            {
                animal = new Penguin(animalName);
            }
            attachAnimalToAviary(animal);

        }
    }

    public void addEntity(Entity value)
    {
        Registry.Add(value);
    }

    public void removeEntity(Entity value)
    {
        Registry.Remove(value);
    }

    private void attachAnimalToAviary(Animals animal)
    {
        foreach (var entity in Registry)
        {
            if (entity is IAviary aviary && aviary.GetType().Name == "Aviary")
            {
                if (aviary.available(animal))
                {
                    aviary.addAnimal(animal);
                    Registry.Add(animal);
                    break;
                }
            }
        }

        if (animal.aviary == null)
        {
            IAviary aviaryForNew = new Aviary();
            Registry.Add(aviaryForNew as Entity);
            Registry.Add(animal);
            aviaryForNew.addAnimal(animal);
        }
    }

    public void AddAnimal()
    {
        Console.WriteLine("Кличка животного:");
        string animalName = Console.ReadLine();

        Console.WriteLine("Вид животного (Kapibara/Cat/Penguin):");
        string animalType = Console.ReadLine();
        Animals newAnimal;
        switch (animalType.ToLower())
        {
            case "kapibara":
                newAnimal = new Kapibara(animalName);
                Registry.Add(newAnimal);
                attachAnimalToAviary(newAnimal);

                break;
            case "cat":
                newAnimal = new Cat(animalName);
                Registry.Add(newAnimal);
                attachAnimalToAviary(newAnimal);
                break;
            case "Penguin":
                newAnimal = new Penguin(animalName);
                Registry.Add(newAnimal);
                attachAnimalToAviary(newAnimal);
                break;
            default: throw new ArgumentException("Неизвестный вид");
        }
    }
    public void RemoveAnimal()
    {
        Animals animal;
        Console.WriteLine("Введите идентификатор:");
        Guid identifikator = Guid.Parse(Console.ReadLine());

        var deleteAniaml = Registry.OfType<Animals>().FirstOrDefault(a => a.getId() == identifikator);

        if (deleteAniaml != null)
        {
            Registry.Remove(deleteAniaml);
            Console.WriteLine("Животное удалено!");
            return;
        }
        else
        {
            Console.WriteLine("Такого животного нет!");
        }
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
        Console.WriteLine("Введите номер вольера : ");
        Guid aviaryNum = Guid.Parse(Console.ReadLine());
        var deleteAviary = Registry.OfType<IAviary>().FirstOrDefault(a => a.getAviaryId() == aviaryNum);

        if (deleteAviary != null)
        {
            var deleteAnimal = deleteAviary.getAnimals();

            Registry.Remove(deleteAviary as Entity);

            foreach (var animal in deleteAnimal)
            {
                Registry.Remove(animal);
            }
        }
        else
        {
            Console.WriteLine("Такого вальера нет!");
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
        Humans.Gender gender;
        if (Enum.TryParse(employeeSex, out gender))
        {
            employee = new Employee(employeeName, gender, employeePosition);
            Registry.Add(employee);
        }
        else
        {
            Console.WriteLine("Неверное значение пола, установлено значение по умолчанию");
            employee = new Employee(employeeName, Employee.Gender.Male, employeePosition);
            Registry.Add(employee);
        }
    }

    public void RemoveEmployee()
    {
        Console.WriteLine("Введите персональный номер сотрудника : ");
        Guid employeeId = Guid.Parse(Console.ReadLine());

        var deleteEmployee = Registry.OfType<Employee>().FirstOrDefault(a => a.getId() == employeeId);

        if (deleteEmployee != null)
        {
            Registry.Remove(deleteEmployee);
            Console.WriteLine("Сотрудник удален");
            return;
        }
        else
        {
            Console.WriteLine("Такого сотрудника нет!");
        }

        // foreach (Employee employees in Registry)
        // {
        //     if (employees.id == employeeId)
        //     {
        //         Registry.Remove(employees);
        //         return;
        //     }
        // }
        // Console.WriteLine("Сотрудник не найден");
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
        Visitors.Gender gender;
        if (Enum.TryParse(visitorSex, out gender))
        {
            visitor = new Visitors(visitorName, gender, int.Parse(visitorMoney));
            Registry.Add(visitor);
        }
        else
        {
            Console.WriteLine("Вы ввели несуществующее значение пола , установлено значение по умолчанию");
            visitor = new Visitors(visitorName, Humans.Gender.Male, int.Parse(visitorMoney));
        }
    }

    public void RemoveVisitor()
    {
        Console.WriteLine("Введите номер билета : ");
        Guid visitorId = Guid.Parse(Console.ReadLine());

        var deleteVisitor = Registry.OfType<Visitors>().FirstOrDefault(a => a.getId() == visitorId);

        if (deleteVisitor != null)
        {
            Registry.Remove(deleteVisitor);
            Console.WriteLine("Посетитель удален");
        }
        else
        {
            Console.WriteLine("Посетитель не найден");
        }
    }
    public void status()
    {
        int countEmployee = Registry.OfType<Employee>().Count();
        int countVisitor = Registry.OfType<Visitors>().Count();
        int countAnimal = Registry.OfType<Animals>().Count();
        int countAviary = Registry.OfType<Aviary>().Count();
        
        Console.WriteLine($"Количество сотрудников:{countEmployee}");
        Console.WriteLine($"Количество посетителей:{countVisitor}");
        Console.WriteLine($"Количество животных:{countAnimal}");
        Console.WriteLine($"Количество вольеров:{countAviary}");
    }
}
