using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.entities
{
    public  class employee
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int NumberOfChildren { get; set; }
        public double Salary { get; set; }

        public employee() { }


        public employee(int code, string name, DateTime dateOfBirth, string gender, int numberOfChildren, double salary)
        {
            Code = code;
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            NumberOfChildren = numberOfChildren;
            Salary = salary;
        }

        public double CalculateAllowance()
        {
            if (NumberOfChildren == 0)
            {
                return 0;
            }
            else if (NumberOfChildren <= 2)
            {
                return 1000000; // ho tro 1 trieu
            }
            else
            {
                return 1500000; // ho tro trieu ruoi
            }
        }

        public double CalculateIncome()
        {
            return Salary + CalculateAllowance();
        }

        // Method to display employee details
        public void Show()
        {
            Console.WriteLine($"Code: {Code}, Name: {Name}, Date of Birth: {DateOfBirth.ToShortDateString()}, Gender: {Gender}, " +
                              $"Children: {NumberOfChildren}, Salary: {Salary}, Income: {CalculateIncome()}");
        }

        public int GetAge()
        {
            var today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

    }
}
