namespace M05_InstrucoesDecisao;

internal class ZodiacSign
{

    #region Properties

    public string Name { get; set; }
    public DateTime InitialDate { get; set; }
    public DateTime EndDate { get; set; }

    #endregion

    #region Constructors

    public ZodiacSign()
    {

    }

    public ZodiacSign (string name, DateTime startDate, DateTime endDate)
    {
        Name = name;
        InitialDate = startDate;
        EndDate = endDate;
    }

    #endregion

    #region Methods

    public string GetZodiac(DateTime birthDate)
    {
        string zodiac = string.Empty;

        if (birthDate.Month >= InitialDate.Month && birthDate <= EndDate)
            zodiac = Name;

        return zodiac;
    }

    #endregion

}