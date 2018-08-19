using ProjetConsole.Data.Metier;
using ProjetConsole.Outils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Data
{
    public class DestinationDonnees : IAccesDonnees<Destination>
    {
        private List<Destination> destinations;

        public IEnumerable<Destination> GetListe()
        {
            InitialiserListe();
            return this.destinations;
        }

        public void Enregistrer(Destination destination)
        {
            InitialiserListe();
            if (!this.destinations.Contains(destination))
            {
                this.destinations.Add(destination);
            }

            this.EcrireFichier();
        }

        public void Supprimer(Destination destination)
        {
            InitialiserListe();
            this.destinations.Remove(destination);
            this.EcrireFichier();
        }

        public void InitialiserListe()
        {
            if (this.destinations == null)
            {
                this.destinations = new List<Destination>();
                List<string[]> listeChamp = OutilsFichier.LireFichier(GetCheminFichier());
                foreach (string[] champs in listeChamp)
                {
                    Destination destination = new Destination()
                    {
                        Id=champs[0],
                        Continent =champs[1],
                        Pays=champs[2],
                        Region=champs[3],
                        Description=champs[4],
                    };
                    this.destinations.Add(destination);
                }
            }
        }

        public void EcrireFichier()
        {
            var contenuFichier = new StringBuilder();
            foreach (var destination in this.destinations)
            {
                contenuFichier.AppendLine(string.Join(
                                            "|",
                                            destination.Id,
                                            destination.Continent,
                                            destination.Pays,
                                            destination.Region,
                                            destination.Description
                                           ));
            }
            Directory.CreateDirectory(Path.GetDirectoryName(GetCheminFichier()));
            File.WriteAllText(GetCheminFichier(), contenuFichier.ToString());
        }

        public string GetCheminFichier()
        {
            return "C:\\Temp\\ProjetConsole\\Destination.txt";
        }

        public bool FichierExiste()
        {
            return File.Exists(GetCheminFichier());
        }

        public Destination RecupererDestinationParId(string id)
        {
            InitialiserListe();
            var resultat = from destination in this.destinations
                        where destination.Id == id
                        select destination;
            return resultat.First();
        }
    }
}
