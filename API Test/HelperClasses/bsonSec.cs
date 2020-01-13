using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using API_Test.Controllers;
using MongoDB.Driver;

namespace API_Test.HelperClasses
{
    public class bsonSec
    {
        public static void bsonSection(int customer_number, string timeValue, string section,IMongoCollection<BsonDocument> collection)
        {

            string newParam = $" {{ $set: {{ '{section}': '{timeValue}'}} }}";
            BsonDocument newFilterDoc = BsonDocument.Parse($" {{ 'customer_number':{customer_number} }}");
            BsonDocument newDocument = BsonDocument.Parse(newParam);
            collection.UpdateOne(newFilterDoc, newDocument);
        }
    }
}
