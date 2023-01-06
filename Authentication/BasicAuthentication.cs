using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiSecure.Authentication
{
    public class BasicAuthentication : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                if(actionContext.Request.Headers.Authorization != null)
                {
                    //Se toma el token desde el header
                    var authToken = actionContext.Request.Headers.Authorization.Parameter;

                    //decodifica el parametro
                    var decodeAuthToken = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                    //obtiene usuario y pass 
                    var userNameAndPassword = decodeAuthToken.Split(':');

                    if (IsAuthorizedUser(userNameAndPassword[0], userNameAndPassword[1]))
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userNameAndPassword[0]), null);
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }                    
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public static bool IsAuthorizedUser(string Username, string Password)
        {
            // In this method we can handle our database logic here...  
            //Here we have given the hard-coded values   
            return Username == "nacho" && Password == "123";
        }
    }
}