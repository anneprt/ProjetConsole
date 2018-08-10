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
            new Destination{Id="0003",Continent="Afrique",Pays="Ethiopie",Region="Addis-Abeba",Description="conseillé pour séjour familial"},
            new Destination{Id="0004",Continent="Asie",Pays="Chine",Region="Beijing",Description="voyage dépaysant"},
            new Destination{Id="0005",Continent="Amérique du Nord",Pays="Bahamas",Region="Anolu Bay",Description="Summer breeaakk is coming!!"},
        };


        private static List<Voyage> voyages = new List<Voyage>
        {
            new Voyage{Id="0001",DateAller=DateTime.Parse("12/08/2018"),DateRetour=DateTime.Parse("19/08/2018"),Tarif=999d, Destination=destinations[0]},
            new Voyage{Id="0002",DateAller=DateTime.Parse("14/08/2018"),DateRetour=DateTime.Parse("22/08/2018"),Tarif=1050d, Destination=destinations[1]},
            new Voyage{Id="0003",DateAller=DateTime.Parse("24/08/2018"),DateRetour=DateTime.Parse("26/08/2018"),Tarif=1070d, Destination=destinations[2]},
            new Voyage{Id="0004",DateAller=DateTime.Parse("25/08/2018"),DateRetour=DateTime.Parse("28/08/2018"),Tarif=1030d, Destination=destinations[3]},
            new Voyage{Id="0005",DateAller=DateTime.Parse("18/08/2018"),DateRetour=DateTime.Parse("22/08/2018"),Tarif=1050d, Destination=destinations[4]},

       
        };

        private static List<Client> clients = new List<Client>
        {
            new Client {Id="0001", Nom="Parrot",Prenom="Alexandre",DateNaissance=DateTime.Parse("03/09/2015"),Email="alex.parrot@bebemail.com",Telephone="123558417"},
            new Client {Id="0002", Nom="Moi",Prenom="Anne",DateNaissance=DateTime.Parse("13/07/1982"),Email="alex.parrot@bebemail.com",Telephone="123558417"},
            new Client {Id="0003", Nom="Dupont",Prenom="Sylvain",DateNaissance=DateTime.Parse("13/07/1972"),Email="dsggdt@bebemail.com",Telephone="654651"},
            new Client {Id="0004", Nom="Farot",Prenom="Lara",DateNaissance=DateTime.Parse("13/07/2003"),Email="dsfgdsgt@bebemail.com",Telephone="651465161"},
            new Client {Id="0005", Nom="Zoroupo",Prenom="Cristtiano",DateNaissance=DateTime.Parse("13/07/2009"),Email="gsdgdsg@bebemail.com",Telephone="65615616"},
        };

        private static List<Commercial> commerciaux = new List<Commercial>
        {
            new Commercial {Id="0003", Nom="Bazan", Prenom="Yannick", Email = "ybazan@prof.mail.fr"},
            new Commercial {Id="0004", Nom="Kinfu", Prenom="Laynet", Email = "kikinf@prof.mail.fr"},
            new Commercial {Id="0005", Nom="Bauduin", Prenom="Anne", Email = "ababab@prof.mail.fr"},
            new Commercial {Id="0006", Nom="Dupont", Prenom="Axelle", Email = "adgdb@prof.mail.fr"},
            new Commercial {Id="0007", Nom="Bauduin", Prenom="Thierry", Email = "dsfgd@prof.mail.fr"},

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
