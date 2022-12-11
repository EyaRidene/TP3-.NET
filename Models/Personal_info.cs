using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Drawing;

namespace TP3.Models
{
    public class Personal_info
    {
        public List<Person> GetAllPerson()
        {
            List<Person> persons = new List<Person>();
            SQLiteConnection db = new SQLiteConnection("Data Source=C:\\Users\\Eya\\Desktop\\TP3_database.db;");
            
            try
            {
                db.Open();
                using (db)
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info ", db);
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
                            persons.Add(new Person(id, first_name, last_name, email, birthDate ,image, country));
                        }
                    }
                }

                return persons;
            }
            catch (Exception ex)
            {
                return null;
            }

            
        }
        public Person GetPerson(int id)
        {
            List<Person> list = GetAllPerson();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].id == id)
                {
                    return list[i];
                }
            }
            return null;

        }

    }
}