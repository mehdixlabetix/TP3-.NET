using System.Data.SQLite;

namespace TP3.Models
{
    public class Personal_info
    {
        public List<Personne> GetAllPerson()
        {
            List<Personne> list = new List<Personne>();
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:\\Users\\mehdi\\Desktop\\.NET TP3 - SQLite database.db;");
            dbCon.Open();

            using (dbCon)
            {
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM personal_info", dbCon);
                SQLiteDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string prenom = (string)reader["prenom"];
                        string nom = (string)reader["nom"];
                        string email = (string)reader["email"];
                        string image = (string)reader["image"];
                        string pays = (string)reader["pays"];
                        list.Add(new Personne(id, prenom, nom, email, image, pays));
                    }
                }
            }

            return list;
        }
        public Personne GetPerson(int id)
        {
            List<Personne> list = GetAllPerson();
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
