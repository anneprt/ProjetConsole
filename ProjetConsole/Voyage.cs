using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole
{
    public class Voyage
    {
        public double TarifPourcentageReduction { get; set; }
        public DateTime Aller { get; set; }
        public DateTime Retour { get; set; }
        public int NombreVoyageur { get; set; }

        public static void CalculTarifReduit()
        {
        }
    }   

}
