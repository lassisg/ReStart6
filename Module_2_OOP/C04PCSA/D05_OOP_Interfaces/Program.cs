namespace D05_OOP_Interfaces;

internal class Program
{

    static void Main(string[] args)
    {

        User user01 = new User("leandro", "pass");
        User user02 = new User("leonardo", "pass");
            
        bool isValidUser;

        Dictionary<string, string> users01 = new Dictionary<string, string>();
        users01.Add("leandro", "");
        users01.Add("leonardo", "pass");
        users01.Add("leandro", "pass");

        foreach (var user in users01)
        {
            isValidUser = user01.Validate(user.Key, user.Value);
            user01.Message($"User 1 é válido? {isValidUser}", "\n");
        }


        user01.Exit();


        Dictionary<string, string> users02 = new Dictionary<string, string>();
        users02.Add("leonardo", "");
        users02.Add("leandro", "pass");
        users02.Add("leonardo", "pass");

        foreach (var user in users02)
        {
            isValidUser = user02.Validate(user.Key, user.Value);
            user02.Message($"User 2 é válido? {isValidUser}", "\n");
        }

        user02.Exit();

    }

}