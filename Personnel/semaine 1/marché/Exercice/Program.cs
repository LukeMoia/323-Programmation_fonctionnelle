using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vendeur> Vendeurs = new List<Vendeur>();
            StreamReader streamexel = new StreamReader("../../../Place du marché.csv", Encoding.UTF8 );
            streamexel.ReadLine();
            while (!streamexel.EndOfStream)
            {
                string[] str = streamexel.ReadLine().Split(';');
                Vendeurs.Add(new Vendeur(Convert.ToInt32(str[0]), str[1], str[2], Convert.ToInt32(str[3]), str[4], float.Parse(str[5])));
            }

            IEnumerable<Vendeur> VendeursPeches = from Vendeur in Vendeurs where Vendeur.Produit == "Pêches" select Vendeur;
            Console.WriteLine($"1: Il y a {VendeursPeches.Count()} vendeurs de pêches");
            IEnumerable<Vendeur> VendeursPasteques = (from Vendeur in Vendeurs where Vendeur.Produit == "Pastèques" select Vendeur).OrderByDescending(vend => vend.Quantite) ;
            Console.WriteLine($"2: C'est {VendeursPasteques.First().Producteur}. Il est sur le stand {VendeursPasteques.First().Emplacement}. Il a {VendeursPasteques.First().Quantite} {VendeursPasteques.First().Produit}.");
            Console.ReadLine();

            /* // ou
            int Vpeche = 0;
            Vendeur vendpast = new Vendeur(0);

            foreach (Vendeur vendeur in Vendeurs)
            { 
                // Console.WriteLine(vendeur.Produit);
                if(vendeur.Produit == "Pêches")
                {
                    Vpeche++;
                }
                if(vendeur.Produit == "Pastèques" && vendeur.Quantite >= vendpast.Quantite)
                {
                    vendpast = vendeur;
                }
            }
                Console.WriteLine($"1: Il y a {Vpeche} vendeurs de pêches");
                Console.WriteLine($"2: C'est {vendpast.Producteur}. Il est sur le stand {vendpast.Emplacement}. Il a {vendpast.Quantite} {vendpast.Produit}.");
            Console.ReadLine();*/
        }
    }

    public class Vendeur
    {

        public Vendeur(int emplacement, string producteur, string produit, int quantite, string unite, float prixParUnite)
        {
            Emplacement = emplacement;
            Producteur = producteur;
            Produit = produit;
            Quantite = quantite;
            Unite = unite;
            PrixParUnite = prixParUnite;
        }

        public Vendeur(int quantite)
        {
            Quantite = quantite;
        }

        public int Emplacement { get; set; }
        public string Producteur { get; set; }
        public string Produit { get; set; }
        public int Quantite { get; set; }
        public string Unite { get; set; }
        public float PrixParUnite { get; set; }
    }
}
