using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymLibrary
{

    public static class TextConnectorProcessor
    {

        /// <summary>
        /// Represents the full path for the teaxt file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Full file path, including the file name</returns>
        public static string FullFilePath(this string fileName)
        {
            return $@"{GlobalConfig.FilePath}\{fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<IRequest> ConvertToRequests(this List<string> lines)
        {
            // Id, TrainerName, RequestDate, RequestStatus, CompletedAt, Message, MessageAt, 
            // 1,ptlag,01/07/2022 16:00,1,01/07/2022 16:00,mensagem,01/07/2022 16:00

            List<IRequest> output = new List<IRequest>();

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');

                IRequest request = new Request();

                request.Id = int.Parse(columns[0]);
                request.TrainerName = columns[1];
                request.RequestDate = DateTime.Parse(columns[2]);
                request.RequestStatus = (RequestStatus)int.Parse(columns[3]);
                request.CompletedAt = DateTime.Parse(columns[4]);
                request.Message = columns[5];
                request.MessageAt = DateTime.Parse(columns[6]);

                output.Add(request);
            }

            return output;
        }

        public static List<IUser> ConvertToUsers(this List<string> lines)
        {
            // id, Name, Password, Requests - id|id|id, IsLoggedIn 
            // 1,leandro,segredo, 1|3|6,0

            List<IUser> output = new List<IUser>();
            List<IRequest> requests = GlobalConfig.RequestsFile.FullFilePath().LoadFile().ConvertToRequests();

            foreach (var line in lines)
            {
                string[] columns = line.Split(',');

                IUser user = new RegisteredUser
                {
                    Id = int.Parse(columns[0]),
                    Name = columns[1],
                    Password = columns[2],
                    Requests = new List<IRequest>()
                };


                string[] requestIds = columns[3].Split('|');

                foreach (var id in requestIds)
                {
                    if (id != string.Empty)
                        user.Requests.Add(requests.FirstOrDefault(r => r.Id == int.Parse(id)));
                }
                user.IsLoggedIn = (LoginStatus)int.Parse(columns[4]);

                output.Add(user);
            }

            return output;
        }

        public static void SaveToRequestsFile(this List<IRequest> requests)
        {
            List<string> lines = new List<string>();
            IUser user = GlobalConfig.UsersFile
                                     .FullFilePath()
                                     .LoadFile()
                                     .ConvertToUsers()
                                     .First(u => u.IsLoggedIn == LoginStatus.LoggedIn);

            List<IRequest> newRequests = GlobalConfig.RequestsFile
                                                  .FullFilePath()
                                                  .LoadFile()
                                                  .ConvertToRequests()
                                                  .FindAll(r => requests.All(ur => ur.Id != r.Id));

            newRequests.AddRange(requests);

            newRequests = newRequests.OrderBy(r => r.Id).ToList();
            foreach (IRequest r in newRequests)
            {
                StringBuilder line = new StringBuilder();
                line.Append($"{r.Id},");
                line.Append($"{r.TrainerName},");
                line.Append($"{r.RequestDate},");
                line.Append($"{r.RequestStatus.GetHashCode()},");
                line.Append($"{r.CompletedAt},");
                line.Append($"{r.Message},");
                line.Append($"{r.MessageAt}");

                lines.Add(line.ToString());
            }

            File.WriteAllLines(GlobalConfig.RequestsFile.FullFilePath(), lines);
        }

        public static void SaveToUsersFile(this IUser user)
        {
            List<string> lines = new List<string>();
            List<IUser> users = GlobalConfig.UsersFile
                                            .FullFilePath()
                                            .LoadFile()
                                            .ConvertToUsers()
                                            .FindAll(u => u.Id != user.Id);
            // ToDo: Check is GuestUser
            if (user.GetType() != typeof(GuestUser))
            {
                users.Add(user);
            }

            users = users.OrderBy(u => u.Id).ToList();
            foreach (IUser u in users)
            {
                StringBuilder line = new StringBuilder();
                line.Append($"{u.Id},");
                line.Append($"{u.Name},");
                line.Append($"{u.Password},");
                line.Append($"{ConvertRequestsToString(u.Requests)},");
                line.Append($"{u.IsLoggedIn.GetHashCode()}");

                lines.Add(line.ToString());
            }

            File.WriteAllLines(GlobalConfig.UsersFile.FullFilePath(), lines);
        }

        public static string ConvertRequestsToString(List<IRequest> requests)
        {
            string output = (requests.Count == 0) ? string.Empty : string.Join("|", requests.Select(r => r.Id));

            return output;
        }

    }

}
