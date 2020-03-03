using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamersGridApp.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public UserController()
        {
            context = new ApplicationDbContext();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProfilePage()
        {
            return View();
        }

        public ActionResult Register()
        {
            var viewmodel = new UserFormViewModel();

            return View("UserForm",viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(User user)
        {
            if (user.id == 0)
            {
                var newUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email

                };
                context.GamersGridUsers.Add(newUser);
            }
            else
            {
                var userInDb = context.GamersGridUsers.Single(u => u.Id == user.id);

                FirstName = user.FirstName;
                LastName = user.LastName;
                Email = user.Email;
            }

            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}