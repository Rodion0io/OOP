using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ZooSimulation;

class Director
{

    private Zoo zoo;
    private RandomNumberGenerator generator;
    private Timer timer;
    public Director(Zoo zoo, RandomNumberGenerator generator,Timer timer)
    {
        this.zoo = zoo;
        this.generator = generator;
        this.timer = timer;
    }

    public void DisplayEntities<T>(IEnumerable<T> entities, Func<T, string> displayFunc, string entityName)
    {
        Console.WriteLine($"Список {entityName}:");

        foreach (var entity in entities)
        {
            Console.WriteLine(displayFunc(entity));
        }
    }
    
    public void displayAnimals()
    {
        DisplayEntities(zoo.getAnimals(), animal => $"Имя: {animal.name} Вид: {animal.GetType().Name}", "животных");
    }
    
    public void displayEmployees()
    {
        DisplayEntities(zoo.getEmployee(), employee => $"Имя: {employee.name} Пол: {employee.sex}" +
        $" Персональный номер: {employee.id} Должность: {employee.post}" +
        $" Количество закрепленных вольеров: {employee.aviaryList.Count}", "сотрудников");
    }

    public void displayVisitors()
    {
        DisplayEntities(zoo.getVisitors(), visitor => $"Имя: {visitor.name} Пол: {visitor.sex}" +
        $" Номер билета: {visitor.id}  Количество денег:{visitor.money}", "посетителей");
    }

    public void displayAviarys()
    {
        DisplayEntities(zoo.getAviarys(), aviary => $"Номер: {aviary.getAviaryId()}" +
        $" Количество животных:{aviary.getAnimals().Count} Запасы еды: Первый контейнер {aviary.getFirstContainer()}, Второй контейнер {aviary.getSecondContainer()}", "вольер");
    }
    public void EditEntity<T>(List<T> entityList, Predicate<T> predicate, Action<T> editAction, string entityName)
    {
        Console.WriteLine($"Введите данные для редактирования {entityName}:");
        var entityToEdit = entityList.Find(predicate);

        if (entityToEdit != null)
        {
            editAction(entityToEdit);
            Console.WriteLine($"Отредактирован {entityName}: {entityToEdit}");
        }
        else
        {
            Console.WriteLine($"Не найден {entityName}");
        }
    }

    public void attachAviaryToEmployee()
    {
        Console.WriteLine("Введите персональны номер сотрудника:");
        string employeeId = Console.ReadLine();
        Employee employee = zoo.getEmployee().FirstOrDefault(a => a.id == employeeId);
        if (employee != null)
        {
            Console.WriteLine("Введите номер вольера");
            string aviaryId = Console.ReadLine();
            IAviary aviary = zoo.getAviarys().FirstOrDefault(a => a.getAviaryId() == aviaryId);
            if (aviary != null)
            {
                employee.aviaryList.Add(aviary);
            }
            else
            {
                Console.WriteLine("Вольера с таким номером не найдено");
            }
        }
        else
        {
            Console.WriteLine("Сотрудник не найден");
        }
    }

    public void unpinAviary()
    {
        Console.WriteLine("Введите персональны номер сотрудника:");
        string employeeId = Console.ReadLine();
        Employee employee = zoo.getEmployee().FirstOrDefault(a => a.id == employeeId);
        if (employee != null)
        {
            Console.WriteLine("Введите номер вольера");
            string aviaryId = Console.ReadLine();
            IAviary aviary = zoo.getAviarys().FirstOrDefault(a => a.getAviaryId() == aviaryId);
            if (aviary != null)
            {
                employee.aviaryList.Remove(aviary);
            }
            else
            {
                Console.WriteLine("Вольера с таким номером не найдено");
            }
        }
        else
        {
            Console.WriteLine("Сотрудник не найден");
        }
    }
    public void AddAnimal()
    {
        zoo.AddAnimal();
    }

    public void RemoveAnimal()
    {
       zoo.RemoveAnimal();
    }

    public void EditAnimal()
    {
        EditEntity(zoo.getAnimals(),
            animal =>
            {
                Console.WriteLine("Текущее имя животного:");
                string oldName = Console.ReadLine();

                Console.WriteLine("Вид животного:");
                string animalType = Console.ReadLine();

                return animal.name.Equals(oldName, StringComparison.OrdinalIgnoreCase) &&
                animal.GetType().Name.Equals(animalType, StringComparison.OrdinalIgnoreCase);
            },
            animal =>
            {
                Console.WriteLine("Новое имя животного:");
                animal.name = Console.ReadLine();
            },
            "животное");
    }
    public void AddVisitor()
    {
        zoo.AddVisitor();
    }

    public void AddAviary()
    {
        zoo.AddAviary();
        
    }
    public void RemoveAviary() {
           zoo.RemoveAviary();
    }
    public void RemoveVisitor()
    {
      zoo.RemoveVisitor();
    }

