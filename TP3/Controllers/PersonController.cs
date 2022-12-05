using Microsoft.AspNetCore.Mvc;
using TP3.Models;

namespace TP3.Controllers
{
    public class PersonController : Controller
    {
        [Route("Personne/{id:int}")]
        public IActionResult index(int id)
        {
            Personal_info p_info = new Personal_info();

            return View(p_info.GetPerson(id));
        }
        [Route("Personne/")]
        public IActionResult all()
        {
            Personal_info p_info = new Personal_info();

            return View(p_info.GetAllPerson());
        }
        [HttpGet]
        public IActionResult search()
        {
            ViewBag.notFound = false;
            return View();
        }
        [HttpPost]
        public IActionResult search(String prenom, String pays)
        {
            Personal_info p_info = new Personal_info();
            List<Personne> p_infoo = p_info.GetAllPerson();
            foreach (Personne p in p_infoo)
            {
                if (p.prenom == prenom && p.pays == pays)
                {
                    return Redirect(p.id.ToString());

                }
            }
            ViewBag.notFound = true;
            return View();
        }
    }
}
