using MongoDB.Bson;
using MongoDB.Driver;
using PM.DataContracts;
using PM.DataContracts.Response;
using PM.UtilityClasses;
using System;

using System.Collections;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DataLayer
{

    public static class UserAccess
    {
        public static CreateUserResponse CreateUser(User user)
        {
            try
            {
                var dataAccess = GenericDataAccess.GetDatabase();
                var mongoCollection = GetMongoDBCollection<User>.GetDatabaseCollection(dataAccess, "Users");
                mongoCollection.InsertOne(user);

                if (user.ID == null)
                    throw new MongoDBDataAccessException("Exception while creating user");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


            return new CreateUserResponse() { ID = ObjectId.GenerateNewId(), IsUserCreated = true, Message = "User Created" };
        }

        //public static bool ValidateUser(string userName,string hasehdPassword)
        //{ 
        //    return new CreateUserResponse() { ID = ObjectId.GenerateNewId(), IsUserCreated = true };
        //}

        public static bool ValidateUser(string userName, string password)

        {
            var dataAccess = GenericDataAccess.GetDatabase();
            var mongoCollection = GetMongoDBCollection<User>.GetDatabaseCollection(dataAccess, "Users");

            if (mongoCollection.Find(x => x.UserName == userName && x.HashedPassword == password).CountDocuments() == 1)

                return true;
            else
                return false;
        }


        public static bool ValidateIfUserExists(string username, string pan)
        {
            var dataAccess = GenericDataAccess.GetDatabase();
            var mongoCollection = GetMongoDBCollection<User>.GetDatabaseCollection(dataAccess, "Users");
            if (mongoCollection.Find(x => x.UserName == username && x.PAN == pan).CountDocuments() == 1)
                return true;
            else
                return false;
        }

        public static string GetSalt(string username)
        {
            string salt;
            try
            {
                var dataAccess = GenericDataAccess.GetDatabase();
                var mongoCollection = GetMongoDBCollection<User>.GetDatabaseCollection(dataAccess, "Users");

                salt = mongoCollection.Find(x => x.UserName == username).FirstOrDefault().Salt;
                // check how can you select the salt value from json/single value
                if (salt == null)
                    throw new MongoDBDataAccessException("Unable to find salt for respective user");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return salt;
        }

    }
}
