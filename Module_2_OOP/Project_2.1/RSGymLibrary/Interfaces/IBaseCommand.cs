using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymLibrary
{

    public interface IBaseCommand
    {

        /* Comandos CLI Gerais
        Comando                                 Pattern         Ações
        help                                    Listar os comandos disponíveis na CLI.
        exit                                    Sair da aplicação.
        clear                                   Limpar a consola.
        login     -u {username} -p {password}   Fazer o login na aplicação.
        */

        // Considere 2 utilizadores fictícios.

        /* Comandos CLI do Utilizador
        Comando                                  Ações
        request   -n {nome} -d {data} -h {horas} Fazer o pedido do PT indicando: nome, dia e horas. Não pode haver pedidos duplicados.
        cancel    -r {nº pedido}                 Anular um pedido. Validar a existência do pedido.
        finish    -r {nº pedido}                 Mensagem automática com estado ‘aula concluída’, data e horas automáticas. Validar a existência do pedido.
        message   -r {nº pedido} -s {assunto}    Mensagem a informar o motivo, data e horas automáticas. Validar a existência do pedido.
        myrequest -r {nº pedido}                 Listar o pedido efetuado. Validar a existência do pedido.
        requests  -a                             Listar todos os pedidos efetuados. 
        */

        IUser CurrentUser { get; set; }

        string Name { get; }

        string HelpText { get; }

        Dictionary<string, string> Arguments { get; }

        string Pattern { get; }

        bool IsValid { get; set; }

        bool IsRestricted { get; }

        bool ValidateArguments(string inputCommand);

        bool Execute(Dictionary<string,string> inputArguments, out bool isExit);

    }

}
