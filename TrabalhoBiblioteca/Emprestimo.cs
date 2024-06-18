using System.Collections.Generic;
using static TrabalhoBiblioteca.Livro;
using static TrabalhoBiblioteca.Utilizador;

namespace TrabalhoBiblioteca
{
    public class Emprestimo
    {

        // Atributos da Classe Livros
        public Utilizador Utilizador { get; set; }
        public Livro Livro { get; set; }
        public DateTime DataRequisicao { get; set; }

        public static List<Emprestimo> listaEmprestimo = new List<Emprestimo>();




        // Construtor com parâmetros
        public Emprestimo(Utilizador utilizador, Livro livro, DateTime dataRequisicao)
        {
            Utilizador = utilizador;
            Livro = livro;
            DataRequisicao = dataRequisicao;
        }





        // Construtor padrão
        public Emprestimo() { }






        // Método para ler dados do empréstimo
        public Livro LerDadosEmprestimo()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------------");
            Console.WriteLine("-        Empréstimo       -");
            Console.WriteLine("---------------------------");
            Console.WriteLine("");
            Console.WriteLine("ISBN:");
            string isbn = Console.ReadLine();

            // Procura o livro na lista de livros pelo ISBN
            Livro livro = listaLivro.FirstOrDefault(l => l.ISBN == isbn);
            if (livro == null)
            {
                Console.WriteLine("");
                Console.WriteLine($"Livro com ISBN '{isbn}' não encontrado.");
                return null; // Retorna null se o livro não for encontrado
            }

            Console.WriteLine("Utilizador: ");
            string nomeUtilizador = Console.ReadLine();

            // Procura o utilizador na lista de utilizadores pelo nome
            Utilizador utilizador = listaUtilizador.FirstOrDefault(u => u.Nome == nomeUtilizador);
            if (utilizador == null)
            {
                Console.WriteLine($"Utilizador '{nomeUtilizador}' não encontrado.");
                return null; // Retorna null se o utilizador não for encontrado
            }

            // Registra a data de requisição
            DataRequisicao = DateTime.Now;

            // Adiciona os dados à lista de empréstimos
            Emprestimo novoEmprestimo = new Emprestimo(utilizador, livro, DataRequisicao);
            listaEmprestimo.Add(novoEmprestimo);

            // Mensagem de empréstimo registrado com sucesso
            Console.WriteLine("");
            Console.WriteLine(" -     Empréstimo Registrado Com Sucesso     -");
            Console.WriteLine("");
            Console.WriteLine($" Título: {livro.Titulo}\n ISBN: {livro.ISBN}\n Utilizador: {utilizador.Nome}\n Data de Requisição: {DataRequisicao}");
            Console.WriteLine("");
            Console.WriteLine(" ---------------------------------------------");
            Console.WriteLine("");

            // Mensagem para informar o utilizador que precisa devolver o livro em 15 dias
            DateTime dataDevolucao = DataRequisicao.AddDays(15);
            Console.WriteLine($"Por favor, devolva o livro até {dataDevolucao.ToString("dd/MM/yyyy")}.");
            Console.WriteLine("");

            return livro;
        }






        // Método para adicionar empréstimo
        public void AdicionarEmprestimo()
        {
            Livro livro1 = LerDadosEmprestimo();

            // Atualiza o número de exemplares disponíveis do livro
            foreach (Livro livro in listaLivro)
            {
                if (livro.Titulo == livro1.Titulo)
                {
                    if (livro.NExemplares > 0)
                    {
                        livro.NExemplares--; // Decrementa o número de exemplares
                        Console.WriteLine(" ----------------------------------------------------------------------------");
                        Console.WriteLine($" Livro '{livro.Titulo}' emprestado. Exemplares restantes: {livro.NExemplares}");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine(" ------------------------------------------------------------------------");
                        Console.WriteLine($"Não há exemplares disponíveis do livro '{livro.Titulo}' para empréstimo.");
                        Console.WriteLine("");
                    }
                    break;
                }
            }
        }






        // Método para remover empréstimo
        public void RemoverEmprestimo()
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------------");
            Console.WriteLine("-         Devolução        -");
            Console.WriteLine("----------------------------");
            Console.WriteLine("");
            Console.WriteLine("ISBN: ");
            string isbnLivro = Console.ReadLine();

            // Procura o empréstimo na lista de empréstimos pelo ISBN do livro
            Emprestimo emprestimo = listaEmprestimo.FirstOrDefault(e => e.Livro.ISBN == isbnLivro);
            // O método 'FirstOrDefault' é uma função que retorna o primeiro elemento de uma sequência que atende a uma condição específica ou um valor padrão se nenhum elemento for encontrado na sequência.
            if (emprestimo == null)
            {
                Console.WriteLine("");
                Console.WriteLine($"O livro com ISBN '{isbnLivro}' não foi emprestado.");
                Console.WriteLine("");
                return;
            }
            else
            {
                // Remove o empréstimo da lista de empréstimos
                listaEmprestimo.Remove(emprestimo);
            }

            // Atualiza o número de exemplares disponíveis do livro
            foreach (Livro livro in listaLivro)
            {
                if (livro.ISBN == isbnLivro)
                {
                    livro.NExemplares++; // Incrementa o número de exemplares
                    Console.WriteLine("");
                    Console.WriteLine($"Livro com ISBN '{isbnLivro}' devolvido. Exemplares disponíveis agora: {livro.NExemplares}");
                    return;
                }
            }

            Console.WriteLine($"Não foi possível encontrar o livro com ISBN '{isbnLivro}' na lista de livros.");
        }



        // Método para mostrar empréstimos
        public void MostrarEmprestimos()

        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("-           Lista de Empréstimos           -");
            foreach (Emprestimo emprestimo in listaEmprestimo)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"Livro: {emprestimo.Livro.Titulo}");
                Console.WriteLine($"ISBN: {emprestimo.Livro.ISBN}");
                Console.WriteLine($"Utilizador: {emprestimo.Utilizador.Nome}");
                Console.WriteLine($"Data de Requisição: {emprestimo.DataRequisicao}");
                // Calcula e mostra a data de devolução (15 dias após a data de requisição)
                DateTime dataDevolucao = emprestimo.DataRequisicao.AddDays(15);
                Console.WriteLine($"Data de Devolução: {dataDevolucao}");
                Console.WriteLine("--------------------------------------------");
            }
        }

    }
}
