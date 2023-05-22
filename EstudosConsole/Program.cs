
using ExercicioCSharpEnum.Entities;
using ExercicioCSharpEnum.Entities.Enums;
using System;
using System.Globalization;

namespace EstudosConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter department's name: ");
            string departmentName = Console.ReadLine();


            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department department = new Department(departmentName);
            Worker worker = new Worker(name, level, baseSalary, department);

            Console.Write("How many contracts to this worker? ");
            int qtdContract = int.Parse(Console.ReadLine());


            for (int i = 0; i < qtdContract; i++)
            {
                Console.Write($"Enter #{i + 1} contract data: ");
                Console.WriteLine("Date (dd/MM/YYYY): ");
                DateTime contractDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (Hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(contractDate, valuePerHour, hours);

                worker.AddContract(contract);

            }

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string vet = Console.ReadLine();

            int month = int.Parse(vet.Substring(0, 2));
            int year = int.Parse(vet.Substring(3));
            Console.WriteLine($"Name:  {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {vet}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");
           



        }
    }
}
