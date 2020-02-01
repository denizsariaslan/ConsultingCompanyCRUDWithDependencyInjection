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
    public class ClientController : Controller
    {
        //ConsultingCompanyRepository _repository = new ConsultingCompanyRepository();

        readonly IConsultingCompanyRepository _repository;
        public ClientController(IConsultingCompanyRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult Index()
        {

            var clients = _repository.GetAllClients();

            
            return View(clients);
        }

        // GET: Clients
        //public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        //{
        //    var clients = _repository.GetAllClients();

        //    int pageSize = 20;
        //    int pageNumber = (page ?? 1);
        //    return View(clients.ToPagedList(pageNumber, pageSize));
        //}

        //GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

     

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {

            try
            {
                if (ModelState.IsValid)
                {

                  _repository.InsertClient(client);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(client);
        }

        // GET: Clients/Edit
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client client = _repository.GetAllClients().Where(p => p.Id == id).FirstOrDefault();
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // Post: Clients/Edit

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            try
            {
                _repository.UpdateClient(client);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clients/Delete
        public ActionResult Delete(int id)
        {
            Client obj = _repository.GetAllClients().Where(p => p.Id == id).FirstOrDefault();
            return View(obj);
        }

        // POST: Clients/Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repository.DeleteClient(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

    }
}