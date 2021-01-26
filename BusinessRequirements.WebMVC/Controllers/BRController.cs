using BusinessRequirements.Models.BR;
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
    public class BRController : Controller
    {
        // GET: LIST (BR)
        public ActionResult Index(int? projectId,int? hlcId)
        {
            var service = CreateBRService();
            var model = service.GetBRs(projectId,hlcId);

            return View(model);
        }
        ////GET : Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //GET : Create
        public ActionResult Create(int? projectId, int? hlcId) //Nullable Ints
        {
            if (projectId == null || hlcId == null) { return View(); }

            BRCreate model = new BRCreate()
            {
                ProjectId = (int)projectId,
                HLCId = (int)hlcId
            };
            return View(model);
        }

        //POST : Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BRCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateBRService();
            if (service.CreateBR(model))
            {
                TempData["SaveResult"] = "BR was created";
                return RedirectToAction("Index",new {HLCId = model.HLCId });//Redirect to the BR view filtered by the HLC
            };
            ModelState.AddModelError("", "BR Could not be createad");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateBRService();
            var model = svc.GetBRById(id);

            return View(model);
        }
        //EDIT//
        public ActionResult Edit(int id)
        {
            var service = CreateBRService();
            var detail = service.GetBRById(id);
            var model =
                new BREdit
                {
                    BRId = detail.BRId,
                    BRNumber = detail.BRNumber,
                    HLCNumber = detail.HLCNumber,
                    ProjectName = detail.ProjectName,
                    ProjectId = detail.ProjectId,
                    HLCId = detail.HLCId,
                    BusinessRequirement = detail.BusinessRequirement
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BREdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BRId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBRService();

            if (service.UpdateBR(model))
            {
                TempData["SaveResult"] = "BR was updated.";
                return RedirectToAction("Index",new {projectid = model.ProjectId });
            }

            ModelState.AddModelError("", "BR could not be updated.");
            return View(model);
        }

        //DELETE//
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBRService();
            var model = svc.GetBRById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBRService();

            service.DeleteBR(id);

            TempData["SaveResult"] = "Your BR was deleted";

            return RedirectToAction("Index");
        }




        //Refactored Code//
        private BRService CreateBRService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BRService(userId);
            return service;
        }
    }
}