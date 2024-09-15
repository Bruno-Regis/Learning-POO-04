using Projeto.Exceptions;
using Projeto.Modelos.Conta;

namespace Projeto.ByteBankAtendimento;
#nullable disable
internal class ByteBankAtendimento
{
    private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
{
    new ContaCorrente (034, "123-10"){Saldo=1560,Titular = new Cliente{Cpf="123456789",Nome= "João"}},
    new ContaCorrente (032, "123-20"){Saldo=160, Titular =  new Cliente{Cpf ="987654321", Nome= "Bruno"}},
    new ContaCorrente(034, "123-30") {Saldo = 156, Titular = new Cliente {Cpf = "100100100", Nome = "Mariana"}}
};
    public void MenuDeAtendimentoAoCliente()
    {
        char opcao = '0';
        try
        {
            while (opcao != '6')
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===       Atendimento       ===");
                Console.WriteLine("===1 - Cadastrar Conta      ===");
                Console.WriteLine("===2 - Listar Contas        ===");
                Console.WriteLine("===3 - Remover Conta        ===");
                Console.WriteLine("===4 - Ordenar Contas       ===");
                Console.WriteLine("===5 - Pesquisar Conta      ===");
                Console.WriteLine("===6 - Sair do Sistema      ===");
                Console.WriteLine("===============================");
                Console.WriteLine("\n\n");
                Console.Write("Digite a opção desejada: ");

                try
                {
                    opcao = Console.ReadLine()[0];
                }
                catch (Exception excecao)
                {

                    throw new ByteBankException(excecao.Message);
                }


                switch (opcao)
                {
                    case '1':
                        CadastrarConta();
                        break;
                    case '2':
                        ListarContas();
                        break;
                    case '3':
                        RemoverContas();
                        break;
                    case '4':
                        OrdenarContas();
                        break;
                    case '5':
                        PesquisarContas();
                        break;
                    default:
                        Console.WriteLine("Opcao não implementada.");
                        break;
                }
            }
        }
        catch (ByteBankException excecao)
        {
            Console.WriteLine($"{excecao.Message}");
        }

    }


    private void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===   CADASTRO DE CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("=== Informe dados da conta ===");
        Console.WriteLine("Número da agência");
        int numeroAgencia = int.Parse(Console.ReadLine());

        Console.Write("Número da conta: ");
        string numeroConta = Console.ReadLine();

        ContaCorrente conta = new(numeroAgencia, numeroConta);
        Console.WriteLine("Informe o nome do titular");
        conta.Titular.Nome = Console.ReadLine();

        Console.WriteLine("Informe o CPF do titular");
        conta.Titular.Cpf = Console.ReadLine();

        Console.WriteLine("Informe a profissão do titular");
        conta.Titular.Profissao = Console.ReadLine();

        Console.WriteLine("Informe o saldo inicial:");
        conta.Saldo = double.Parse(Console.ReadLine());

        _listaDeContas.Add(conta);

        Console.WriteLine("Conta cadastrada com sucesso!");
        Console.ReadKey();
    }

    private void ListarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===     LISTA DE CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");

        if (_listaDeContas.Count <= 0)
        {
            Console.WriteLine("Não há contas cadastradas no sistema");
            Console.ReadKey();
            return;
        }

        foreach (ContaCorrente conta in _listaDeContas)
        {
            //Console.WriteLine("===  Dados da Conta  ===");
            //Console.WriteLine("Número da Agência: " + conta.Numero_agencia);
            //Console.WriteLine("Número da Conta : " + conta.Conta);
            //Console.WriteLine("Saldo da Conta : " + conta.Saldo);
            //Console.WriteLine("Titular da Conta: " + conta.Titular.Nome);
            //Console.WriteLine("CPF do Titular  : " + conta.Titular.Cpf);
            //Console.WriteLine("Profissão do Titular: " + conta.Titular.Profissao);
            Console.WriteLine(conta.ToString());
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ReadKey();
        }
    }

    private void RemoverContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===   REMOÇÃO DE CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("Informe o número da conta: ");
        string numeroDaConta = Console.ReadLine();
        ContaCorrente contaARemover = null;

        foreach (ContaCorrente conta in _listaDeContas)
        {
            if (conta.Conta.Equals(numeroDaConta))
            {
                contaARemover = conta;
            }
        }

        if (contaARemover != null)
        {
            _listaDeContas.Remove(contaARemover);
            Console.WriteLine("Conta removida com sucesso!");
        }
        else
        {
            Console.WriteLine("A conta para remoção não foi encontrada");
        }

        Console.WriteLine("Aperte enter para sair");
        Console.ReadKey();
    }

    private void OrdenarContas()
    {
        // Para utilzar o método .Sort de listas, por se tratar de uma coleção de objetos deve-se implementar a Interface IComparable e configurar por qual parâmetro será configurado
        // Rever documentação quando for utilizar, pois se return 0, 1 ou -1 tem propósitos diferentes.
        Console.WriteLine("Lista de contas ordenada.");
        Console.ReadKey();
    }

    private void PesquisarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===   PESQUISA DE CONTAS ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("Deseja pesquisar por (1) número da conta, (2) CPF do cliente, (3) número da agência ?");

        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                {
                    Console.WriteLine("Informe o número da conta: ");
                    string numeroDaConta = Console.ReadLine();
                    ContaCorrente consultaConta = ConsultaPorNumeroConta(numeroDaConta);
                    Console.WriteLine(consultaConta.ToString());
                    Console.ReadKey();
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Informe o CPF do cliente: ");
                    string cpfDaConta = Console.ReadLine();
                    ContaCorrente consultaCpf = ConsultaPorCPF(cpfDaConta);
                    Console.WriteLine(consultaCpf.ToString());
                    Console.ReadKey();
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Informe o número da agência ára filtrar ");
                    int numeroDaAgencia = int.Parse(Console.ReadLine());
                    var consultaAgencia = ConsultaPorAgencia(numeroDaAgencia);
                    ExibirListaDeContas(consultaAgencia);
                    Console.ReadKey();
                    break;
                }
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }

    private ContaCorrente ConsultaPorCPF(string? cpfDaConta)
    {
        // LINQ da maneira mais enxuta.. acho que gosto bastante dela, lembra muito python...
        return _listaDeContas.Where(conta => conta.Titular.Cpf.Equals(cpfDaConta)).FirstOrDefault();
    }

    private ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
    {
        // É Possível escrever LINQ de forma muito semelhante à linguagem SQL =O
        return (from conta in _listaDeContas
                where conta.Conta == numeroConta
                select conta).FirstOrDefault();
    }
    private List<ContaCorrente> ConsultaPorAgencia(int agencia)
    {
        var consulta = (from conta in _listaDeContas
                        where conta.Numero_agencia == agencia
                        select conta).ToList();
        return consulta;
    }

    private void ExibirListaDeContas(List<ContaCorrente> consultaAgencia)
    {
        if (consultaAgencia == null)
        {
            Console.WriteLine("A consulta não retornou dados");
        }
        else
        {
            foreach (ContaCorrente conta in consultaAgencia)
            {
                Console.WriteLine(conta.ToString());
            }
        }
    }
}
