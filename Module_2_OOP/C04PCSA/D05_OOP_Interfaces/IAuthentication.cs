using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D05_OOP_Interfaces
{

    internal interface IAuthentication
    {

        #region MyRegion

        string UserName { get; }
        string UserPassword { get; }

        #endregion

        #region Methods

        bool Validate(string userName, string password);
        void Exit();
        void Message(string message, string startline = "", string endlline = "");
        
        #endregion

    }

}
