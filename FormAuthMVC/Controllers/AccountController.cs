using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using FormAuthMVC.Models;

namespace FormAuthMVC.Controllers
{
    public class AccountController : Controller
    {
        mydb db = new mydb();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User user, string ReturnUrl = "")
        {
            var count = db.Users.Count(x => x.Username == user.Username && x.Password == user.Password);
            if (count == 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials");
                return View();
            }

            FormsAuthentication.SetAuthCookie(user.Username, false);
            if (!string.IsNullOrEmpty(ReturnUrl)) return Redirect(ReturnUrl);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}