using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"Sum of numbers: {numbers.Sum()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($"Average of numbers: {numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("Ascending order:");
            numbers.OrderBy(x => x)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            //TODO: Order numbers in descending order and print to the console
            Console.WriteLine("Descending order:");
            numbers.OrderByDescending(x => x)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Numbers greater than 6:");
            var greaterThanSixList = numbers.Where(x => x > 6);
            foreach (int x in greaterThanSixList)
            {
                Console.WriteLine(x);
            }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Print 4 numbers:");
            var list = numbers.OrderBy(x => x)
                .Take(4);
            foreach (int n in list)
            {
                Console.WriteLine(n);
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers.SetValue(30, 4);
            Console.WriteLine("Change value at index 4, then print the number in descending order");
            numbers.OrderByDescending(x => x)
                .ToList()
                .ForEach(x => Console.WriteLine(x));


            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("\nPeople with FirstName starts with a C OR an S and in ascending order by FirstName.");
            employees.Where(e => e.FirstName.ToLower().StartsWith("c") || e.FirstName.ToLower().StartsWith("s"))
                .OrderBy(e => e.FirstName)
                .ToList()
                .ForEach(e => Console.WriteLine(e.FullName));

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("\nPeople who are over the age 26 and order this by Age first and then by FirstName");
            employees.Where(e => e.Age > 26)
                .OrderBy(e => e.Age)
                .ThenBy(e => e.FirstName)
                .ToList()
                .ForEach(e => Console.WriteLine($"Full Name: {e.FullName} | Age: {e.Age}"));

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            // Create a filtered list
            int sumOfYOE = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35)
                .Sum(e => e.YearsOfExperience);
            
            Console.WriteLine($"\nSum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35 equals {sumOfYOE}");

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            double averageYOE = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35)
                .Average(e => e.YearsOfExperience);
            
            Console.WriteLine($"Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35 equals {Math.Round(averageYOE, 3)}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("\nNew Employee List:");
            var newEmployeeList = employees.Append(new Employee { FirstName = "Elon", LastName = "Musk", Age = 52, YearsOfExperience = 25 });
            foreach (Employee e in newEmployeeList)
            {
                Console.WriteLine(e.FullName);
            }

            Console.WriteLine("\nOriginal List:");
            foreach (Employee e in employees)
            {
                Console.WriteLine(e.FullName);
            }


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
