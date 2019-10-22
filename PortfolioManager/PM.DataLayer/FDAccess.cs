using MongoDB.Bson;
using MongoDB.Driver;
using System.Runtime;
using PM.DataContracts;
using PM.UtilityClasses;
//using System.Runtime.File
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;       

namespace PM.DataLayer
{
    public static class FDAccess
    {
        //static MongoClient mongoClient;

        public static CreateFdResponse Insert(FixedDeposite fd)
        {
            try
            {
                var dataAccess = GenericDataAccess.GetDatabase();
                var mongoCollection = GetMongoDBCollection<FixedDeposite>.GetDatabaseCollection(dataAccess, "FixedDeposits");
                mongoCollection.InsertOne(fd);

                if (fd.ID == null)
                    throw new MongoDBDataAccessException("Exception while creating fd");

            }
            catch (MongoDBDataAccessException ex)
            {
                throw new MongoDBDataAccessException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Undefined Exception." + ex.Message, ex);
            }

            return new CreateFdResponse()
            {
                FDId = ObjectId.GenerateNewId(),
                IsFdCreated = true,
                IsOperationSuccess = true
            };
        }


        public static SearchFDResponse SearchFD(string searchKey)
        {
            var dataAccess = GenericDataAccess.GetDatabase();
            var mongoCollection = GetMongoDBCollection<FixedDeposite>.GetDatabaseCollection(dataAccess, "FixedDeposits");


            var fds = mongoCollection.Find(x => x.FdId == searchKey).ToList();
            if (fds == null)
                throw new MongoDBDataAccessException("Exception while sarching FD");           
            
            List<FixedDeposite> ListFDs = new List<FixedDeposite>();
            if (fds.Capacity > 0)
            {
                foreach(FixedDeposite fd in fds )
                {
                    ListFDs.Add(fd);
                }
            }

            return new SearchFDResponse()
            {
                ListOfFDs = ListFDs
            };
        }
    }
}
