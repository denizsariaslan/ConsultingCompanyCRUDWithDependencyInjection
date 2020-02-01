using ConsultingCompany.DataStore;
using ConsultingCompany.Lib;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ConsultingCompanyMVC.Controllers
{
    public class ResourceController : Controller
    {
        // ConsultingCompanyRepository _repository = new ConsultingCompanyRepository();

        readonly IConsultingCompanyRepository _repository;
        public ResourceController(IConsultingCompanyRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult Index()
        {

            var resources = _repository.SelectResource();


            return View(resources);
        }

        //GET: Resources
       // public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
       // {

       //  var resources = _repository.SelectResource();


       // int pageSize = 20;
       //  int pageNumber = (page ?? 1);
       //     return View(resources.ToPagedList(pageNumber, pageSize));
       //  }

        //GET: Resources/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Resources/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resource resource)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    _repository.InsertResource(resource);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(resource);
        }

        //GET: Resources/Edit
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Resource resource = _repository.SelectResource().Where(p => p.Id == id).FirstOrDefault();
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }


        //POST: Resources/Edit
        [HttpPost]
        public ActionResult Edit(Resource resource)
        {
            try
            {
                _repository.UpdateResource(resource);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Resources/Delete
        public ActionResult Delete(int id)
        {
            Resource obj = _repository.SelectResource().Where(x => x.Id == id).FirstOrDefault();
            return View(obj);
        }

        //POST: Resources/Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repository.DeleteResource(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}