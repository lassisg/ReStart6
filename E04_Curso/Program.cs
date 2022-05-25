using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04_Curso
{

    class Program
    {

        static void Main(string[] args)
        {

            Curso c1 = new Curso();

            c1.InserirCurso();
            c2.InserirCurso();

            Curso.ListarCurso(c1.listaCursos);
            Console.ReadLine();

        }

    }

}
