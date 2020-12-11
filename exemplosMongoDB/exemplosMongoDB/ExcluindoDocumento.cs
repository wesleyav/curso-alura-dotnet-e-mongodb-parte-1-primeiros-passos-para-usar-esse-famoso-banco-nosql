using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class ExcluindoDocumento
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

            Console.WriteLine("Buscar os livros de M. Assis");

            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Autor, "M. Assis");

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();

            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());

            }

            Console.WriteLine("Fim da lista!");
            Console.WriteLine("----------");
            Console.WriteLine("Excluindo os livros!");
            
            await conexaoBiblioteca.Livros.DeleteManyAsync(condicao);

            //---------------------------------------------------------------------------------------

            Console.WriteLine("Buscar os livros de M. Assis");

            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Autor, "M. Assis");

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
