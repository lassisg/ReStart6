using D00_Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D04_OOP_Abstraction
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Utils.SetUTF8Encoding();

            Utils.PrintHeader("Abstraction");

            // Não se pode instanciar uma classe abstract
            //Course course = new Course();

            CourseSoftSkills curso01 = new CourseSoftSkills(1, "Javascript Web Developer", "Dev", "Top");

            curso01.ListCourse();

            Utils.CleanConsole();

        }

    }

}
