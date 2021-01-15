using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogSystem.BLL;
using BlogSystem.MVCSite.Filters;
using BlogSystem.MVCSite.Models.UserViewModels;

namespace BlogSystem.MVCSite.Controllers
{
    public class HomeController : Controller
    {
        [BlogSystemAuth]
        public ActionResult Index()
        {
            return View();
        }

        [BlogSystemAuth]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [BlogSystemAuth]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //防止别人伪造的戳
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>Register(Models.UserViewModels.RegisterViewModel model)
        {
            //校验
            if (ModelState.IsValid)
            {
                IBLL.IUserManager userManager = new UserManager();
                await userManager.Register(model.Email, model.Password);
                return Content("注册成功");
            }
            return View(model);
        }
        //通过反射来判断有没有Session或者Cooike有的话跳过
        //[AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                IBLL.IUserManager userManager = new UserManager();
                Guid userid;
                if(userManager.Login(model.Email, model.LoginPwd , out userid))
                {
                    if (model.RemeberMe)
                    {
                        Response.Cookies.Add(new HttpCookie("loginName")
                        {
                            Value = model.Email,
                            Expires = DateTime.Now.AddDays(7)
                        });
                        Response.Cookies.Add(new HttpCookie("UserID")
                        {
                            Value = userid.ToString(),
                            Expires = DateTime.Now.AddDays(7)
                        });
                    }
                    else
                    {
                        Session["loginName"] = model.Email;
                        Session["UserID"] = userid;
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "您的账号或密码有误");
                }
            }
            return View(model);
        }
    }
}