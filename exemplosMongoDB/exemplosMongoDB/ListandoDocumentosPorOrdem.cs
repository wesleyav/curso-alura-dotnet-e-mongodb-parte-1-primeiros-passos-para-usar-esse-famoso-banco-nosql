using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class ListandoDocumentosPorOrdem
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

            

            Console.WriteLine("Listando documentos mais de 100 páginas");

            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Gt(x => x.Paginas, 100);

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).SortBy(x => x.Titulo).Limit(5).ToListAsync();

            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());

            }

            Console.WriteLine("Fim da lista!");
            Console.WriteLine("----------");

            
        }
    }
}
