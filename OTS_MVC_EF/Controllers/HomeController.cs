using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTS_MVC_EF.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace OTS_MVC_EF.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var db = new SalesDBContext();
            db.Database.Log += Log;


            //Grab the employee with an ID of 1
            var test1 = db.Employees.Find(1);
            //if SalesIMade is marked virtual then this Count() call will be lazy loaded. If not 
            //it will not hit the database and thus return 0.
            var num = test1.SalesIMade.Count();


            //Test JOIN
            var results = from e in db.Employees
                          join s in db.Sales on e.Id equals s.Salesperson.Id

                          select
                          new
                          {
                              e.Name,
                              e.Id,
                              Sales = s.Amount,
                          };

            //Notice that "results" query will not execute until we call ToList (or loop through the results). 
            //This is called deferred query exectuion.
            var test2 = results.ToList();


            //AsNoTracking will not cache the results. We are not able to update these results in the database.
            //Performance will be faster with this command.
            var result = db.Employees.AsNoTracking()
                 .Select(e =>
                 new
                 {
                     e.Name,
                     e.Id,

                     Sales = e.SalesIMade.Select(s => new
                     {
                         s.Description,
                         Amount = s.Amount
                     })
                 }).OrderBy(x => x.Name).Skip(1).Take(1).ToList();




            //Using Find() will perform first level caching. Repeated calls for the same entity with the same
            //primary key will not result in any more calls to the database.
            var test3 = db.Employees.Find(1);
            test3 = db.Employees.Find(1);
            test3 = db.Employees.Find(1);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Used to write the DB Context's logging out to the debug window.
        /// </summary>
        /// <param name="s"></param>
        private void Log(string s)
        {
            Debug.Write(s);
        }


    }
}