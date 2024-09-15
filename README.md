# Learning-POO-04
Quarto curso de POO da Alura, agora estou aprofundando em collections

Resumo comparativo entre as diferentes estrutas de coleções em C# - Texto gerado por IA.
Array: Estrutura de tamanho fixo e fortemente tipada. Ótima para quando o tamanho é conhecido antecipadamente, com acesso rápido aos elementos, mas sem suporte para alterações dinâmicas no tamanho.

ArrayList: Coleção de tamanho dinâmico que pode armazenar objetos de qualquer tipo (object). Flexível, mas com desempenho inferior devido à necessidade de conversões de tipo (casting) e unboxing.

List<T>: Lista genérica de tamanho dinâmico e fortemente tipada. Oferece melhor desempenho que ArrayList, pois elimina a necessidade de conversão de tipo, além de ser segura em relação à tipagem e oferecer métodos avançados para manipulação de dados.

Resumo:
Array: Melhor para tamanho fixo e acesso rápido.
ArrayList: Flexível, mas menos eficiente e sem segurança de tipo.
List<T>: Ideal para coleções dinâmicas com segurança de tipo e bom desempenho.

| Característica           | Array               | ArrayList            | List<T>          |
|--------------------------|---------------------|----------------------|------------------|
| **Tamanho**              | Fixo                | Dinâmico             | Dinâmico         |
| **Tipagem**              | Fixa                | Dinâmica (`object`)  | Fixa (tipado)    |
| **Segurança de tipo**    | Alta                | Baixa (unboxing)     | Alta             |
| **Desempenho**           | Muito Alto          | Médio                | Alto             |
| **Facilidade de uso**    | Baixa (operações simples) | Alta (operações dinâmicas) | Alta (operações dinâmicas com tipagem) |
| **Métodos avançados**    | Não                 | Não                  | Sim              |
