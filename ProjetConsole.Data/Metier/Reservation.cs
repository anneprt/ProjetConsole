using ProjetConsole.Outils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Data.Metier
{
	public class Reservation
	{
		public string NumeroReservation { get; set; }

		public string NumeroCb { get; set; }

		public enum EtatDossier
		{
			EnAttente = 1,
			EnCours = 2,
			Refuse = 3,
			Accepte = 4

		}
		
		public Client Client { get; set; }
		public Voyage Voyage { get; set; }
		public List<Client> Accompagnant { get; set; }

		public double CalculerCoutTotal()
		{
			double coutTotal;
			coutTotal = CalculerTarifReduit(Client);
			foreach (Client accompagnant in Accompagnant)
			{
				coutTotal = coutTotal + CalculerTarifReduit(accompagnant);
			}
			return coutTotal;
		}

		private double CalculerTarifReduit(Client client)
		{
			if (OutilsDate.CalculerAge(client.DateNaissance) < 12)
			{
				return Voyage.Tarif * 0.4;
			}
			return Voyage.Tarif;
		}

	   
		public class EtatReservation 
			{
			public EtatDossier EtatDossier { get; set; }
			}



		static void DemanderEtatDossier () 
		{
			

		} 
}
}
