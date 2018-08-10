using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Data.Metier
{
	public class Assurance
	{
		public string Type { get; set; }

	}
	public enum TypeAssurance
	{
		AssuranceAnnulation=1,
		AssuranceRapatriement=2,
		AssuranceVol=2
	}

}
