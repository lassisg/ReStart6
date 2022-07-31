﻿using System;
using System.Collections.Generic;
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
                request = context.Request.FirstOrDefault(u => u.RequestID == requestId);
            }

            return request;

        }

        public static List<Request> GetAllRequests()
        {

            var allRequests = new List<Request>();

            using (var context = new GymDbContext())
            {
                allRequests = context.Request.Select(u => u).ToList();
            }

            return allRequests;

        }

        #endregion

    }

}
