using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole
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



}	}
