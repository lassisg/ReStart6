using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{

    public interface IMenuItem
    {

        #region Properties

        char Code { get; set; }

        string Description { get; set; }

        #endregion

    }

}
