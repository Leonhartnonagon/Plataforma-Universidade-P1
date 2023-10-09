using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    public class ChamadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
