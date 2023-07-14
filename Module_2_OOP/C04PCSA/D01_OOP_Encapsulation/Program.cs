using D00_Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D01_OOP_Encapsulation;

internal class Program
{

    static void Main(string[] args)
    {

        Utils.SetUTF8Encoding();

        Utils.PrintHeader("Encapsulation");

        // Instanciar a classe e usar os seus membros públicos
        Course course01 = new Course();


        course01.CourseID = 1;
        course01.CourseName = "C#";
        course01.ListCourse();

        Utils.CleanConsole();

    }

}