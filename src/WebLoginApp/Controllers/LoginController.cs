using System.Threading.Tasks;
using System.Web.Mvc;
using EventTriggerLibrary.Services;

namespace WebLoginApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;

        public LoginController()
        {
            _authService = MvcApplication.Container.Resolve<IAuthService>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string username, string password)
        {
            var success = await _authService.LoginAsync(username, password);
            ViewBag.Result = success;
            return View();
        }
    }
}
