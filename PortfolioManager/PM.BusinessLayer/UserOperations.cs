using PM.BusinessLayer.Interfaces;
using System.IdentityModel.Tokens;
using PM.DataContracts;
//using PM.DataContracts.ResponseContracts;
using PM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using PM.DataContracts.Response;
using Microsoft.IdentityModel.Tokens;




namespace PM.BusinessLayer
{
    public class UserOperations : PMOperations, IUserOperations
    {


        private const string key = "mncvaasdfhfioehasdfalsdfhjasdnfasjkasdldiooiqwerjkl8654asdasdf38655";
        private const int maxLenghtOfSalt = 10;

        public CreateUserResponse CreateUser(CreateUserRequest createUserRequest)
        {
            //generate salt
            string salt = GenerateSalt(maxLenghtOfSalt); // new byte[maxLenghtOfSalt];

            //create hash and then store user name and hased password and salt

            string hashedPassword = CreateHashedPassword(Encoding.UTF8.GetBytes(createUserRequest.Password + salt));

            User user = new User()
            {
                UserName = createUserRequest.Username,
                HashedPassword = hashedPassword,
                Salt = salt.ToString(),
                PAN = createUserRequest.PAN
            };
            var createUserResponse = UserAccess.CreateUser(user);
            return createUserResponse;
        }

        //<<<<<<< HEAD
        protected string GenerateSalt(int length)
        {
            RNGCryptoServiceProvider rngc = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[length];
            rngc.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        protected string GetSaltForGivenUser(string userName)
        {
            return UserAccess.GetSalt(userName);
        }

        protected string CreateHashedPassword(byte[] saltedPassword)
        {
            //string secretKey="mncvaasdfhfioehasdfalsdfhjasdnfasjkasdldiooiqwerjkl8654asdasdf38655";
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            byte[] hashedPassword = hmac.ComputeHash(saltedPassword);
            return Convert.ToBase64String(hashedPassword);
        }


        public AuthenticateUserResponse AuthenticateUser(string userName, string password)
        {
            bool isValidUser = false;
            string encodedString = String.Empty;
            AuthenticateUserResponse response = null;

            if ((!(string.IsNullOrWhiteSpace(userName)) &&
                  !(string.IsNullOrWhiteSpace(password))))
            {
                string salt = GetSaltForGivenUser(userName);

                string hashedPassword = CreateHashedPassword(Encoding.UTF8.GetBytes(password + salt));

                isValidUser = UserAccess.ValidateUser(userName, hashedPassword);
            }

            if (isValidUser)
            {
                HMACSHA256 hmac = new HMACSHA256();
                hmac.Key = Encoding.UTF8.GetBytes(key);
                byte[] secretKey = hmac.Key;

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor();

                JwtSecurityToken token = tokenHandler.CreateJwtSecurityToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity
                    (new[] {
                                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name,userName)
                                }
                    ),
                    Issuer = "http://localhost:53596",
                    Expires = DateTime.Now.AddMinutes(30),
                    NotBefore = DateTime.Now,
                    IssuedAt = DateTime.Now,
                    SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                    (new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(secretKey),
                                                        SecurityAlgorithms.HmacSha256Signature)
                });
                encodedString = tokenHandler.WriteToken(token);

                response = new AuthenticateUserResponse()
                {
                    IsUserAuthenticated = true,
                    AuthenticationToken = encodedString
                };
            }
            else
            {
                response = new AuthenticateUserResponse()
                {
                    IsUserAuthenticated = false,
                    AuthenticationToken = string.Empty
                };
            }
            return response;
        }

        public bool ValidateToken(string token)
        {

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = (JwtSecurityToken)handler.ReadToken(token);
            Microsoft.IdentityModel.Tokens.SecurityToken validatedToken;
            HMACSHA256 hmac = new HMACSHA256();
            hmac.Key = Encoding.UTF8.GetBytes(key);
            byte[] secretKey = hmac.Key;

            Microsoft.IdentityModel.Tokens.TokenValidationParameters validationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = "http://localhost:64907",
                ValidateLifetime = true,
                ValidateAudience = false,
                RequireExpirationTime = true,
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(secretKey),

            };

            ClaimsPrincipal claimPrinciple = handler.ValidateToken(token, validationParameters, out validatedToken);

            //1.Add try catch block
            //2.Add  respective Custom Exception handling 


            return true;

        }
        public void RemoveUSer()
        {
            throw new NotImplementedException();
        }

        public void UpdateUserProfile()
        {
            throw new NotImplementedException();
        }
        //<<<<<<< HEAD

        public bool ValidateUsernameIfExistsAlready(string username, string pan)
        {
            if (UserAccess.ValidateIfUserExists(username, pan))
                return true;
            else
                return false;
        }


    }



}

