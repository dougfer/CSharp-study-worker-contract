using System.Globalization;
using WorkerContract.Entities;
using WorkerContract.Entities.Enums;

namespace WorkerContract // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: " );
            string departmentName = Console.ReadLine();

            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string workerName = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel?Senior): ");
            WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            Department dept = new Department(departmentName);

            Worker worker = new Worker {
                Name = workerName,
                Level = workerLevel,
                BaseSalary = baseSalary,
                Department = dept,
            };

            Console.Write("How many contracts to this worker?  ");
            int contractsNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= contractsNumber; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double value = double.Parse(Console.ReadLine() , CultureInfo.InvariantCulture);

                Console.Write("Duration: ");
                int duration = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract
                {
                    Date = date,
                    Hours = duration,
                    ValuePerHour = value

                };

                worker.AddContract(contract);
            }


            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");

            string[] period = Console.ReadLine().Split("/");

            int month = int.Parse(period[0]);

            int year = int.Parse(period[1]);

            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {month}/{year}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");

        }
    }
}