using BusinessRequirements.Models.Project;
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
    public class ProjectController : Controller
    {
        // GET: LIST(Project)
        public ActionResult Index()
        {
            var service = CreateProjectService();
            var model = service.GetProjects();

            return View(model);

        }
        public ActionResult Create()
        {
            return View();
        }
        //Create Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateProjectService();
            if (service.CreateProject(model))
            {
                TempData["SaveResult"] = "Your Project was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Project could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProjectService();
            var detail = service.GetProjectById(id);
            var model =
                new ProjectEdit
                {
                    ProjectId = detail.ProjectId,
                    Ticket = detail.Ticket,
                    ProjectName = detail.ProjectName,
                    Area = detail.Area,
                    Budget = detail.Budget
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProjectId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProjectService();

            if (service.UpdateProject(model))
            {
                TempData["SaveResult"] = "Your project was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your project could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProjectService();

            service.DeleteProject(id);

            TempData["SaveResult"] = "Your project was deleted";

            return RedirectToAction("Index");
        }


        //Refactored Code//
        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            return service;
        }
    }
}