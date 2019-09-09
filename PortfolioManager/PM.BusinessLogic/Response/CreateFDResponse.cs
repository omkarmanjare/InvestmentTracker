//using PM.BusinessLogic.Response;
using PM.DataContracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PM.DataContracts
{
    [DataContract]
    public class CreateFdResponse : PMAbstractResponse
    {
        [DataMember]
        public object FDId { get; set; }
        [DataMember]
        public bool IsFdCreated { get; set; }
    }

}
