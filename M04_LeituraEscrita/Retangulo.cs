using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M04_LeituraEscrita
{
    internal class Retangulo
    {

        #region Properties

        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Area { get; set; }

        #endregion

        #region Constructors

        public Retangulo() 
        { 
            Altura = 0; 
            Largura = 0; 
            Area = 0;
        }
        public Retangulo(int altura, int largura) 
        {
            Altura = altura;
            Largura = largura; 
        }

        #endregion

        #region Methods

        public void CalcularArea() => Area = Altura * Largura;

        #endregion

    }
}
