using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class ListandoDocumentos
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
            Console.WriteLine("Listando documentos!");

            var listaLivros = await conexaoBiblioteca.Livros.Find(new BsonDocument()).ToListAsync();

            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());

            }

            Console.WriteLine("Fim da lista!");
        }
    }
}
