﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class ConectandoMongoDB
    {
        public const string STRING_DE_CONEXAO = "mongodb://localhost:27017";
        public const string NOME_DA_BASE = "Biblioteca";
        public const string NOME_DA_COLECAO = "Livros";

        private static readonly IMongoClient _cliente;
        private static readonly IMongoDatabase _baseDados;

        static ConectandoMongoDB()
        {
            _cliente = new MongoClient(STRING_DE_CONEXAO);
            _baseDados = _cliente.GetDatabase(NOME_DA_BASE);
        }

        public IMongoClient Cliente
        {
            get
            {
                return _cliente;
            }
        }

        public IMongoCollection<Livro> Livros
        {
            get
            {
                return _baseDados.GetCollection<Livro>(NOME_DA_COLECAO);
            }
        }



    }
}
