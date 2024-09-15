using Challenges.Modelos;
/*
Estudando arrays :) Lembrando sempre da estrutura de dados: arrays têm O(1) para consulta quando o índice é conhecido,
mas O(n) para inserção, já que os elementos precisam ser deslocados ou realocados 
*/
double[] arrayDeDoubles = { 1, 2, 3, 4, 5 };
Estatistica.Media(arrayDeDoubles);


/*
Estudo da classe genérica List
*/

// Dada uma lista abaixo, desenvolver uma função que fazer uma checagem se existe um elemento dentro da lista de nomeDosEscolhidos
List<string> nomesDosEscolhidos = new List<string>()
{
    "Bruce Wayne",
    "Carlos Vilagran",
    "Richard Grayson",
    "Bob Kane",
    "Will Farrel",
    "Lois Lane",
    "General Welling",
    "Perla Letícia",
    "Uxas",
    "Diana Prince",
    "Elisabeth Romanova",
    "Anakin Wayne"
};

bool ChecaElemento(List<string> listaParaChecar, string nome)
{
    return listaParaChecar.Contains(nome);
}

if(ChecaElemento(nomesDosEscolhidos, "Anakin Wayne") == true)
{
    Console.WriteLine("O elemento existe na lista");
}
 