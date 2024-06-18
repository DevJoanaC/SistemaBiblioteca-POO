namespace TrabalhoBiblioteca
{

    public class Funcionario
    {
        // Atributos da Classe Funcionario
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }

        public static List<Funcionario> listaFuncionarios = new List<Funcionario>();


        // Construtor com parâmetros
        public Funcionario(string nome, string endereco, string telefone, string senha)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Senha = senha;
        }

        // Construtor padrâo
        public Funcionario() { }


        public static void AdicionarDados()
        {
            // Adiciona funcionários
            listaFuncionarios.Add(new Funcionario("Tânia Ribeiro", "Braga", "919606972", "12345"));
            listaFuncionarios.Add(new Funcionario("Joana Cardoso", "Braga", "916547922", "12345"));
            listaFuncionarios.Add(new Funcionario("Henrique Gonçalves", "Braga", "919606972", "12345"));

        }



        // Método para validação da senha
        public bool ValidarLogin(string nome, string senha)         // Este método 'ValidarLogin' recebe o nome e a senha como entrada. Ele compara as entradas com o nome do utilizador e a senha
        {                                                           // armazenados no objeto atual (representado pelo 'this'). Se os valores fornecidos coincidirem com os valores armazenados, o método retorna
            return this.Nome == nome && this.Senha == senha;        // true, indicando que o login é válido. Caso contrário, retorna false.
        }



        // Método para fazer o login 
        public static void LoginFuncionario()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("-            LOGIN            -");
            Console.WriteLine("");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            // Verifica se as credenciais estão corretas
            Funcionario funcionario = listaFuncionarios.Find(f => f.ValidarLogin(nome, senha));
            if (funcionario == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Credenciais inválidas. Por favor, tente novamente.");
                Console.WriteLine("");
                return;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine($"Bem-vindo, {funcionario.Nome}!");
                Console.WriteLine("");
                MenuFuncionario();
            }

        }


        // Método para mostrar o menu do Funcionário e gerir as operações
        public static void MenuFuncionario()
        {
            Livro classLivro = new Livro();
            Emprestimo classEmprestimo = new Emprestimo();

            int opcao;

            // Loop para manter o menu do Funcionário visível até escolher sair
            while (true)
            {
                Console.WriteLine(" -------------- BEM-VINDO FUNCIONÁRIO -------------- ");
                Console.WriteLine("|                                                   |");
                Console.WriteLine("|                                                   |");
                Console.WriteLine("|        [1] - Registar Funcionário                 |");
                Console.WriteLine("|        [2] - Consultar Funcionários               |");
                Console.WriteLine("|                                                   |");
                Console.WriteLine("|        [3] - Registar Utilizador                  |");
                Console.WriteLine("|        [4] - Apagar Utilizador                    |");
                Console.WriteLine("|        [5] - Consultar Utilizadores               |");
                Console.WriteLine("|                                                   |");
                Console.WriteLine("|        [6] - Inserir Livro                        |");
                Console.WriteLine("|        [7] - Consultar Livros                     |");
                Console.WriteLine("|                                                   |");
                Console.WriteLine("|        [8] - Requistar Livro                      |");
                Console.WriteLine("|        [9] - Devolver Livro                       |");
                Console.WriteLine("|                                                   |");
                Console.WriteLine("|        [10] - Consultar Empréstimos               |");
                Console.WriteLine("|                                                   |");
                Console.WriteLine("|        [0] - Sair                                 |");
                Console.WriteLine("|                                                   |");
                Console.WriteLine("|                                                   |");
                Console.WriteLine(" --------------------------------------------------- ");
                Console.WriteLine(" Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                // Realiza a ação correspondente à escolha do Funcionário
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        AdicionarFuncionario();
                        break;
                    case 2:
                        Console.Clear();
                        MostrarFuncionarios();
                        break;
                    case 3:
                        Console.Clear();
                        Utilizador.AdicionarUtilizador();
                        break;
                    case 4:
                        Utilizador.RemoverUtilizador();
                        break;
                    case 5:
                        Console.Clear();
                        Utilizador.MostrarUtilizadores();
                        break;
                    case 6:
                        Console.Clear();
                        classLivro.AdicionarLivro();
                        break;
                    case 7:
                        Livro.MostrarLivros();
                        break;
                    case 8:
                        classEmprestimo.AdicionarEmprestimo();
                        break;
                    case 9:
                        classEmprestimo.RemoverEmprestimo();
                        break;
                    case 10:
                        classEmprestimo.MostrarEmprestimos();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("A sair...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                        break;
                }
                Console.WriteLine();
            }

        }


        

        // Método para ler dados do funcionário
        public static void LerDadosFuncionario()
        {
            Funcionario novoFuncionario = new Funcionario();
            Console.WriteLine("Nome do Funcionário:");
            novoFuncionario.Nome = Console.ReadLine();
            Console.WriteLine("Endereco:");
            novoFuncionario.Endereco = Console.ReadLine();
            Console.WriteLine("Telefone:");
            novoFuncionario.Telefone = Console.ReadLine();
            Console.WriteLine("Senha");
            novoFuncionario.Senha = Console.ReadLine();
            listaFuncionarios.Add(novoFuncionario);

        }

        // Método para adicionar funcionário
        public static void AdicionarFuncionario()
        {
            LerDadosFuncionario();
            Funcionario novoFuncionario = listaFuncionarios[listaFuncionarios.Count - 1];
            Console.WriteLine("");
            Console.WriteLine(" ------------------------------------------------------------------------------------------");
            Console.WriteLine(" -                              Funcionário Registado Com Sucesso                         -");
            Console.WriteLine(" ------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine($" Nome: {novoFuncionario.Nome} || Endereço: {novoFuncionario.Endereco} || Telefone: {novoFuncionario.Telefone} || Senha: ******* ");
            Console.WriteLine("");
        }





        // Método para mostrar funcionários
        public static void MostrarFuncionarios()
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("-                       Lista de Funcionário                     -");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("");
            foreach (Funcionario funcionario in listaFuncionarios)
            {
                Console.WriteLine(funcionario.ToString());
            }
            Console.WriteLine("");
        }





        // Método para concatenar informações e retornar como string
        public override string ToString()
        {
            return ($"Nome: {Nome} | Endereço: {Endereco} | Telefone: {Telefone}\n");
        }
    }
}

