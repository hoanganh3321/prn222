using ConsoleApp1.entities;

namespace ConsoleApp1
{
    internal class Program
    {
        private employee ee = new();

        static void Main(string[] args)
        {

            List<employee> employees = new List<employee>
        {
            new employee(1, "John", new DateTime(1985, 6, 15), "Male", 2, 5000000),
            new employee(2, "Alice", new DateTime(1990, 8, 22), "Female", 0, 4500000),
            new employee(3, "Bob", new DateTime(1982, 3, 11), "Male", 3, 6000000),
            new employee(4, "Eve", new DateTime(1975, 10, 30), "Female", 1, 7000000),
            new employee(5, "Charlie", new DateTime(1995, 12, 5), "Male", 0, 3500000)
        };

            Manager manager = new Manager(employees);
            int choice;
            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Enter employee list");
                Console.WriteLine("2. Show employee list");
                Console.WriteLine("3. Count female employees without allowances");
                Console.WriteLine("4. Show employees with children < n");
                Console.WriteLine("5. Sort male employees by salary");
                Console.WriteLine("6. Remove male employees with more than n children");
                Console.WriteLine("7. Show employees by name");
                Console.WriteLine("8. Update salary");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");
                choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter number of employees to input: ");
                            int size = int.Parse(Console.ReadLine());
                            manager.InputList(size);
                            break;
                        case 2:
                            manager.ShowList();
                            break;
                        case 3:
                            Console.WriteLine($"Female employees with no allowances: {manager.Count()}");
                            break;
                        case 4:
                            Console.Write("Enter maximum number of children: ");
                            int n = int.Parse(Console.ReadLine());
                            manager.ShowSocon(n);
                            break;
                        case 5:
                            manager.SortBySalary();
                            break;
                        case 6:
                            Console.Write("Enter number of children to filter by: ");
                            int deleteN = int.Parse(Console.ReadLine());
                            manager.Delete(deleteN);
                            break;
                        case 7:
                            Console.Write("Enter employee name: ");
                            string name = Console.ReadLine();
                            manager.ShowByName(name);
                            break;
                        case 8:
                            manager.UpdateSalary();
                            Console.WriteLine("Salaries updated.");
                            break;
                        case 9:
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } while (choice != 9);

        }

    }

}

