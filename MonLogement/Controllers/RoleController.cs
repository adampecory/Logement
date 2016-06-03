using MonLogement.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using MonLogement.Services;

namespace MonLogement.Controllers
{
    public class RoleController : Controller
    {


        RoleService svc = new RoleService();


        //GET  /Role
        public ActionResult Index()
        {
            IEnumerable<Role> model = new List<Role>();
            model = svc.GetAll();
            return View(model);
        }

        //GET  /Role/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST  /Role/Create
        [HttpPost]
        public ActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                svc.Add(role);
                return RedirectToAction("Index");
            }
            return View();           
        }

        //GET /Role/Edit
        public ActionResult Edit(long id)
        {
            var model = new Role();
            model = svc.GetbyId(id);
            return View(model);
        }

        //POST /Role/Edit
        [HttpPost]
        public ActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                svc.Update(role);
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET /Role/Delete
        public ActionResult Delete(long id)
        {
            var model = new Role();
            model = svc.GetbyId(id);
            return View(model);
        }

        //POST /Role/Delete
        [HttpPost]
        public ActionResult Delete(Role role)
        {
            try
            {
                svc.Delete(role.Id);;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }




	}
}