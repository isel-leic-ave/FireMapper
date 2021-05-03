**DATA LIMITE de entrega**: 23 de Maio de 2021. Fazer _push_ a tag `trab3` no repositório do grupo.

**Objectivos**: Análise e manipulação programática de código intermédio com API
de `System.Reflection.Emit`.

No seguimento do Trabalho 1 desenvolvido na biblioteca **FireMapper**
pretende-se desenvolver uma nova classe `DynamicDataMapper` que implementa
`IDataMapper`, mas que ao contrário de `FireDataMapper` **NÃO usa reflexão no
acesso (leitura ou escrita) das propriedades das classes de domínio**. 
Note, que **continuará a ser usada reflexão na consulta** da
_metadata_, deixando apenas de ser usada reflexão em operações como
`<property>.SetValue(…)` ou `<property>.GetValue(…)`.
O acesso a propriedades passa a ser realizado directamente com base em código IL
emitido em tempo de execução através da API de `System.Reflection.Emit`. 

Para tal, `DynamicDataMapper` deve gerar em tempo de execução implementações, em
que **cada tipo** implementa o acesso a uma determinada propriedade de uma
classe de domínio.

## Etapa 0 - TPC06 - `System.Reflection`

Ainda usando apenas a Reflection API (sem Emit) reorganize o projecto resultante
do Trabalho 1 de modo a que `FireDataMapper` mantenha uma estrutura de dados com
um tipo de elemento (interface) que define a API de acesso a uma propriedade de
uma classe de domínio.

Esta interface deve ter implementações diferentes, consoante represente o acesso
a uma propriedade "simples" (_string_ ou primitivo) ou "complexa" (do tipo de
outra classe de domínio).


## Etapa 1 - `System.Reflection.Emit`

Implemente `DynamicFireMapper` que gera dinamicamente implementações da
interface definida na Etapa 0, para cada propriedade de cada classe de
domínio acedida pelo Logger.

Implemente testes unitários que validem o correcto funcionamento de `DynamicFireMapper`.

***
### Abordagem de desenvolvimento

Como suporte ao desenvolvimento de `DynamicFireMapper` deve usar as ferramentas:
  * `ildasm`
  * `peverify`

Deve desenvolver em C# uma classe _dummy_ num projecto separado com uma
implementação semelhante aquela que pretende que seja gerada através da API de
`System.Reflection.Emit`. 
Compile a classe _dummy_ e use a ferramenta `ildasm` para visualizar as instruções
IL que servem de base ao que será emitido através da API de `System.Reflection.Emit`. 

Grave numa DLL as classes geradas pelo `DynamicFireMapper` e valide através da ferramenta 
`peverify` a correcção do código IL.

## Etapa 2 - Benchmarking

Implemente uma aplicação consola num outro projecto **FireMapperBench** da mesma
solução para comparar o desempenho dos métodos entre as classes `FireDataMapper`
e `DynamicDataMapper`.

Para as medições de desempenho **use a abordagem apresentada nas aulas**.
Registe e comente os desempenhos obtidos entre as duas abordagens. 

**Atenção:**
* **testes de desempenho NÃO são testes unitários**
* Use `WeakDataSource` nas medidas de desempenho.
* Evite IO.
