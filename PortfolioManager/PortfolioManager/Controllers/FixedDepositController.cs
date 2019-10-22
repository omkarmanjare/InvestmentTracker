using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PM.BusinessLayer.Interfaces;
using PM.DataContracts;
using System.Web.Http.Description;
using PortfolioManager.Filters;
//using PortfolioManager.Filters;

namespace PortfolioManager.Controllers
{
    public class FixedDepositController : ApiController
    {

        private IFDOperations ifdOperations;// { get; }
        public FixedDepositController(IFDOperations iFDOperations) //: base()
        {
            this.ifdOperations = iFDOperations;
        }

        [BasicAuthentication]
        [HttpGet]
        [Route("fd/test")]
        public IHttpActionResult Get()
        {
            return Ok("Hello....");
        }



        [BasicAuthentication] 
        // can make single attribute Authorize. Thene based on configuration it can be decided
        // weatehr its simple usernamepassword, certificate or JWT token based authentication
        //By using Factory pattern
        [HttpPost]
        [Route("fd/create")]
        [ResponseType(typeof(CreateFdResponse))]
        public IHttpActionResult CreateFD([FromBody] CreateFDRequest fd)
        {
            var response = ifdOperations.CreateFd(fd);
            if (response == null)
                throw new NullReferenceException("Null reference occured while creating FD");
            return Ok(response);
        }

        [BasicAuthentication]
        [HttpPost]
        [Route("fd/search")]
        [ResponseType(typeof(SearchFDResponse))]
        public IHttpActionResult SearchFD([FromBody] SearchFDRequest fd)
        {
            var response = ifdOperations.SearchFD(fd.searchKey);
            if (response == null)
                throw new NullReferenceException("Null reference occured while creating FD");
            return Ok(response);
        }
    }
}