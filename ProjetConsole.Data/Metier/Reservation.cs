using ProjetConsole.Outils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Data.Metier
{
    public class Reservation
    {
        public string NumeroReservation { get; set; }

        public string NumeroCB { get; set; }
        public string Etat { get; set; }
        public Client Client { get; set; }
        public Voyage Voyage { get; set; }
        public List<Client> Accompagnant { get; set; }

        public double CalculerCoutTotal()
        {
            double CoutTotal;
            CoutTotal = CalculerTarifReduit(Client);
            foreach(Client accompagnant in Accompagnant)
            {
                CoutTotal = CoutTotal + CalculerTarifReduit(accompagnant);
            }
            return CoutTotal;
        }

        private double CalculerTarifReduit(Client client)
        {
            if (OutilsDate.CalculerAge(client.DateNaissance) < 12)
            {
                return Voyage.Tarif * 0.4;
            }
            return Voyage.Tarif;
        }

    }
}
