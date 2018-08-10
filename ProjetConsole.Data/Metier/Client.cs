using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Data.Metier
{
	public class Client :Personne
	{
		public Client()
		{
			Type = EnumTypePersonne.Client;
		}

		public string Telephone { get; set; }
		public DateTime DateNaissance { get; set; }
		public string Adresse { get; set; }





		
	}
}
