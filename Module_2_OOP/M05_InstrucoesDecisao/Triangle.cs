namespace M05_InstrucoesDecisao;

internal class Triangle
{

    #region Properties

    public int SideA { get; set; }
    public int SideB { get; set; }
    public int SideC { get; set; }

    #endregion

    #region Constructors

    public Triangle()
    {

    }

    public Triangle(int[] sides)
    {
        SideA = Convert.ToInt16(sides[0]);
        SideB = Convert.ToInt16(sides[1]);
        SideC = Convert.ToInt16(sides[2]);
    }

    public Triangle(int sideA, int sideB, int sideC)
    {
        this.SideA = sideA;
        this.SideB = sideB;
        this.SideC = sideC;
    }

    #endregion

    #region Methods

    public bool isTriangle()
    {
        bool isTriangle = false;

        if ((SideA + SideB > SideC) & (SideA + SideC > SideB) & (SideB + SideC > SideA))
        {
            isTriangle = true;
        }

        return isTriangle;
    }

    public string GetTriangleType()
    {

        string trinagleType;

        if ((SideA == SideB) & (SideA == SideC))
        {
            trinagleType = "equilátero";
        }
        else if ((SideA == SideB) | (SideA == SideC) | (SideB == SideC))
        {
            trinagleType = "isósceles";
        }
        else
        {
            trinagleType = "escaleno";
        }

        return trinagleType;
    }

    #endregion

}