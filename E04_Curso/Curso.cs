using D00_Utils;
using System;
using System.Collections.Generic;
using System.Text;

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

        private List<string> ReadInputs()
        {

            List<string> result = new List<string>();

            string cursoID, nomeCurso, numeroSessoes, numeroHorasPorSessao;

            Console.Write("Digite o ID do curso: ");
            cursoID = Console.ReadLine();

            Console.Write("Digite o nome do curso: ");
            nomeCurso = Console.ReadLine();

            Console.Write("Digite o nº de sessões do curso: ");
            numeroSessoes = Console.ReadLine();

            Console.Write("Digite o nº de horas por sessões do curso: ");
            numeroHorasPorSessao = Console.ReadLine();

            result.Add(cursoID);
            result.Add(nomeCurso);
            result.Add(numeroSessoes);
            result.Add(numeroHorasPorSessao);

            return result;

        }

        private void ValidateInputs(List<string> userInputs)
        {
            // Evitar atribuição de valores lidos diretamente às propriedades
            int cursoID, numeroSessoes, numeroHorasPorSessao;
            string nomeCurso;
            bool result;

            result = int.TryParse(userInputs[0], out cursoID);
            if (result)
            {
                CursoID = cursoID;
            }
            else
            {
                CursoID = listaCursos.Count + 1;
            }

            nomeCurso = userInputs[1];
            if (nomeCurso != string.Empty)
            {
                NomeCurso = TransformarNomeCursoMaiusculas(nomeCurso);
            }
            else
            {
                NomeCurso = $"Curso {CursoID}";
            }

            result = int.TryParse(userInputs[2], out numeroSessoes);
            if (result)
            {
                NumeroSessoes = numeroSessoes;
            }
            else
            {
                NumeroSessoes = 7;
            }

            result = int.TryParse(userInputs[3], out numeroHorasPorSessao);
            if (result)
            {
                NumeroHorasPorSessao = numeroHorasPorSessao;
            }
            else
            {
                NumeroHorasPorSessao = 3;
            }

        }

        #endregion

        #region Protected Methods

        protected internal void InserirCurso()
        {

            Utils4.PrintSubHeader("Novo curso");

            List<string> userInputs;

            userInputs = ReadInputs();
            ValidateInputs(userInputs);

            _ = CalcularNumeroHoras();

            listaCursos.Add(this);

        }

        protected internal static void ListarCurso(List<Curso> listaCursos)
        {
            
            StringBuilder sb = new StringBuilder();

            Console.Clear();
            Utils4.PrintSubHeader("Cursos disponíveis");
            Console.WriteLine();

            foreach (Curso item in listaCursos)
            {
                sb.Clear();
                sb.AppendLine($"Curso {item.CursoID}:");
                sb.AppendLine(new String('-', 10));
                sb.AppendLine($"-> Nome do curso: {item.NomeCurso}");
                sb.AppendLine($"-> Nº de sessões: {item.NumeroSessoes}");
                sb.AppendLine($"-> Horas por sessão: {item.NumeroHorasPorSessao}");
                sb.AppendLine($"-> Duração total do curso: {item.duracaoHoras} horas");
                sb.AppendLine(new String('-', 16));

                Console.WriteLine(sb.ToString());
            }
        }

        #endregion

    }
}
