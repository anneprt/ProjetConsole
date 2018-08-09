using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Data.Metier
{
    public class Commercial:Personne
    {

        public Commercial()
        {
            Type = EnumTypePersonne.Commercial;
        }

        public static void DemarcherClient()
        {

        }
        public static void NegocierVoyage()
        {

        }

    }

}
