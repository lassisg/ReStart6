using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_DAL
{

    public static class TrainerRepository
    {

        public static void CreateTrainer(Trainer newTrainer)
        {
            using (var context = new GymDbContext())
            {
                context.Trainer.Add(newTrainer);
                context.SaveChanges();
            }
        }

        public static Trainer GetTrainerById(int trainerID)
        {
            var trainer = new Trainer();

            using (var context = new GymDbContext())
            {
                trainer = context.Trainer
                    .Where(t => t.TrainerID == trainerID)
                    .Single();
            }

            return trainer;
        }

        public static List<Trainer> GetAllTrainers()
        {
            var trainers = new List<Trainer>();

            using (var context = new GymDbContext())
            {
                trainers = context.Trainer.ToList();
            }

            return trainers;
        }

        public static void UpdateTrainer(Trainer updatedTrainer)
        {
            using (var context = new GymDbContext())
            {
                var trainer = context.Trainer
                    .Where(t => t.Code == updatedTrainer.Code)
                    .Single();

                context.Entry(trainer).CurrentValues.SetValues(updatedTrainer);
                context.SaveChanges();
            }
        }

        public static List<Trainer> GetTopTrainer()
        {
            var trainers = new List<Trainer>();

            using (var context = new GymDbContext())
            {
                var allTrainers = context.Trainer.Include(r => r.Requests);
                int maxRequests = allTrainers.Max(o => o.Requests.Count());
             
                trainers = allTrainers.Where(f => f.Requests.Count() == maxRequests).ToList();
            }

            return trainers;
        }
    }

}
