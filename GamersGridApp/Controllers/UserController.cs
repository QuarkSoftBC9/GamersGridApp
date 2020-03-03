using GamersGridApp.Models;
using GamersGridApp.ViewModels;
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
            var viewmodel = new UserRegisterViewModel();

            return View("UserFormRegister", viewmodel);
        }

        public ActionResult Edit()
        {
            var viewmodel = new UserFormEditViewModel();

            return View("UserFormEdit", viewmodel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveRegister(UserRegisterViewModel userViewModel)
        {
            var newUser = new User()
            {
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                Email = userViewModel.Email

            };
            context.GamersGridUsers.Add(newUser);

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEdit(User user)
        {
            //Edit
            var userInDb = context.GamersGridUsers.Single(u => u.ID == user.ID);

            userInDb.FirstName = user.FirstName;
            userInDb.LastName = user.LastName;
            userInDb.Email = user.Email;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}