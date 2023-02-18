namespace D03_DataTypes;

class Curso
{

    // Class elements - methods, properties, events

    #region Fields (devem ser privados)

    string nome;

    #endregion

    #region Properties (devem ser publicas) : auto-implemented

    public int CursoID { get; set; }
    public string Nome { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public double numeroHoras { get; set; }

    #endregion

}