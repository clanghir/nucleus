using Microsoft.AspNetCore.Antiforgery;
using Nucleus.Controllers;

namespace Nucleus.Web.Host.Controllers
{
    public class AntiForgeryController : NucleusControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
