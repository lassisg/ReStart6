using System;

namespace E02_NomeCompleto
{

    internal class Program
    {

        static void Main(string[] args)
        {

            Employee employee = new Employee();

            employee.ReadNames();

            employee.ValidateNames();

            employee.CreateFullName();

            employee.WriteFullName();

            Console.ReadLine();

        }

    }

}
