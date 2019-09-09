using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PM.DataContracts
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        public ObjectId ID { get; set; }
        public string UserName { get; set; }
        public string PAN { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }

    }
}
