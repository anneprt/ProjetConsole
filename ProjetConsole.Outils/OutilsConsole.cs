using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Outils
{
	public class OutilsConsole
	{
		public static string SaisirChaineObligatoire(string message, string erreur)
		{
			Console.WriteLine(message);
			var saisie = Console.ReadLine();
			while (string.IsNullOrWhiteSpace(saisie))
			{

				AfficherMessageErreur("Ce champ est requis");

				saisie = Console.ReadLine();

			}
			return saisie;

		}

		public static void AfficherMessageErreur(string message)
		{

			AfficherMessage(message, ConsoleColor.Red);
		}

		public static void AfficherMessage(string message, ConsoleColor couleur = ConsoleColor.Gray)
		{

			Console.ForegroundColor = couleur;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		public static void AfficherRetourMenu()
		{
			Console.WriteLine();
			AfficherMessage("\n Appuyez sur une touche pour revenir au menu", ConsoleColor.Cyan);
			Console.ReadKey();
		}

		public static void AfficherEntete()
		{
			Console.WriteLine("*****************************");
			Console.WriteLine("BIENVENUE CHEZ BO VOYAGE");
			Console.WriteLine("*****************************");
			Console.WriteLine("\n");
		}

		public static void AfficherChamp(string texte, int longueurAffichage)
		{
			texte = (texte ?? string.Empty);

			
			texte = texte.Substring(0, Math.Min(texte.Length, longueurAffichage));
			Console.Write($"{texte.PadRight(longueurAffichage)} | ");
		}


        public static DateTime SaisirDateObligatoire(string message)
        {
            Console.WriteLine(message);
            string saisie = Console.ReadLine();
            DateTime date;

            while (string.IsNullOrEmpty(saisie)
                || !DateTime.TryParse(saisie, out date))

            {
                var messageErreur = string.IsNullOrEmpty(saisie)
                    ? "Champ obligatoire.Recommencez:"
                    : "Saisie invalide.Recommencez :";
                AfficherMessageErreur(messageErreur);
                saisie = Console.ReadLine();

            }
            return date;
        }

    }	}
