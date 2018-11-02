using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Address);
            return View(customers.ToList());
        }


        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            customer.Address = db.Addresses.Where(a => a.Id == customer.AddressId).SingleOrDefault();

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            string user = User.Identity.GetUserId();
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "NumberAndStreet");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Email,PhoneNumber,AddressId,UserName,PickupDay,PickupStartDate,PickupEndDate,SpecialPickup,SuspendStartDate,SuspendEndDate,MoneyOwed,Balance, Address")] Customer customer)
        public ActionResult Create([Bind(Include = "Name,Email,PhoneNumber,UserName,PickupDay,PickupStartDate,PickupEndDate,SpecialPickup,SuspendStartDate,SuspendEndDate,Address")] Customer customer)

        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(customer.Address);
                db.SaveChanges();

                customer.AddressId = customer.Address.Id;               
                customer.ApplicationCustId = User.Identity.GetUserId();
                
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "NumberAndStreet", customer.AddressId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);           
            customer.Address = db.Addresses.Where(a => a.Id == customer.AddressId).SingleOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AddressId = new SelectList(db.Addresses, "Id", "NumberAndStreet", "Zipcode", customer.AddressId);
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "NumberAndStreet", "Zipcode", customer.AddressId);

            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Email,PhoneNumber,AddressId,Name,UserName,PickupDay,PickupStartDate,PickupEndDate,SpecialPickup,SuspendStartDate,SuspendEndDate,MoneyOwed,Balance")] Customer customer)
        public ActionResult Edit([Bind(Include = "Id,Email,PhoneNumber,Name,UserName,PickupDay,PickupStartDate,PickupEndDate,SpecialPickup,SuspendStartDate,SuspendEndDate,AddressId,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;

                //db.Customers.Add(viewModel.customer);
                //db.Addresses.Add(viewModel.address);
                
                //db.Entry(customer.Address).State = EntityState.Modified;

                db.SaveChanges();
                var updatedAddress = db.Addresses.Where(a => a.Id == customer.AddressId).FirstOrDefault();
                updatedAddress.City = customer.Address.City;
                updatedAddress.NumberAndStreet = customer.Address.NumberAndStreet;
                updatedAddress.State = customer.Address.State;
                updatedAddress.Zipcode = customer.Address.Zipcode;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "NumberAndStreet", customer.AddressId);
            //ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Zipcode", customer.AddressId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
