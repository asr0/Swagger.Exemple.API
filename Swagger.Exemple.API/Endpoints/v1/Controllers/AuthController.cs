using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Swagger.Exemple.API.Endpoints.v1.Controllers
{
    public class AuthController : Controller
    {

        [AllowAnonymous]
        public ActionResult<string> Login(string user, string pass)
        {
            return "abc";
        }



    }
}
