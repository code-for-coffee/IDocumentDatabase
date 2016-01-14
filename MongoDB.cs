using MongoDB.Bson;
using MongoDB.Driver;
using RESTMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTMongoDB.Domain
{
    public class Mongo : IDocumentDatabase <MongoClient, IMongoCollection<BsonDocument>>
    {
        /// <summary>
        /// Generic Constructor w/no args
        /// </summary>
        public Mongo()
        {
            this.Host = "";
            this.Port = "";
            this.Username = "";
            this.Password = "";
        }
        /// <summary>
        /// Constructor w/args, username/password are nullable
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Mongo(string host, string port, string database, string username = null, string password = null)
        {
            this.Host = host;
            this.Port = port;
            this.DatabaseName = database;
            this.Username = username;
            this.Password = password;
        }
        /// <summary>
        /// Implementing URI per MongoDB Spec: 
        /// https://docs.mongodb.org/manual/reference/connection-string/
        /// </summary>
        /// <returns>Complete URI as connection string</returns>
        public string ToConnectionString()
        {
            string uri = this.Host + ":" + this.Port;
            string connectionString = "";
            if (this.Username.Length > 0 && this.Password.Length > 0)
            {
                connectionString = this.Username + ":" + this.Password + "@";
            }
            connectionString = "mongodb://" + connectionString + uri;
            return connectionString;
        }

        public MongoClient Database(string connectionString)
        {
            return new MongoClient(connectionString);
        }

        public IMongoCollection<BsonDocument> Collection(string collectionName)
        {
            var client = new MongoClient(this.ToConnectionString());
            var database = client.GetDatabase(this.DatabaseName);
            var collection = database.GetCollection<BsonDocument>(collectionName);
            return collection;
        }


        string Username { get; set; }
        string Password { get; set; }
        string Host { get; set; }
        string Port { get; set; }
        string DatabaseName { get; set; }
    }
}
