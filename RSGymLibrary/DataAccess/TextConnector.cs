using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymLibrary
{

    internal class TextConnector : IDataConnection
    {
        public void CreateRequest(IRequest request)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public List<IRequest> GetAllRequests()
        {
            return GlobalConfig.RequestsFile.FullFilePath().LoadFile().ConvertToRequests();
        }

        public List<IUser> GetAllUsers()
        {
            //return GlobalConfig.UsersFile.FullFilePath().LoadFile().ConvertToUsers();
            throw new NotImplementedException();
        }

        public void UpdateRequest(IRequest request)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(IUser user)
        {
            throw new NotImplementedException();
        }
    }

}
