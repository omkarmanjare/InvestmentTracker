using MongoDB.Driver;
using PM.DataContracts;
using PM.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PM.DataLayer
{
    public static class GenericDataAccess
    {

        // public static GetDa
        public static IMongoDatabase GetDatabase()
        {
            var _client = new MongoClient(ConfigurationProvider.MongoConnectionString());
            IMongoDatabase _mongoDB = _client.GetDatabase("PortfolioManagement");
            return _mongoDB;
        }
    }

    public static class GetMongoDBCollection<T> where T : class
    {
        public static IMongoCollection<T> GetDatabaseCollection(IMongoDatabase db, string collectionName)
        {
            return db.GetCollection<T>(collectionName);
        }
    }



}
