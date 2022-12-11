using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP3.Models;

namespace TP3.Controllers
{
    public class PersonController : Controller
    {
        [Route("Person/")]
        public ActionResult All()
        {
            Personal_info persons = new Personal_info();

            return View(persons.GetAllPerson());
        }

        [Route("Person/{id:int}")]
        public ActionResult Index(int id)
        {
            Personal_info persons = new Personal_info();
            if (persons.GetPerson(id)== null)
            {
                ViewBag.notFound = true;
            }
            return View(persons.GetPerson(id));
        }


        public ActionResult Search(String first_name, String country)
        {
            Personal_info info = new Personal_info();
            List<Person> persons = info.GetAllPerson();
            foreach (Person person in persons)
            {
                if (person.first_name == first_name && person.country == country)
                {
                    return RedirectToRoute ("Person/{person.id}");

                }
            }
            ViewBag.notFound = true;
            return View();
            
        }
    }

}