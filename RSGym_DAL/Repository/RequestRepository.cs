using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion

    }

}
