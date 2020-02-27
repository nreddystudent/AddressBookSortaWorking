using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactBook.Models;

namespace ContactBook.Controllers
{
    public class ContactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contacts
        public ActionResult Index(string searchBy, string search)
        {
            var id = UserController.globalUID;
            List<Contact> contacts = new List<Contact>();
            List<User> users = new List<User>();
            var conn = new SqlConnection("data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=|DataDirectory|\\Database1.mdf;integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework");
            SqlCommand command = new SqlCommand("SelectContacts", conn);
            SqlCommand com2nd = new SqlCommand("SELECT * FROM UserView", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserID", UserController.globalUID);
            conn.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var FirstName = reader["First Name"].ToString();
                    var LastName = reader["Last Name"].ToString();
                    var Email = reader["Email"].ToString();
                    var Favorite = (bool)reader["Favourite"];
                    var PhoneNumber = reader["Phone Number"].ToString();
                    var Category = reader["Categories"].ToString();

                    var ContactID = (int)reader["ContactID"];

                    contacts.Add(new Contact() { FirstName = FirstName, LastName = LastName, Email = Email, Favourite = Favorite, CellNumber = PhoneNumber, ContactID = ContactID, Category = new Categories() { Category = Category } });
                }
            }

            conn.Close();

            conn.Open();
            using (var reader = com2nd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var FirstName = reader["FirstName"].ToString();
                    var LastName = reader["LastName"].ToString();
                    var DateOfBirth = (DateTime)reader["DateOfBirth"];
                    users.Add(new User() { FirstName = FirstName, LastName = LastName, DateOfBirth = DateOfBirth });
                }
            }
            conn.Close();

            if (UserController.globalUID > 0)
            {
                ViewBag.Session = UserController.globalUID;
                if (searchBy == "Lastame")
                {
                    return View(db.Contacts.Where(value => (value.LastName == search || search == null) && value.UserID == UserController.globalUID).OrderBy(contact => contact.LastName).ToList());
                }
                else
                {
                    return View(contacts);
                }
            }
            else
                return RedirectToAction("Login", "User");
        }

        // GET: Contacts/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            if (UserController.globalUID > 0)
                ViewBag.Session = UserController.globalUID;
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            if (UserController.globalUID > 0)
                ViewBag.Session = UserController.globalUID;
            return View();
        }

        // POST: Contacts/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,CellNumber,Email,Favourite,CategoryID")] Contact contact)
        {
            var uid = UserController.globalUID;
            contact.UserID = uid;
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                if (UserController.globalUID > 0)
                    ViewBag.Session = UserController.globalUID;
                return RedirectToAction("Index");
            }
            if (UserController.globalUID > 0)
                ViewBag.Session = UserController.globalUID;
            return View(contact);
        }

        // GET: Contacts/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            if (UserController.globalUID > 0)
                ViewBag.Session = UserController.globalUID;
            return View(contact);
        }

        // POST: Contacts/Edit
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactID,FirstName,LastName,CellNumber,Email,Address,UserID,CategoryID")] Contact contact)
        {
            var uid = UserController.globalUID;
            contact.UserID = uid;
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                if (UserController.globalUID > 0)
                    ViewBag.Session = UserController.globalUID;
                return RedirectToAction("Index");
            }
            if (UserController.globalUID > 0)
                ViewBag.Session = UserController.globalUID;
            return View(contact);
        }

        // GET: Contacts/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            if (UserController.globalUID > 0)
                ViewBag.Session = UserController.globalUID;
            return View(contact);
        }

        // POST: Contacts/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
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
