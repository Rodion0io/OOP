using System;
using System.Collections.Generic;
using System.Timers;
using ConsoleApp1;


namespace ZooSimulation
{
    internal class Maine
    {
        static void Main(string[] args)
        {
            Randomizer generator = new Randomizer();
            Zoo zoo = new Zoo();
            Director direct = new Director(zoo, generator);
            
            direct.GenerateFirstAnimal();

            while (true)
            {
                Console.WriteLine("\nChoose action:");
                Console.WriteLine("1. Display a list of animals");
                Console.WriteLine("2. Display a list of employee");
                Console.WriteLine("3. Display a list of visitor");
                Console.WriteLine("4. Add animal");
                Console.WriteLine("5. Redact animal");
                Console.WriteLine("6. Delete animal");
                Console.WriteLine("7. Add employee");
                Console.WriteLine("8. Redact employee");
                Console.WriteLine("9. Delete employee");
                Console.WriteLine("10. Add visiter");
                Console.WriteLine("11. Redact visiter");
                Console.WriteLine("12. Delete visiter");
                Console.WriteLine("13. Voice");
                Console.WriteLine("14. Animal status");
                Console.WriteLine("15. Employee status");
                Console.WriteLine("16. Visiter status");
                Console.WriteLine("17. Zoo status");
                Console.WriteLine("18. Fix aviary to employee");
                Console.WriteLine("19. Unpin animal");
                Console.WriteLine("20. Start timer");
                Console.WriteLine("21. Stop timer");
                Console.WriteLine("22. Show aviaryes");
                Console.WriteLine("23. Aviary status");
                Console.WriteLine("24. New aviary");
                Console.WriteLine("25. Add animal in aviary");
                Console.WriteLine("26. exit\n");

                Console.Write("Enter action: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        direct.DisplayEntities(zoo.ListAnimals,animal=>$"Name: {animal.name} Type: {animal.GetType().Name}","animal");
                        break;

                    case "2":
                        direct.DisplayEntities(zoo.ListEmployees, employee => $"Name: {employee.name} Gender: {employee.gender}" +
                        $" Personal number: {employee.id} post: {employee.post}" +
                        $" fix aviary: {employee.aviaryList}", "employees");
                        break;

                    case "3":
                        direct.DisplayEntities(zoo.ListVisitors, visitor => $"Name: {visitor.name} gender: {visitor.gender}" +
                                                                        $" number ticket: {visitor.id}", "visiters");
                        break;
                    case "4":
                        direct.AddAnimal();
                        break;
                    case "5":
                        direct.EditAnimal();
                        break;
                    case "6":
                        direct.RemoveAnimalWithDelete();
                        break;
                    case "7":
                        direct.AddEmployee();
                        break;
                    case "8":
                        direct.EditEmployee();
                        break;
                    case "9":
                        direct.RemoveEmployee();
                        break;
                    case "10":
                        direct.AddVisitor();
                        break;
                    case "11":
                        direct.EditVisitor();
                        break;
                    case "12":
                        direct.RemoveVisitor();
                        break;
                    case "13":
                        direct.Voice();
                        break;
                    case "14":
                        direct.getAnimalStatus();
                        break;
                    case "15":
                        direct.getEmployeeStatus();
                        break;
                    case "16":
                        direct.getVisitorStatus();
                        break;
                    case "17":
                        direct.getZooStatus();
                        break;
                    case "18":
                        direct.attachAnimal();
                        break;
                    case "19":
                        direct.unpinAnimal();
                        break;
                    case "20":
                        direct.StartTimer();
                        break;
                    case "21":
                        direct.StopTimer();
                        break;
                    case "22":
                        direct.ReturnListAviares();
                        break;
                    case "23":
                        direct.AviaryStatus();
                        break;
                    case "24":
                        direct.NewAviary();
                        break;
                    case "25":
                        direct.AddAnimalInAviary();
                        break;
                    case "26":
                        return;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }
    }
}