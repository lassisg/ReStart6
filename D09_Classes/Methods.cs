using System;
using D00_Utils;

namespace D09_Classes
{

    class Methods
    {

        #region Procedimento: método void (não devolve valor)

        public static void Procedure()
        {

            Console.WriteLine("Procedimento: método void, que não devolve valor.");
            Console.WriteLine("\n\n");

        }

        #endregion

        #region Função: método não void (devolve valor)

        public static string Function()
        {

            return "Função: método não void, que devolve valor.";

        }

        #endregion

        #region Método com argumento obrigatório

        public static void MethodWithMandatoryArgument(string message01, string message02)
        {

            Console.WriteLine($"Mensagem 01: {message01}");
            Console.WriteLine($"Mensagem 02: {message02}");
            Console.WriteLine("\n\n");

        }

        #endregion

        #region Método com argumento opcional

        public static void MethodWithOptionalArgument(string message01, string message02 = "C#")
        {

            Console.WriteLine($"Mensagem 01: {message01}");
            Console.WriteLine($"Mensagem 02: {message02}");
            Console.WriteLine("\n\n");

        }

        #endregion

        #region Método com argumento designado

        public static void MethodWithNamedArgument(string message01, string message02)
        {

            Console.WriteLine($"Mensagem 01: {message01}");
            Console.WriteLine($"Mensagem 02: {message02}");
            Console.WriteLine("\n\n");

        }

        #endregion

        #region Método com passagem por valor

        // Alterações a 'mensagem' não afetam o seu valor original
        public static void PassingValueToMethod(string message)
        {            

            message = "Mensagem alterada - por valor.";

        }

        #endregion

        #region Método com passagem por referência

        // Alterações a 'mensagem' afetam o seu valor original
        public static void PassingReferenceToMethod(ref string message)
        {

            message = "Mensagem alterada - por referência.";

        }

        #endregion

        #region Método para chamar todos os outros métodos e que vai ser executado no Main()

        public static void MethodsCall()
        {

            // ----------------------------------------------------------------------

            Utils.PrintHeader("Procedure");
            Procedure();
            Utils.CleanConsole();

            // ----------------------------------------------------------------------

            Utils.PrintHeader("Function");
            /*
            string resultado;
            resultado = Function();
            Console.WriteLine(resultado + "\n\n");
            */
            Console.WriteLine(Function() + "\n\n");
            Utils.CleanConsole();

            // ----------------------------------------------------------------------

            Utils.PrintHeader("Method with mandatory argument");
            MethodWithMandatoryArgument("Microsoft", "C#");
            Utils.CleanConsole();

            // ----------------------------------------------------------------------

            Utils.PrintHeader("Method with optional argument");
            MethodWithOptionalArgument("Microsoft");
            Utils.CleanConsole();

            // ----------------------------------------------------------------------

            Utils.PrintHeader("Method with named argument");
            MethodWithNamedArgument(message02: "C#", message01: "Microsoft");
            Utils.CleanConsole();

            // ----------------------------------------------------------------------

            Utils.PrintHeader("Passing value to method");
            string value = "Mensagem original.";
            Console.WriteLine($"Mensagem ANTES de mudar a variável: {value}");
            PassingValueToMethod(value);
            Console.WriteLine($"Mensagem DEPOIS de mudar a variável: {value}\n\n");
            Utils.CleanConsole();

            // ----------------------------------------------------------------------

            Utils.PrintHeader("Passing reference to method");
            string reference = "Mensagem original.";
            Console.WriteLine($"Mensagem ANTES de mudar a variável: {reference}");
            PassingReferenceToMethod(ref reference);
            Console.WriteLine($"Mensagem DEPOIS de mudar a variável: {reference}\n\n");
            Utils.CleanConsole();

            // ----------------------------------------------------------------------

        }

        #endregion

    }

}
