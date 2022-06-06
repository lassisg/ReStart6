using System;

namespace RSGymPT
{

    internal static class Backend
    {

        internal static bool ApproveRequest()
        {
            Random rnd = new Random();
            bool isApproved = rnd.Next(0, 2) != 0;

            return isApproved;
        }

    }

}
