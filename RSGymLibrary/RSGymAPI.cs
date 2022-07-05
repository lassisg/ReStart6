using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymLibrary
{

    internal static class RSGymAPI
    {

        internal static bool ApproveRequest()
        {
            Random rnd = new Random();
            bool isApproved = rnd.Next(0, 2) != 0;

            return isApproved;
        }

    }

}
