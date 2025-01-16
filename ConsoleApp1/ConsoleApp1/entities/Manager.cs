using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.entities
{
     class Manager : IManager
    {
        private List<employee> employees;

        public Manager(List<employee> employees)
        {
            this.employees = employees;
        }

        public int Count()
        {
            return employees.Count(e => e.Gender.ToLower() == "female" && e.CalculateAllowance() == 0);
        }

        public void Delete(int n)
        {
            employees.RemoveAll(e => e.Gender.ToLower() == "male" && e.NumberOfChildren > n);
        }

        public void InputList(int size)
        {
            for (int i = 0; i < size; i++)
            {
                try
                {
                    Console.Write("Enter employee code: ");
                    int code = int.Parse(Console.ReadLine());
                    Console.Write("Enter employee name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter date of birth (yyyy-MM-dd): ");
                    DateTime dob = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter gender: ");
                    string gender = Console.ReadLine();
                    Console.Write("Enter number of children: ");
                    int numChildren = int.Parse(Console.ReadLine());
                    Console.Write("Enter salary: ");
                    double salary = double.Parse(Console.ReadLine());

                    employee emp = new employee(code, name, dob, gender, numChildren, salary);
                    employees.Add(emp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void ShowByName(string name)
        {
            foreach (var employee in employees.Where(e => e.Name.ToLower() == name.ToLower()))
            {
                employee.Show();
            }
        }

        public void ShowList()
        {
            foreach (var employee in employees)
            {
                employee.Show();
            }
        }

        public void ShowSocon(int n)
        {
            foreach (var employee in employees.Where(e => e.NumberOfChildren < n))
            {
                employee.Show();
            }
        }

        public void SortBySalary()
        {
            var sortedList = employees.OrderBy(e => e.Salary).ToList();
            foreach (var employee in sortedList)
            {
                employee.Show();
            }
        }

        public void UpdateSalary()
        {
            foreach (var employee in employees)
            {
                int age = employee.GetAge();
                double newSalary = employee.Salary;

                if (age < 30)
                {
                    newSalary += employee.Salary * 0.05;
                }
                else if (age >= 30 && age < 40)
                {
                    newSalary += employee.Salary * 0.10;
                }
                else
                {
                    newSalary += employee.Salary * 0.15;
                }

                employee.Salary = newSalary;
            }
        }
    }
}
