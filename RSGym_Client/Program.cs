using RSGym_DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{

    class Program
    {

        static void Main(string[] args)
        {

            try
            {

                //var user01 = new User
                //{
                //    Username = "leandro",
                //    Password = "secreto"
                //};

                //using (var context = new GymDbContext())
                //{
                //    context.User.Add(user01);
                //    context.SaveChanges();
                //}
                Console.Write("acabou");

            }
            catch (DbEntityValidationException e)
            {
                //Console.WriteLine(e.Message);
                StringBuilder errors = new StringBuilder();

                foreach (var validationException in e.EntityValidationErrors)
                {
                    errors.AppendLine($"Erro na validação dos dados:\n");
                    errors.AppendLine("Dado de entrada\t| Valor\t| Erro");
                    foreach (var ve in validationException.ValidationErrors)
                    {
                        errors.AppendLine($"{ve.PropertyName}\t| {validationException.Entry.CurrentValues.GetValue<object>(ve.PropertyName)}\t| {ve.ErrorMessage}");
                    }
                }
                Console.WriteLine(errors.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
            }

        }

    }

}
