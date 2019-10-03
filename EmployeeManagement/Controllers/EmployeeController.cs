using AutoMapper;
using EmployeeManagement.ServiceReference1;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        Service1Client svcClient = new Service1Client();
        // GET: Employee
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Models.Employee>>(svcClient.RetreiveEmployees()));
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View(Mapper.Map<Models.Employee>(svcClient.RetreiveEmployeeByID(id)));
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Models.Employee employee)
        {
            try
            {
                svcClient.AddEmployee(Mapper.Map<ServiceReference1.Employee>(employee));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Models.Employee>(svcClient.RetreiveEmployeeByID(id)));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.Employee employee)
        {
            try
            {
                svcClient.UpdateEmployee(Mapper.Map<ServiceReference1.Employee>(employee));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<Models.Employee>(svcClient.RetreiveEmployeeByID(id)));
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                svcClient.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
