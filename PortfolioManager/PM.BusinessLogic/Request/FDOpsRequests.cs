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
        public string NameOfHolder { get; set; }
        public string NameOfNominee { get; set; }
        public DateTime DateFoCreation { get; set; }
        public DateTime MaturityDate { get; set; }
        public double MaturityAmount { get; set; }
        public double InterestRate { get; set; }
    }


    public class SearchFDRequest
    {
        public object searchKey { get; set; }
    }


    public class SearchFDResponse
    {
        public List<FixedDeposite> searchResult { get; set; }
    }

}
