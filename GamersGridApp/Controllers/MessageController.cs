using GamersGridApp.Models;
using GamersGridApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GamersGridApp.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        private ApplicationDbContext db = new ApplicationDbContext();
        //var currentUser = db.Users.Where(u => u.Id == CurrentUserID).SingleOrDefault();

        [Authorize]
        public ActionResult MessageBoard()
        {
            var CurrentUserID = User.Identity.GetUserId();
            var currentUser = db.Users.Where(u =>u.Id==CurrentUserID).Select(u=>u.UserAccount).SingleOrDefault();

            var viewmodel = new MessageBoardViewModel
            {
                MessageChats = db.MessageChats.Include(m => m.Users).Include(m => m.ChatHistory).Where(m => m.Users.Contains(db.Users.Where(u => u.Id == CurrentUserID).Select(u => u.UserAccount).FirstOrDefault())).ToList(),
                CurrentUserNickName = currentUser.NickName,
                CurrentChatID = 1

            };


            return View(viewmodel);
        }
    }
}