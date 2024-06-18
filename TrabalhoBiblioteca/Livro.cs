using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoBiblioteca
{
    public class Livro
    {
        // Atributos da Classe Livro
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public int NExemplares { get; set; }

        public static List<Livro> listaLivro = new List<Livro>();




        // Construtor com parâmetros
        public Livro(string titulo, string isbn, string autor, int anoPublicacao, int nExemplares)
        {
            Titulo = titulo;
            ISBN = isbn;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            NExemplares = nExemplares;
        }




        // Construtor padrão
        public Livro() { }   // Este cosntrutor não aceita parâmetros e é usado para criar um objeto 'Livro' com atributos não inicializados.
                             // É útil quando precisamos criar um objeto primeiro e definirmos os seus atributos posteriormente.





        // Método para adicionar os objetos às listas estáticas
        public static void AdicionarDados()
        {
            // Adiciona livros
            listaLivro.Add(new Livro("A floresta", "12345", "José Maria", 2006, 5));
            listaLivro.Add(new Livro("A utopia da felicidade", "6789", "Tânia Ribeiro", 2024, 10));
            listaLivro.Add(new Livro("A menina que nunca chorava", "54321", "Maria José", 2010, 3));

        }





        // Método para ler os dados do livro
        public void LerDadosLivro()
        {
            Console.WriteLine("");
            Console.WriteLine("Título do livro:"); // Solicita e armazena o título do livro
            Titulo = Console.ReadLine();
            Console.WriteLine("ISBN:"); // Solicita e armazena o ISBN do livro
            ISBN = Console.ReadLine();
            Console.WriteLine("Autor:"); // Solicita os autores do livro e armazena em uma lista
            Autor = Console.ReadLine();
            Console.WriteLine("Ano de Publicação:");
            AnoPublicacao = int.Parse(Console.ReadLine());
            Console.WriteLine("Número de exemplares:");
            NExemplares = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        }





        // Método para adicionar um novo livro
        public void AdicionarLivro()
        {
            Livro novoLivro = new Livro();
            LerDadosLivro();
            listaLivro.Add(novoLivro);
            Console.WriteLine("");
            Console.WriteLine(" ---------------------------------------------");
            Console.WriteLine(" -        Livro Registado Com Sucesso        -");
            Console.WriteLine(" ---------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine($" Título: {Titulo}\n ISBN: {ISBN}\n Autores: {Autor}\n Ano: {AnoPublicacao}\n Exemplares: {NExemplares} ");
            Console.WriteLine("");
            Console.WriteLine(" ---------------------------------------------");

        }





        // Método para mostrar os livros
        public static void MostrarLivros()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("-                                                 Lista de Livros                                                  -");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("");
            foreach (Livro livro in listaLivro)
            {
                Console.WriteLine(livro.ToString());   // Para cada livro na lista, o método 'ToString()' é chamado para converter o objeto Livro numa representação de string.
                Console.WriteLine("");
            }
        }





        // Método para concatenar informação e tornar numa string
        public override string ToString()
        {
            return ($" Título: {Titulo} || ISBN: {ISBN} || Autor: {Autor} || Ano Publicação: {AnoPublicacao} || Exemplares: {NExemplares}\n ");
        }




    }
}
