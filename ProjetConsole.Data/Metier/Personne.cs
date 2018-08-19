using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Data.Metier
{
	public abstract class Personne
	{
		public string Id { get; set; }
		public string Civilite { get; set; }
		public string Nom { get; set; }
		public string Prenom { get; set; }
		public string Email { get; set; }
		public TypePersonne Type { get; set; }
		
	}
}
