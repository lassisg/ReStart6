﻿# D17 Notes

## Alterar a precedência das operações matemáticas

- Matemática: {[()]}
- Programação: ((()))

## Concatenação

**Evitar conversão implícita!**

- Concatenação não deve ser feita com o operador +
  ```csharp
  Console.WriteLine("\nAluno inscrito no curso " + curso2);
  ```

- String interpolation: técnica correta para concatenar sem o +
  ```csharp
  Console.WriteLine($"\nAluno inscrito no curso {curso2}");
  ```

- StringBuilder: classe para manipular strings, nomeadamente concatenações

## Escape Sequence = caracter de escape

> https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170

- \n -> New line
- \t -> Tab
- \a -> Alert (sound)

## Método da Classe

> Método = method = bloco de código para executar uma ação

## Public / Private

- Por default, as classes são public
- Por default, os métodos são privados

## Data types = tipos de dados

Ao ler do console para uma variável do tipo bool, é preciso que a entrada seja 'true' ou 'false'

Categorias:
	
- value types:
  - standard data types
    > int, double, bool, ...						
	> data_type name [= value];

    ```csharp
    int valor1;
    double valor2 = 10.4;
    ```

- reference types: 
  - object (criados a partir de classes)
	> curso, fatura, string
	> data_type name = new data_type();

	```csharp
	Formando formando01 = new Formando();    // --> instanciar
	Formando formando02 = new Formando();    // --> instanciar
	
	Fatura fatura01 = new Fatura();          // --> ao instanciar invocamos o contrutor da classe
	```

### Tipos de memória nas aplicações de programação:

- stack: standard
- heap: objects

- objetos são geridos na heap

string é gerida pela heap, nõa editamos seu valor na memória.
ao editar um variável string, na verdade criamos um novo espaço na memória para o novo valor

Processo para destruir os reference types (objects)	-->	GC = Garbage Collector


### Processo para destruir os reference types (objects)

GC = garbage collector

## Classes

- Exemplos: Cliente, Fatura, Curso, Formando, ...

- Methods, métodos:
	- ações
	- ImprimirFatura();
	- Somar();

- Properties, propriedades
	- caraterísticas
	- NomeCliente = "asdsad";
	- NIFFormador = "123456789";
	- DataNascimentoFormando = new DateTime(2000, 01, 01);

- Events, eventos: 
	- acontecimentos na vida do objeto
	- FormandoAoInscrever()
	- FormadorAoNascer()
	- ClienteAoFaturar()

## Culture

- pt-PT
- pt-BR

## Estruturas programáticas

- Condicionais:
	- IF simples
	- IF...ELSE
	- IFs encadeados
	- IF...ELSEIF
	- SWITCH

- Ciclicas:
	- WHILE
	- DO...WHILE
	- FOR
	- FOREACH

## Carateres especiais na Consola

### Ativar o suporte a Unicode na consola

```csharp
Console.WriteLine("á é í ó ú ç ã â");
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("á é í ó ú ç ã â");
```

## Estruturas de dados: ARRAYS

- Vetor ou single-dimensional array: várias linhas x 1 coluna
- Matriz ou multi-dimensional array: várias linhas x várias colunas

## Estruturas de dados: COLLECTIONS

- Collections: lista de valores
- ArrayList = substituir os vetores; não é fortemente tipada
- List<...> = substituir a ArrayList; é fortemente tipada; Generics
  ```csharp
  List<Fatura>
  List<Cliente>
  List<Comida>
  List<int>
  ```

> Queue --> Fila --> FIFO (first-in, first-out)
>
> Stack --> Pilha --> LIFO (last-in, first-out)

## Calculadora v04

- 3 construtores
	- vazio
	- 2 valores
	- 2 valores e a operação
- 1 método para criar um menu com as operações
	- listar as operações usando 1 array e 1 estrutura iterativa
	- para sair do sair do menu carregar em 'x'
- 1 método para ler a operação do menu
- 1 método para validar a escolha do menu

> opcao = Console.ReadLine();

```csharp
Calculadora c1 = new Calculadora(1, 2, "+");	// 3
Calculadora c1 = new Calculadora(1, 2, opcao);	// 3
Calculadora c2 = new Calculadora(1, 2);			// 2
Calculadora c3 = new Calculadora();				// 1
```

## Dictionary - demo

- Pedir na consola um novo valor

- Ver te tem menos de 2 caracteres
  - Dizer que é nome errado

- Se for nome válido
  - Se existir
    - Dizer que é nome duplicado

  - Se não existir
    - Usando o valor criar a chave: 2 primeiros caracteres à esquerda em maíusculas
    - Pesquisar a nova chave
      - Se não existir
        - Adicionar a nova linha com o valor inserido na consola e a chave calculada
      - Se existir
        - Adicionar a nova linha com o valor inserido na consola e a chave com o nº incrementado (ex: FR2, FR3)

## GITHUB

Features:
- Repositório de código
- Versionamento de código
- Integração com VS

## ENUMS

> https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum

An enumeration type (or enum type) is a value type defined by a set of named constants of the underlying integral numeric type.
To define an enumeration type, use the enum keyword and specify the names of enum members

```csharp
enum Season
{
    Spring ,
    Summer,
    Autumn,
    Winter
}
```

## Exercício CARROS

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


## Structs vs Classes

> https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct
> https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct

- Classes
  - Reference types
  - Allocated on the heap and garbage-collected
  - Assignments of large reference types are cheaper than assignments of large value types.

- Structs
  - Value types
  - Allocated on the stack
  - Allocations and de-allocations of value types are in general cheaper than allocations and de-allocations of reference types
	
**CONSIDER**

- The use of a struct if instances of the type are small and commonly short-lived	
- It logically represents a single value, similar to primitive types (int, double, etc.)
- It has an instance size under 16 bytes
- It is immutable
- It will not have to be boxed (converted) frequently

## Regular Expression (REGEX)

> https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=net-6.0

- Qual o tipo de dado?
- É obrigatório?

## Aaccess Modifiers

- Public
- Private
- Internal
- Protected
- Protected Internal

## LINQ

O código: `name => name.Lenght > 5`

Lê-se: _**let name be = to name.Lenght > 5**_

- Estrutura da query:
  ```csharp
  collection.filtrar().ordenar().selecionar();
  collection
      .where()
      .orderby()
      .select();
  ```

## Abstract Class vs Interface

Abstract Class + Interface
- Podem conter:
  - propriedades
  - métodos
  - eventos
  - indexers

- Não podem ser instanciadas

Abstract Class
- Podem ter fields
- Podem ter construtores
- Podem usar access modifiers
- Podem ter implementações ou não
- Podem ter métodos estáticos

Interface
- Não podem ter fields
- Não podem ter construtores
- Não podem usar access modifiers
- É público por defeito
- Não podem ter implementação alguma
- Não podem ter métodos estáticos

> **C# não suporta múltipla herança de classes, mas de interfaces, sim**
