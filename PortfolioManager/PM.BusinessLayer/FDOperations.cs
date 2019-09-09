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
                    //FixedDeposite Object = 

                    response = FDAccess.Insert(new FixedDeposite()
                    {
                        Amount = requestModel.Amount,
                        DateFoCreation = requestModel.DateFoCreation,
                        FIName = requestModel.FIName,
                        InterestRate = requestModel.InterestRate,
                        MaturityAmount = requestModel.MaturityAmount,
                        MaturityDate = requestModel.MaturityDate,
                        NameOfHolder = requestModel.NameOfHolder,
                        NameOfNominee = requestModel.NameOfNominee,
                        FdId = requestModel.FdId
                    });


                    //response = FDAccess.Insert();
                }

                catch (Exception ex)
                {

                    throw new Exception(ex.Message);

                    //log ex

                }
            }
            return response;
        }
        public List<SearchFDResponse> GetFD()
        {
            //var mapper = Mapper.Map<FixedDeposite>(requestModel);

            //var fdGet = FDAccess.GetFD();

            //Call to databse operations and
            return new List<SearchFDResponse>();
            // throw new NotImplementedException();
        }




    }
}
