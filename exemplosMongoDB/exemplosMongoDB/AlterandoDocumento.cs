using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class AlterandoDocumento
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



            Console.WriteLine("Listar e alterar o livro Guerra dos Tronos");

            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Titulo, "Guerra dos tronos");

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();

            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
                doc.Ano = 2000;
                doc.Paginas = 900;
                await conexaoBiblioteca.Livros.ReplaceOneAsync(condicao, doc);
            }

            Console.WriteLine("Fim da lista!");
            Console.WriteLine("----------");

            //---------------------------------------------------------------------------------------

            Console.WriteLine("Listar o livro Guerra dos Tronos");

            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Titulo, "Guerra dos tronos");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();

            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());                
            }

            Console.WriteLine("Fim da lista!");
            Console.WriteLine("----------");

        }
    }
}
