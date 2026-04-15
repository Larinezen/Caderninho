using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;

namespace Caderninho
{
    public class Menu
    {
        const int largura = 60; // Constante unica da largura que será utilizada.
        public static void MenuInicial()
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            
            var title= "MENU PRINCIPAL";
            Show(title);
            Console.SetCursorPosition(3, 3);
            Console.Write("Selecione uma opção abaixo:");
            Console.SetCursorPosition(3, 5);
            Console.WriteLine(" [1] - Novo arquivo ");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine(" [2] - Abrir ");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine(" [0] - Sair ");
            Console.SetCursorPosition(3, 11);
            Console.WriteLine("Opção: ");
            Console.SetCursorPosition(3, 13);
            Console.Write(" ");

            

            var opc = Convert.ToInt32(Console.ReadLine());
            switch(opc)
            {
                case 1: Arquivo.Criar();break;
                case 2: Arquivo.Abrir();break;
                case 0: Arquivo.Encerrar(); break;
                default: Menu.MenuInicial(); break;
            }

            

        }
        public static void Show(string title)
        {
            
            Cabecalho(title);
            Corpo();
            RodaPe();


        }
        // Método desenha Rodapé da tela do menu
        public static void RodaPe()
        {
            {
                Console.Write("|");
                for (int i = 0; i < 60; i++)
                {
                    Console.Write("-");

                }
                Console.Write("|");
                Console.Write("\n");
            }
        }
        // Método desenha o cabeçalho da tela do menu
        static void Cabecalho(string title)
        {
            // Linha Superior
            Console.WriteLine("|" + new string('=', largura) + '|');


            // Centralização do titulo
            int espacosEsquerda = (largura + title.Length) / 2;
            var linhaTitulo = title.PadLeft(espacosEsquerda).PadRight(largura);
            Console.WriteLine("|" + linhaTitulo + "|");

            
            LinhaSeparadora();
        }
        // Método desenha linha separadora de tela
        public static void LinhaSeparadora()
        {
            Console.Write("|");
            for (int i = 0; i < 60; i++)
            {
                Console.Write("=");
            }
            Console.Write("|"); Console.Write("\n");

        }
        // Método desenha o corpo da tela do menu
        public static void Corpo()
        {
            for (int lines = 0; lines < 15; lines++)
            {
                Console.Write("|");
                for (int i = 0; i < 60; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
                Console.Write("\n");
            }

        }
    }
}
