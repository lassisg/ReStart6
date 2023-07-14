using D00_Utils;

namespace D04_OOP_Abstraction;

internal class Program
{

    static void Main(string[] args)
    {
        Utils.SetUtf8Encoding();

        Utils.PrintHeader("Abstraction");

        // Não se pode instanciar uma classe abstract
        //Course course = new Course();

        CourseSoftSkills curso01 = new CourseSoftSkills(1, "Javascript Web Developer", "Dev", "Top");

        curso01.ListCourse();

        Utils.CleanConsole();

    }

}