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

### CLI general commands

| Command                           | Actions                                              |
| --------------------------------- | ---------------------------------------------------- |
| help                              | List available commands.                             |
| exit                              | Exit application.                                    |
| clear                             | Clear console.                                       |
| login -u {username} -p {password} | Login in application.<br>Consider 2 fictional users. |

### CLI user commands

| Command                                | Actions                                                                                                       |
| -------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| request -n {name} -d {day} -h {hour}   | Make a PT request informing: name, day and hour.<br>It is not allowed to exist duplicates.                    |
| cancel -r {request nr}                 | Cancel a request.<br>Validate request existence.                                                              |
| finish -r {request nr}                 | AUtomatic message with 'Finished class' status, automatic date and hour.<br>Validate request existence.       |
| message -r {request nr} -s {subject}   | Send absence message informing the reason, with automatic date and hour.<br>VValidate request existence.      |
| myrequest -r {request nr}              | List request info.<br>Validate request existence.                                                             |
| requests -a                            | List all user requests.                                                                                       |
