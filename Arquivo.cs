using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace Caderninho
{
    internal class Arquivo
    {
        // Está classe é responsável por criar o arquivo de texto onde as informações do caderninho serão armazenadas e manipuladas.

        public static void Criar()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Menu.Show("CRIAR ARQUIVO");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("Digite o nome do arquivo: ");
            Console.SetCursorPosition(1, 4);
            Console.Write(" ");
            var nome = Console.ReadLine();
            var directory = @"C:\Projetos\Caderninho\";
            var path = Path.Combine(directory, $"{nome}.txt");

            Console.Clear();
            Menu.LinhaSeparadora();
            Console.WriteLine("  Digite o conteúdo do arquivo (Digite OK para finalizar):");
            Menu.LinhaSeparadora();
            var conteudo = new StringBuilder();

            while (true)
            {
                var linha = Console.ReadLine();
                if (linha.Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                conteudo.AppendLine(linha);

            }
            var textoFinal = conteudo.ToString();
            Carregando();
            Console.WriteLine("Estamos processando seu arquivo...");
            Thread.Sleep(2000);
            Console.WriteLine("Arquivo criado com sucesso!");
            Console.WriteLine(" ");
            Menu.LinhaSeparadora();
            Console.WriteLine(" ");
            Console.Write(textoFinal);
            Console.WriteLine(" ");
            Menu.LinhaSeparadora();
            Thread.Sleep(3000);
            Console.WriteLine(" Para prosseguir com os próximos passos  [ENTER]");
            Console.ReadKey(true);
            var textoSalvo = false;
            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                ProximoPasso(nome, textoSalvo, path, textoFinal);
            }
            else
            {
                Console.WriteLine("Opção Inválida, para prosseguir [ENTER] para retornar ao menu incial [ESC]");
                Console.ReadKey();
                if(Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    ProximoPasso(nome, textoSalvo, path, textoFinal);
                }
                else
                {
                    Console.WriteLine("Retornando ao Menu Inicial..");
                    Thread.Sleep(2000);
                    Menu.MenuInicial();
                }
            }

        } // Método criação de arquivo

        public static void Abrir()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Menu.Show("ABRIR ARQUIVO");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("Digite o nome do arquivo que deseja abrir: ");
            Console.SetCursorPosition(2, 4);
            Console.Write(" ");
            var nome = Console.ReadLine();
            var directory = @"C:\Projetos\Caderninho\";
            var path = Path.Combine(directory, $"{nome}.txt");

            if (File.Exists(path))
            {
                var conteudo = File.ReadAllText(path);
                Console.Clear();
                Console.WriteLine($"Conteúdo do arquivo {nome}.txt:");
                Console.WriteLine("Para seguir com os próximos passos [ENTER]");
                Console.WriteLine(" ");
                Console.Write(conteudo);
                Console.WriteLine(" ");
                var textoSalvo = true;
                Console.ReadKey(true);
                if(Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    ProximoPasso(nome, textoSalvo, path, conteudo);

                }
                else
                {
                    Console.Write("Opção inválida, selecione [ENTER] para seguir para os próximos passos.");
                    Console.ReadKey(true);
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        ProximoPasso(nome, textoSalvo, path, conteudo);

                    }
                    AlgoMais();

                }

            }
            else
            {
                Console.WriteLine($"Arquivo {nome}.txt não encontrado.");
                Thread.Sleep(2000);
                AlgoMais();
            }
        }         // Método responsável por abrir um arquivo existente e exibir seu conteúdo.

        public static void Carregando()
        {
            Console.Clear();
            Console.WriteLine("Carregando...");
            Thread.Sleep(3000);
        } // Simulação de programa em carregamento
        public static void ProximoPasso(string nome,bool textoSalvo, string path, string textoFinal)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Menu.Show("PRÓXIMOS PASSOS");

            if (textoSalvo)
            {
                Console.SetCursorPosition(2, 5);
                Console.WriteLine("O que você deseja fazer com o arquivo?");
                Console.SetCursorPosition(2, 7);
                Console.WriteLine("[1] Salvar");
                Console.SetCursorPosition(2, 9);
                Console.WriteLine("[2] Editar");
                Console.SetCursorPosition(2, 11);
                Console.WriteLine("[3] Voltar ao menu");
                Console.SetCursorPosition(2, 13);
                Console.WriteLine("[4] Remover ");
                Console.SetCursorPosition(2, 15);
                Console.WriteLine("[5] Sair ");
                Console.SetCursorPosition(2, 17);
                var opcao = Console.ReadLine();
                var opcaoFormatada = Convert.ToInt32(opcao);

                switch (opcaoFormatada)
                {
                    case 1: Salvar(nome,path, textoFinal); break;
                    case 2: MenuEditar(nome,path, textoFinal); break;
                    case 3: Menu.MenuInicial(); break;
                    case 4: Remover(nome,path); break;
                    case 5: Encerrar(); break;
                    default: Console.WriteLine("  Opção inválida!"); Thread.Sleep(2000); Menu.MenuInicial(); break; // REVISAR

                }
            }
            else
            {
                Console.SetCursorPosition(2, 5);
                Console.WriteLine("O que você deseja fazer com o arquivo?");
                Console.SetCursorPosition(2, 7);
                Console.WriteLine("[1] Salvar");
                Console.SetCursorPosition(2, 9);
                Console.WriteLine("[2] Voltar ao menu");
                Console.SetCursorPosition(2, 11);
                Console.WriteLine("[3] Sair");
                Console.SetCursorPosition(2, 13);
                Console.Write(" ");   
                var opcao = Console.ReadLine();
                var opcaoFormatada = Convert.ToInt32(opcao);

                switch (opcaoFormatada)
                {
                    case 1: Salvar(nome,path, textoFinal); break;
                    case 2: Menu.MenuInicial(); break;
                    case 3: Encerrar(); break;
                    default: Console.WriteLine("Opção inválida!"); Menu.MenuInicial(); Thread.Sleep(2000); break; // REVISAR

                }


            }
        } // Validação de próximos passos
        public static void Salvar(string nome,string path, string textoFinal)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Menu.Show("SALVAR ARQUIVO");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("Deseja salvar o arquivo? [S] - SIM || [N] - NÃO");
            Console.SetCursorPosition(2, 4);
            Console.Write(" ");
            var resposta = Console.ReadLine().ToUpper();

            if (resposta == "S")
            {
                File.WriteAllText(path, textoFinal);
                Console.SetCursorPosition(2, 6);
                Console.WriteLine($"Arquivo salvo com sucesso.");
                Console.Write(" ");
                Console.SetCursorPosition(2, 8);
                Console.WriteLine($"Caminho: {path}");
                Thread.Sleep(5000);
                AlgoMais();
            }
            else
            {
                Console.SetCursorPosition(2, 6);
                Console.WriteLine($"Arquivo {nome}.txt não salvo.");
                Thread.Sleep(5000);
                AlgoMais();
            }
        } // Salvar arquivos
        public static void MenuEditar(string nome, string path, string textoFinal)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor= ConsoleColor.Magenta;
            Console.ForegroundColor= ConsoleColor.Black;
            Menu.Show("EDITAR ARQUIVO");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("Selecione uma opção de edição:");
            Console.SetCursorPosition (2, 7);
            Console.WriteLine("[1] - Editor de Texto Simples");
            Console.SetCursorPosition(2, 9);
            Console.WriteLine("Para retornar ao MENU digite [0]");
            Console.SetCursorPosition(2, 11);
            Console.Write(" ");
            var option = Console.ReadLine();
            var opcFormatado = Convert.ToInt32(option);

            switch(opcFormatado) {
             
                case 1: EditorTextoSimples(nome,path, textoFinal);break;
                default: Console.WriteLine("Opção inválida!"); Menu.MenuInicial(); break;
            }

        } // Menu editor, para selecionar o tipo de editor.
        public static void EditorTextoSimples(string nome, string path, string textoFinal)
        {
            Console.Clear();
            Menu.LinhaSeparadora();
            var conteudoAtualizado = new StringBuilder(textoFinal);
            Console.WriteLine("  Digite o conteúdo do arquivo (Digite OK para finalizar)");
            Menu.LinhaSeparadora();
            while (true)
            {
                var linha = Console.ReadLine();
                if (linha.Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                conteudoAtualizado.AppendLine(linha);
            }
            
            var atualizacao = conteudoAtualizado.ToString();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Menu.Show($"Conteudo atualizado");
            Carregando();
            Menu.LinhaSeparadora();
            Console.WriteLine("  Para prosseguir com os próximos passos [ENTER]");
            Menu.LinhaSeparadora();
            Console.Write(" ");
            Console.Write(atualizacao);
            Console.Write(" ");
            Console.ReadKey(true);
            var textoSalvo = false;
            if(Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                ProximoPasso(nome,textoSalvo, path, atualizacao);
            }
            else
            {
                Console.WriteLine("Opção inválida");
                Thread.Sleep(3000);
                AlgoMais();
            }

        } // Editor de texto simples
        public static void Remover(string nome, string path)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Menu.Show("REMOVER ARQUIVO");
                Console.SetCursorPosition(2, 3);
                Console.WriteLine("Deseja remover o arquivo? [S] - SIM || [N] - NÃO");
                Console.SetCursorPosition(2, 4);
                Console.Write(" ");
                var resposta = Console.ReadLine().ToUpper();
    
                if (resposta == "S")
                {
                    // Lógica para remover o arquivo
                    File.Delete(path);
                    Console.WriteLine($"Arquivo {nome}.txt removido com sucesso!");
                    Thread.Sleep(3000);
                AlgoMais();
                }
                else
                {
                    Console.WriteLine($"Arquivo {nome}.txt não removido.");
                    Thread.Sleep(2000);
                    AlgoMais();
                }
        } // Remover arquivos
        public static void AlgoMais()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Menu.Show("ALGO MAIS ?");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("Deseja realizar outra ação? [S] - SIM || [N] - NÃO");
            Console.SetCursorPosition(2, 4);
            Console.Write(" ");
            var resposta = Console.ReadLine().ToUpper();
            if (resposta == "S")
            {
                Menu.MenuInicial();
            }
            else
            {
                Encerrar();
            }
        } // Validação de "Algo mais"
        public static void Encerrar()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Menu.Show("ENCERRAR");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("Obrigada por usar o Caderninho! Até a próxima!");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }// Encerramento do programa
    }
}
