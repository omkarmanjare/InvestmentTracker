using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DataContracts.Response
{
    public abstract class PMAbstractResponse
    {
        public int ResponseCode { get; set; }
        public bool IsOperationSuccess { get; set; }
    }
}
