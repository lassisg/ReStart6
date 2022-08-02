using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{

    public class MenuItem : IMenuItem
    {

        #region Properties

        public char Code { get; set; }

        public string Description { get; set; }

        #endregion

        #region Contructors

        public MenuItem()
        {
            Code = '0';
            Description = string.Empty;
        }

        public MenuItem(char code, string description)
        {
            Code = code;
            Description = description;
        }

        #endregion


    }

}
