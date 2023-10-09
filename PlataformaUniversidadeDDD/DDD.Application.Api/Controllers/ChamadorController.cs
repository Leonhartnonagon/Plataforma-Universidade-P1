using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    public class ChamadorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
