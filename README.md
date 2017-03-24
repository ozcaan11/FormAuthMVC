### Custom Form Authentication in Asp.Net MVC
-----

#### Glabal.asax

       protected void Application_Start()
       {
           GlobalFilters.Filters.Add(new AuthorizeAttribute());
       }


----------
#### MyRoleProvider.cs

        public class MyRoleProvider : RoleProvider
        {
            public override string[] GetRolesForUser(string username)
            {
                // get role for this username from database
                var roles = ["Admin","SuperAdmin"];
                return roles;
            }
            
            .
            .
            Other implemented methods.
            .
            .
        }


----------
#### web.config
    <system.web>
      <authentication mode="Forms">
        <forms loginUrl="Account/Login/"></forms>
      </authentication>
      
      <!-- Role type = where your MyRoleProvider class -->
      
      <roleManager enabled="true" defaultProvider="MyProvider">
        <providers>
          <clear />
          <add name="MyProvider" type="FormAuthMVC.Helper.MyRoleProvider" />
        </providers>
      </roleManager>
    </system.web>

----------

#### AccountController

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
        
        FormsAuthentication.SetAuthCookie(user.Username, false);  // false for remember me!
        if (!string.IsNullOrEmpty(ReturnUrl)) return Redirect(ReturnUrl);
        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    public ActionResult Logout()
    {
        FormsAuthentication.SignOut();
        return RedirectToAction("Index", "Home");
    }


----------
#### Any Action or Controller for Filter
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        public ActionResult EmployeeList()
        {
            return View();
        }
