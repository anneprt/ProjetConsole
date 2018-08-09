using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole
{
    public class Client
    {
        public int IDClient { get; set; }
        // L'ID client correspond à "l'identifiant client" qui lui permet de s'authentifier sur le site de BoVoyage lors de sa réservation. 
        public int NumeroCB { get; set; }
        public bool Accompagnant { get; set; }
        public int NombreAccompagnant { get; set; }
    }
}
