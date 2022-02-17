using AdoptToShop.Models;
using AdoptToShop.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoptToShop.Controllers
{
    [Authorize]
    public class AdopterController : Controller
    {
        // GET: Adopter
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AdopterService(userId);
            var model = service.GetAdopter();

            return View(model);
        }

        // GET : Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdopterCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAdopterService();

            if (service.CreateAdopter(model))
            {
                TempData["SaveResult"] = "Your entry was added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Entry could not be added.");

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var svc = CreateAdopterService();
            var model = svc.GetAdopterById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAdopterService();
            var detail = service.GetAdopterById(id);
            var model =
                new AdopterEdit
                {
                    AdopterId = detail.AdopterId,
                    FullName = detail.FullName,
                    Contact = detail.Contact,
                    Approved = detail.Approved
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, AdopterEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AdopterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch.");
                return View(model);
            }

            var service = CreateAdopterService();

            if (service.UpdateAdopter(model))
            {
                TempData["SaveResult"] = "Your info was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your info could not be udpated");
            return View(model);
        }

        // DELETE
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAdopterService();
            var model = svc.GetAdopterById(id);

            return View(model);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(Guid id)
        {
            var service = CreateAdopterService();
            service.DeteleAdopter(id);
            TempData["SaveResult"] = "Your info was deleted.";
            return RedirectToAction("Index");
        }


        private AdopterService CreateAdopterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AdopterService(userId);
            return service;
        }
    }
}