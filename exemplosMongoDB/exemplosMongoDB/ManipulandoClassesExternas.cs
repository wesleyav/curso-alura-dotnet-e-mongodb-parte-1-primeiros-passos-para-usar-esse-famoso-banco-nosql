using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class ManipulandoClassesExternas
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
            livro.Titulo = "Star Wars Legends";
            livro.Autor = "Timothy Zahn";
            livro.Ano = 2010;
            livro.Paginas = 245;
            List<string> Lista_Assuntos = new List<string>();
            Lista_Assuntos.Add("Ficção Científica");
            Lista_Assuntos.Add("Ação");
            livro.Assunto = Lista_Assuntos;


            //// acesso ao servidor mongodb
            //string stringConexao = "mongodb://localhost:27017";
            //IMongoClient cliente = new MongoClient(stringConexao);

            //// acesso ao banco de dados
            //IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");

            //// acesso a coleção
            //IMongoCollection<Livro> colecao = bancoDados.GetCollection<Livro>("Livros");

            // acessando através da classe de conexão
            var conexaoBiblioteca = new ConectandoMongoDB();


            // incluindo documento

            await conexaoBiblioteca.Livros.InsertOneAsync(livro);

            Console.WriteLine("Documento incluído!");



        }
    }
}
