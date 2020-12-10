using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class ManipulandoClasses
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            //var doc = new BsonDocument
            //{
            //    {"Titulo", "Guerra dos tronos" }
            //};
            //doc.Add("Autor", "George R. R. Martin");
            //doc.Add("Ano", 1999);
            //doc.Add("Páginas", 856);

            //var assuntoArray = new BsonArray();
            //assuntoArray.Add("Fantasia");
            //assuntoArray.Add("Ação");

            //doc.Add("Assunto", assuntoArray);

            //Console.WriteLine(doc);

            // inicializar uma variável do tipo objet libro
            Livro livro = new Livro();
            livro.Titulo = "Sob a redoma";
            livro.Autor = "Stepan King";
            livro.Ano = 2012;
            livro.Paginas = 679;

            List<string> listaAssuntos = new List<string>();
            listaAssuntos.Add("Ficção científica");
            listaAssuntos.Add("Terror");
            listaAssuntos.Add("Ação");
            livro.Assunto = listaAssuntos;


            // acesso ao servidor mongodb
            string stringConexao = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(stringConexao);


            // acesso ao banco de dados
            IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");


            // acesso a coleção
            IMongoCollection<Livro> colecao = bancoDados.GetCollection<Livro>("Livros");


            // incluindo documento

            await colecao.InsertOneAsync(livro);

            Console.WriteLine("Documento incluído!");



        }
    }
}
