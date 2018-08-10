using ProjetConsole.Data;
using ProjetConsole.Data.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Business
{
    public class GestionClientService
    {
        private ClientDonnees clientDonnees = new ClientDonnees();
        private CommercialDonnees commercialDonnees = new CommercialDonnees();

        public Commercial RecupererCommercialParId(string id)
        {
            var resultat = from commercial in commercialDonnees.GetListe()
                              where commercial.Id == id
                              select commercial;

            if (resultat.Count() > 1)
            {
                throw new Exception($"Il existe plus d'un commercial ayant l'identifiant {id}");
            }

            if (resultat.Count() == 0)
            {
                throw new Exception("Identifiant incorrect...");
            }
            return resultat.First();
        }

        public Client RecupererClientParId(string id)
        {
            var resultat = from client in clientDonnees.GetListe()
                           where client.Id == id
                           select client;

            if (resultat.Count() > 1)
            {
                throw new Exception($"Il existe plus d'un client ayant l'identifiant {id}");
            }

            if (resultat.Count() == 0)
            {
                throw new Exception("Identifiant incorrect...");
            }
            return resultat.First();
        }

        public List<Client> RecupererTousLesClients()
        {
            return clientDonnees.GetListe().ToList();
        }

        public void SupprimerUnClient(string id)
        {
            var resultat = RecupererClientParId(id);
            clientDonnees.Supprimer(resultat);
        }

        public void AjouterUnClient(Client client)
        {
            clientDonnees.Enregistrer(client);
        }

        public List<Client> FiltrerLesClientsParNomParPrenom(string saisie)
        {
            return (from client in clientDonnees.GetListe()
                                where client.Nom.StartsWith(saisie, StringComparison.OrdinalIgnoreCase)
                                || client.Prenom.StartsWith(saisie, StringComparison.OrdinalIgnoreCase)
                                select client).ToList();
            
        }

        public List<Client> TrierLesClientsParNom(string saisie)
        {
            return (from client in clientDonnees.GetListe()
                                orderby client.Nom ascending
                                select client).ToList();
        }

        public List<Client> TrierLesClientsParPrenom(string saisie)
        {
            return (from client in clientDonnees.GetListe()
                    orderby client.Prenom ascending
                    select client).ToList();
        }

        public string IncrementerIdentifiantClient()
        {
            // Source Google
            // On récupère le dernier identifiant dans la liste avec Linq
            string dernierId = (from client in clientDonnees.GetListe() select client.Id).Max();
            // On transforme la chaine de caractère en int et on ajoute + 1
            int dernierIdIncremente = int.Parse(dernierId) + 1;
            // On retourne le dernier id incrémenté au format chaine de caractère et on remplie par des "0" à gauche sur 4 caractères
            return dernierIdIncremente.ToString().PadLeft(4, '0');
        }
    }


}
