using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			OutilsConsole.AfficherEntete();

			Console.WriteLine("Veuillez saisir votre identifiant pour continuer");

			AfficherMenu();


			bool continuer = true;
			while (continuer == true)  //while(menu)
			{


				string choix1 = Console.ReadLine();
				switch (choix1)
				{
					case "1":
						Console.Clear();
						ListerVoyage();
						OutilsConsole.AfficherRetourMenu();
						Console.ReadKey();
						break;
					case "2":
						Console.Clear();
						ReserverVoyage();
						break;
					case "3":
						Console.Clear();
						ConsulterDossier();
						break;
					case "q":
					case "Q":
						Console.Clear();
						continuer = false;
						break;
					default:
						break;
				}

				Console.Clear();


				//IdClient.Client= OutilsConsole.SaisirChaineObligatoire("Saisir votre identifiant pour continuer", "Ce chanmp est requis, veuillez rentrer votre identifiant");

				Console.ReadKey();
			}

			void AfficherMenu()
			{
				Console.WriteLine("Menu");
				string item1 = "1.Liste des voyages";
				string item2 = "2.Faire une réservation";
				string item3 = "3.Annuler une réservation";
				string item4 = "4.Gestion clientèle";
				string item5 = "Q.Quitter";

				Console.WriteLine($"{ item1}\n{ item2}\n{ item3}\n{item4}\");

				//OutilsConsole.AfficherRetourMenu();
			}



			void ConsulterDossier()
			{
				var saisie = Console.ReadLine();



			}

			void ListerVoyage()
			{

			}

			void ReserverVoyage()
			{


			}






		}
	}
}

