using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Outils
{
    public abstract class OutilsFichier
    {
        public static List<string[]> LireFichier(string cheminFichier, char separateur='|')
        {
            List<string[]> listeChamps = new List<string[]>(); 
            if (File.Exists(cheminFichier))
            {
                var lignes = File.ReadAllLines(cheminFichier);
                foreach (var ligne in lignes)
                {
                    var champs = ligne.Split(separateur);
                    listeChamps.Add(champs);
                }
            }
            return listeChamps;
        }
    }
}
