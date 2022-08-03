using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{
    public interface ICommunicable
    {
        void BuildFeedbackMessage(string previous, int current);

    }
}
