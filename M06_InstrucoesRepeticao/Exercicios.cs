using D00_Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M06_InstrucoesRepeticao
{

    internal class Exercicios
    {
        internal static void ExecutarExercicio01()
        {

            Utils.PrintHeader("Exercício 1");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever um programa que imprima no ecrã um retângulo com o";
            subHeader += "\nsímbolo '0' sabendo a sua largura e comprimento.";

            Utils.PrintSubHeader(subHeader);

            int largura = 40;
            int comprimento = 10;
            char border = '0';

            Console.WriteLine(new string(border, largura));

            for (int i = 1; i < (comprimento - 1); i++)
            {
                Console.WriteLine($"{border}{new string(' ', largura - 2)}{border}");
            }

            Console.WriteLine(new string(border, largura));

        }

        internal static void ExecutarExercicio02()
        {

            Utils.PrintHeader("Exercício 2");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escreva um programa que imprima no ecrã os números ímpares";
            subHeader += "\nentre 1 e 50.";

            Utils.PrintSubHeader(subHeader);

            int length = 50;

            for (int i = 1; i < length; i++)
            {
                bool isOdd = (i % 2 != 0) ? true : false;

                if (isOdd)
                {
                    Console.WriteLine(i);
                }
            }

        }

        internal static void ExecutarExercicio03()
        {

            Utils.PrintHeader("Exercício 3");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escreva um programa que calcule a soma, com incrementos de 3,";
            subHeader += "\nde todos os números menores que 100, começando em 4";
            subHeader += "\n(ex.: 4+7+10+13+...), utilizando as três estruturas de";
            subHeader += "\nrepetição que conhece.";

            Utils.PrintSubHeader(subHeader);

            int soma = 0;
            int limite = 100;

            for (int i = 4; i < limite; i+=3)
            {
                soma += i;
            }

            Console.WriteLine($"\nSoma, utilizando 'for': {soma}");

            soma = 0;
            int j = 4;

            while (j < limite)
            {
                soma += j;
                j += 3;
            }

            Console.WriteLine($"\nSoma, utilizando 'while': {soma}");

            soma = 0;
            j = 4;

            do
            {
                soma += j;
                j += 3;
            }
            while (j < limite);

            Console.WriteLine($"\nSoma, utilizando 'do': {soma}");

        }

        internal static void ExecutarExercicio04()
        {

            Utils.PrintHeader("Exercício 4");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escreva um programa que receba dois números inteiros e gere";
            subHeader += "\nos números inteiros que estão no intervalo compreendidos";
            subHeader += "\npor eles.";

            Utils.PrintSubHeader(subHeader);

            int num01, num02, menor, maior;

            // Sem validação porque não é o objetivo do exercício
            Console.Write("\nDigite o 1º número inteiro: ");
            num01 = int.Parse(Console.ReadLine());

            Console.Write("Digite o 2º número inteiro: ");
            num02 = int.Parse(Console.ReadLine());


            if (num01 == num02)
            {
                Console.WriteLine("\nOs números são iguais");
            }
            else
            {
                menor = (num01 < num02) ? num01 : num02;
                maior = (num01 > num02) ? num01 : num02;

                for (int i = menor + 1; i < maior; i++)
                {
                    Console.WriteLine(i);
                }
            }

        }

        internal static void ExecutarExercicio05()
        {

            Utils.PrintHeader("Exercício 5");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Altere o programa anterior para mostrar no final a soma dos";
            subHeader += "\nnúmeros.";

            Utils.PrintSubHeader(subHeader);

            int num01, num02, menor, maior, soma;

            // Sem validação porque não é o objetivo do exercício
            Console.Write("\nDigite o 1º número inteiro: ");
            num01 = int.Parse(Console.ReadLine());

            Console.Write("Digite o 2º número inteiro: ");
            num02 = int.Parse(Console.ReadLine());


            if (num01 == num02)
            {
                Console.WriteLine("\nOs números são iguais");
            }
            else
            {
                menor = (num01 < num02) ? num01 : num02;
                maior = (num01 > num02) ? num01 : num02;
                soma = 0;

                for (int i = menor + 1; i < maior; i++)
                {
                    soma += i;
                }

                Console.WriteLine($"A soma é {soma}");

            }

        }

        internal static void ExecutarExercicio06()
        {

            Utils.PrintHeader("Exercício 6");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escreva um programa que leia uma sequência de números";
            subHeader += "\ninteiros a partir do teclado e apresente o máximo e o";
            subHeader += "\nmínimo. O programa termina quando o número lido for zero.";

            Utils.PrintSubHeader(subHeader);

            string userInput;
            List<int> valores = new List<int>();
            int inputValue;

            Console.WriteLine();

            do
            {
                // Sem validação porque não é o objetivo do exercício
                Console.Write("Digite um número: ");
                userInput = Console.ReadLine();

                if (userInput != "0" && userInput != String.Empty)
                {
                    inputValue = int.Parse(userInput);
                    valores.Add(inputValue);
                }

            } while (userInput != "0");

            Console.WriteLine($"\nO valor máximo é {valores.Max()} e o mínimo é {valores.Min()}");

        }

        internal static void ExecutarExercicio07()
        {

            Utils.PrintHeader("Exercício 7");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escreva um programa que leia uma sequência de números";
            subHeader += "\ninteiros a partir do teclado e acumule unicamente a soma";
            subHeader += "\ndos inteiros positivos. O programa termina quando o";
            subHeader += "\nnúmero lido for zero.";

            Utils.PrintSubHeader(subHeader);

            string userInput;
            int soma = 0;

            Console.WriteLine();

            do
            {
                // Sem validação porque não é o objetivo do exercício
                Console.Write("Digite um número inteiro positivo: ");
                userInput = Console.ReadLine();

                if (userInput != "0" && userInput != String.Empty)
                {
                    soma += int.Parse(userInput);
                }

            } while (userInput != "0");

            Console.WriteLine($"\nA soma dos valores é {soma}");

        }

        internal static void ExecutarExercicio08()
        {

            Utils.PrintHeader("Exercício 8");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever um programa que peça a altura de n funcionários de";
            subHeader += "\numa empresa e apresente as seguintes estatísticas:";
            subHeader += "\n  • A altura do funcionário mais baixo;";
            subHeader += "\n  • A altura do funcionário mais alto;";
            subHeader += "\n  • A altura média.";

            Utils.PrintSubHeader(subHeader);

            string userInput;
            List<double> alturas = new List<double>();
            double inputValue;

            Console.WriteLine();

            do
            {
                // Sem validação porque não é o objetivo do exercício
                Console.Write("Digite a altura de um funcionário (digite '0' para sair): ");
                userInput = Console.ReadLine();

                if (userInput != "0" && userInput != String.Empty)
                {
                    inputValue = double.Parse(userInput);
                    alturas.Add(inputValue);
                }

            } while (userInput != "0");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\nEstatísticas:");
            sb.AppendLine($"  • Altura do funcionário mais baixo: {alturas.Min()}");
            sb.AppendLine($"  • Altura do funcionário mais alto: {alturas.Max()}");
            sb.AppendLine($"  • Altura média dos funcionários: {alturas.Average()}");

            Console.WriteLine(sb.ToString());
        }

        internal static void ExecutarExercicio09()
        {

            Utils.PrintHeader("Exercício 9");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escreva um programa que leia um número inteiro e calcule a";
            subHeader += "\nsoma dos seus dígitos.";

            Utils.PrintSubHeader(subHeader);

            string userInput;
            int inputValue;
            int soma = 0;

            // Sem validação porque não é o objetivo do exercício
            Console.Write("\nDigite um número inteiro: ");
            userInput = Console.ReadLine();
            
            bool isInteger = int.TryParse(userInput, out inputValue);

            if (!isInteger)
            {
                Console.WriteLine("Erro! Format inválido!");
            }
            else
            {

                foreach (char c in userInput.ToCharArray())
                {
                    soma += int.Parse(c.ToString());
                }
            }
            
            Console.WriteLine($"\nA soma dos dígitos de {userInput} é {soma}.");

        }

        internal static void ExecutarExercicio10()
        {
            
            Utils.PrintHeader("Exercício 10");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Analise o programa e descreva o seu comportamento.";
            subHeader += "\n\nRandon rnd = new Random();";
            subHeader += "\nint numeroSecreto = rnd.Next(<valorInicial>, <valorFinal>);";
            subHeader += "\n\nusing System;";
            subHeader += "\nnamespace MODULO6_Exercicios";
            subHeader += "\n{";
            subHeader += "\n    class Program";
            subHeader += "\n    {";
            subHeader += "\n        static void Main(string[] args)";
            subHeader += "\n        {";
            subHeader += "\n            int n;";
            subHeader += "\n            Random rnd = new Random();";
            subHeader += "\n            int numeroSecreto = rnd.Next(1, 6);";
            subHeader += "\n            do";
            subHeader += "\n            {";
            subHeader += "\n                Console.WriteLine(\"Introduza um nº: \");";
            subHeader += "\n                n = Convert.ToInt32(Console.ReadLine());";
            subHeader += "\n            }";
            subHeader += "\n            while (numeroSecreto != n);";
            subHeader += "\n            Console.WriteLine(\"Acertou!\");";
            subHeader += "\n        }";
            subHeader += "\n    }";
            subHeader += "\n}";

            Utils.PrintSubHeader(subHeader);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\nÉ instanciado um objeto Random na variável 'rnd'.");
            sb.Append("O método 'Next' de 'rbd' retorna un número aleatório entre 1 e 6,");
            sb.AppendLine("que é atribuído à variável 'numeroSecreto'.");
            sb.AppendLine("\nEm seguida, entra em um ciclo em que pede ao utilizador que digite um nº.");
            sb.AppendLine("\nEnquanto o utilizador digitar um nº diferente do 'numeroSecreto', permanece no ciclo.");
            sb.AppendLine("Se o utilizador digitar um número igual ao 'numeroSecreto', sai do ciclo e escreve a mensagem:");
            sb.AppendLine("'Acertou!'");

            Console.WriteLine(sb.ToString());

        }

        internal static void ExecutarExercicio11()
        {

            Utils.PrintHeader("Exercício 11");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Alterar o exercício anterior para contabilizar o nº de";
            subHeader += "\ntentativas falhadas.";

            Utils.PrintSubHeader(subHeader);

            int n;
            int errorCount = -1;

            Random rnd = new Random();
            int numeroSecreto = rnd.Next(1, 6);
            do
            {
                errorCount++;

                Console.WriteLine("Introduza um nº: ");
                n = Convert.ToInt32(Console.ReadLine());
            }
            while (numeroSecreto != n);
            
            Console.WriteLine($"\nAcertou!\nMas errou {errorCount} vezes...");

        }

        internal static void ExecutarExercicio12()
        {

            Utils.PrintHeader("Exercício 12");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever um programa que peça a n pessoas de uma empresa a";
            subHeader += "\nsua idade. No final o programa deverá verificar se a";
            subHeader += "\nmédia de idades varia entre 0 e 25, 26 e 60 e maior que";
            subHeader += "\n60; e dizer se os funcionários são jovens, adultos ou";
            subHeader += "\nidosos, conforme a média calculada.";

            Utils.PrintSubHeader(subHeader);

            string userInput, classification;
            int inputValue;
            List<int> listaIdades = new List<int>();
            double mediaIdade;

            Console.WriteLine();

            do
            {
                // Sem validação porque não é o objetivo do exercício
                Console.Write("Digite sua idade (digite 0 para sair): ");
                userInput = Console.ReadLine();

                if (userInput != "0" && userInput != string.Empty)
                {
                    inputValue = int.Parse(userInput);
                    listaIdades.Add(inputValue);
                }

            } while (userInput != "0");

            mediaIdade = listaIdades.Average();

            if (mediaIdade <= 25)
            {
                classification = "jovens";
            }
            else if (mediaIdade <= 60)
            {
                classification = "adultos";
            }
            else
            {
                classification = "idosos";
            }

            Console.WriteLine($"\nOs funcionários da empresa são {classification}, porque a média de idade é {mediaIdade}.");

        }

        internal static void ExecutarExercicio13()
        {

            Utils.PrintHeader("Exercício 13");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "O dono de um hotel concebeu uma forma original de cobrar aos";
            subHeader += "\nseus clientes. A primeira noite custa 50 euros. A segunda";
            subHeader += "\nsegunda custa 25 euros (ou seja, 50\\2 euros), a terceira ";
            subHeader += "\n50\\3 euros e a n-ésima noite custa 50\\n euros. Escreva";
            subHeader += "\num programa que calcule a cobrança a efetuar a um cliente";
            subHeader += "\nque fique X noites no hotel. O programa deve indicar o";
            subHeader += "\npreço a pagar por cada noite e também o total.";
            subHeader += "\n\nDica: Para conseguir visualizar o carácter € pode";
            subHeader += "\nintroduzir, no Main, a seguinte instrução:";
            subHeader += "\nConsole.OutputEncoding = System.Text.Encoding.UTF8;";

            Utils.PrintSubHeader(subHeader);

            string userInput;
            int inputValue;
            double basePrice = 50;
            double currentPrice;
            double totalPrice = 0;

            Console.WriteLine("Quantas noites dormiu no hotel?");
            userInput = Console.ReadLine();

            // Sem validação porque não é o objetivo do exercício
            inputValue = int.Parse(userInput);

            for (int i = 1; i <= inputValue; i++)
            {
                currentPrice = basePrice / i;
                totalPrice += currentPrice;
                Console.WriteLine($"O preço da {i}ª noite é: {currentPrice:c}");
            }

            Console.WriteLine($"Preço Total é: {totalPrice:c}");

        }

        internal static void ExecutarExercicio14()
        {

            Utils.PrintHeader("Exercício 14");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Supondo que a população do país A é de 80 000 habitantes com";
            subHeader += "\numa taxa anual de crescimento de 3% e que a população do";
            subHeader += "\npaís B é 200 000 habitantes com uma taxa de crescimento";
            subHeader += "\nde 1.5%. Escreva um programa que calcule e escreva o";
            subHeader += "\nnúmero de anos necessários para que a população do país";
            subHeader += "\nA ultrapasse ou iguale a população do país B, mantidas as";
            subHeader += "\ntaxas de crescimento.";

            Utils.PrintSubHeader(subHeader);

            double populacaoA = 80000;
            double populacaoB = 200000;
            double taxaCrescimentoA = 0.03;
            double taxaCrescimentoB = 0.015;
            int anos = 0;

            while (populacaoB > populacaoA)
            {
                populacaoA += populacaoA * taxaCrescimentoA;
                populacaoB += populacaoB * taxaCrescimentoB;
                anos++;
            }

            Console.WriteLine($"\nSeriam necessários {anos} anos para que a" +
                $" população do país A igualasse" +
                $" ou ultrapassasse a população do país B.");

        }

        internal static void ExecutarExercicio15()
        {

            Utils.PrintHeader("Exercício 15");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escreva um programa que calcule o total das entradas a pagar";
            subHeader += "\nnum parque de diversões, sabendo que os bilhetes para";
            subHeader += "\ncrianças até aos 4 anos são grátis, dos 6 aos 12 são 6";
            subHeader += "\neuros, dos 12 aos 17 são 12 euros e para os adultos são 18";
            subHeader += "\neuros. O programa deverá pedir ao utilizador o número e";
            subHeader += "\ntipo de entradas.";

            Utils.PrintSubHeader(subHeader);

            string userInput;
            int entradas = 0;
            int tipoBilhete = 0;
            int custoTotal = 0;

            // Sem validação porque não é o objetivo do exercício
            Console.Write("Digite o nº de entradas que deseja comprar: ");
            userInput = Console.ReadLine();
            entradas = int.Parse(userInput);

            for (int i = 1; i <= entradas; i++)
            {
                Console.WriteLine($"\nQual é o tipo do {i}º bilhete?");
                Console.WriteLine("1 - Crianças até aos 4 anos");
                Console.WriteLine("2 - Crianças dos 4 aos 12 anos");
                Console.WriteLine("3 - Crianças dos 12 aos 17 anos");
                Console.WriteLine("4 - Adultos");
                userInput = Console.ReadLine();

                tipoBilhete = int.Parse(userInput);

                switch (tipoBilhete)
                {
                    case 1:
                        break;

                    case 2:
                        custoTotal += 6;
                        break;

                    case 3:
                        custoTotal += 12;
                        break;

                    case 4:
                        custoTotal += 18;
                        break;

                    default:
                        break;
                }

            }

            Console.WriteLine($"\nO custo total é {custoTotal:c}");

        }

        internal static void ExecutarExercicio16()
        {
            Utils.PrintHeader("Exercício 16");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escreva um programa que leia 20 números entre 10 e 30 (os";
            subHeader += "\nnúmeros lidos devem ser validados) e apresente o produto";
            subHeader += "\ndos que pertencerem ao intervalo [10,20].";

            Utils.PrintSubHeader(subHeader);

            string userInput;
            int currentNumber = 1;
            int inputValue;
            int product = 1;
            bool isNumeric, isValid;

            do
            {
                Console.Write($"Digite o {currentNumber}º número inteiro entre 10 e 30: ");
                userInput = Console.ReadLine();

                isNumeric = int.TryParse(userInput, out inputValue);

                if (isNumeric)
                {
                    isValid = (inputValue >= 10 && inputValue <= 30) ? true : false;
                    product *= (isValid && inputValue <= 20) ? inputValue : 1;
                    currentNumber += isValid ? 1 : 0;
                }

            } while (currentNumber <= 3);

            Console.WriteLine($"O produto dos números entre 10 e 20 é: {product}");

        }

    }

}
