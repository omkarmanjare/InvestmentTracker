using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.DataContracts;

//using PortfolioManager.Models;

namespace PM.BusinessLayer.Interfaces
{
    public interface IFDOperations : IPMOperations
    {
        CreateFdResponse CreateFd(CreateFDRequest createFdRequest); 
        SearchFDResponse SearchFD(string searchKey);

    }
}
