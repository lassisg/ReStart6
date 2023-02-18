using D00_Utils;
using E04_Curso;

Utils.PrintHeader("E07: Cursos");

Curso c1 = new Curso();
c1.InserirCurso();

Curso c2 = new Curso();
c2.InserirCurso();

Curso c3 = new Curso();
c3.InserirCurso();

Curso.ListarCurso(Curso.listaCursos);

Utils.CleanConsole();