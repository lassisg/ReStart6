using System;
using D00_Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace M04_LeituraEscrita
{

    public static class Exercicios
    {

        public static void ExecutarExercicio01()
        {

            // 1.Apresentar a área de um retângulo a partir de dois valores (altura e largura)
            // introduzidos pelo utilizador.
            // Nota: area = altura * largura
            Utils4.PrintHeader("Exercício 1");

            string subHeader;
            subHeader = "Apresentar a área de um retângulo a partir de dois valores";
            subHeader += "\n(altura e largura) introduzidos pelo utilizador.";

            Utils4.PrintSubHeader(subHeader);

            Retangulo r = new Retangulo();

            Console.Write("Altura do retângulo: ");
            r.Altura = Convert.ToInt16(Console.ReadLine());

            Console.Write("Largura do retângulo: ");
            r.Largura = Convert.ToInt16(Console.ReadLine());

            r.CalcularArea();

            Console.WriteLine($"\nA area do retângulo é: {r.Area}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio02() 
        {

            // 2.Refazer o exemplo 3b com outros valores.
            Utils4.PrintHeader("Exercício 2");

            string subHeader = "Refazer o exemplo 3b com outros valores.";

            Utils4.PrintSubHeader(subHeader);

            Console.Write("Digite o 1º número: ");
            double number01 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o 2º número: ");
            double number02 = Convert.ToDouble(Console.ReadLine());

            double resultado = number01 / number02;
            Console.WriteLine($"O resultado das expressão \'{number01} / {number02}\' é: {resultado}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio03() 
        {

            // 3.Escrever um programa que apresente no ecrã o resultado das expressões:
            //      › 15 + 2
            //      › 15 / 2
            //      › Resto da divisão de 15 por 2.

            Utils4.PrintHeader("Exercício 3");

            string subHeader = "Escrever um programa que apresente no ecrã o resultado das expressões:";
            subHeader += "\n\t› 15 + 2";
            subHeader += "\n\t› 15 / 2";
            subHeader += "\n\t› Resto da divisão de 15 por 2.";

            Utils4.PrintSubHeader(subHeader);

            double resultado = 15 + 2;
            Console.WriteLine($"O resultado das expressão \'15 + 2\' é: {resultado}");

            resultado = 15 / 2;
            Console.WriteLine($"O resultado das expressão \'15 / 2\' é: {resultado}");

            resultado = 15 % 2;
            Console.WriteLine($"Resto da divisão de 15 por 2 é: {resultado}");


            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio04() 
        {

            // 4.Escreva um programa que apresente os números(8.456796, 9.8, 3.12345, 6)
            // arredondados em três linhas diferentes.sendo que na primeira linha
            // aparecem todos arredondados a três casas decimais, na segunda a uma
            // e na terceira a sem casa decimal.
            Utils4.PrintHeader("Exercício 04");

            string subHeader = "4. Escreva um programa que apresente os números(8.456796, 9.8, 3.12345, 6) arredondados em três linhas diferentes";
            subHeader += "\nsendo que na primeira linha aparecem todos arredondados a três casas decimais,";
            subHeader += "\nna segunda a uma e na terceira sem casa decimal.";
            
            Utils4.PrintSubHeader(subHeader);

            double number01 = 8.456796;
            double number02 = 9.8;
            double number03 = 3.12345;
            double number04 = 6;

            Console.WriteLine($"{number01:F3}\t{number02:F3}\t{number03:F3}\t{number04:F3}");
            Console.WriteLine($"{number01:F1}\t{number02:F1}\t{number03:F1}\t{number04:F1}");
            Console.WriteLine($"{number01:F0}\t{number02:F0}\t{number03:F0}\t{number04:F0}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio05() 
        {

            //5.Escrever um programa que apresente os números do exercício anterior em percentagem.
            Utils4.PrintHeader("Exercício 05");

            string subHeader = "5. Escrever um programa que apresente os números do exercício anterior em percentagem.";

            Utils4.PrintSubHeader(subHeader);

            double number01 = 8.456796;
            double number02 = 9.8;
            double number03 = 3.12345;
            double number04 = 6;

            Console.WriteLine($"{number01:P}\t{number02:P}\t{number03:P}\t{number04:P}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio06() 
        {

            //6.Escrever um programa que leia do utilizador 3 números e os apresente dois resultados diferentes:
            //› Na 1ª linha, os números estão alinhados à esquerda, com duas casas decimais e cada um com 20
            //casas.
            //› Na 1ª linha, os números estão alinhados à direita, com uma casa decimal e cada um com 20
            //casas.
            Utils4.PrintHeader("Exercício 06");

            string subHeader = "6. Escrever um programa que leia do utilizador 3 números e os apresente dois resultados diferentes:";
            subHeader += "\n\t› Na 1ª linha, os números estão alinhados à esquerda, com duas casas decimais e cada um com 20 casas";
            subHeader += "\n\t> Na 2ª linha, os números estão alinhados à direita, com uma casa decimal e cada um com 20 casas";

            Utils4.PrintSubHeader(subHeader);

            double[] numbers = new double[3];

            for (int i = 0; i < numbers.Length; i++)
            {

                Console.Write("Digite um número: ");
                numbers[i] = Convert.ToDouble(Console.ReadLine());

            }

            Console.WriteLine("\n12345678901234567890");
            Console.WriteLine(new String('-', 20));

            Console.WriteLine($"{numbers[0]:F2}; {numbers[1]:F2}; {numbers[2]:F2}".PadRight(20, ' '));
            Console.WriteLine($"{numbers[0]:F1}; {numbers[1]:F1}; {numbers[2]:F1}".PadLeft(20, ' '));

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio07() 
        {

            //7.Escrever um programa que apresente no ecrã a parte inteira de um número introduzido pelo utilizador.
            Utils4.PrintHeader("Exercício 07");

            string subHeader = "7. Escrever um programa que apresente no ecrã a parte inteira de um";
            subHeader += "\nnúmero introduzido pelo utilizador.";

            Utils4.PrintSubHeader(subHeader);

            double numero;

            Console.Write("Digite um número com casas decimais: ");
            numero = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"\nA parte inteira é {(int)numero}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio08() 
        {

            //8.Escrever uma mensagem que peça ao utilizador o primeiro nome e o apelido e apresente o seguinte resultado:
            //< nome > < apelido >, acabou de ganhar o 1º prémio. Parabéns!
            Utils4.PrintHeader("Exercício 08");

            string subHeader = "8. Escrever uma mensagem que peça ao utilizador o primeiro nome e o apelido";
            subHeader += "\ne apresente o seguinte resultado:";
            subHeader += "\n< nome > < apelido >, acabou de ganhar o 1º prémio. Parabéns!";

            Utils4.PrintSubHeader(subHeader);

            string nome, apelido;

            Console.Write("Digite seu nome: ");
            nome = Console.ReadLine();

            Console.Write("Digite seu apelido: ");
            apelido = Console.ReadLine();


            Console.WriteLine($"\n{nome} {apelido}, acabou de ganhar o 1º prémio. Parabéns!");
            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio09() 
        {

            //9.Criar uma apliação do tipo consola para receber do utilizador dois valores inteiros e devolver a média aritmética.
            Utils4.PrintHeader("Exercício 09");

            string subHeader = "9. Criar uma apliação do tipo consola para receber do utilizador dois";
            subHeader += "\nvalores inteiros e devolver a média aritmética.";

            int numero01, numero02;
            double media;

            Utils4.PrintSubHeader(subHeader);

            Console.Write("\nDigite um número inteiro: ");
            numero01 = Convert.ToInt16(Console.ReadLine());

            Console.Write("\nDigite outro número inteiro: ");
            numero02 = Convert.ToInt16(Console.ReadLine());

            media = (numero01 + numero02) / 2;

            Console.WriteLine($"\nA média aritmética é {media}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio10() 
        {

            //10.Escreva um programa que converta dólares americanos para euros(a taxa de câmbio é de 1,1579 USD para 1€).
            Utils4.PrintHeader("Exercício 10");

            string subHeader = "10. Escreva um programa que converta dólares americanos para euros";
            subHeader += "\n(a taxa de câmbio é de 1,1579 USD para 1€).";

            Utils4.PrintSubHeader(subHeader);

            double dolar, euro, rate;
            rate = 1.1579;

            CultureInfo us = new CultureInfo("en-US");
            CultureInfo pt = new CultureInfo("pt-PT");
            
            Console.Write("\nDigite um valor (em USD): ");
            dolar = Convert.ToDouble(Console.ReadLine());

            euro = dolar / rate;

            Console.WriteLine($"{dolar.ToString("c", us)} equivale a {euro.ToString("c", pt)}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio11() 
        {

            //11.Escreva um programa que converta a temperatura lida em graus Fahrenheit para graus Celsius.
            //A fórmula é C = 5 / 9 * (f - 32).
            Utils4.PrintHeader("Exercício 11");

            string subHeader = "11. Escreva um programa que converta a temperatura lida em graus";
            subHeader += "\nFahrenheit para graus Celsius.";

            Utils4.PrintSubHeader(subHeader);

            double temperatureFahrenheit, temperatureCelsius;

            Console.Write("\nDigite uma temperatura em Fahrenheit: ");
            temperatureFahrenheit = Convert.ToDouble(Console.ReadLine());

            // Fórmula sugerida dá resultado errado
            // verifiquei em https://www.metric-conversions.org/temperature/fahrenheit-to-celsius.htm

            //temperatureCelsius = 5 / 9 * (temperatureFahrenheit - 32);
            temperatureCelsius = 5 * (temperatureFahrenheit - 32) / 9;

            Console.WriteLine($"\nA temperatura em Celsius é {temperatureCelsius}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio12() 
        {

            //12.Escrever um programa que leia o preço base de um determinado produto e calcule o seu valor de venda ao
            //público(ou seja, valor acrescido da taxa de IVA a 23 %).
            Utils4.PrintHeader("Exercício 12");

            string subHeader = "12. Escrever um programa que leia o preço base de um determinado";
            subHeader += "\nproduto e calcule o seu valor de venda ao público";
            subHeader += "\n(ou seja, valor acrescido da taxa de IVA a 23 %).";

            Utils4.PrintSubHeader(subHeader);

            double preco, precoComIVA;
            byte IVA = 23;

            Console.Write("Digite o preço do produto: ");
            preco = Convert.ToDouble(Console.ReadLine());

            precoComIVA = preco + preco * IVA / 100;

            Console.WriteLine($"\nO preço com IVA é {precoComIVA}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio13() 
        {

            //13.Escrever um programa leia o valor base e o iva de um produto e que calcule o valor final do produto.
            Utils4.PrintHeader("Exercício 13");

            string subHeader = "13. Escrever um programa leia o valor base e o iva de um";
            subHeader += "\nproduto e que calcule o valor final do produto.";

            Utils4.PrintSubHeader(subHeader);

            double preco, precoComIVA;
            double IVA;

            Console.Write("Digite o preço do produto: ");
            preco = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o valor do IVA: ");
            IVA = Convert.ToDouble(Console.ReadLine());

            precoComIVA = preco + preco * IVA / 100;

            Console.WriteLine($"\nO preço com IVA é {precoComIVA}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio14() 
        {

            //14.Escrever um programa que converta um valor em segundos para horas, minutos e segundos.
            Utils4.PrintHeader("Exercício 14");

            string subHeader = "14. Escrever um programa que converta um valor em segundos para horas,";
            subHeader += "\nminutos e segundos.";

            Utils4.PrintSubHeader(subHeader);

            int seconds;

            Console.Write("Digite um valor de segundos: ");
            seconds = Convert.ToInt16(Console.ReadLine());

            TimeSpan tempo = TimeSpan.FromSeconds(seconds);

            Console.WriteLine($"\n{seconds} s = {tempo.TotalHours} h");

            Utils4.CleanConsole();

        }


        public static void ExecutarExercicio15() 
        {

            //15.Escrever um programa que apresente ao utilizador a sua idade daqui a vinte anos.
            Utils4.PrintHeader("Exercício 15");

            string subHeader = "15. Escrever um programa que apresente ao utilizador a sua idade";
            subHeader += "\ndaqui a vinte anos.";

            Utils4.PrintSubHeader(subHeader);


            Console.Write("\nDigite sua idade hoje: ");
            int idade = Convert.ToByte(Console.ReadLine());
            int idadeFutura = idade + 20;

            Console.WriteLine($"\nSua idade daqui a vinte anos será {idadeFutura}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio16() 
        {

            // ----------------------------------------------------------------------
            // 16. Escrever um programa que calcule a despesa média diária que um
            // turista despendeu numa viagem de quatro dias ao Porto, sabendo que
            // cada dia gastou mais 20 % do que no dia anterior.O valor da despesa
            // deverá ser apresentado sem casas decimais. 4 / 13
            Utils4.PrintHeader("Exercício 16");

            string subHeader = "16. Escrever um programa que calcule a despesa média diária que";
            subHeader += "\nturista despendeu numa viagem de quatro dias ao Porto, sabendo que";
            subHeader += "\ncada dia gastou mais 20 % do que no dia anterior.O valor da despesa";
            subHeader += "\ndeverá ser apresentado sem casas decimais. 4 / 13";

            Utils4.PrintSubHeader(subHeader.ToString());

            double day1Spent, totalSpent;

            Console.Write("Quanto foi gasto no 1º dia da viagem? ");
            day1Spent = Convert.ToDouble(Console.ReadLine());

            totalSpent = day1Spent;
            for (int i = 1; i < 4; i++)
            {
                totalSpent += day1Spent * Math.Pow(1.2, i);
            }

            Console.WriteLine($"\nO total gasto na viagem será de {totalSpent:F0}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio17() 
        {

            // ----------------------------------------------------------------------
            // 17. Num determinado stand de automóveis, os vendedores ganham um
            // salário mensal base X, uma comissão de Y euros por cada automóvel que
            // vendem e uma percentagem P sobre o valor das vendas V que efetuarem.
            // Escreva um programa que calcule e imprima o salário que um vendedor
            // vai auferir este mês.
            Utils4.PrintHeader("Exercício 17");

            string subHeader = "17. Num determinado stand de automóveis, os vendedores ganham um";
            subHeader += "\nsalário mensal base X, uma comissão de Y euros por cada automóvel que";
            subHeader += "\nvendem e uma percentagem P sobre o valor das vendas V que efetuarem.";
            subHeader += "\nEscreva um programa que calcule e imprima o salário que um vendedor";
            subHeader += "\nvai auferir este mês.";

            Utils4.PrintSubHeader(subHeader);

            double baseSalary, comission, ratePerSale, monthSales, salary;
            int totalVehicles;

            Console.Write("Digite o salário base: ");
            baseSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o valor da comissão: ");
            comission = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o valor da taxa sobre vendas: ");
            ratePerSale = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o nº de veículos vendidos no mês: ");
            totalVehicles = Convert.ToInt16(Console.ReadLine());

            Console.Write("Digite o total de vendas do mês: ");
            monthSales = Convert.ToDouble(Console.ReadLine());

            salary = baseSalary + (totalVehicles * comission) + (monthSales * ratePerSale);

            Console.WriteLine($"\nO salário mensal será {salary.ToString("C", new CultureInfo("pt-PT"))}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio18() 
        {

            // ----------------------------------------------------------------------
            // 18.Escrever um programa que troque entre si o valor contido em duas
            // variáveis inteiras a e b, ou seja, o valor contido em a passa a ser o
            // valor de b e vice-versa, sem utilizar uma terceira variável.
            Utils4.PrintHeader("Exercício 18");

            string subHeader = "18.Escrever um programa que troque entre si o valor contido em duas";
            subHeader += "\nvariáveis inteiras a e b, ou seja, o valor contido em a passa a ser o";
            subHeader += "\nvalor de b e vice-versa, sem utilizar uma terceira variável.";

            Utils4.PrintSubHeader(subHeader);

            int a, b;

            a = 1;
            b = 2;

            Console.WriteLine($"Antes da troca: a = {a}, b = {b}");

            (a, b) = (b, a);

            Console.WriteLine($"Depois da troca: a = {a}, b = {b}");

            Utils4.CleanConsole();

        }
        
        public static void ExecutarExercicio19() 
        {

            // ----------------------------------------------------------------------
            // 19. Escreva um programa que apresente no ecrã antecessor e sucessor de
            // um número introduzido pelo utilizador.
            Utils4.PrintHeader("Exercício 19");

            string subHeader = "19. Escreva um programa que apresente no ecrã antecessor e sucessor de";
            subHeader += "\num número introduzido pelo utilizador.";

            Utils4.PrintSubHeader(subHeader);

            int numero, antecessor, sucessor;

            Console.Write("Escreva um número inteiro: ");
            numero = Convert.ToInt16(Console.ReadLine());

            antecessor = numero - 1;
            sucessor = numero + 1;

            Console.WriteLine($"\nNúmero antecessor: {antecessor}");
            Console.WriteLine($"Número sucessor: {sucessor}");

            Utils4.CleanConsole();

        }
    }

}
