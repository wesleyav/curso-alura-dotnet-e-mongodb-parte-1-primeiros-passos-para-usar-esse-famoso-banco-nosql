using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class UsandoValoresLivros
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            var conexaoBiblioteca = new ConectandoMongoDB();

            //Livro livro = new Livro();
            //livro.Titulo = "Star Wars Legends";
            //livro.Autor = "Timothy Zahn";
            //livro.Ano = 2010;
            //livro.Paginas = 245;
            //List<string> Lista_Assuntos = new List<string>();
            //Lista_Assuntos.Add("Ficção Científica");
            //Lista_Assuntos.Add("Ação");
            //livro.Assunto = Lista_Assuntos;

            Livro livro = new Livro();
            livro = ValoresLivro.incluiValoresLivro("Dom Casmurro", "Machado de Assis", 1923, 188, "Romance, Literatura  Brasileira");            
            await conexaoBiblioteca.Livros.InsertOneAsync(livro);

            Livro livro2 = new Livro();
            livro2 = ValoresLivro.incluiValoresLivro("A Arte da Ficção", "David Lodge", 2002, 230, "Didático, Auto Ajuda");
            await conexaoBiblioteca.Livros.InsertOneAsync(livro2);



            Console.WriteLine("Documento incluído!");



        }
    }
}
