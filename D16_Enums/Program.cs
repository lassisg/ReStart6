using System;
using System.ComponentModel;

namespace D16_Enums
{

    class Program
    {

        enum Weekdays
        {
            Monday,     // 0
            Tuesday,    // 1
            Wednesday,  // 2
            Thursday,   // 3
            Friday,     // 4
            Saturday,   // 5
            Sunday      // 6
        }

        enum Classification
        {
            // Não tem interesse!
            // A ideia das enums é ter um shortcut para um nº e não um friendly name
            [Description("Very good")]
            VeryGood = 90,    
            Good = 80,        
            Medium = 60,      
            Bad = 20          
        }

        static void Main(string[] args)
        {

            #region Enum Weekdays com variáveis fazendo cast
            int weekday = (int)Weekdays.Wednesday;
            Console.WriteLine($"{weekday} \n\n");

            var day = (Weekdays)2;
            Console.WriteLine($"{day} \n\n");
            #endregion           

            #region Enum Classification com Switch
            Classification classification = Classification.VeryGood;

            switch (classification)
            {
                case Classification.VeryGood:
                    Console.WriteLine($"{(int)classification} - {classification} ---> Master");
                    break;
                case Classification.Good:
                    Console.WriteLine($"{(int)classification} - {classification} ---> Next");
                    break;
                case Classification.Medium:
                    Console.WriteLine($"{(int)classification} - {classification} ---> Same");
                    break;
                case Classification.Bad:
                    Console.WriteLine($"{(int)classification} - {classification} ---> Previous");
                    break;
                default:
                    break;
            }
            #endregion

            Console.ReadKey();

        }

    }

}
