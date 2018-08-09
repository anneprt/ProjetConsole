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

        public List<Client> RecupererTousLesClients()
        {
            return clientDonnees.GetListe().ToList();
        }

        public void SupprimerUnClient(string id)
        {
            var resultat = from client in clientDonnees.GetListe()
                         where client.Id == id
                         select client;

            clientDonnees.Supprimer(resultat.First());
        }
    }
}
