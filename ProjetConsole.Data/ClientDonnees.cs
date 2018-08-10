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
    public class ClientDonnees : IAccesDonnees<Client>
    {
        private List<Client> clients;

        public IEnumerable<Client> GetListe()
        {
            InitialiserListe();
            return this.clients;
        }

        public void Enregistrer(Client client)
        {
            InitialiserListe();
            if (!this.clients.Contains(client))
            {
                this.clients.Add(client);
            }

            this.EcrireFichier();
        }

        public void Supprimer(Client client)
        {
            InitialiserListe();
            this.clients.Remove(client);
            this.EcrireFichier();
        }

        public void InitialiserListe()
        {
            if (this.clients == null)
            {
                this.clients = new List<Client>();
                List<string[]> listeChamp = OutilsFichier.LireFichier(getCheminFichier());
                foreach (string[] champs in listeChamp)
                {
                    Client client = new Client()
                    {
                        Id = champs[0],
                        Civilite = champs[1],
                        Nom = champs[2],
                        Prenom = champs[3],
                        Adresse = champs[4],
                        Email = champs[5],
                        DateNaissance = DateTime.Parse(champs[6]),
                        Telephone = champs[7]
                    };
                    this.clients.Add(client);
                }
            }
        }

        public void EcrireFichier()
        {
            var contenuFichier = new StringBuilder();
            foreach (var client in this.clients)
            {
                contenuFichier.AppendLine(string.Join(
                                            "|",
                                            client.Id,
                                            client.Civilite,
                                            client.Nom,
                                            client.Prenom,
                                            client.Adresse,
                                            client.Email,
                                            client.DateNaissance.ToShortDateString(),
                                            client.Telephone));
            }
            // On récupère le chemin du dossier, en gros on enlève le nom du fichier dans le chemin
            var dossier = Path.GetDirectoryName(getCheminFichier());
            // Si le dossier n'existe pas, alors on le crée pour eviter les problèmes
            Directory.CreateDirectory(dossier);
            File.WriteAllText(getCheminFichier(), contenuFichier.ToString());
        }

        public string getCheminFichier()
        {
            return "C:\\Temp\\ProjetConsole\\Client.txt";
        }

        public bool FichierExiste()
        {
            return File.Exists(getCheminFichier());
        }

        public Client RecupererClientParId(string id)
        {
            InitialiserListe();
            var resultat = from client in this.clients
                           where client.Id == id
                           select client;
            return resultat.First();
        }
    }
}
