using CMS.BLL.Services;
using CMS.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CMS.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost, ActionName("UserLogin")]
        public ActionResult LoginForCollege(LoginViewModel model)
        {
            // 實務上可能驗證表單.驗證該使用者是否存在.寫在BLL層.Web層只要知道是否登入成功
            var UserID = LoginService.CheckUser(model);
            // 登入成功，寫入FormsAuthentication
            SetLogin(UserID, "Admin");
            return RedirectToAction("Index", "Home");
        }

        /// <summary>寫入FormsAuthentication登入資訊</summary>
        /// <param name="UserID"></param>
        /// <param name="Role"></param>
        private void SetLogin(int UserID, string Role)
        {
            var now = DateTime.Now;
            var ticket = new FormsAuthenticationTicket(
                version: 1,
                name: UserID.ToString(),
                issueDate: now,
                expiration: now.AddHours(12),
                isPersistent: true,
                userData: Role + ",",
                cookiePath: FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(cookie);
        }

        /// <summary>登出頁面</summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            //清除所有的 session
            Session.RemoveAll();

            //建立一個同名的 Cookie 來覆蓋原本的 Cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            //建立 ASP.NET 的 Session Cookie 同樣是為了覆蓋
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
            return RedirectToAction("Index", "Login");
        }

    }
}