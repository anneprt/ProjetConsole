using ProjetConsole.Data;
using ProjetConsole.Data.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Business
{
    public class GestionVoyageService
    {
        private VoyageDonnees voyageDonnees = new VoyageDonnees();
        private DestinationDonnees destinationDonnees = new DestinationDonnees();
       
        public List<Voyage> RecupererTousLesVoyages()
        {
            return voyageDonnees.GetListe().ToList();
        }

       
    }
}
