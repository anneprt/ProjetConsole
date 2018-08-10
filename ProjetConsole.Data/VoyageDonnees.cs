﻿using ProjetConsole.Data.Metier;
using ProjetConsole.Outils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Data
{
    public class VoyageDonnees : IAccesDonnees<Voyage>
    {
        private List<Voyage> voyages;

        public IEnumerable<Voyage> GetListe()
        {
            InitialiserListe();
            return this.voyages;
        }

        public void Enregistrer(Voyage voyage)
        {
            InitialiserListe();
            if (!this.voyages.Contains(voyage))
            {
                this.voyages.Add(voyage);
            }

            this.EcrireFichier();
        }

        public void Supprimer(Voyage voyage)
        {
            InitialiserListe();
            this.voyages.Remove(voyage);
            this.EcrireFichier();
        }

        public void InitialiserListe()
        {
            if (this.voyages == null)
            {
                DestinationDonnees destinationDonnees = new DestinationDonnees();
                this.voyages = new List<Voyage>();
                List<string[]> listeChamp = OutilsFichier.LireFichier(getCheminFichier());
                foreach (string[] champs in listeChamp)
                {
                    Voyage voyage = new Voyage()
                    {
                        Id = champs[0],
                        DateAller = DateTime.Parse(champs[1]),
                        DateRetour = DateTime.Parse(champs[2]),
                        Tarif = double.Parse(champs[3]),
                        Destination = destinationDonnees.RecupererDestinationParId(champs[4]),
                    };
                    this.voyages.Add(voyage);
                }
            }
        }

        public void EcrireFichier()
        {
            var contenuFichier = new StringBuilder();
            foreach (var voyage in this.voyages)
            {
                contenuFichier.AppendLine(string.Join(
                                            "|",
                                            voyage.Id,
                                            voyage.DateAller.ToShortDateString(),
                                            voyage.DateRetour.ToShortDateString(),
                                            voyage.Tarif.ToString(),
                                            voyage.Destination.Id
                                           ));
            }
            Directory.CreateDirectory(Path.GetDirectoryName(getCheminFichier()));
            File.WriteAllText(getCheminFichier(), contenuFichier.ToString());
        }

        public string getCheminFichier()
        {
            return "C:\\Temp\\ProjetConsole\\Voyage.txt";
        }

        public bool FichierExiste()
        {
            return File.Exists(getCheminFichier());
        }
    }
}