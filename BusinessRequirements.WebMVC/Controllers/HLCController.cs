using BusinessRequirements.Models.HLC;
using BusinessRequirements.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessRequirements.WebMVC.Controllers
{
    [Authorize]
    public class HLCController : Controller
    {     
        // GET: LIST (HLC)
        public ActionResult Index()
        {
            var service = CreateHLCService();
            var model = service.GetHLCs();

            return View(model);
        }
        //GET : Create
        public ActionResult Create()
        {
            return View();
        }
        //POST : Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HLCCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateHLCService();
            if (service.CreateHLC(model))
            {
                 TempData["SaveResult"] = "HLC was created";
                 return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "HLC Could not be createad");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateHLCService();
            var model = svc.GetHLCById(id);

            return View(model);
        }
        //EDIT//
        public ActionResult Edit(int id)
        {
            var service = CreateHLCService();
            var detail = service.GetHLCById(id);
            var model =
                new HLCEdit
                {
                    HLCId = detail.HLCId,
                    HLCNumber = detail.HLCNumber,
                    HLCDescription = detail.HLCDescription      
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HLCEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.HLCId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateHLCService();

            if (service.UpdateHLC(model))
            {
                TempData["SaveResult"] = "HLC was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "HLC could not be updated.");
            return View(model);
        }

        //DELETE//
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateHLCService();
            var model  = svc.GetHLCById(id);
          
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateHLCService();

            service.DeleteHLC(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }







        //Refactored Code//
        private HLCService CreateHLCService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HLCService(userId);
            return service;
        }






        //public ActionResult Create(HLCCreate model)
        //{
        //    if (ModelState.IsValid) return View(model);
        //    var service = CreateHLCService();
        //    if (service.CreateHLC(model))
        //    {
        //        TempData["SaveResult"] = "HLC was created.";
        //        return RedirectToAction("Index");
        //    };
        //    ModelState.AddModelError("", "HLC could not be created.");

        //    return View(model);
        //}


        //


    }
}