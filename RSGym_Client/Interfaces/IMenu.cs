using System.Collections.Generic;

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
