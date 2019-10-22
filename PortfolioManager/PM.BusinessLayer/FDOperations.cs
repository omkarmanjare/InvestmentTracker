using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.BusinessLayer.Interfaces;
using PM.DataContracts;
using PM.DataLayer;



namespace PM.BusinessLayer
{
    public class FDOperations : PMOperations, IFDOperations //How ablout creating the static class
    {
        public CreateFdResponse CreateFd(CreateFDRequest requestModel)
        {
            CreateFdResponse response = null;

            if (requestModel != null)
            {
                try
                {
                    response = FDAccess.Insert(new FixedDeposite()
                    {
                        Amount = requestModel.Amount,
                        DateFoCreation = requestModel.DateFoCreation,
                        FIName = requestModel.FIName,
                        InterestRate = requestModel.InterestRate,
                        MaturityAmount = requestModel.MaturityAmount,
                        StartDate = requestModel.StartDate,
                        NameOfOwner = requestModel.NameOfOwner,
                        MaturityDate = requestModel.MaturityDate,
                        NameOfHolder = requestModel.NameOfFirstHolder,
                        NameOfNominee = requestModel.NameOfNominee,
                        FdId = requestModel.FdId
                    });

                }

                catch (Exception ex)
                {

                    throw new Exception(ex.Message);

                    //log ex

                }
            }
            return response;
        }
        public SearchFDResponse SearchFD(string searchKey)
        {
           return  FDAccess.SearchFD(searchKey);           
        }
    }
}
