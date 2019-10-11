using Aula118_Exercicios_propostos_PARTE1.Entities;
using Aula118_Exercicios_propostos_PARTE1.Entities.Enums;
using System;
using System.Globalization;

namespace Aula118_Exercicios_propostos_PARTE1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter department's name: " );
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            //Descrição - Recebe o level em forma de string e converte para o tipo de objeto WorkLevel 
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkLevel level = Enum.Parse<WorkLevel>(Console.ReadLine());

            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //Descrição - Instância o departamento em seguida instância o trabalhador associado com o departamento
            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? " );
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                //Lembrete - interpolação {}
                Console.WriteLine($"Enter #{i} contact data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                //
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY); ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year,month).ToString("F2",CultureInfo.InvariantCulture));
        }
    }
}
