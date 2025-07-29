using Microsoft.AspNetCore.Mvc;

namespace ClinicDM.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            
            return View();
        }
    }
}
