using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.Controllers
{
    public class AuthenticationController : Controller
    {
        public async Task Logout()
        {
            // Clears the  local cookie ("RMDBCookies" must match scheme)
            await HttpContext.SignOutAsync("RMDBCookies");
            // Logs out of the IDP
            await HttpContext.SignOutAsync("oidc");             
        }
    }
}
