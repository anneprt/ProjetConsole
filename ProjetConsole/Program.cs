using ProjetConsole.Outils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole
{
	public class Program
	{
        static List<Voyage> Voyages = new List<Voyage>();

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
						ListerVoyages(Voyages);
						OutilsConsole.AfficherRetourMenu();
						Console.ReadKey();
						break;
					case "2":
						Console.Clear();
						//ReserverVoyage();
						break;
					case "3":
						Console.Clear();
						//ConsulterDossier();
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

			}

        public static void AfficherMenu()
        {
            Console.WriteLine("Menu");
            string item1 = "1.Liste des destinations";
            string item2 = "2.Faire une réservation";
            string item3 = "3.Annuler une réservation";
            string item4 = "4.Gestion clientèle";
            string item5 = "Q.Quitter";

            Console.WriteLine($"{ item1}\n{ item2}\n{ item3}\n{item4}\n{item5}");

            //OutilsConsole.AfficherRetourMenu();
        }

        public static void ListerVoyages(IEnumerable<Voyage> listeVoyages)
        {


            Console.WriteLine("Voici la liste des destinations disponibles");
            Console.ForegroundColor = ConsoleColor.Yellow;


            OutilsConsole.AfficherChamp("CONTINENT", 20);
            OutilsConsole.AfficherChamp("PAYS", 10);
            OutilsConsole.AfficherChamp("REGION", 10);
            OutilsConsole.AfficherChamp("DESCRIPTION", 20);
            OutilsConsole.AfficherChamp("DATE ALLER", 10);
            OutilsConsole.AfficherChamp("DATE RETOUR", 10);
            OutilsConsole.AfficherChamp("DATE RETOUR", 10);
            OutilsConsole.AfficherChamp("TARIF PAR PERSONNE", 20);


            Console.WriteLine();
            Console.WriteLine(new string('_', 75));

            Console.ResetColor();


            foreach (var contact in listeVoyages)
            {

                /*OutilsConsole.AfficherChamp(destination.Continent, 10);
                OutilsConsole.AfficherChamp(destination.Pays, 10);
                OutilsConsole.AfficherChamp(destination.Region, 20);
                OutilsConsole.AfficherChamp(destination.DescriptionVoyage, 10);
                OutilsConsole.AfficherChamp(destination.DateAller.ToShortDateString(), 10);
                OutilsConsole.AfficherChamp(destination.DateRetour.ToShortDateString(), 10);*/

            }
            OutilsConsole.AfficherRetourMenu();
        }

        public static void ConsulterDossier()
        {
            var saisie = Console.ReadLine();



        }

        public static void ListerVoyage()
        {

        }

        public static void ReserverVoyage()
        {


        }
    }
}

