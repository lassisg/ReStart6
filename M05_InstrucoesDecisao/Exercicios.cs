using D00_Utils;
using System;
using System.Collections;
using System.Globalization;
using System.Linq;

namespace M05_InstrucoesDecisao
{

    public static class Exercicios
    {

        public static void ExecutarExercicio01()
        {

            // 1. Escrever um programa que apresente o resultado das seguintes operações lógicas:
            //   2 == 3
            //   8 != 12
            //   14 > 15
            //   true == false
            //   ‘a’ == ‘a’
            //   ‘a’ == ‘b’
            //   2 < 3 E 3 > 4
            //   2 < 3 OU 3 > 4
            //   NÃO(2 < 3 OU 3 > 4)
            Utils.PrintHeader("Exercício 1");

            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever um programa que apresente o resultado das seguintes";
            subHeader += "\noperações lógicas:";
            subHeader += "\n\t2 == 3";
            subHeader += "\n\t8 != 12";
            subHeader += "\n\t14 > 15";
            subHeader += "\n\ttrue == false";
            subHeader += "\n\t‘a’ == ‘a’";
            subHeader += "\n\t‘a’ == ‘b’";
            subHeader += "\n\t2 < 3 E 3 > 4";
            subHeader += "\n\t2 < 3 OU 3 > 4";
            subHeader += "\n\tNÃO(2 < 3 OU 3 > 4)";

            Utils.PrintSubHeader(subHeader);


            Console.WriteLine($"\nResultado da operação lógica              2 == 3: {2 == 3}");
            Console.WriteLine($"Resultado da operação lógica             8 != 12: {8 != 12}");
            Console.WriteLine($"Resultado da operação lógica             14 > 15: {14 > 15}");
            Console.WriteLine($"Resultado da operação lógica       true == false: {true == false}");
            Console.WriteLine($"Resultado da operação lógica          ‘a’ == ‘a’: {'a' == 'a'}");
            Console.WriteLine($"Resultado da operação lógica          ‘a’ == ‘b’: {'a' == 'b'}");
            Console.WriteLine($"Resultado da operação lógica       2 < 3 E 3 > 4: {2 < 3 & 3 > 4}");
            Console.WriteLine($"Resultado da operação lógica      2 < 3 OU 3 > 4: {2 < 3 | 3 > 4}");
            Console.WriteLine($"Resultado da operação lógica NÃO(2 < 3 OU 3 > 4): {!(2 < 3 | 3 > 4)}");

            Utils.CleanConsole();

        }
        
        public static void ExecutarExercicio02() 
        {

            //2. Escrever um programa para converter um número real positivo para um número inteiro.Deve ainda de
            //arredondar o número.
            Utils.PrintHeader("Exercício 2");

            // ---------------------------------------------------------------------------------------
            string subHeader = "Escrever um programa para converter um número real positivo para um";
            subHeader += "\nnúmero inteiro. Deve ainda de arredondar o número.";
            Utils.PrintSubHeader(subHeader);

            Console.Write("Digite um número real positivo: ");
            double number01 = Convert.ToDouble(Console.ReadLine());

            int number02 = Convert.ToInt16(Math.Round(number01, 0));

            Console.WriteLine($"O número \'{number01}\' convertido para inteiro e arredondado é \'{number02}\'");

            Utils.CleanConsole();

        }
        
        public static void ExecutarExercicio03() 
        {


            //3. Escrever um programa para determinar se um número é par e positivo.
            Utils.PrintHeader("Exercício 3");

            // ---------------------------------------------------------------------------------------
            string subHeader = "Escrever um programa para determinar se um número é par e positivo.";

            Utils.PrintSubHeader(subHeader);

            Console.Write("Digite um número: ");
            double number01 = Convert.ToDouble(Console.ReadLine());

            string mensagem = $"\nO número {number01} não é positivo ou não é par.";

            if (number01 > 0 & number01 % 2 == 0)
            {
                mensagem = $"\nO número {number01} é positivo e par.";
            }

            Console.WriteLine(mensagem);

            Utils.CleanConsole();

        }
        
