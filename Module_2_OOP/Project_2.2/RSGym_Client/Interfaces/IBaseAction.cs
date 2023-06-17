using RSGym_DAL;

namespace RSGym_Client
{

    public interface IBaseAction
    {

        #region Properties

        char Code { get; set; }

        string Name { get; set; }

        IUser User { get; set; }

        MenuType MenuType { get; set; }

        bool Success { get; set; }

        string FeedbackMessage { get; set; }

        #endregion

        #region Methods

        void Execute(out bool isExit);

        #endregion

    }

}