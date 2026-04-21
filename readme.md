## O Projeto Caderninho

A publicação de projetos de estudo é uma etapa fundamental para a consolidação do aprendizado técnico. Confesso que venho relutando em adotar esta prática, muitas vezes por insegurança, mas entendo que é algo que de fato agrega conhecimento a partir do momento que uma publicação é realizada. Este artigo detalha o desenvolvimento do Projeto Caderninho, uma aplicação de edição de texto simples, desenvolvida em C# durante o curso de fundamentos da plataforma Balta.io.

### O Conceito do Projeto

O objetivo central foi aplicar conhecimentos de manipulação de arquivos e lógica de programação em uma interface de console que prioriza a organização e a acessibilidade visual. Parto do princípio de que a simplicidade de uma aplicação não justifica a falta de cuidado com a interface e com a experiência do usuário final.

O sistema foi estruturado de forma modular para garantir a separação de responsabilidades, utilizando como base um fluxograma criado para direcionar a construção do projeto.

*Classe Menu (MenuCaderninho.cs)*
Esta classe gerencia a interação com o usuário. Foram implementados métodos específicos para a construção da interface:

- *MenuInicial() e Show()*: Responsáveis pela lógica de navegação principal através de estruturas de decisão (switch).
- *Cabecalho(), LinhaSeparadora(), Corpo() e RodaPe()*: Métodos dedicados à construção da moldura visual do software.

*Gestão de Arquivos e Métodos Funcionais*
A lógica de persistência e manipulação de dados foi concentrada em métodos que simulam o fluxo de um software de edição real:

- *Métodos Criar e Salvar*: O sistema permite a entrada de texto pelo usuário, que é posteriormente capturado e armazenado através do mapeamento do caminho (path) informado.
- *Método Abrir*: Implementa a busca por arquivos existentes. Inclui um tratamento de exceções básico: caso o arquivo não seja localizado, o usuário é notificado e redirecionado para novas opções de ação.

*Método EditorTextoSimples*: Desenvolvido para permitir a inclusão de conteúdo em arquivos já existentes, reforçando a lógica de edição incremental. Além disso, visando a escalabilidade do projeto, implementei o método MenuEditar()  que foi estruturado para servir como um ponto de expansão, reservando o espaço necessário para o crescimento do sistema e a futura implementação de funções avançadas de texto.

- *Método Remover*: Responsável pela exclusão de arquivos e manutenção do diretório.

### Fluxo de Operação e Usabilidade

Para aprimorar a experiência de uso, foram incluídos métodos de apoio:

- *Método Carregando*: Gera um feedback visual de processamento, informando ao usuário que uma ação está em execução.
- *Métodos ProximoPasso e AlgoMais*: Estes métodos garantem a continuidade da execução, evitando o encerramento abrupto do programa e permitindo que o usuário realize múltiplas tarefas em uma única sessão.
- *Método Encerrar*: Finaliza a aplicação de forma segura.

O Projeto Caderninho serviu como um laboratório para a prática de fundamentos essenciais em C#, como manipulação de arquivos (System.IO), modularização de métodos e lógica de navegação. A experiência demonstra que a atenção aos detalhes visuais e à estrutura de código é válida em qualquer nível de desenvolvimento, independentemente da complexidade da ferramenta.

## Fluxograma do projeto

![Fluxograma](https://github.com/Larinezen/Caderninho/blob/master/caderninho-fluxo.png?raw=true)
