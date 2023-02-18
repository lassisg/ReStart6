using D00_Utils;
using System;

namespace E04_Curso
{

    class Program
    {

        static void Main(string[] args)
        {

            Utils4.PrintHeader("E07: Cursos");

            Curso c1 = new Curso();
            c1.InserirCurso();

            Curso c2 = new Curso();
            c2.InserirCurso();

            Curso c3 = new Curso();
            c3.InserirCurso();

            Curso.ListarCurso(Curso.listaCursos);

            Utils4.CleanConsole();

        }

    }

}
