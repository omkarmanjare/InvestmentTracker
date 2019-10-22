using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DataContracts
{

    public class PMCreateRequest
    {

    }

    public class CreateFDRequest : PMCreateRequest
    {
        public string FdId { get; set; }
        public double Amount { get; set; }
        public string FIName { get; set; }
        public string NameOfFirstHolder { get; set; }
        public string NameOfNominee { get; set; }
        public string NameOfOwner { get; set; }
        public DateTime DateFoCreation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public double MaturityAmount { get; set; }
        public double InterestRate { get; set; }
    }


    public class SearchFDRequest
    {
        public string searchKey { get; set; }
    }
   
    public  class CloseFDRequest {


    }
    public class CloseRDResponse { }

}
