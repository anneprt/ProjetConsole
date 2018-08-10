using ProjetConsole.Business;
using ProjetConsole.Data.Metier;
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
		static Commercial commercialConnecte = null;
		static GestionClientService gestionClientService = new GestionClientService();
		static GestionVoyageService gestionVoyageService = new GestionVoyageService();

		static void Main(string[] args)
		{
			InitialisationService.Initialiser();
			OutilsConsole.AfficherEntete();

			while (commercialConnecte == null)
			{
				Console.WriteLine("Veuillez saisir votre identifiant pour continuer");
				string idConnexion = Console.ReadLine();
				try
				{
					commercialConnecte = gestionClientService.RecupererCommercialParId(idConnexion);
				}
				catch (Exception erreur)
				{
					OutilsConsole.AfficherMessageErreur(erreur.Message);
				}
			}

			Console.Clear();
			OutilsConsole.AfficherEntete();
			OutilsConsole.AfficherMessage($"Bonjour {commercialConnecte.Nom} {commercialConnecte.Prenom}\n", ConsoleColor.Cyan);
			//Console.WriteLine($"Bonjour {commercialConnecte.Nom} {commercialConnecte.Prenom}\n");
			AfficherMenu();


			bool continuer = true;
			while (continuer == true)
			{

				string choix1 = Console.ReadLine();
				switch (choix1)
				{
					case "1":
						Console.Clear();
						ListerVoyages();
						OutilsConsole.AfficherRetourMenu();
						Console.ReadKey();
						continuer = false;
						break;
					case "2":
						Console.Clear();
						//ReserverVoyage();
						continuer = false;
						break;
					case "3":
						Console.Clear();
						//AnnulerVoyage();
						continuer = false;
						break;
					case "4":
						Console.Clear();
						//ConsulterDossier();
						continuer = false;
						break;
					case "5":
						Console.Clear();
						AfficherMenuGestionClientele();
						continuer = false;
						break;
					case "q":
					case "Q":
						Console.Clear();
						continuer = false;
						break;
					default:
						break;
				}

				if (continuer == true)
				{
					OutilsConsole.AfficherMessageErreur("Touche incorrecte");
				}

			}
			Console.Clear();

		}

		public static void AfficherMenu()
		{
			Console.WriteLine("Menu");
			string item1 = "1.Liste des destinations";
			string item2 = "2.Faire une réservation";
			string item3 = "3.Annuler une réservation";
			string item4 = "4.Consulter un dossier de réservation";
			string item5 = "5.Gestion clientèle";
			string item6 = "Q.Quitter";

			Console.WriteLine($"{ item1}\n{ item2}\n{ item3}\n{item4}\n{item5}\n{item6}");

			
		}

		public static void ListerVoyages()
		{


			Console.WriteLine("Voici la liste des destinations disponibles");
			Console.ForegroundColor = ConsoleColor.Yellow;


			OutilsConsole.AfficherChamp("CONTINENT", 10);
			OutilsConsole.AfficherChamp("PAYS", 10);
			OutilsConsole.AfficherChamp("REGION", 10);
			OutilsConsole.AfficherChamp("DESCRIPTION", 20);
			OutilsConsole.AfficherChamp("DATE ALLER", 10);
			OutilsConsole.AfficherChamp("DATE RETOUR", 10);
			OutilsConsole.AfficherChamp("TARIF PAR PERSONNE", 10);


			Console.WriteLine();
			Console.WriteLine(new string('_', 100));

			Console.ResetColor();


			foreach (var voyage in gestionVoyageService.RecupererTousLesVoyages())
			{

				OutilsConsole.AfficherChamp(voyage.Destination.Continent, 10);
				OutilsConsole.AfficherChamp(voyage.Destination.Pays, 10);
				OutilsConsole.AfficherChamp(voyage.Destination.Region, 10);
				OutilsConsole.AfficherChamp(voyage.Destination.Description, 20);
				OutilsConsole.AfficherChamp(voyage.DateAller.ToShortDateString(), 10);
				OutilsConsole.AfficherChamp(voyage.DateRetour.ToShortDateString(), 10);
				OutilsConsole.AfficherChamp(voyage.Tarif.ToString(), 10);
				Console.WriteLine();
			}
			OutilsConsole.AfficherRetourMenu();
		}

		public static void AfficherMenuGestionClientele()
		{
			Console.WriteLine("Menu");
			string item1 = "1.Liste des clients";
			string item2 = "2.Filtrer les clients";
			string item3 = "3.Trier les clients";
			string item4 = "4.Ajouter un client";
			string item5 = "5.Supprimer un client";
			string item6 = "6.Prospection";
			string item7 = "Q.Quitter";

			Console.WriteLine($"{ item1}\n{ item2}\n{ item3}\n{item4}\n{item5}\n{item6}\n{item7}");

			bool continuer = true;
			while (continuer == true)
			{

				string choix2 = Console.ReadLine();
				switch (choix2)
				{
					case "1":
						Console.Clear();
						ListerClients();
						OutilsConsole.AfficherRetourMenu();
						Console.ReadKey();
						continuer = false;
						break;
					case "2":
						Console.Clear();
						FiltrerClients();
						continuer = false;
						break;
					case "3":
						Console.Clear();
						TrierClients();
						continuer = false;
						break;
					case "4":
						Console.Clear();
						//AjouterClient();
						continuer = false;
						break;
					case "5":
						Console.Clear();
						//SupprimerClient();
						continuer = false;
						break;
					case "q":
					case "Q":
						Console.Clear();
						continuer = false;
						break;
					default:
						break;
				}

				if (continuer == true)
				{
					OutilsConsole.AfficherMessageErreur("Touche incorrecte");
				}

			}
			Console.Clear();

		}

		public static void ListerClients(List<Client> clients = null)
		{
			if (clients == null)
			{
				clients = gestionClientService.RecupererTousLesClients();
			}

			Console.WriteLine("Voici la liste des clients");
			Console.ForegroundColor = ConsoleColor.Yellow;


			OutilsConsole.AfficherChamp("IDENTIFIANT", 20);
			OutilsConsole.AfficherChamp("NOM", 10);
			OutilsConsole.AfficherChamp("PRENOM", 10);
			OutilsConsole.AfficherChamp("DATE DE NAISSANCE", 20);
			OutilsConsole.AfficherChamp("TELEPHONE", 10);
			OutilsConsole.AfficherChamp("EMAIL", 20);



			Console.WriteLine();
			Console.WriteLine(new string('_', 120));

			Console.ResetColor();


			foreach (var client in clients)
			{

				OutilsConsole.AfficherChamp(client.Id, 20);
				OutilsConsole.AfficherChamp(client.Nom, 10);
				OutilsConsole.AfficherChamp(client.Prenom, 10);
				OutilsConsole.AfficherChamp(client.DateNaissance.ToShortDateString(), 20);
				OutilsConsole.AfficherChamp(client.Telephone, 10);
				OutilsConsole.AfficherChamp(client.Email, 20);

				Console.WriteLine();
			}
		}

		public static void FiltrerClients()
		{
			OutilsConsole.AfficherMessage("Entrez les premières lettres du nom ou du prénom à filtrer");
			string saisie = Console.ReadLine();
			Console.ReadKey();

			OutilsConsole.AfficherRetourMenu();
		}

		public static void TrierClients()
		{
			OutilsConsole.AfficherMessage("1.Tri par nom\n2.Tri par prénom", ConsoleColor.Yellow);

			var saisie = Console.ReadLine();
			byte tri;
			while (!byte.TryParse(saisie, out tri)
				|| (tri < 1 || tri > 2))
			{
				OutilsConsole.AfficherMessageErreur("Entrée invalide, recommencez");
				saisie = Console.ReadLine();

			}

			List<Client> clientsTries = null;

			switch (tri)
			{
				case 1:
					clientsTries = gestionClientService.TrierLesClientsParNom(saisie);
					ListerClients(clientsTries);
					break;
				case 2:
					clientsTries = gestionClientService.TrierLesClientsParPrenom(saisie);
					ListerClients(clientsTries);
					break;
				default:
					break;
			}

			OutilsConsole.AfficherRetourMenu();

		}

        static void AjouterClient()
        {
            var client = new Client(clientDonnees);

            Console.WriteLine("Ajout d'un client");
            client.Civilite = OutilsConsole.SaisirChaineObligatoire("Entrez la civilité du client", "Ce chanmp est requis, veuillez rentrer la civilité du client");
            client.Nom = OutilsConsole.SaisirChaineObligatoire("Entrez le nom du client", "Ce chanmp est requis, veuillez rentrer le nom du client");
            client.Prenom = OutilsConsole.SaisirChaineObligatoire("Entrez le prénom du client", "Ce chanmp est requis, veuillez rentrer le prénom du client");

            Console.WriteLine("Entrez l'adresse email du client");
            client.Email = Console.ReadLine();
            Console.WriteLine("Entrez le numéro de téléphone du client");
            client.Telephone = Console.ReadLine();
            Console.WriteLine("Entrez la date de naissance du client");
            client.DateNaissance = OutilsConsole.SaisirDateObligatoire(Console.ReadLine());
            ClientDonnees.Add(client);

            OutilsConsole.AfficherMessage("le client est bien ajouté !", ConsoleColor.Cyan);
            OutilsConsole.AfficherRetourMenu();

        }


        static void SupprimerClients()
        {
            ListerClients(clients);
            Console.WriteLine("Entrez le numéro du client à supprimer");

            for (var i = 0; i < clients.Count; i++)
            {
                Console.WriteLine($"-{i + 1}- {clients[i]}");
            }


            var index = int.Parse(Console.ReadLine());


            if (index > 0 && index <= clients.Count)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Etes-vous sûr de vouloir supprimer ce client? o/n");
                Console.ResetColor();
                string reponse = Console.ReadLine();
                switch (reponse)
                {
                    case "o":
                        {
                            clients.RemoveAt(index - 1);
                            Console.WriteLine("Client supprimé");
                            Console.ReadKey();
                            break;
                        }
                    default: break;

                }
            }
            else
            {
                Console.WriteLine("Cette entrée n'existe pas, faire un autre choix");
                Console.ReadKey();
            }


        }
    }
}

