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
    public class CommercialDonnees : IAccesDonnees<Commercial>
    {
        private List<Commercial> commerciaux;

        public IEnumerable<Commercial> GetListe()
        {
            InitialiserListe();
            return this.commerciaux;
        }

        public void Enregistrer(Commercial commercial)
        {
            InitialiserListe();
            if (!this.commerciaux.Contains(commercial))
            {
                this.commerciaux.Add(commercial);
            }

            this.EcrireFichier();
        }

        public void Supprimer(Commercial commercial)
        {
            InitialiserListe();
            this.commerciaux.Remove(commercial);
            this.EcrireFichier();
        }

        public void InitialiserListe()
        {
            if (this.commerciaux == null)
            {
                this.commerciaux = new List<Commercial>();
                List<string[]> listeChamp = OutilsFichier.LireFichier(GetCheminFichier());
                foreach (string[] champs in listeChamp)
                {
                    Commercial commercial = new Commercial()
                    {
                        Id=champs[0],
                        Nom=champs[1],
                        Prenom=champs[2],
                        Email=champs[3],
                    };
                    this.commerciaux.Add(commercial);
                }
            }
        }

        public void EcrireFichier()
        {
            var contenuFichier = new StringBuilder();
            foreach (var commercial in this.commerciaux)
            {
                contenuFichier.AppendLine(string.Join(
                                            "|",
                                            commercial.Id,
                                            commercial.Nom,
                                            commercial.Prenom,
                                            commercial.Email
                                           ));
            }
            Directory.CreateDirectory(Path.GetDirectoryName(GetCheminFichier()));
            File.WriteAllText(GetCheminFichier(), contenuFichier.ToString());
        }

        public string GetCheminFichier()
        {
            return "C:\\Temp\\ProjetConsole\\Commercial.txt";
        }

        public bool FichierExiste()
        {
            return File.Exists(GetCheminFichier());
        }
    }
}
