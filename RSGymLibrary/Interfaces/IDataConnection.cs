using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymLibrary
{

    internal interface IDataConnection
    {

        void CreateUser(IUser user);
        
        void UpdateUser(IUser user);
        
        void CreateRequest(IRequest request);
        
        void UpdateRequest(IRequest request);
        
        List<IUser> GetAllUsers();
        
        List<IRequest> GetAllRequests();

    }

}
