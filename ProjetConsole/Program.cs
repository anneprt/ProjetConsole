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

			OutilsConsole.AfficherMessage("1.Je suis un client\n2.Je suis un commercial\nVotre choix", ConsoleColor.Yellow);

			string choix = Console.ReadLine();
			switch (choix)
			{
				case "1":
					Console.Clear();
					AfficherMenuAccueilClient();
					Console.WriteLine("\nVotre choix:");
					break;
				case "2":
					Console.Clear();
					AfficherMenuAccueilCommercial();
					break;
			}


			bool continuer = true;
			while (continuer == true)  //while(menu)
			{

				
				string choix1 = Console.ReadLine();
				switch (choix1)
				{
					case "1":
						Console.Clear();
						//ListerOffresVoyages;
						OutilsConsole.AfficherRetourMenu();
						Console.ReadKey();
						break;
					case "2":
						Console.Clear();
						//ReserverVoyage();
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

			void AfficherMenuAccueilClient()
			{
				Console.WriteLine("Menu");
				string item1 = "1.Découvrir notre offre de voyages";
				string item2 = "2.Réserver un voyage";
				string item3 = "3.Consulter mon dossier";
				string item4 = "Q.Quitter";

				Console.WriteLine($"{ item1}\n{ item2}\n{ item3}\n{item4}");

				//OutilsConsole.AfficherRetourMenu();
			}

			void AfficherMenuAccueilCommercial()
			{

				Console.WriteLine("Veuillez saisir votre identifiant pour continuer");
				
			}

			void ConsulterDossier()
			{
				var saisie = Console.ReadLine();
				Console.WriteLine("Veuillez saisir votre identifiant client pour continuer");


			}





		}
	}
}

