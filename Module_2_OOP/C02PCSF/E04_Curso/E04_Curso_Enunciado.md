# E04 Curso

## Classe

Classe _Curso_ para ser usada somente na mesma assembly	


## Variáveis

- Variável para uso interno da classe: _**duracaoHoras**_
- Variável da classe ou derivadas, com valor 10: _**numeroMedioSessoes**_
- Variável para ter uma coleção de valores: _**listaCursos**_
	
## Atributo
	
Atributo de suporte à propriedade clássica NomeCurso: _**nomeCurso**_

## Propriedades públicas à assembly:

- Propriedade clássica: _**NomeCurso**_
- Propriedades automáticas: _**CursoID**_, _**NumeroSessoes**_, _**NumeroHorasPorSessao**_

## Métodos privados à classe:

- Método para calcular a duração total de horas, guardar na respetiva variável e devolver: _**CalcularNumeroHoras**_
- Método para transformar e devolver o nome do curso em maiúsculas: _**TransformarNomeCursoMaiusculas**_
	
## Métodos da classe ou derivadas:

- Método de instância void que pede os valores ao user, guarda nas propriedades e adiciona à lista: _**InserirCurso**_
- Método estático void que recebe a lista de cursos e mostra no ecrã: _**ListarCurso**_

## Testar

Usar o Main para testar a classe
