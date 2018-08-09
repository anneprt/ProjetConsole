using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Outils
{
    public abstract class OutilsDate
    {
        public static int CalculerAge(DateTime dateNaissance)
        {
            return DateTime.Now.Date.Subtract(dateNaissance).Days / 365;
        }
    }
}
