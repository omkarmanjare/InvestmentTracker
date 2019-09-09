using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PM.DataContracts.Response
{
    [DataContract]
    public class CreateUserResponse
    {
        [DataMember]
        public object ID { get; set; }

        [DataMember]
        public bool IsUserCreated { get; set; }

        [DataMember]
        public string Message { get; set; }

    }

    [DataContract]
    public class AuthenticateUserResponse
    {
        [DataMember]
        public bool IsUserAuthenticated { get; set; }

        [DataMember]
        public string AuthenticationToken { get; set; }

    }
}
