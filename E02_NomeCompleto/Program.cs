using System;

namespace E02_NomeCompleto
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee employee = new Employee();

            employee.ReadNames();

            employee.CreateFullName();

            employee.WriteFullName();

            Console.ReadLine();

        }

    }

}
