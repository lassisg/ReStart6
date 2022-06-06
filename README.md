# Primavera Academy | ReStart 6 | OOP

## Project II (1) - RSGymPT | 2022-05

### System description

The RSGym gym intends to expand its range of offer in a highly competitive market, offering the service of personal trainer (PT) classes at home. This new service is supported by the RSGymPT application, to be developed in this project.

Gym users use the application to send a message requesting the service, after which they receive confirmation from the gym. For each order, the system assigns a unique identifier and sequential, which must accompany all order messages. The order is received by the gym that coordinates the allocation of the PT and confirms the service with the client.

When the class ends, the client sends a message with the status 'class completed' and automatic date and time. If the class has not taken place, send a message informing the reason, with automatic date and time. All messages must be associated with the order number.

The application is a command line system, known as CLI (Command Line Interface).

### CLI development

A CLI application has great flexibility in executing commands. Although initially not as simple for the user as a menu, it is faster when you master the commands and their arguments.

Whenever the command is wrong, the list of available commands should be displayed.

### Comandos CLI Gerais

| Comando                           | Ações                                                              |
| --------------------------------- | ------------------------------------------------------------------ |
| help                              | Listar os comandos disponíveis na CLI.                             |
| exit                              | Sair da aplicação.                                                 |
| clear                             | Limpar a consola.                                                  |
| login -u {username} -p {password} | Fazer o login na aplicação.<br>Considere 2 utilizadores fictícios. |

### Comandos CLI do Utilizador

| Comando                                | Ações                                                                                                         |
| -------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| request -n {nome} -d {data} -h {horas} | Fazer o pedido do PT indicando: nome, dia e horas.<br>Não pode haver pedidos duplicados.                      |
| cancel -r {nº pedido}                  | Anular um pedido.<br>Validar a existência do pedido.                                                          |
| finish -r {nº pedido}                  | Mensagem automática com estado ‘aula concluída’, data e horas automáticas.<br>Validar a existência do pedido. |
| message -r {nº pedido} -s {assunto}    | Mensagem a informar o motivo, data e horas automáticas.<br>Validar a existência do pedido.                    |
| myrequest -r {nº pedido}               | Listar o pedido efetuado.<br>Validar a existência do pedido.                                                  |
| requests -a                            | Listar todos os pedidos efetuados.                                                                            |
