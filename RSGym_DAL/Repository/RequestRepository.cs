using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RSGym_DAL
{

    public static class RequestRepository
    {

        public static void CreateRequest(Request newRequest)
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
                allRequests = context.Request.Include(t => t.Trainer).Select(r => r).ToList();
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

        public static void UpdateRequest(Request updatedRequest)
        {
            using (var context = new GymDbContext())
            {
                var request = context.Request
                    .Where(t => t.RequestID == updatedRequest.RequestID)
                    .Single();

                context.Entry(request).CurrentValues.SetValues(updatedRequest);
                context.SaveChanges();
            }
        }

        public static void DeleteRequestByID(int requestID)
        {
            using (var context = new GymDbContext())
            {
                var request = context.Request
                    .Where(t => t.RequestID == requestID)
                    .Single();

                context.Request.Remove(request);
                context.SaveChanges();
            }
        }

    }

}
