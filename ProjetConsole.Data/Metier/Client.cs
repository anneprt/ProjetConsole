﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole
{
	public class Client :Personne
	{
		
        public string Telephone { get; set; }
        public DateTime DateNaissance { get; set; }





        public void CalculerAge()
		{
			//var dateNaissance = DateTime.Parse(saisie);//la variable vient de la liste du fichier client

			//var age = DateTime.Now.Date.Subtract(dateNaissance).Days / 365;
		}
	}
}