namespace TP3.Models
{
    public class Personne
    {
        public int id { get; set; }
        public string prenom { get; set; }
        public string nom { get; set; }
        public string email { get; set; }
        public string image { get; set; }
        public string pays { get; set; }

        public Personne(int id, string prenom, string nom, string email, string image, string pays)
        {
            this.id = id;
            this.prenom = prenom;
            this.nom = nom;
            this.email = email;
            this.image = image;
            this.pays = pays;
        }
    }
}
