using PM.BusinessLayer.Interfaces;
using PM.DataContracts;
using PM.DataContracts.Response;

//using PortfolioManager.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PortfolioManager.Controllers
{
    public class UserController : ApiController
    {
        private IUserOperations _iUserOperations;

        public UserController()
        {

        }

        public UserController(IUserOperations iUserOperations)
        {
            this._iUserOperations = iUserOperations;
        }

        [HttpPost]
       // [ModelFilter]
        [Route("user/create")]
        [ResponseType(typeof(CreateUserResponse))]
        public IHttpActionResult RegisterUser([FromBody]CreateUserRequest createUserRequest)
        {
            bool isUsernameExists = false;
            CreateUserResponse createUserResponse;

            //validate if user with same number exists or not
            isUsernameExists = _iUserOperations.ValidateUsernameIfExistsAlready(createUserRequest.Username, createUserRequest.PAN);
            if (isUsernameExists)
                createUserResponse = new CreateUserResponse() { ID = null, IsUserCreated = false, Message = "User already exists" };
            else
                createUserResponse = _iUserOperations.CreateUser(createUserRequest);

            return Ok(createUserResponse);
        }

        //AuthenticateUser
        [HttpPost]
       // [ModelFilter]
        [Route("user/authenticate")]
        [ResponseType(typeof(AuthenticateUserResponse))]
        public IHttpActionResult AuthenticateUser([FromBody]AuthenticateUserRequest request)
        {
            AuthenticateUserResponse response = null;
            response = _iUserOperations.AuthenticateUser(request.Username, request.Password);

            if (response.IsUserAuthenticated)
                return Ok(response);
            else
                return Ok(response);
        }

      //  [HttpPost]
      ////  [ModelFilter]
      //  [Route("user/create")]
      //  public IHttpActionResult CreateUser([FromBody]CreateUserRequest createUserRequest)
      //  {
      //      var createUser = _iUserOperations.CreateUser(createUserRequest);
      //      return Ok(createUser);
      //  }
    }
}