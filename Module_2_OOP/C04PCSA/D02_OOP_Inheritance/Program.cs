using D00_Utils;

namespace D02_OOP_Inheritance
{

    internal class Program
    {

        static void Main(string[] args)
        {

            Utils.SetUTF8Encoding();

            Utils.PrintHeader("Inheritance");

            // Esta técnica deve ser evitada, pois não cumpre o polimorfismo

            // Instanciar a classe e usar os seus membros públicos
            Course course01 = new Course(1, "Database Fundamentals");
            course01.ListCourse($"ID: {course01.CourseID}; Name: {course01.CourseName}");

            CourseSoftSkills course02 = new CourseSoftSkills(2, "TIcket to your next job", "Carreer");
            course02.ListCourse($"ID: {course02.CourseID}; Name: {course02.CourseName}; Area: {course02.Area}");

            CourseIT course03 = new CourseIT(3, "Javascript Web Developer", "Dev", true);
            course03.ListCourse($"ID: {course03.CourseID}; Name: {course03.CourseName}; Area: {course03.Area}; Has exam: {course03.HasExam}");


            Utils.CleanConsole();

        }

    }

}
