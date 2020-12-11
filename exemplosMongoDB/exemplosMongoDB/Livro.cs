﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace exemplosMongoDB
{
    public class Livro
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public List<string> Assunto { get; set; }
    }

    public class ValoresLivro
    {
        public static Livro incluiValoresLivro(string Titulo, string Autor, int Ano, int Paginas, string Assuntos)
        {
            Livro livro = new Livro();
            livro.Titulo = Titulo;
            livro.Autor = Autor;
            livro.Ano = Ano;
            livro.Paginas = Paginas;
            string[] vetAssunto = Assuntos.Split(',');
            List<string> vetAssunto2 = new List<string>();
            for (int i = 0; i <= vetAssunto.Length - 1; i++)
            {
                vetAssunto2.Add(vetAssunto[i].Trim());
            }
            livro.Assunto = vetAssunto2;
            return livro;
        }
    }
}
