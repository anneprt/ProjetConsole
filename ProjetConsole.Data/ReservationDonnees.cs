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
				List<string[]> listeChamp = OutilsFichier.LireFichier(getCheminFichier());
				foreach (string[] champs in listeChamp)
				{
					Reservation reservation = new Reservation()
					{
						NumeroReservation= champs[0],
						NumeroCb = champs[1],
						EtatDosssier = champs[2],
						Client = Client.TryParse(champs[3], out reservation),
						Voyage = voyageDonnees.RecupererVoyageParId(champs[4]),
						Accompagnant = champs[5]
					};
					this.reservations.Add(reservation);
				}
			}
		}

		public void EcrireFichier()
		{
			var contenuFichier = new StringBuilder();
			foreach (var client in this.reservations)
			{
				contenuFichier.AppendLine(string.Join(
											"|",
											reservation.NumeroReservation,
											reservation.NumeroCb,
											reservation.EtatDossier,
											reservation.Email,
											reservation.DateNaissance.ToShortDateString(),
											reservation.Accompagnant));
			}
			// On récupère le chemin du dossier, en gros on enlève le nom du fichier dans le chemin
			var dossier = Path.GetDirectoryName(getCheminFichier());
			// Si le dossier n'existe pas, alors on le crée pour eviter les problèmes
			Directory.CreateDirectory(dossier);
			File.WriteAllText(getCheminFichier(), contenuFichier.ToString());
		}

		public string getCheminFichier()
		{
			return "C:\\Temp\\ProjetConsole\\Reservation.txt";
		}

		public bool FichierExiste()
		{
			return File.Exists(getCheminFichier());
		}
	}
}
