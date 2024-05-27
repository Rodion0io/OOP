namespace ConsoleApp1;

class Director
{

    private Zoo zoo;
    private Randomizer generator;
    private Timee animalsStarving;
    private IOperationsAviary OperationsAviary;
    private IOperationsAviary firstAviary;
    private IOperationsAviary secondAviary;
    private IOperationsAviary thirdAviary;
    public Director(Zoo zoo, Randomizer generator)
    {
        this.zoo = zoo;
        this.generator = generator;
        animalsStarving = new Timee(zoo);
        OperationsAviary = new Aviary(0,zoo);
        firstAviary = new Aviary(1,zoo);
        secondAviary = new Aviary(2,zoo);
        thirdAviary = new Aviary(3,zoo);
    }

    public void DisplayEntities<T>(IEnumerable<T> entities, Func<T, string> displayFunc, string entityName)
    {
        Console.WriteLine($"List {entityName}:");

        foreach (var entity in entities)
        {
            Console.WriteLine(displayFunc(entity));
        }
    }

    public void AddEntity<T>(List<T> entityList, Func<T> createEntity, string entityName)
    {
        Console.WriteLine($"Enter the data to add a new one {entityName}:");
        var newEntity = createEntity();

        entityList.Add(newEntity);
        Console.WriteLine($"Add new class object {entityName}: {newEntity}");
    }

    public void RemoveEntity<T>(List<T> entityList, Predicate<T> predicate, string entityName)
    {
        Console.WriteLine($"Enter the data to delete {entityName}:");
        var entityToRemove = entityList.Find(predicate);

        if (entityToRemove != null)
        {
            entityList.Remove(entityToRemove);
            Console.WriteLine($"Delete {entityName}: {entityToRemove}");
        }
        else
        {
            Console.WriteLine($"Not found {entityName}");
        }
    }

    public void EditEntity<T>(List<T> entityList, Predicate<T> predicate, Action<T> editAction, string entityName)
    {
        Console.WriteLine($"Enter the data to redact {entityName}:");
        var entityToEdit = entityList.Find(predicate);

        if (entityToEdit != null)
        {
            editAction(entityToEdit);
            Console.WriteLine($"Redacted {entityName}: {entityToEdit}");
        }
        else
        {
            Console.WriteLine($"Not found {entityName}");
        }
    }

    public void AddAnimal()
    {
        AddEntity(zoo.ListAnimals, () =>
        {
            Console.WriteLine("Animal name:");
            string animalName = Console.ReadLine();

            Console.WriteLine("Animal type (Cat, Penguin, kapibara):");
            string animalType = Console.ReadLine();

            switch (animalType.ToLower())
            {
                case "cat": return new Cat(animalName);
                case "penguin": return new Penguin(animalName);
                case "kapibara": return new Kapibara(animalName);
                default: throw new ArgumentException("Error");
            }
        }, "animal");
    }

    public void AddAnimalInAviary()
    {
        Console.WriteLine("Enter name: ");
        string animalName = Console.ReadLine();
        
        Console.WriteLine("Animal type (Cat, Penguin, kapibara):");
        string animalType = Console.ReadLine();
        
        Console.WriteLine("Enter the aviary number");
        int aviaryNumber = int.Parse(Console.ReadLine());
        
        var avia = zoo.ListAviary.FirstOrDefault(a => a.GetNumberAviary() == aviaryNumber);

        if (avia != null)
        {
            switch (animalType.ToLower())
            {
                case "cat":
                    avia.AddAnimal(new Cat(animalName));
                    break;
                case "penguin":
                    avia.AddAnimal(new Penguin(animalName));
                    break;
                case "kapibara":
                    avia.AddAnimal(new Kapibara(animalName));
                    break;
                default:
                    throw new ArgumentException("Error");
                    
            }
        }
    }

