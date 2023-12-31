# Observações importantes

> Evitar conversão implícita!

### Alterar a precedência das operações matemáticas

- Matemática  `{[()]}`
- Programação `((()))`

### Concatenação

Concatenação não deve ser feita com o operador '**+**'

- **String interpolation**: técnica correta para concatenar sem o '**+**'
- **StringBuilder**: classe para manipular strings, nomeadamente concatenações


### Escape Sequence 
> https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170

- `\n` -> New line
- `\t` -> Tab
- `\a` -> Alert (sound)


### Tipos de dados

Ao ler do console para uma variável do tipo bool, é preciso que a entrada seja 'true' ou 'false'

### Método

Método = method = bloco de código para executar uma ação

### Public / Private

- Por default, as classes são public
- Por default, os métodos são privados

### Data types = tipos de dados

Categorias:

* value types: int, double, bool			-->	standard

  data_type variableName [= value]

  int valor1;
  double valor2 = 10.4;


* reference types: curso, fatura, (string)	-->	objects (criados a partir de classes)

  data_type variableName = new data_type();

  Formando formando01 = new Formando();		--> instanciar
  Formando formando02 = new Formando();		--> instanciar

  Fatura fatura01= new Fatura();				--> ao instanciar, invocamos o construtor da classe
  Produto produto01 = new Produto()			--> instanciar


Tipos de memória nas aplicações:
* stack	-->	standard
* heap	-->	objects

objetos são geridos na heap

string é gerida pela heap, nõa editamos seu valor na memória.
ao editar um variável string, na verdade criamos um novo espaço na memória para o novo valor

Processo para destruir os reference types (objects)	-->	GC = Garbage Collector

### Classes

- **Exemplos**: Cliente, Fatura, Curso, Formando, ...

- **Acções**: methods, métodos
  - ImprimirFatura();
  - Somar();

- **Características**: properties, propriedades
  - NomeCLiente = "Fulano";
  - NIFFormador = "123456789";
  - DataNascimentoFormando = new DateTime (2000, 01, 01);

- **Gatilhos**: events, eventos
  - acontecimentos na vida do objeto
  - FormadorAoInscrever()
  - FormadorAoNascer()
  - ClienteAoFaturar()

### Precedência dos tipos de dados


### Estruturas programáticas

- Condicionais:
  - IF simples
  - IF ... ELSE
  - IFs encadeados
  - IF ... ELSEIF
  - SWITCH

- Cíclicas:
  - WHILE
  - DO ... WHILE
  - FOR
  - FOREACH

### Estruturas de dados: ARRAYS

- _**Vetor**_ ou _**single-dimensional array**_: várias linhas x 1 coluna
- _**Matriz**_ ou _**multi-dimensional array**_: várias linhas x várias colunas

### Estruturas de dados: COLLECTIONS

- **Collections**: lista de valores

  - ArrayList = substituir vetores; não é fortemente tipada (permite elementos de tipos diferentes)

  - List<...> = substituir a ArrayList; é fortemente tipada; Generics
    - List<fatura>
    - List<clientes>
    - List<comida>
    - List<int>

### Dictionary - demo

- Pedir na consola um novo valor
- Ver te tem menos de 2 caracteres
- Dizer que é nome errado

- Se for nome válido
  - Se existir
  - Dizer que é nome duplicado

  - Se não existir
    - Usando o valor, criar a chave: 2 primeiros caracteres à esquerda em maíusculas
        
	- Pesquisar a nova chave
      - Se não existir
        - Adicionar a nova linha com o valor inserido na consola e a chave calculada
      - Se existir
        - Adicionar a nova linha com o valo inserido na consola e a chave com o nº incrementado (ex: FR2, FR3)

### Carateres especiais na Consola

#### Ativar o suporte a Unicode na consola

- Console.WriteLine("á é í ó ú ç ã â");
- Console.OutputEncoding = System.Text.Encoding.UTF8;
- Console.WriteLine("á é í ó ú ç ã â");

### Exercício CARROS

- Tratamento de erros

- Propriedades
  - Marca: uma enumeração de 3 marcas
  - Modelo: uma enumeração de 6 modelos
  - Cor: uma enumeração de 5 cores
  - Matricula
  - Cilindrada
  - Velocidade
  - Data de registo

- Construtores
  1. O default com tudo vazio e a zero
  2. Cria um carro da marca 'Bólide', do modelo 'Novo Bólide', com 1000 de cilindrada.
  3. Um carro que receba os parâmetros de entrada

- Destrutor
  - Diz que o carro vai para a sucata

- Métodos
  - Criar: criar o carro pedindo os valores ao user
  - Parar: velocidade passa a zero
  - Acelerar: incrementa a velocidade com o valor de aceleração
  - Desacelerar: decrementa a velocidade com o valor de desaceleração

### Structs vs Classes

- Classes
  - Reference types
  - Allocated on the heap and garbage-collected
  - Assignments of lalrge reference types are cheaper than assignments of large value types

- Structs
  - Value types
  - Allocated on the stack
  - Allocations and de-allocations of value types are in general cheaper than allocation and de-allocation of


### Regular Expression (REGEX)

> https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=net-6.0

### Aaccess Modifiers

- Public
- Private
- Internal
- Protected
- Protected Internal

### LINQ

- **O código**: name => name.Lenght > 5
- **Lê-se**: let name be = to name.Lenght > 5

- Estrutura da query:

  - collection.filtrar().ordenar().selecionar()
  - collection.where().orderby().select()
  