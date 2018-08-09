﻿using ProjetConsole.Business;
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
            Console.WriteLine($"Bonjour {commercialConnecte.Nom} {commercialConnecte.Prenom}\n");
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
                        //ConsulterDossier();
                        continuer = false;
                        break;
                    case "4":
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
            string item4 = "4.Gestion clientèle";
            string item5 = "Q.Quitter";

            Console.WriteLine($"{ item1}\n{ item2}\n{ item3}\n{item4}\n{item5}");

            //OutilsConsole.AfficherRetourMenu();
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
            string item4 = "Q.Quitter";

            Console.WriteLine($"{ item1}\n{ item2}\n{ item3}\n{item4}");

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
    }
}