    public void RemoveAnimalWithDelete()
    {
        Console.WriteLine("Enter name: ");
        string nameAnimal = Console.ReadLine();
        
        Console.WriteLine("Enter type animal: ");
        string typeAnimal = Console.ReadLine();

        var animal = zoo.ListAnimals.FirstOrDefault(a => a.name == nameAnimal && a.GetType().Name == typeAnimal);

        if (animal != null)
        {
            firstAviary.DeleteAnimal(animal);
            Console.WriteLine("Animal delete");
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }

    public void EditAnimal()
    {
        EditEntity(zoo.ListAnimals,
            animal =>
            {
                Console.WriteLine("Current animal name:");
                string oldName = Console.ReadLine();

                Console.WriteLine("animal type:");
                string animalType = Console.ReadLine();

                return animal.name.Equals(oldName, StringComparison.OrdinalIgnoreCase) &&
                animal.GetType().Name.Equals(animalType, StringComparison.OrdinalIgnoreCase);
            },
            animal =>
            {
                Console.WriteLine("new animal name:");
                animal.name = Console.ReadLine();
            },
            "animal");
    }
    public void AddVisitor()
    {
        AddEntity(zoo.ListVisitors, () =>
        {
            Console.WriteLine("visitor name:");
            string visitorName = Console.ReadLine();

            Console.WriteLine("visiter gender:");
            string visitorGender = Console.ReadLine();
            Visitor.Gender gender;
            if(Enum.TryParse(visitorGender, out gender))
            {
                return new Visitor(visitorName, gender, (zoo.ListVisitors.Count() + generator.RandomValue(1, 100)).ToString());
            }
            else
            {
                Console.WriteLine("Error");
                return new Visitor(visitorName, Visitor.Gender.Male, (zoo.ListVisitors.Count() + generator.RandomValue(1, 100)).ToString());
            }

        }, "visitor");
    }

    public void RemoveVisitor()
    {
        RemoveEntity(zoo.ListVisitors,
            visitor =>
            {
                Console.WriteLine("Enter ticket number : ");
                string visitorId = Console.ReadLine();
                return visitor.name.Equals(visitorId, StringComparison.OrdinalIgnoreCase);
            },
            "visitor");
    }

    public void EditVisitor()
    {
        EditEntity(zoo.ListVisitors,
            visitor =>
            {
                Console.WriteLine("Enter ticket number : ");
                string visitorId = Console.ReadLine();

                return visitor.name.Equals(visitorId, StringComparison.OrdinalIgnoreCase);
            },
            visitor =>
            {
                Console.WriteLine("New name visiter:");
                string newName = Console.ReadLine();
                visitor.changeName(newName);

                Console.WriteLine("New gender visiter:");
                string visitorGender = Console.ReadLine();
                Visitor.Gender gender;
                visitor.changeGender(visitorGender);
            },
            "visiter");
    }

    public void AddEmployee()
    {
        AddEntity(zoo.ListEmployees, () =>
        {
            Console.WriteLine("Employee name:");
            string employeeName = Console.ReadLine();

            Console.WriteLine("Employee post:");
            string employeePosition = Console.ReadLine();

            Console.WriteLine("Employee gender:");
            string employeeGender = Console.ReadLine();
            Employee.Gender gender;
            if(Enum.TryParse(employeeGender,out gender))
            {
                return new Employee(employeeName, gender, generator.RandomValue(1, 100).ToString(), employeePosition);
            }
            else
            {
                Console.WriteLine("Error");
                return new Employee(employeeName,Employee.Gender.Male, generator.RandomValue(1, 100).ToString(), employeePosition);
            }
        }, "Employee");
    }

    public void RemoveEmployee()
    {
        RemoveEntity(zoo.ListEmployees,
            employee =>
            {
                Console.WriteLine("Endter personal number Employee : ");
                string employeeId = Console.ReadLine();

                return employee.id.Equals(employeeId, StringComparison.OrdinalIgnoreCase);
            },
            "Employee");
    }

    public void EditEmployee()
    {
        EditEntity(zoo.ListEmployees,
            employee =>
            {
                Console.WriteLine("Endter personal number Employee : ");
                string employeeId = Console.ReadLine();

                return employee.id.Equals(employeeId, StringComparison.OrdinalIgnoreCase);
            },
            employee =>
            {
                Console.WriteLine("new name employee:");
                string name = Console.ReadLine();
                
                employee.changeEmployeeName(name);

                Console.WriteLine("new gender employee:");
                
                string employeeGender = Console.ReadLine();
                Employee.Gender gender;
                
                employee.changeEmployeeGender(employeeGender);

                Console.WriteLine("new post employeeа:");
                employee.post = Console.ReadLine();

            },
            "employee");
    }

    public void getAnimalStatus()
    {
        Console.WriteLine("Enter animal name: ");
        string animalName = Console.ReadLine();

        Console.WriteLine("Enter animal type: ");
        string animalType = Console.ReadLine();

        var animalStatus = zoo.ListAnimals.FirstOrDefault(a => a.name == animalName && a.GetType().Name == animalType);

        if (animalStatus != null)
        {
            animalStatus.status();
        }

        else
        {
            Console.WriteLine("Error");
        }
    }

    public void Voice()
    {
        Console.WriteLine("Enter animal name");
        string animalName = Console.ReadLine();

        Console.WriteLine("Enter animal type:");
        string animalType = Console.ReadLine();

        var animalVoice = zoo.ListAnimals.FirstOrDefault(a => a.name == animalName && a.GetType().Name == animalType);

        if (animalVoice != null)
        {
            animalVoice.voiceCommand();
        }

        else
        {
            Console.WriteLine("Error");
        }
    }

    public void getVisitorStatus()
    {
       Console.WriteLine("Enter number ticket : ");
        string visitorId = Console.ReadLine();
        var visitorToGetStatus = zoo.ListVisitors.FirstOrDefault(a => a.id == visitorId);

        if (visitorToGetStatus != null)
        {
            visitorToGetStatus.status();
        }

        else
        {
            Console.WriteLine("Error");
        }
    }
    
    public void getEmployeeStatus()
    {
       Console.WriteLine("Enter personal number employee: ");
        string employeeId = Console.ReadLine();

        var employeeToGetStatus = zoo.ListEmployees.FirstOrDefault(a => a.id == employeeId);

        if (employeeToGetStatus != null)
        {
            employeeToGetStatus.status();
        }

        else
        {
            Console.WriteLine("Error");
        }

    }
    public void getZooStatus()
    {
        zoo.status();
    }

    public void attachAnimal()
    {
        Console.WriteLine("Enter personal number employee. You can see in status employee: ");
        string employeeId = Console.ReadLine();

        var employeeToAttach = zoo.ListEmployees.FirstOrDefault(a => a.id == employeeId);
        if (employeeToAttach != null)
        {
            int aviaryId = int.Parse(Console.ReadLine());
            var av = zoo.ListAviary.FirstOrDefault(a => a.GetNumberAviary() == aviaryId);
            if (av != null)
            {
                Console.WriteLine($"{employeeToAttach.aviaryList.Count}");
                employeeToAttach.AddAviary(av);
                av.chagedAttached();
                Console.WriteLine("The animal is attached");
            }
            else
            {
                Console.WriteLine("The animal was not found");
            }
        }
        else
        {
            Console.WriteLine("The employee was not found");
        }
    }
    
    public void unpinAnimal()
    {
        Console.WriteLine("Enter personal number employee. You can see in status employee: ");
        string employeeId = Console.ReadLine();

        var employeeToAttach = zoo.ListEmployees.FirstOrDefault(a => a.id == employeeId);
        if (employeeToAttach != null)
        {
            Console.WriteLine("Enter the number of the aviary you want to unattach: ");
            int aviaryId = int.Parse(Console.ReadLine());
            var av = zoo.ListAviary.FirstOrDefault(a => a.GetNumberAviary() == aviaryId);
            if (av != null)
            {
                employeeToAttach.aviaryList.Remove(av);
                av.chagedAttached();
                Console.WriteLine("The animal is detached");
            }
            else { Console.WriteLine("The animal was not found"); }
        }
        else { Console.WriteLine("The employee was not found"); }
    }

    public void StartTimer()
    {
        animalsStarving.StartTime();
        Console.WriteLine("Time has started");
    }
    
    public void StopTimer()
    {
        animalsStarving.StopTime();
        Console.WriteLine("Time has stopped");
    }

    public void GenerateFirstAnimal()
    {
        string[] animalNames = new string[] { "Pingu", "Pippa", "Penguin", "Percy", "Pip", "Capy", "Cara", "Casper", "Camilla",
            "Whiskers", "Mittens", "Simba", "Leo", "Cleo", "Misty", "Felix", "Oliver", "Shadow", "Smokey", "Luna"};

        int counter = 1;
        
        
        zoo.ListAviary.Add(firstAviary);
        zoo.ListAviary.Add(secondAviary);
        zoo.ListAviary.Add(thirdAviary);
        
        firstAviary.AddAnimal(new Cat("name"));

        while (counter != 20)
        {
            string generateName = animalNames[generator.RandomNameNumber()];
            int typeAnimal = generator.RandomTypeAnimal();
        
            if (typeAnimal == 1)
            {
                firstAviary.AddAnimal(new Cat(generateName));
                zoo.ListAnimals.Add(new Cat(generateName));
                counter++;
            }
            else if (typeAnimal == 2)
            {
                secondAviary.AddAnimal(new Penguin(generateName));
                zoo.ListAnimals.Add(new Penguin(generateName));
                counter++;
            }
            else if (typeAnimal == 3)
            {
                thirdAviary.AddAnimal(new Kapibara(generateName));
                zoo.ListAnimals.Add(new Kapibara(generateName));
                counter++;
            }
            
        }
    }

    public void ReturnListAviares()
    {
        foreach (var i in zoo.ListAviary)
        {
            Console.WriteLine($"{i.GetNumberAviary()}, {i.GetStatusForLists()}");
        }
    }

    public void AviaryStatus()
    {
        Console.WriteLine("Enter the number aviary. You look in the command show aviaryes");
        int num = int.Parse(Console.ReadLine());

        foreach (var i in zoo.ListAviary)
        {
            if (i.GetNumberAviary() == num)
            {
                i.GetStatusForLists();
                break;
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
    }

    public void NewAviary()
    {
        int generateNumber = generator.RandovNumberForAviary();
        zoo.ListAviary.Add(new Aviary(generateNumber, zoo));
        Console.WriteLine("Add aviary");
    }
}

