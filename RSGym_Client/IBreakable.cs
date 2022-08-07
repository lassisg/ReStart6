using System.Collections.Generic;

namespace RSGym_Client
{

    public interface IBreakable
    {

        List<(string, string)> Errors { get; set; }

    }

}
