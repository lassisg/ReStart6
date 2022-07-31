using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_Client
{

    public interface IMenu
    {

        #region Properties

        List<IMenuItem> MenuItems { get; set; }

        MenuType Type { get; set; }

        #endregion

        #region Methods

        void Show();

        #endregion

    }

}
