using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RSGym_DAL
{

    public static class RequestRepository
    {

        #region CRUD Methods

        public static void Create(Request newRequest)
        {

            using (var context = new GymDbContext())
            {
                context.Request.Add(newRequest);

                context.SaveChanges();
            }

        }

        public static Request GetRequestById(int requestId)
        {

            Request request;

            using (var context = new GymDbContext())
            {
                request = context.Request.Include(t => t.Trainer).FirstOrDefault(r => r.RequestID == requestId);
            }

            return request;

        }

        public static List<Request> GetAllRequests()
        {

            var allRequests = new List<Request>();

            using (var context = new GymDbContext())
            {
                allRequests = context.Request.Select(r => r).ToList();
            }

            return allRequests;

        }

        public static List<Request> GetRequestsByUserID(int userID)
        {

            var allRequests = new List<Request>();

            using (var context = new GymDbContext())
            {
                allRequests = context.Request.Where(r => r.UserID == userID).Include(t => t.Trainer).ToList();
            }

            return allRequests;

        }

        public static int GetTotalRequests()
        {
            int requestCount;

            using (var context = new GymDbContext())
            {
                requestCount = context.Request.Count();
            }

            return requestCount;
        }

        public static int GetTotalRequestsByUserID(int userID)
        {
            int requestCount;

            using (var context = new GymDbContext())
            {
                requestCount = context.Request.Where(r => r.UserID == userID).Count();
            }

            return requestCount;
        }

        public static int GetTotalRequestsByTrainerID(int trainerID)
        {
            int requestCount;

            using (var context = new GymDbContext())
            {
                requestCount = context.Request.Where(r => r.TrainerID == trainerID).Count();
            }

            return requestCount;
        }

        public static Dictionary<string, int> GetRequestsByStatus()
        {
            var allRequests = new Dictionary<string, int>();

            using (var context = new GymDbContext())
            {
                context.Request.ToList().GroupBy(r => r.Status).ToList().ForEach(r => allRequests.Add(r.Key.ToString(), r.Count()));
            }

            return allRequests;
        }

        public static Dictionary<int, int> GetRequestsByTrainer()
        {
            var allRequests = new Dictionary<int, int>();

            using (var context = new GymDbContext())
            {
                context.Request.ToList().GroupBy(r => r.TrainerID).ToList().ForEach(r => allRequests.Add(r.Key, r.Count()));
            }

            return allRequests;
        }

        #endregion

    }

}
