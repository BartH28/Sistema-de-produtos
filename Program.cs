using System;

namespace Produtos
{
    class Program
    {
        
        static int retornoMenu;
        static bool respostaInvalida = false;
        static string respostaMenu;
        static int i2 = 0;
        static string retorno;
        static string[] nome = new string[10];
        static float[] preço = new float[10];
        static bool[] promoção = new bool[10];
        static int c = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Cadastro de produtos mercadão");
            Mostrarmenu();
        }

        static int Mostrarmenu()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($@" 
    Menu
            
    Digite a o numero para confirmar a opção:

    1 - Cadastrar produto
    2 - Listar Produtos
            ");
                Console.ResetColor();
                respostaMenu = Console.ReadLine();

                if (respostaMenu == "1")
                {
                    Cadastro();
                    retorno = Console.ReadLine();
                }
                else if (respostaMenu == "2")
                {
                    Listarprodutos();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Opção invalida!!! Digite novamente");
                    respostaInvalida = true;
                    Console.ResetColor();
                }
            } while (respostaInvalida);

            return retornoMenu;
        }

        static string Cadastro()
        {
            bool digiteNovamente = false;
            bool maisProduto = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Protudo {c}\n");
                Console.WriteLine("Digite o nome do produto...:");
                nome[i2] = Console.ReadLine();
                Console.WriteLine("Digite o preço do produto...:");
                preço[i2] = float.Parse(Console.ReadLine());
                do
                {
                    Console.WriteLine("Digite se o produto esta em promoção (s/n)...:");
                    string sn = Console.ReadLine().ToLower();

                    switch (sn)
                    {
                        case "s":
                            promoção[i2] = true;
                            digiteNovamente = false;
                            break;
                        case "n":
                            promoção[i2] = false;
                            digiteNovamente = false;
                            break;
                        default:
                            digiteNovamente = true;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opção invalida (obs: apens S para sim e N para não)");
                            Console.ResetColor();
                            break;
                    }
                } while (digiteNovamente);

                Console.WriteLine("Voce gostaria de cadastrar mais um produto? (s/n)");
                Console.WriteLine("LIMITE DE 10 PRODUTOS");
                string respostaProduto = Console.ReadLine().ToLower();
                i2++;
                c++;


                if (respostaProduto == "s")
                {
                    Console.WriteLine("------>");
                    maisProduto = true;
                }
                else if (respostaProduto == "n")
                {
                    Mostrarmenu();
                }
                
            } while (maisProduto);

            return retorno;
        }

        static void Listarprodutos()
        {

            for (var i = 0; i < nome.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($@"
                {(i + 1)}º produto: {nome[i]}     {preço[i]}       {(promoção[i]? "sim" : "não")}");
            }
            Mostrarmenu();
        }
    }
}