    public void EditVisitor()
    {
        EditEntity(zoo.getVisitors(),
            visitor =>
            {
                Console.WriteLine("Введите номер билета посетителя : ");
                string visitorId = Console.ReadLine();

                return visitor.name.Equals(visitorId, StringComparison.OrdinalIgnoreCase);
            },
            visitor =>
            {
                Console.WriteLine("Новое имя посетителя:");
                visitor.name = Console.ReadLine();

                Console.WriteLine("Новый пол посетителя:");
                string visitorSex = Console.ReadLine();
                Humans.Gender sex;
                if(Enum.TryParse(visitorSex,out sex))
                {
                    visitor.sex = sex;
                }
                else
                {
                    Console.WriteLine("Неверное значения пола, установлено значение по умолчанию");
                    visitor.sex = Visitors.Gender.Male;
                }
            },
            "посетитель");
    }

    public void AddEmployee()
    {
        zoo.AddEmployee();
    }

    public void RemoveEmployee()
    {
        zoo.RemoveEmployee();
    }

    public void EditEmployee()
    {
        EditEntity(zoo.getEmployee(),
            employee =>
            {
                Console.WriteLine("Введите персональный номер сотрудника : ");
                string employeeId = Console.ReadLine();

                return employee.id.Equals(employeeId, StringComparison.OrdinalIgnoreCase);
            },
            employee =>
            {
                Console.WriteLine("Новое имя сотрудника:");
                employee.name = Console.ReadLine();

                Console.WriteLine("Новый пол сотрудника:");
                
                string employeeSex = Console.ReadLine();
                Humans.Gender sex;
                if(Enum.TryParse(employeeSex,out sex))
                {
                    employee.sex = sex;
                }
                else
                {
                    Console.WriteLine("Вы ввели неверное значение пола, установлено значение по умолчанию");
                    employee.sex = Employee.Gender.Male;
                }

                Console.WriteLine("Новая должность сотрудника:");
                employee.post = Console.ReadLine();

            },
            "сотрудник");
    }

    public void getAnimalStatus()
    {
        Console.WriteLine("Введите имя животного: ");
        string animalName = Console.ReadLine();

        Console.WriteLine("Введите вид животного: ");
        string animalType = Console.ReadLine();

        var animalStatus = zoo.getAnimals().FirstOrDefault(a => a.name == animalName &&
        a.GetType().Name == animalType);

        if (animalStatus != null)
        {
            animalStatus.status();
        }

        else
        {
            Console.WriteLine($"Животное {animalName} не найдено");
        }
    }

    public void Order()
    {
        Console.WriteLine("Введите имя животного");
        string animalName = Console.ReadLine();

        Console.WriteLine("Введите вид животного");
        string animalType = Console.ReadLine();

        var animalVoice = zoo.getAnimals().FirstOrDefault(a => a.name == animalName &&
        a.GetType().Name == animalType);

        if (animalVoice != null)
        {
            animalVoice.voiceCommand();
        }

        else
        {
            Console.WriteLine($"Животное {animalName} не найдено");
        }
    }



    public void getVisitorStatus()
    {
       Console.WriteLine("Введите номер билета посетителя : ");
        string visitorId = Console.ReadLine();
        var visitorToGetStatus = zoo.getVisitors().FirstOrDefault(a => a.id == visitorId);

        if (visitorToGetStatus != null)
        {
            visitorToGetStatus.status();
        }

        else
        {
            Console.WriteLine($"Посетитель с билетом {visitorId} не найден");
        }
    }



    public void getEmployeeStatus()
    {
       Console.WriteLine("Введите персональный номер сотрудника : ");
        string employeeId = Console.ReadLine();

        var employeeToGetStatus = zoo.getEmployee().FirstOrDefault(a => a.id == employeeId);

        if (employeeToGetStatus != null)
        {
            employeeToGetStatus.status();
        }

        else
        {
            Console.WriteLine($"Сотрудник с номером {employeeId} не найден");
        }

    }

    public void getAviaryStatus()
    {
        Console.WriteLine("Введите номер вольера:");
        string aviaryNum = Console.ReadLine();
        var aviaryToGetStatus = zoo.getAviarys().FirstOrDefault(a => a.getAviaryId() == aviaryNum);
        if(aviaryToGetStatus != null)
        {
            aviaryToGetStatus.getStatus();
        }
        else
        {
            Console.WriteLine($"Вольер с номером {aviaryNum} не найден");
        }
    }

    public void resettleAnimal()
    {
        Animals animal;
        Console.WriteLine("Имя животного:");
        string animalName = Console.ReadLine();

        Console.WriteLine("Вид животного:");
        string animalType = Console.ReadLine();

        var animalToResettle = zoo.getAnimals().FirstOrDefault(a => a.name == animalName &&
        a.GetType().Name == animalType);

        if (animalToResettle != null)
        {
            Console.WriteLine("Введите номер вольера:");
            string aviaryId = Console.ReadLine();
            var newAnimalAviary = zoo.getAviarys().FirstOrDefault(a=>a.getAviaryId() == aviaryId);

            if (newAnimalAviary != null)
            {
                animalToResettle.aviary.removeAnimal(animalToResettle);
                newAnimalAviary.addAnimal(animalToResettle);

            }
            else
            {
                Console.WriteLine("Вольер с таким номером не найден");
            }
        }

        Console.WriteLine("Животное не найдено");
    }

    public void getZooStatus()
    {
        zoo.status();
    }
    public void onPause()
    {
        timer.pause();
    }

    public void unPause()
    {
        timer.unpause();
    }
    
}
