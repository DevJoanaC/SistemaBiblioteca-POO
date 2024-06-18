using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace TrabalhoBiblioteca
{
    public class Utilizador
    {
        // Atributos da Classe Utilizadores
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }

        // Lista de utilizadores (static para ser compartilhada entre todas as instâncias)
        public static List<Utilizador> listaUtilizador = new List<Utilizador>();

        // Método construtor com parâmetros
        public Utilizador(string nome, string endereco, string telefone, string senha)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Senha = senha;
        }

        // Método construtor padrão
        public Utilizador() { }

        // Método para adicionar alguns utilizadores de exemplo à lista
        public static void AdicionarDados()
        {
            // Adicionar utilizadores de exemplo
            listaUtilizador.Add(new Utilizador("Isabel Ribeiro", "Braga", "919606972", "12345"));
            listaUtilizador.Add(new Utilizador("Juju Cardoso", "Braga", "919606972", "12345"));
            listaUtilizador.Add(new Utilizador("Manuel Gonçalves", "Braga", "919606972", "12345"));
        }

        // Método para validar as credenciais de login
        public bool ValidarLogin(string nome, string senha)
        {
            return Nome == nome && Senha == senha;
        }

        // Método para realizar o login do utilizador
        public static void LoginUtilizador()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("-            LOGIN            -");
            Console.WriteLine("");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            // Este método verifica se o nome de nome e a senha correspondem aos dados fornecidos.
            Utilizador utilizador = listaUtilizador.Find(u => u.ValidarLogin(nome, senha)); // 'Find' é um método que procura na lista um elemento que corresponde a um critério específico.
            //'u => u.ValidarLogin(nome, senha)': Esta é uma expressão lambda que atua como o predicado para o método 'Find'. O parâmetro 'u' representa cada elemento da lista enquanto o método
            //é aplicado. 'u.ValidarLogin(nome, senha)' chama o método 'ValidarLogin' no objeto 'u' (que é um Utilizador), passando o nome e a senha como argumentos.

            // Uma 'expressão lambda' é uma maneira concisa de definir uma função anônima. 

            if (utilizador == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Credenciais inválidas. Por favor, tente novamente.");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine($"Bem-vindo, {utilizador.Nome}!");
                Console.WriteLine("");
                MenuUser();
            }
        }

        // Método para mostrar o menu do Utilizador e gerir as operações
        public static void MenuUser()
        {
            Emprestimo emprestimo = new Emprestimo();

            int opcao;

            // Loop para manter o menu do Utilizador visível até escolher sair
            while (true)
            {
                Console.WriteLine(" ----------- BEM-VINDO UTILIZADOR ---------- ");
                Console.WriteLine("|                                           |");
                Console.WriteLine("|     [1] - Registar                        |");
                Console.WriteLine("|     [2] - Consultar Livros                |");
                Console.WriteLine("|     [3] - Requisitar Livro                |");
                Console.WriteLine("|     [4] - Devolver Livro                  |");
                Console.WriteLine("|     [0] - Sair                            |");
                Console.WriteLine("|                                           |");
                Console.WriteLine(" ------------------------------------------- ");
                Console.WriteLine(" Escolha uma opção:");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        AdicionarUtilizador();
                        break;
                    case 2:
                        Console.Clear();
                        Livro.MostrarLivros();
                        break;
                    case 3:
                        emprestimo.AdicionarEmprestimo();
                        break;
                    case 4:
                        Console.Clear();
                        emprestimo.RemoverEmprestimo();
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

        // Método para ler os dados do utilizador
        public static void LerDadosUtilizador()
        {
            Utilizador novoUtilizador = new Utilizador(); // Cria uma nova instância da classe Utilizador e associa à variável 'novoUtilizador'.
            Console.WriteLine("Nome do Utilizador:");
            novoUtilizador.Nome = Console.ReadLine(); // Atribuir o nome ao novoUtilizador
            Console.WriteLine("Endereco:");
            novoUtilizador.Endereco = Console.ReadLine(); // Atribuir o endereço ao novoUtilizador
            Console.WriteLine("Telefone:");
            novoUtilizador.Telefone = Console.ReadLine(); // Atribuir o telefone ao novoUtilizador
            Console.WriteLine("Senha:");
            novoUtilizador.Senha = Console.ReadLine(); // Atribuir a senha ao novoUtilizador

            // Adicionar o novo usuário à lista de usuários
            listaUtilizador.Add(novoUtilizador);
        }

        public static void AdicionarUtilizador()
        {
            LerDadosUtilizador(); // Chamar o método para ler os dados do usuário
            Utilizador novoUtilizador = listaUtilizador[listaUtilizador.Count - 1]; // Aceder o último usuário adicionado à lista

            Console.WriteLine(" ------------------------------------------------");
            Console.WriteLine(" -       Utilizador Registado Com Sucesso       -");
            Console.WriteLine(" ------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine($" Nome: {novoUtilizador.Nome} || Endereço: {novoUtilizador.Endereco} || Telefone: {novoUtilizador.Telefone} ");
        }

        // Método para remover utlizador
        public static void RemoverUtilizador()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-       Remover Utilizador       -");
            Console.WriteLine("");
            Console.WriteLine(" Nome: ");
            string nome = Console.ReadLine();
            Utilizador utilizadorRemover = listaUtilizador.Find(u => u.Nome == nome);
            if (utilizadorRemover != null)
            {
                listaUtilizador.Remove(utilizadorRemover);
                Console.WriteLine("");
                Console.WriteLine("Utilizador removido com sucesso!");
                Console.WriteLine("--------------------------------");
            }
            else
            {
                Console.WriteLine("Utilizador não encontrado");
                Console.WriteLine("-------------------------");
            }
        }

        // Método para mostrar os Utilizadores
        public static void MostrarUtilizadores()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-       Lista de Utilizadores       -");
            Console.WriteLine("");
            foreach (Utilizador utilizador in listaUtilizador)
            {
                Console.WriteLine(utilizador.ToString());
            }
            Console.WriteLine("");
        }

        // Método para concatenar informações e tornar numa string
        public override string ToString()
        {
            return ($"Nome: {Nome} | Endereço: {Endereco} | Telefone: {Telefone}\n");
        }
    }
}