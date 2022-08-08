using RSGym_DAL;
using System.Collections.Generic;

namespace RSGym_Client
{

    public interface IBreakable
    {

        List<RequestError> Errors { get; set; }

    }

}
