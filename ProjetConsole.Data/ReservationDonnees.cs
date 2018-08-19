using ProjetConsole.Data.Metier;
using ProjetConsole.Outils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjetConsole.Data.Metier.Reservation;

namespace ProjetConsole.Data
{
	public class ReservationDonnees : IAccesDonnees<Reservation>
	{
		private List<Reservation> reservations;

		public IEnumerable<Reservation> GetListe()
		{
			InitialiserListe();
			return this.reservations;
		}

		public void Enregistrer(Reservation reservation)
		{
			InitialiserListe();
			if (!this.reservations.Contains(reservation))
			{
				this.reservations.Add(reservation);
			}

			this.EcrireFichier();
		}

		public void Supprimer(Reservation reservation)
		{
			InitialiserListe();
			this.reservations.Remove(reservation);
			this.EcrireFichier();
		}

		public void InitialiserListe()
		{
			if (this.reservations == null)
			{
				this.reservations = new List<Reservation>();
				List<string[]> listeChamp = OutilsFichier.LireFichier(GetCheminFichier());
				foreach (string[] champs in listeChamp)
				{
                    // Pour convertir la valeur en enumération
                    Enum.TryParse(champs[2], out StatutEtatDossier etat);

                    Reservation reservation = new Reservation()
                    {
                        NumeroReservation = champs[0],
                        NumeroCb = champs[1],
                        EtatDossier = etat,
                        Client = new ClientDonnees().RecupererClientParId(champs[3]),
                        Voyage = new VoyageDonnees().RecupererVoyageParId(champs[4]),
                        Accompagnant = (from accompagnantId in champs[5].Split(',') select new ClientDonnees().RecupererClientParId(accompagnantId)).ToList()

                    };
					this.reservations.Add(reservation);
				}
			}
		}

		public void EcrireFichier()
		{
			var contenuFichier = new StringBuilder();
			foreach (var reservation in this.reservations)
			{
				contenuFichier.AppendLine(string.Join(
											"|",
											reservation.NumeroReservation,
											reservation.NumeroCb,
											reservation.EtatDossier,
											reservation.Client.Id,
											reservation.Voyage.Id,
											String.Join(",", (from accompagnant in reservation.Accompagnant select accompagnant.Id))
                                            ));
			}
			// On récupère le chemin du dossier, en gros on enlève le nom du fichier dans le chemin
			var dossier = Path.GetDirectoryName(GetCheminFichier());
			// Si le dossier n'existe pas, alors on le crée pour eviter les problèmes
			Directory.CreateDirectory(dossier);
			File.WriteAllText(GetCheminFichier(), contenuFichier.ToString());
		}

		public string GetCheminFichier()
		{
			return "C:\\Temp\\ProjetConsole\\Reservation.txt";
		}

		public bool FichierExiste()
		{
			return File.Exists(GetCheminFichier());
		}
	}
}
