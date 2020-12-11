using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class AlterandoDocumentoClasse
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
          
            }

            Console.WriteLine("Fim da lista!");
            Console.WriteLine("----------");

            var construtorAlteracao = Builders<Livro>.Update;
            var condicaoAlteracao = construtorAlteracao.Set(x => x.Ano, 2001);
            await conexaoBiblioteca.Livros.UpdateOneAsync(condicao, condicaoAlteracao);

            Console.WriteLine("Registro alterado!");
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


            //---------------------------------------------------------------------------------------

            Console.WriteLine("Listar os livros de Machado de Assis");

            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Autor, "Machado de Assis");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();

            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista!");
            Console.WriteLine("----------");

            construtorAlteracao = Builders<Livro>.Update;
            condicaoAlteracao = construtorAlteracao.Set(x => x.Autor, "M. Assis");
            await conexaoBiblioteca.Livros.UpdateManyAsync(condicao, condicaoAlteracao);

            Console.WriteLine("Registro alterado!");
            Console.WriteLine("----------");
        }
    }
}
