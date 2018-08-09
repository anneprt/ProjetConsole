using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Data.Metier
{
    public class Voyage
    {
        public string Id { get; set; }
        public double Tarif { get; set; }
        public DateTime DateAller { get; set; }
        public DateTime DateRetour { get; set; }
        public Destination Destination { get; set; }
    }   

}
