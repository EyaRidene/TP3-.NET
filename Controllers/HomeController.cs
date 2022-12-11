using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using TP3.Models;

namespace TP3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            SQLiteConnection db = new SQLiteConnection("Data Source=C:\\Users\\Eya\\Desktop\\2022 GL3 .NET Framework TP3 - SQLite database.db;");

            try
            {
                db.Open();
                using( db)
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info", db);
                    SQLiteDataReader dataReader = cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            int id = (int)dataReader["id"];
                            string first_name = (string)dataReader["first_name"];
                            string last_name = (string)dataReader["last_name"];
                            string email = (string)dataReader["email"];
                            DateTime birthDate = Convert.ToDateTime((string)dataReader["date_birth"].ToString());
                            string image = (string)dataReader["image"];
                            string country = (string)dataReader["country"];
                            Debug.WriteLine(first_name, " " ,  last_name , " ", email , " ", birthDate , " ", country );
                            db.Close();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine (ex.Message);
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}