        public static void ExecutarExercicio04() 
        {

            // 4. Escrever um programa para calcular o salário semanal a pagar a um empregado, tendo em atenção que todas as
            // horas após as 40 serão pagas a dobrar. O utilizador deve de indicar o valor do salário por hora e o valor das horas
            // trabalhadas.
            Utils.PrintHeader("Exercício 04");

            // ---------------------------------------------------------------------------------------
            string subHeader = "Escrever um programa para calcular o salário semanal a pagar a um";
            subHeader += "\nempregado, tendo em atenção que todas as horas após as 40 serão pagas a";
            subHeader += "\ndobrar. O utilizador deve de indicar o valor do salário por hora e o";
            subHeader += "\nvalor das horas trabalhadas.";
            
            Utils.PrintSubHeader(subHeader);

            double hourSalary;
            double workHours;
            double weeklySalary;

            Console.Write("Informe o valor do salário por hora: ");
            hourSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Informe o valor de horas trabalhadas: ");
            workHours = Convert.ToDouble(Console.ReadLine());

            if (workHours > 40)
            {
                weeklySalary = (40 * hourSalary) + (workHours - 40) * (2 * hourSalary);
            }
            else
            {
                weeklySalary = workHours * hourSalary;
            }

            Console.WriteLine($"\nO salário semanal será de {weeklySalary.ToString("C", new CultureInfo("pt-PT"))}");

            Utils.CleanConsole();

        }
        
        public static void ExecutarExercicio05() 
        {

            // 5. Escrever um programa que permita identificar o número maior entre três números
            // introduzidos pelo utilizador.
            Utils.PrintHeader("Exercício 05");

            // ---------------------------------------------------------------------------------------
            string subHeader = "Escrever um programa que permita identificar o número maior entre três";
            subHeader += "\nnúmeros introduzidos pelo utilizador.";

            Utils.PrintSubHeader(subHeader);

            double[] number = new double[3];
            double greatest;

            for (int i = 0; i < number.Length; i++)
            {
                Console.Write($"Digite o {i + 1}º número: ");
                number[i] = Convert.ToDouble(Console.ReadLine());
            }

            greatest = number.Max();

            Console.WriteLine($"\nO maior dos três números é: {greatest}");

            Utils.CleanConsole();

        }
        
