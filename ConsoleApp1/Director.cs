namespace ConsoleApp1;

class Director
{

    private Zoo zoo;
    private Randomizer generator;
    public Director(Zoo zoo, Randomizer generator)
    {
        this.zoo = zoo;
        this.generator = generator;
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

    public void RemoveAnimal()
    {
        RemoveEntity(zoo.ListAnimals,
            animal =>
            {
                Console.WriteLine("Animal name:");
                string animalName = Console.ReadLine();

                Console.WriteLine("Animal type:");
                string animalType = Console.ReadLine();

                return animal.name.Equals(animalName, StringComparison.OrdinalIgnoreCase) &&
                animal.GetType().Name.Equals(animalType, StringComparison.OrdinalIgnoreCase);
            },
            "animal");
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
        Console.WriteLine("Enter personal number employee: ");
        string employeeId = Console.ReadLine();

        var employeeToAttach = zoo.ListEmployees.FirstOrDefault(a => a.id == employeeId);
        if (employeeToAttach != null)
        {
            Console.WriteLine("Enter the name of the animal you want to attach: ");
            string animalName = Console.ReadLine();
            Console.WriteLine("Введите тип животного");
            string animalType = Console.ReadLine();
            var animal = zoo.ListAnimals.FirstOrDefault(a => a.name == animalName && a.GetType().Name == animalType);
            if(animal != null && !animal.attached)
            {
                employeeToAttach.animalList.Add(animal);
                animal.changeAttached();
                Console.WriteLine("The animal is attached");
            }
            else { Console.WriteLine("The animal has not been found or it has already been assigned to an employee"); }
        }
        else { Console.WriteLine("The employee was not found"); }
    }
    
    public void unpinAnimal()
    {
        Console.WriteLine("Enter the employee's personal number: ");
        string employeeId = Console.ReadLine();

        var employeeToAttach = zoo.ListEmployees.FirstOrDefault(a => a.id == employeeId);
        if (employeeToAttach != null)
        {
            Console.WriteLine("Enter the name of the animal you want to attach: ");
            string animalName = Console.ReadLine();
            Console.WriteLine("Enter the type of animal");
            string animalType = Console.ReadLine();
            var animal = zoo.ListAnimals.FirstOrDefault(a => a.name == animalName && a.GetType().Name == animalType);
            if (animal != null)
            {
                employeeToAttach.animalList.Remove(animal);
                animal.changeAttached();
                Console.WriteLine("The animal is detached");
            }
            else { Console.WriteLine("The animal was not found"); }
        }
        else { Console.WriteLine("The employee was not found"); }
    }
}