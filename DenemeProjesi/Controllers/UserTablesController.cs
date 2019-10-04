using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DenemeProjesi.Models;

namespace DenemeProjesi.Controllers
{
    public class UserTablesController : Controller
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers userTable = db.Customers.Find(id);
            db.Customers.Remove(userTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers userTable = db.Customers.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AvatarURL,FirstName,LastName,CompanyName,ContactPhone,EmailAddess,CompanySite")] Customers userTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userTable);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customers userTable)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(userTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userTable);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int? ContactName)
        {
            if (ContactName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(ContactName);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customer() 
        {
            var user = db.Customers.ToList();
            return View(user);
        }

        public ActionResult CustomerDemo()
        {
            var user = db.CustomerDemographics.ToList();
            return View(user);
        }

        public ActionResult Categories()
        {
            var user = db.Categories.ToList();
            return View(user);
        }

        public ActionResult Employees()
        {
            var user = db.Employees.ToList();
            return View(user);
        }

        public ActionResult OrderDetail()
        {
            var user = db.Order_Details.ToList();
            return View(user);
        }

        public ActionResult Orders()
        {
            var user = db.Orders.ToList();
            return View(user);
        }

        public ActionResult Product()
        {
            var user = db.Products.ToList();
            return View(user);
        }

        public ActionResult Region()
        {
            var user = db.Region.ToList();
            return View();
        }

        public ActionResult Shippers()
        {
            var user = db.Shippers.ToList();
            return View(user);
        }

        public ActionResult Suppliers()
        {
            var user = db.Suppliers.ToList();
            return View(user);
        }

        public ActionResult sysdiagrams()
        {
            var user = db.sysdiagrams.ToList();
            return View();
        }

        public ActionResult ListUser()
        {
            var user = db.Employees.ToList();
            return View(user);
        }

        public ActionResult Territories()
        {
            var user = db.Territories.ToList();
            return View(user);
        }

    }
}