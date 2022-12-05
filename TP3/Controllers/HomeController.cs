using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System.Diagnostics;
using TP3.Models;
//using System.Data.SQLite;
namespace TP3.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            Debug.WriteLine("Get started ... ");
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

                        Debug.WriteLine("id = {0} prenom = {1}  nom = {2}  email={3}  image= {4}  pays= {5}  date=", id, prenom, nom, email, image, pays);
                    }


                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}