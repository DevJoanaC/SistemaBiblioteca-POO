namespace TrabalhoBiblioteca
{
    internal class Program
    {

        // Iniciar o programa Main
        public static void Main(string[] args)
        {
            Utilizador.AdicionarDados();
            Livro.AdicionarDados();
            Funcionario.AdicionarDados();

            int escolha;

            // Loop principal para manter o menu visível até que o usuário escolha sair


            while (true) // O "while(true)" cria um loop infinito que continua a executar até que a condição 'return' seja escolhida. E,
                         // que mantêm o programa em execução continuamente, permitindo que o utilizador faça escolhas no menu principal repetidamente.

            {
                // Mostrar o menu principal
                Console.WriteLine(" ----------- MENU ----------- ");
                Console.WriteLine("|                            |");
                Console.WriteLine("|     [1] - Utilizador       |");
                Console.WriteLine("|     [2] - Funcionário      |");
                Console.WriteLine("|     [0] - Sair             |");
                Console.WriteLine("|                            |");
                Console.WriteLine(" ---------------------------- ");
                Console.WriteLine(" Escolha uma opção: ");
                escolha = int.Parse(Console.ReadLine());

                // Realiza a ação correspondente à escolha do usuário
                switch (escolha)
                {
                    case 1:
                        Console.Clear(); // método que limpa o conteúdo do console, criando uma aparência mais limpa ao mostrar informações ou menus.
                        Utilizador.LoginUtilizador();
                        break;
                    case 2:
                        Console.Clear();
                        Funcionario.LoginFuncionario();
                        break;
                    case 0:
                        Console.WriteLine("A sair...");
                        return;
                    default:   // é usado quando nenhuma das opções de caso (case) correspondem ao valores fornecido
                        Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                        break;
                }
            }

        }




    }



}

