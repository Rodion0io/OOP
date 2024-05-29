using System;
using System.Collections.Generic;
using System.Timers;


namespace ZooSimulation
{
    internal class Menu
    {
        static void Main(string[] args)
        {
            RandomNumberGenerator generator = new RandomNumberGenerator();
            Zoo zoo = new Zoo();
            Timer timer = new Timer(zoo);
            Director user = new Director(zoo,generator,timer);
       
            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Отобразить список животных");
                Console.WriteLine("2. Отобразить список сотрудников");
                Console.WriteLine("3. Отобразить список посетителей");
                Console.WriteLine("4. Добавить животное");
                Console.WriteLine("5. Редактировать животное");
                Console.WriteLine("6. Удалить животное");
                Console.WriteLine("7. Добавить Сотрудника");
                Console.WriteLine("8. Редактировать Сотрудника");
                Console.WriteLine("9. Удалить Сотрудника");
                Console.WriteLine("10. Добавить Посетителя");
                Console.WriteLine("11. Редактировать Посетителя");
                Console.WriteLine("12. Удалить Посетителя");
                Console.WriteLine("13. Команда голос");
                Console.WriteLine("14. Узнать статус животного");
                Console.WriteLine("15. Узнать статус сотрудника");
                Console.WriteLine("16. Узнать статус посетителя");
                Console.WriteLine("17. Узнать статус зоопарка");
                Console.WriteLine("18. Прикрепить сотрудника к вольеру");
                Console.WriteLine("19. Открепить сотрудника");
                Console.WriteLine("20. Пауза");
                Console.WriteLine("21. Снять паузу");
                Console.WriteLine("22. Добавить вольер");
                Console.WriteLine("23. Удалить вольер");
                Console.WriteLine("24. Узнать статус вольера");
                Console.WriteLine("25. Узнать список вольеров");
                Console.WriteLine("26. Переселить животное");
                Console.WriteLine("27. Выйти из меню");
                Console.Write("Введите номер действия: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        user.displayAnimals();
                        break;

                    case "2":
                        user.displayEmployees();
                        break;

                    case "3":
                        user.displayVisitors();
                        break;
                    case "4":
                        user.AddAnimal();
                        break;
                    case "5":
                        user.EditAnimal();
                        break;
                    case "6":
                        user.RemoveAnimal();
                        break;
                    case "7":
                        user.AddEmployee();
                        break;
                    case "8":
                        user.EditEmployee();
                        break;
                    case "9":
                        user.RemoveEmployee();
                        break;
                    case "10":
                        user.AddVisitor();
                        break;
                    case "11":
                        user.EditVisitor();
                        break;
                    case "12":
                        user.RemoveVisitor();
                        break;
                    case "13":
                        user.Order();
                        break;
                    case "14":
                        user.getAnimalStatus();
                        break;
                    case "15":
                        user.getEmployeeStatus();
                        break;
                    case "16":
                        user.getVisitorStatus();
                        break;
                    case "17":
                        user.getZooStatus();
                        break;
                    case "18":
                        user.attachAviaryToEmployee();
                        break;
                    case "19":
                        user.unpinAviary();
                        break;
                    case "20":
                        user.onPause();
                        break;
                    case "21":
                        user.unPause();
                        break;
                    case "22":
                        user.AddAviary();
                        break;
                    case "23":
                        user.RemoveAviary();
                        break;
                    case "24":
                        user.getAviaryStatus();
                        break;
                    case "25":
                        user.displayAviarys();
                        break;
                    case "26":
                        user.resettleAnimal();
                        break;
                    case "27":
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 1 до 27.");
                        break;
                }
            }
        }
    }
}