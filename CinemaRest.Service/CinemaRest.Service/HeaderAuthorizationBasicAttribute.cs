using CinemaRest.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace CinemaRest.Service
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class HeaderAuthorizationBasicAttribute : ActionFilterAttribute
    {
        private const string AUTH_HEADER_NAME = "Authorization";
        private const string AUTH_METHOD_NAME = "Basic ";
        private ICinemaContext _context;
        public HeaderAuthorizationBasicAttribute() {
        }
        public HeaderAuthorizationBasicAttribute(ICinemaContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var svc = context.HttpContext.RequestServices;
                var dc = svc.GetService(typeof(ICinemaContext));
                var usernamePasswordString = ParseAuthorizationHeader(context?.HttpContext?.Request);
                if (usernamePasswordString != null)
                {
                    string[] usernamePasswordArray = usernamePasswordString.Split(new char[] { ':' });
                    string username = usernamePasswordArray[0];
                    string password = usernamePasswordArray[1];
                    if ((username != null) && (password != null) && User.SignIn((CinemaContext)dc, username, password))
                    {
                    }
                    else
                    {
                        context.Result = new ContentResult()
                        {
                            Content = "Invalid credentials.",
                            StatusCode = 401
                        };
                    }
                }
                else
                    context.Result = new ContentResult()
                    {
                        Content = "Missing authorization data in Authorization header.",
                        StatusCode = 401
                    };
            }
            catch(Exception ex)
            {
                context.Result = new ContentResult()
                {
                    Content = ex.Message,
                    StatusCode = 400
                };
            }
        }

        private string ParseAuthorizationHeader(HttpRequest request)
        {
            string rtnString = null;
            string authHeader = GetRequestAuthorizationHeaderValue(request);
            if (string.IsNullOrEmpty(authHeader))
            {
                throw new AuthenticationException("You must send your credentials using Authorization header");
            }                
            authHeader = authHeader.Trim();
            if (authHeader.IndexOf("Basic", 0) == 0)
            {
                string encodedCredentials = authHeader.Substring(6);
                byte[] decodedBytes = Convert.FromBase64String(encodedCredentials);
                rtnString = new ASCIIEncoding().GetString(decodedBytes);
            }

            return rtnString;
        }

        private string GetRequestAuthorizationHeaderValue(HttpRequest request)
        {
            return request.Headers.Keys.Contains(AUTH_HEADER_NAME) ? request.Headers[AUTH_HEADER_NAME].First() : null;
        }

        public static string CalculateSHA1(string text)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(hash);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
            
        }
    }
}
