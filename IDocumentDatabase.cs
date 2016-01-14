using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace RESTMongoDB.Models
{
    public interface IDocumentDatabase<db, col>
    {
        string ToConnectionString();
        db Database(string connectionString);
        col Collection(string collectionName);
    }
}
