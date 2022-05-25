using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04_Curso
{
    internal class Curso
    {

        #region Fields / Variables

        private int duracaoHoras;
        protected int NumeroMedioSessoes = 10;
        private string nomeCurso;
        internal List<Curso> listaCursos = new List<Curso>();

        #endregion

        #region Properties

        internal string NomeCurso
        {
            get { return nomeCurso; }
            set { nomeCurso = value; }
        }
        internal int CursoID { get; set; }
        internal int NumeroSessoes { get; set; }
        internal int NumeroHorasPorSessoes { get; set; }

        #endregion

        #region Constructors

        internal Curso()
        {
            CursoID = 0;
            NomeCurso = string.Empty;
            NumeroSessoes = 0;
            NumeroHorasPorSessoes = 0;
            duracaoHoras = 0;
        }

        internal Curso(int cursoID, string nomeCurso, int numeroSessoes, int numeroHorasPorSessoes)
        {
            CursoID = cursoID;
            NomeCurso = TransformarNomeCursoMaiusculas(nomeCurso);
            NumeroSessoes = numeroSessoes;
            NumeroHorasPorSessoes = numeroHorasPorSessoes;
            duracaoHoras = CalcularNumeroHoras();
        }

        #endregion

        #region Private Methods

        private int CalcularNumeroHoras()
        {

            duracaoHoras = NumeroSessoes * NumeroHorasPorSessoes;

            return duracaoHoras;
        }

        private string TransformarNomeCursoMaiusculas(string nomeCurso)
        {
            
            NomeCurso = nomeCurso.ToUpper();
            
            return NomeCurso;

        }

        #endregion

        #region Protected Methods

        protected internal void InserirCurso()
        {
            // Método de instância void que pede os valores ao user,
            // guarda nas propriedades
            // e adiciona à lista
            Console.Write("Digite o ID do curso: ");
            CursoID = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do curso: ");
            NomeCurso = Console.ReadLine();

            Console.Write("Digite o nº de sessões do curso: ");
            NumeroSessoes = int.Parse(Console.ReadLine());

            Console.Write("Digite o nº de horas por sessões do curso: ");
            NumeroHorasPorSessoes = int.Parse(Console.ReadLine());

            listaCursos.Add(this);

        }

        protected internal static void ListarCurso(List<Curso> listaCursos)
        {
            // Método estático void que recebe a lista de cursos e mostra no ecrã:
            foreach (Curso item in listaCursos)
            {
                Console.WriteLine($"{item.CursoID} - {item.NomeCurso}, {item.NumeroSessoes} sessões ({item.NumeroHorasPorSessoes} horas por sessão).");
            }
        }

        #endregion

    }
}
