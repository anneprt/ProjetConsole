using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole
{
	public class Client :Personne
	{
		public int IdClient { get; set; }
		// L'ID client correspond à "l'identifiant client" qui lui permet de s'authentifier sur le site de BoVoyage lors de sa réservation. 
		public int NumeroCB { get; set; }
		public bool Accompagnant { get; set; }
		public int NombreAccompagnant { get; set; }

		public void CalculerAge()
		{
			//var dateNaissance = DateTime.Parse(saisie);//la variable vient de la liste du fichier client

			//var age = DateTime.Now.Date.Subtract(dateNaissance).Days / 365;
		}
	}
}
