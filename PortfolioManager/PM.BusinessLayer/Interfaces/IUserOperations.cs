using PM.DataContracts;
using PM.DataContracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.BusinessLayer.Interfaces
{
    public interface IUserOperations : IPMOperations
    {
        CreateUserResponse CreateUser(CreateUserRequest createUserRequest);

        void UpdateUserProfile();

        void RemoveUSer();


        bool ValidateUsernameIfExistsAlready(string username, string pan);

        AuthenticateUserResponse AuthenticateUser(string username, string password);

    }
}
