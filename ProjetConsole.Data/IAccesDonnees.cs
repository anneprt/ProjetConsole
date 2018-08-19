using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole.Data
{
    public interface IAccesDonnees<T>
    {
        // Pour donner le chemin vers le fichier
        string GetCheminFichier();

        // Initialise la liste si elle est vide
        void InitialiserListe();

        // Récupérer une liste
        IEnumerable<T> GetListe();

        // Enregistrer dans la liste
        void Enregistrer(T donnee);

        // Supprimer dans la liste
        void Supprimer(T donnee);

        // Verifier si le fichier existe
        bool FichierExiste();

        // Ecrire dans le fichier (Ecrase le fichier avec le contenu de la liste)
        void EcrireFichier();
    }
}
