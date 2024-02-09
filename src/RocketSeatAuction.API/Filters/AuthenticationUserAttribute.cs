using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Repositories;

namespace RocketSeatAuction.API.Filters
{
    public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IUserRepository _repository;
        public AuthenticationUserAttribute(IUserRepository respository) 
        {
                _repository = respository;
        } 
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string token = TokenOnRequest(context.HttpContext);

                var email = FromBase64String(token);

                var existingUser = _repository.ExistUserWithEmail(email);

                if (!existingUser)
                {
                    context.Result = new UnauthorizedObjectResult("Email not valid");
                }
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
        }

        private string TokenOnRequest(HttpContext context)
        {

            var authentication = context.Request.Headers.Authorization.ToString();

            //Bearer Y3Jpc3RpYW5vQGNyaXN0aWFuby5jb20=

            if (string.IsNullOrEmpty(authentication))
            {
                throw new Exception("Token is missing.");
            }

            return authentication["Bearer ".Length..];
        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}

