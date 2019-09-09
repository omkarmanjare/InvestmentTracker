using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PM.DataContracts
{
    [DataContract]
    public class Requset
    {

    }

    [DataContract]
    public class UserRequset : Requset
    { }


    [DataContract]
    public class CreateUserRequest : UserRequset
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]

        public string Password { get; set; }
        [DataMember]
        public string PAN { get; set; }
    }

    [DataContract]
    public class AuthenticateUserRequest : UserRequset
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }

        public string HashedPassword { get; set; }
        [DataMember]
        public int PAN { get; set; }

    }

    public class UpdateUserRequest
    {
    }

    public class RemoveUserRequest
    {
    }
}
