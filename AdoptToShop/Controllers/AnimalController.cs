using AdoptToShop.Models;
using AdoptToShop.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace AdoptToShop.Controllers
{
    [Authorize]
    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AnimalService(userId);
            var model = service.GetAnimal();

            return View(model);
        }

        // GET : Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnimalCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAnimalService();

            if (service.CreateAnimal(model))
            {
                TempData["SaveResult"] = "Your entry was added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Entry could not be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAnimalService();
            var model = svc.GetAnimalById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAnimalService();
            var detail = service.GetAnimalById(id);
            var model =
                new AnimalEdit
                {
                    PetId = detail.PetId,
                    Name = detail.Name,
                    Species = detail.Species,
                    Sex = detail.Sex,
                    Breed = detail.Breed,
                    Age = detail.Age,
                    Spayed = detail.Spayed,
                    Description = detail.Description,
                    Availability = detail.Availability
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, AnimalEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PetId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAnimalService();

            if (service.UpdateAnimal(model))
            {
                TempData["SaveResult"] = "Your pet info was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your pet info could not be updated");
            return View(model);
        }

        // DELETE

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAnimalService();
            var model = svc.GetAnimalById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(Guid id)
        {
            var service = CreateAnimalService();

            service.DeleteAnimal(id);

            TempData["SaveResult"] = "Your pet was deleted.";

            return RedirectToAction("Index");
        }

        private AnimalService CreateAnimalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AnimalService(userId);
            return service;
        }
    }
}