using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeirdBlacksmith.Models;

namespace WeirdBlacksmith.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Forge()
        {
            
            ViewBag.Message = "Welcome to the forge!";
            ViewBag.CurrentPage = "forge";
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("NotLoggedIn");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Forge([Bind]Models.WeaponsModels weaponsModels)
        {

            ViewBag.Message = "Welcome to the forge!";
            ViewBag.CurrentPage = "forge";
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserName();
                var db = new ApplicationDbContext();
                var data = (from titles in db.TitleModels
                            where titles.AspNetUsersId == user
                            select titles).First();
                weaponsModels.TitleModelsId = data.Id;
                data.WeaponsCount = data.WeaponsCount + 1;

                if (data.WeaponsCount > 3 && data.Title == "apprentice") {
                    data.WeaponsCount = 0;
                    data.Title = "journeyman";
                    
                }

                if (data.WeaponsCount > 6 && data.Title == "journeyman")
                {
                    data.WeaponsCount = 0;
                    data.Title = "master";
                    data.CurrentUserRole = "moderator";
                }
                if (data.WeaponsCount > 10 && data.Title == "journeyman")
                {
                    data.WeaponsCount = 0;
                    data.Title = "legendary master";
                    data.CurrentUserRole = "admin";
                }
                db.WeaponsModels.Add(weaponsModels);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return Forge();
        }

        public ActionResult Collection()
        {
            var db = new ApplicationDbContext();
            var weapons = db.WeaponsModels.ToArray();
            ViewBag.Message = "Blacksmith likes to show his collection";
            ViewBag.CurrentPage = "collection";
            return View(weapons);
        }

        public ActionResult NotLoggedIn()
        {
            ViewBag.CurrentPage = "notlogged";
            return View();
        }

        public ActionResult AccountMenu()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("NotLoggedIn");
            }
            var db = new ApplicationDbContext();
            var user = User.Identity.GetUserName();
            var data = (from titles in db.TitleModels
                        where titles.AspNetUsersId == user
                        select titles).First();
            ViewBag.CurrentPage = "notlogged";
            return View(data);
        }

        public ActionResult MyWeapons()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("NotLoggedIn");
            }
            var db = new ApplicationDbContext();
            var user = User.Identity.GetUserName();
            var data = (from titles in db.TitleModels
                        where titles.AspNetUsersId == user
                        select titles.Id).First();

            var weaponData = (from weapons in db.WeaponsModels
                              orderby weapons.Rarity
                              where weapons.TitleModelsId == data
                              select weapons).ToArray();
            ViewBag.CurrentPage = "notlogged";
            return View(weaponData);
        }

        [HttpGet]
        public ActionResult Managament()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("NotLoggedIn");
            }
            var user = User.Identity.GetUserName();
            var db = new ApplicationDbContext();
            var weaponData = (from weapons in db.WeaponsModels
                              select weapons).ToArray();

            var users = (from permission in db.TitleModels
                        where permission.OwnedBy == user
                        select permission).First();
            ViewBag.CurrentPage = "notlogged";
            if(users.CurrentUserRole == "moderator")
            {
                ViewBag.UserPermission = "moderator";
            }
            else if(users.CurrentUserRole == "admin")
            {
                ViewBag.UserPermission = "admin";
            }
            else
            {
                return RedirectToAction("NoPermission");
            }
            

            return View(weaponData);
        }

        [HttpPost]
        public ActionResult Managament(WeaponsModels weaponsModels)
        {
            var db = new ApplicationDbContext();
            var summary_delete = from wp in db.WeaponsModels
                                 where wp.Id == weaponsModels.Id
                                 select wp;
            db.WeaponsModels.RemoveRange(summary_delete);

            db.SaveChanges();
            return RedirectToAction("ActionSuccess");
        }



        public ActionResult ActionSuccess()
        {
            ViewBag.CurrentPage = "notlogged";
            return View();
        }

        public ActionResult NoPermission()
        {
            ViewBag.CurrentPage = "notlogged";
            return View();
        }

        [HttpGet]
        public ActionResult ModifyForm(long whatever)
        {
            ViewBag.Whatever = whatever;
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("NotLoggedIn");
            }
            var user = User.Identity.GetUserName();
            var db = new ApplicationDbContext();
            var weaponData = (from weapons in db.WeaponsModels
                              where weapons.Id == whatever
                              select weapons).First();

            var users = (from permission in db.TitleModels
                         where permission.OwnedBy == user
                         select permission).First();
            ViewBag.CurrentPage = "notlogged";
            if (users.CurrentUserRole == "moderator")
            {
                ViewBag.UserPermission = "moderator";
            }
            else if (users.CurrentUserRole == "admin")
            {
                ViewBag.UserPermission = "admin";
            }
            else
            {
                return RedirectToAction("NoPermission");
            }


            return View(weaponData);
        }


        [HttpPost]
        public ActionResult ModifyForm(WeaponsModels weaponsModels)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("NotLoggedIn");
            }
            var user = User.Identity.GetUserName();
            var db = new ApplicationDbContext();
            var weaponData = (from weapons in db.WeaponsModels
                              where weapons.Id == weaponsModels.Id
                              select weapons).First();
            weaponData.Rarity = weaponsModels.Rarity;
            weaponData.Name = weaponsModels.Name;
            weaponData.Description = weaponsModels.Description;
            weaponData.MinDamage = weaponsModels.MinDamage;
            weaponData.MaxDamage = weaponsModels.MaxDamage;
            weaponData.ImageUrl = weaponsModels.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("ActionSuccess");
        }

        [HttpPost]
        public ActionResult Modify(WeaponsModels weaponsModels)
        {
            long idToPass = weaponsModels.Id;  
            return RedirectToAction("ModifyForm", "Home", new { whatever = idToPass });
        }




    }
}