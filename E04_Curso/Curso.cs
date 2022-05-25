using D00_Utils;
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
        internal static List<Curso> listaCursos = new List<Curso>();

        #endregion
        
        #region Attributes

        private string nomeCurso;
        
        #endregion

        #region Properties

        internal string NomeCurso
        {
            get { return nomeCurso; }
            set { nomeCurso = value; }
        }
        internal int CursoID { get; set; }
        internal int NumeroSessoes { get; set; }
        internal int NumeroHorasPorSessao { get; set; }

        #endregion

        #region Constructors

        internal Curso()
        {
            CursoID = 0;
            NomeCurso = string.Empty;
            NumeroSessoes = 0;
            NumeroHorasPorSessao = 0;
            duracaoHoras = 0;
        }

        internal Curso(int cursoID, string nomeCurso, int numeroSessoes, int numeroHorasPorSessoes)
        {
            CursoID = cursoID;
            NomeCurso = TransformarNomeCursoMaiusculas(nomeCurso);
            NumeroSessoes = numeroSessoes;
            NumeroHorasPorSessao = numeroHorasPorSessoes;
            duracaoHoras = CalcularNumeroHoras();
        }

        #endregion

        #region Private Methods

        private int CalcularNumeroHoras()
        {

            duracaoHoras = NumeroSessoes * NumeroHorasPorSessao;

            return duracaoHoras;
        }

        private string TransformarNomeCursoMaiusculas(string nomeCurso)
        {
            
            // Se guardo algo na propriedade, não faz sentido devolvê-la, pq já é acessível
            //NomeCurso = nomeCurso.ToUpper();
            //return NomeCurso;

            return nomeCurso.ToUpper();

        }

        #endregion

        #region Protected Methods

        protected internal void InserirCurso()
        {
            Utils.PrintSubHeader("Novo curso");

            // TODO: v2 - Usar int.TryParse
            Console.Write("Digite o ID do curso: ");
            CursoID = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do curso: ");
            NomeCurso = TransformarNomeCursoMaiusculas(Console.ReadLine());

            Console.Write("Digite o nº de sessões do curso: ");
            NumeroSessoes = int.Parse(Console.ReadLine());

            Console.Write("Digite o nº de horas por sessões do curso: ");
            NumeroHorasPorSessao = int.Parse(Console.ReadLine());

            int numeroTotalHoras = CalcularNumeroHoras();

            listaCursos.Add(this);

        }

        protected internal static void ListarCurso(List<Curso> listaCursos)
        {
            
            StringBuilder sb = new StringBuilder();
            
            Utils.PrintSubHeader("Cursos disponíveis");

            foreach (Curso item in listaCursos)
            {
                sb.Clear();
                sb.AppendLine($"Curso {item.CursoID}:");
                sb.AppendLine($"\tNome do curso: {item.NomeCurso}");
                sb.AppendLine($"\tNº de sessões: {item.NumeroSessoes}");
                sb.AppendLine($"\tHoras por sessão: {item.NumeroHorasPorSessao}");
                sb.AppendLine($"\tDuração total do curso: {item.duracaoHoras} horas");

                Console.WriteLine(sb.ToString());
            }
        }

        #endregion

    }
}
