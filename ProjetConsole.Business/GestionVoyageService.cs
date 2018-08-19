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
		private ReservationDonnees reservationDonnees = new ReservationDonnees();
        private ClientDonnees clientDonnees = new ClientDonnees();
       
        public List<Voyage> RecupererTousLesVoyages()
        {
            return voyageDonnees.GetListe().ToList();
        }

		public List<Reservation> RecupererTouteslesReservation()
		{
			return reservationDonnees.GetListe().ToList();
		}

        // On passe l'id du client et l'id du voyage au service
        public void ReserverVoyage(string clientId, string voyageId)
        {
            // On récupère un client par rapport à son id

            Client client = clientDonnees.RecupererClientParId(clientId);

            // On récupère un voyage par rapport à son id

            Voyage voyage = voyageDonnees.RecupererVoyageParId(voyageId);

            // On crée une réservation (new) et on lui assigne le client et le voyage
            Reservation reservation = new Reservation();
            reservation.NumeroReservation = "0001";
            reservation.NumeroCb = "123456789";
            reservation.EtatDossier = Reservation.StatutEtatDossier.EnAttente;
            reservation.Client = client;
            reservation.Voyage = voyage;



            // On enregistre la réservation dans le fichier
            reservationDonnees.Enregistrer(reservation);



            



}

       
    }
}
