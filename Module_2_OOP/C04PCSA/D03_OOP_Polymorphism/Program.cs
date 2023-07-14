
using D00_Utils;

namespace D03_OOP_Polymorphism;

internal class Program
{

    static void Main(string[] args)
    {

        Utils.SetUtf8Encoding();

        Utils.PrintHeader("Polymorphism");

        // Instanciar a classe e usar os seus membros públicos
        Course course01 = new Course(1, "Database Fundamentals");
        course01.ListCourse();

        CourseSoftSkills course02 = new CourseSoftSkills(2, "TIcket to your next job", "Carreer");
        course02.ListCourse();

        CourseIT course03 = new CourseIT(3, "Javascript Web Developer", "Dev", true);
        course03.ListCourse();
        course03.ListCourse(course03.Area);
        course03.ListCourse(course03.Area, course03.HasExam);

        Utils.CleanConsole();

    }

}