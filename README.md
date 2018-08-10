# ProjetConsole
Dépot du projet console C# de Laynet et Anne

votre identifiant de connexion est 0003

A propos 
Nous avons essayé au maximum de travailler en "pair programming".
Nous avons essuyé un petit plantage au niveau de Visual Studio jeudi soir, Laynet n'a pas pu committer le travail effectué à l'instant t ...


Afin de vous éviter de nombreux clic inutiles vers des liens morts, l'unique fonctionnalité du menu principal qui aboutit est le menu de gestion clientèle (touche 5).Dans ce sous menu de gestion clientèle l'unique lien qui ne fonctionne pas est celui de la prospection (touche 6).

Ce qu'il reste à faire (entre autres) :

1.Méthode ReserverVoyage() ==>croiser les données client et les voayges à l'aide de leurs identifiants respectifs(requêtes linq avec jointures ?).Lecture-écriture du fichier Reservation.txt.Prise en compte des tarifs réduits en fonction de l'âge et le nombre de participants.Prise en compte de l'assurance.Utilisation des énumerations.

2.Méthode AnnulerReservation()==> sur le même principe que supprimer un client, avec prise en compte de l'assurance annulation et du remboursement associé le cas échéant.

3.Méthode ConsulterDossier()==> consulter l'état d'avancement d'un dossier. Filter à l'aide de leurs identifiants respectifs la réservation, les clients ou filtrer par rapport à l'état du dossier. Utilisation de l'enumeration .

4.En ce qui concerne la prospection (emailing ou phoning): vérifier dans la base de données (!!) qui a déjà été démarché,quels sont les clients qui viennent de rentrer de voyage (comparaison date du jour et date retour) pour leur envoyer un questionnaire par exemple...

NB:il y a pas mal de commentaires dans le code car nous voulions garder une trace de ce que nous avons tenté pour référence future.