        public static void ExecutarExercicio06() 
        {

            // 6.Escrever um programa que determine a aprovação de um formando numa ação de formação.
            // Deve ter em atenção que só é considerado aprovado se a obtiver classificação mínima de
            // 8 valores em dois testes e cada um tem um peso de 10 valores na nota final.
            Utils.PrintHeader("Exercício 06");

            // ---------------------------------------------------------------------------------------
            string subHeader = "Escrever um programa que determine a aprovação de um formando numa";
            subHeader += "\nação de formação. Deve ter em atenção que só é considerado aprovado se a";
            subHeader += "\nobtiver classificação mínima de 8 valores em dois testes e cada um tem um";
            subHeader += "\npeso de 10 valores na nota final.";

            Utils.PrintSubHeader(subHeader);

            double[] grades = new double[2];
            bool aproved = true;
            string resultMessage;

            for (int i = 0; i < grades.Length; i++)
            {

                Console.Write($"Digite a {i + 1}ª nota: ");
                grades[i] = Convert.ToDouble(Console.ReadLine());

            }

            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] < 8)
                {
                    aproved = false;
                }
            }

            resultMessage = aproved ? "aprovado" : "reprovado";
            
            Console.WriteLine($"\nAluno {resultMessage}.");

            Utils.CleanConsole();

        }
        
        public static void ExecutarExercicio07() 
        {

            // 7. Escrever um programa, utilizando o operador ternário, que apresente a mensagem de “Parabéns” se um
            // formando obteve uma nota superior a 10.No caso contrário, apresente a mensagem “Ups, deve marcar novo
            // exame.”
            Utils.PrintHeader("Exercício 07");

            // ---------------------------------------------------------------------------------------
            string subHeader = "Escrever um programa, utilizando o operador ternário, que apresente a";
            subHeader += "\nmensagem de \"Parabéns\" se um formando obteve uma nota superior a 10. No";
            subHeader += "\ncaso contrário, apresente a mensagem “Ups, deve marcar novo exame.";

            Utils.PrintSubHeader(subHeader);

            double grade;
            string message;

            Console.Write("Digite sua nota: ");
            grade = Convert.ToDouble(Console.ReadLine());

            message = (grade > 10) ? "Parabéns" : "Ups, deve marcar novo exame.";

            Console.WriteLine($"\n{message}");

            Utils.CleanConsole();

        }
        
        public static void ExecutarExercicio08() 
        {

            // 8. Escrever um programa que determine se o ano introduzido é bissexto.
            Utils.PrintHeader("Exercício 08");

            // ---------------------------------------------------------------------------------------
            string subHeader = "Escrever um programa que determine se o ano introduzido é bissexto.";

            Utils.PrintSubHeader(subHeader);

            int year;
            bool bissexto = false;
            string message;

            Console.Write("Digite um ano: ");
            year = Convert.ToInt16(Console.ReadLine());

            bissexto = DateTime.IsLeapYear(year);

            message = bissexto ? "" : " não";

            Console.WriteLine($"\nO ano {year}{message} é bissexto.");
            Utils.CleanConsole();

        }
        
        public static void ExecutarExercicio09() 
        {

            // 9. Escrever um programa que devolva ao utilizador, por ordem crescente, os três números introduzidos
            // inicialmente.
            Utils.PrintHeader("Exercício 09");

            // ---------------------------------------------------------------------------------------
            string subHeader = "Escrever um programa que devolva ao utilizador, por ordem crescente,";
            subHeader += "\nos três números introduzidos inicialmente.";

            Utils.PrintSubHeader(subHeader);

            ArrayList number = new ArrayList();

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Digite o {i + 1}º número: ");
                number.Add(Convert.ToDouble(Console.ReadLine()));
            }

            number.Sort();

            Console.WriteLine("\nNúmero ordenados:");
            foreach (double item in number)
            {
                Console.Write($"\n{item}");
            }

            Utils.CleanConsole();

        }
        
        public static void ExecutarExercicio10() 
        {

            // 10. Escrever um programa para calcular o valor total a pagar por um determinado artigo, sabendo que o tipo de artigo
            // e preço sem iva. Supondo que a taxa de iva é de 5 % para os produtos essenciais, 30 % para os bens de luxo e 20 %
            // para os restantes.
            Utils.PrintHeader("Exercício 10");

            // ---------------------------------------------------------------------------------------
            string subHeader = "Escrever um programa para calcular o valor total a pagar por um";
            subHeader += "\ndeterminado artigo, sabendo que o tipo de artigo e preço sem iva. Supondo";
            subHeader += "\nque a taxa de iva é de 5 % para os produtos essenciais, 30 % para os bens";
            subHeader += "\nde luxo e 20 % para os restantes.";

            Utils.PrintSubHeader(subHeader);

            double price, finalPrice, IVA;
            int productType;

            Console.Write("\nDigite o preço do produto (sem IVA): ");
            price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nEscolha o número de acordo com o tipo de artigo.");
            Console.WriteLine("1 - Produtos essenciais");
            Console.WriteLine("2 - Bens de luxo");
            Console.WriteLine("3 - Outros");
            Console.Write("Opção selecionada: ");
            productType = Convert.ToInt16(Console.ReadLine());

            switch (productType)
            {
                case 1:
                    IVA = 0.05;
                    break;

                case 2:
                    IVA = 0.30;
                    break;

                default:
                    IVA = 0.20;
                    break;
            }

            finalPrice = price * (1 + IVA);

            Console.WriteLine($"O preço final do produto, com IVA, é: {finalPrice.ToString("C", new CultureInfo("pt-PT"))} ");


            Utils.CleanConsole();

        }
        
        public static void ExecutarExercicio11() 
        {

            // 11. Escrever um programa que leia três valores inteiros e verifique se estes podem corresponder aos lados de um
            // triângulo.No caso de se tratar de um triângulo, deve ainda de o classificar como equilátero, isósceles ou escaleno.
            Utils.PrintHeader("Exercício 11");

            // ---------------------------------------------------------------------------------------
            string subHeader = "Escrever um programa que leia três valores inteiros e verifique se";
            subHeader += "\nestes podem corresponder aos lados de um triângulo. No caso de se tratar";
            subHeader += "\nde um triângulo, deve ainda de o classificar como equilátero, isósceles ou";
            subHeader += "\nescaleno.";

            Utils.PrintSubHeader(subHeader);

            int[] sides = new int[3];
            string triangleType;

            for (int i = 0; i < sides.Length; i++)
            {
                Console.Write($"Digite o {i + 1}º lado do triângulo: ");
                sides[i] = Convert.ToInt16(Console.ReadLine());
            }

            Triangle triangle = new Triangle(sides);

            if (triangle.isTriangle())
            {
                triangleType = triangle.GetTriangleType();

                Console.WriteLine($"\nEstes valores correspondem à um triângulo {triangleType}.");

            }
            else
            {
                Console.WriteLine($"\nEstes valores não correspondem à um triângulo.");
            }

            Utils.CleanConsole();

        }
        
        public static void ExecutarExercicio12() 
        {

            // 12. Escrever um programa que escreva, por extenso, os números de 0 até 9.
           Utils.PrintHeader("Exercício 12");

            // ---------------------------------------------------------------------------------------
            string subHeader = "Escrever um programa que escreva, por extenso, os números de 0 até 9.";

            Utils.PrintSubHeader(subHeader);

            for (int i = 0; i < 10; i++)
            {
                string number;

                switch (i)
                {
                    case 1:
                        number = "um";
                        break;

                    case 2:
                        number = "dois";
                        break;

                    case 3:
                        number = "três";
                        break;

                    case 4:
                        number = "quatro";
                        break;

                    case 5:
                        number = "cinco";
                        break;

                    case 6:
                        number = "seis";
                        break;

                    case 7:
                        number = "sete";
                        break;

                    case 8:
                        number = "oito";
                        break;

                    case 9:
                        number = "nove";
                        break;

                    default:
                        number = "zero";
                        break;
                }

                Console.Write($"{number} ");

            }

            Utils.CleanConsole();

        }
        
        public static void ExecutarExercicio13() 
        {

            // 13. Escrever um programa para identificar se o carácter introduzido pelo utilizador é uma vogal ou uma consoante.
            Utils.PrintHeader("Exercício 13");

            // ---------------------------------------------------------------------------------------
            string subHeader = "Escrever um programa para identificar se o carácter introduzido pelo";
            subHeader += "\nutilizador é uma vogal ou uma consoante.";

            Utils.PrintSubHeader(subHeader);

            char input;
            char[] vogais = new char[]
            {
                'a', 'e', 'i', 'o', 'u',
                'A', 'E', 'I', 'O', 'U'
            };


            Console.Write("\nDigite um carácter: ");
            input = Convert.ToChar(Console.ReadLine());

            string message = $"\nO carácter \'{input}\' não é uma vogal.";

            for (int i = 0; i < vogais.Length; i++)
            {
                if (vogais[i] == input)
                {
                    message = $"\nO carácter \'{input}\' é uma vogal.";
                }
            };

            Console.WriteLine(message);

            Utils.CleanConsole();

        }
        
        public static void ExecutarExercicio14() 
        {

            // 14. Escrever um programa que determine o símbolo do zodíaco de uma pessoa baseando-se no dia e no mês do seu
            // nascimento.
            Utils.PrintHeader("Exercício 14");

            // ---------------------------------------------------------------------------------------
            string subHeader = "Escrever um programa que determine o símbolo do zodíaco de uma pessoa";
            subHeader += "\nbaseando-se no dia e no mês do seu nascimento.";

            Utils.PrintSubHeader(subHeader);

            string zodiacSign = string.Empty;

            ArrayList zodiac = new ArrayList();
            zodiac.Add(new ZodiacSign("Capricórnio", new DateTime(2021, 12, 22), new DateTime(2022, 1, 19)));
            zodiac.Add(new ZodiacSign("Aquário", new DateTime(2022, 1, 20), new DateTime(2022, 2, 18)));
            zodiac.Add(new ZodiacSign("Peixes", new DateTime(2022, 2, 19), new DateTime(2022, 3, 20)));
            zodiac.Add(new ZodiacSign("Áries", new DateTime(2022, 3, 21), new DateTime(2022, 4, 19)));
            zodiac.Add(new ZodiacSign("Touro", new DateTime(2022, 4, 20), new DateTime(2022, 5, 20)));
            zodiac.Add(new ZodiacSign("Gêmeos", new DateTime(2022, 5, 21), new DateTime(2022, 6, 20)));
            zodiac.Add(new ZodiacSign("Câncer", new DateTime(2022, 6, 21), new DateTime(2022, 7, 22)));
            zodiac.Add(new ZodiacSign("Leão", new DateTime(2022, 7, 23), new DateTime(2022, 8, 22)));
            zodiac.Add(new ZodiacSign("Virgem", new DateTime(2022, 8, 23), new DateTime(2022, 9, 22)));
            zodiac.Add(new ZodiacSign("Libra", new DateTime(2022, 9, 23), new DateTime(2022, 10, 22)));
            zodiac.Add(new ZodiacSign("escorpião", new DateTime(2022, 10, 23), new DateTime(2022, 11, 21)));
            zodiac.Add(new ZodiacSign("Sagitário", new DateTime(2022, 11, 22), new DateTime(2022, 12, 21)));

            Console.Write($"\nDigite o dia do seu nascimento: ");
            int birthDay = Convert.ToInt16(Console.ReadLine());

            Console.Write($"Digite o nº do mês do seu nascimento: ");
            int birthMonth = Convert.ToInt16(Console.ReadLine());

            int birthYear = (birthMonth == 12 && birthDay >= 22) ? 2021 : 2022;                

            DateTime birthDate = new DateTime(birthYear, birthMonth, birthDay);

            foreach (ZodiacSign sign in zodiac)
            {
                zodiacSign = sign.GetZodiac(birthDate);

                if (zodiacSign != string.Empty)
                {
                    break;
                }
            }

            Console.WriteLine($"\n{zodiacSign}");

            Utils.CleanConsole();

        }

    }

}
