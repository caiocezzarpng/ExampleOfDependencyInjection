using System;
using System.Globalization;
using DependencyInjectionExample.Entities;
using DependencyInjectionExample.Services;

namespace DependencyInjectionExample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Date (dd/MM/yyyy):");
            DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double contractValue = Double.Parse(Console.ReadLine() ?? string.Empty, CultureInfo.InvariantCulture);

            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine() ?? String.Empty);

            Contract myContract = new Contract(number, contractDate, contractValue);

            ContractService contractService = new ContractService(new PayPalService());
            contractService.ProcessContract(myContract, months);

            Console.WriteLine("Installments: ");
            foreach (Installment installment in myContract.Installments)
            {
                Console.WriteLine(installment);
            }
        }
    }
}