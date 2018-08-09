using ProjetConsole;
using ProjetConsole.Data;
using ProjetConsole.Data.Metier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Business
{
    public class InitialisationService
    {
        private static List<Destination> destinations = new List<Destination>
        {
            new Destination{Id="0001",Continent="Europe",Pays="Espagne",Region="Barcelone",Description="Les tapas c'est la vie"},
            new Destination{Id="0002",Continent="Asie",Pays="Japon",Region="Tokyo",Description="L'okonomiyaki c'est la vie"},
        };


        private static List<Voyage> voyages = new List<Voyage>
        {
            new Voyage{Id="0001",DateAller=DateTime.Parse("12/08/2018"),DateRetour=DateTime.Parse("19/08/2018"),Tarif=999d, Destination=destinations[0]},
            new Voyage{Id="0002",DateAller=DateTime.Parse("14/08/2018"),DateRetour=DateTime.Parse("22/08/2018"),Tarif=1050d, Destination=destinations[1]},
        };

        private static List<Client> clients = new List<Client>
        {
            new Client {Id="0001", Nom="Parrot",Prenom="Alexandre",DateNaissance=DateTime.Parse("03/09/2015"),Email="alex.parrot@bebemail.com",Telephone="123558417"},
            new Client {Id="0002", Nom="Moi",Prenom="Anne",DateNaissance=DateTime.Parse("13/07/1982"),Email="alex.parrot@bebemail.com",Telephone="123558417"},
        };

        private static List<Commercial> commerciaux = new List<Commercial>
        {
            new Commercial {Id="0003", Nom="Bazan", Prenom="Yannick", Email = "ybazan@prof.mail.fr"}
        };

        public static void Initialiser()
        {
            ClientDonnees clientDonnees = new ClientDonnees();
            if (!clientDonnees.FichierExiste())
            {
                foreach (Client client in clients)
                {
                    clientDonnees.Enregistrer(client);
                }
            }

            DestinationDonnees destinationDonnees = new DestinationDonnees();
            if (!destinationDonnees.FichierExiste())
            {
                foreach (Destination destination in destinations)
                {
                    destinationDonnees.Enregistrer(destination);
                }
            }

            CommercialDonnees commercialDonnees = new CommercialDonnees();
            if (!commercialDonnees.FichierExiste())
            {
                foreach (Commercial commercial in commerciaux)
                {
                    commercialDonnees.Enregistrer(commercial);
                }
            }

            VoyageDonnees voyageDonnees = new VoyageDonnees();
            if (!voyageDonnees.FichierExiste())
            {
                foreach (Voyage voyage in voyages)
                {
                    voyageDonnees.Enregistrer(voyage);
                }
            }
        }

    }
}
