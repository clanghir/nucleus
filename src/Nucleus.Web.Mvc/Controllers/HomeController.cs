using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Nucleus.Controllers;

namespace Nucleus.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : NucleusControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
