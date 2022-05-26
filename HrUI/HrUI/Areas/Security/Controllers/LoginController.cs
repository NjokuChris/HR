using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HrUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseSecurityController
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(user user)
        {
            try
            {
                if (Membership.ValidateUser(user.email, user.password))
                {
                    FormsAuthentication.SetAuthCookie(user.email, false);
                    return RedirectToAction("Index", "Home", new { area = "common" });
                }
                else
                {
                    TempData["Msg"] = "Login Failed ";
                    return RedirectToAction("Index");
                }

            }
            catch(Exception E1)
            {
                TempData["Msg"] = "Login Failed "+ E1.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login", new { area = "Security" });
        }
    }
}