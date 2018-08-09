using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole
{
    public class Voyage
    {
        public double PourcentageReduction { get; set; }
        public double Tarif { get; set; }
        public DateTime DateAller { get; set; }
        public DateTime DateRetour { get; set; }
        public Destination Destination { get; set; }
    }   

}
