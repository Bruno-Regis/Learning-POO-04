using Projeto.Modelos.Conta;

namespace Projeto.ByteBankUtil
{
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _contas = null; // Lembrando, primeiro passo o tipo de variável, no caso é um objeto ContaCorrente e depois crio o array []
        private int _proximaPosicao = 0;
        public ListaDeContasCorrentes(int tamanhoInicial = 5)
        {
            _contas = new ContaCorrente[tamanhoInicial];
        }

        public void Adicionar(ContaCorrente contaCorrente)
        {
            Console.WriteLine($"Adicionando conta na posição {_proximaPosicao}");
            VerificarCapacidade(_proximaPosicao + 1);
            _contas[_proximaPosicao] = contaCorrente;
            _proximaPosicao++;
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if(_contas.Length >= tamanhoNecessario)
            {
                return;
            }

            Console.WriteLine("Estamos aumentando a capacidade do array!");
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

            for(int i = 0; i < _contas.Length; i++)
            {
                novoArray[i] = _contas[i];               
            }

            _contas = novoArray;
        }

        public void RemoverConta(ContaCorrente conta)
        {
            // Defini indiceItem = -1 só para ter um valor atribuído
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente contaAtual = _contas[i];
                if(contaAtual == conta)
                {
                    indiceItem = i;
                    break;
                }
            }

            // visualizando a lógica do que está sendo feito:
            //     0        1       2        3        4
            // conta[1] conta[2] conta[3] conta[4] conta[5]
            for (int i = indiceItem; i < _proximaPosicao-1; i++)
            {
                _contas[i] = _contas[i + 1];
            }
            _proximaPosicao--;
            _contas[_proximaPosicao] = null;
        }

        public void ExibirContas()
        {
            for (int i = 0; i < _contas.Length; i++)
            {
                if(_contas!=null)
                {
                    var conta = _contas[i];
                    Console.WriteLine($"{conta.Numero_agencia} | {conta.Conta} | R${conta.Saldo}");
                }
                else
                {
                    Console.WriteLine("Não há nenhuma conta cadastrada.");
                }
            }
        }

        public void ObterMaiorsaldo()
        {
            List<double> listaDeSaldo = new();
            ;
            for (int i = 0; i < _contas.Length; i++)
            {
                if (_contas[0]!=null)
                {
                    listaDeSaldo.Add(_contas[i].Saldo);
                }               
            }

            double maiorSaldo = listaDeSaldo.Max();
            // Obtem index de maior valor
            int indexDaLista = listaDeSaldo.IndexOf(maiorSaldo);
            ContaCorrente contaComMaiorSaldo = _contas[indexDaLista];
            Console.WriteLine($"A conta com o maior saldo é a {contaComMaiorSaldo.Conta}\nsaldo:{maiorSaldo}");
        }
    }
}