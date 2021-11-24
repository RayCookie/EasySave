# EasySave
Repositoire du bloc de Programmation systeme du groupe 5


Ce fichier sera mis à jour au cours du développement de notre application.
Dans le but d’un projet scolaire de CESI EXIA, notre équipe composée de de 4 étudiants a conçu « EasySave ».
Notre équipe vient d'intégrer l'éditeur de logiciels ProSoft. Sous la responsabilité du DSI, on a pour but de gérer et concevoir le projet “EasySave”, ce projet consiste à développer un logiciel de sauvegarde.
Comme tout logiciel de la Suite ProSoft, notre logiciel « EasySave » s'intégrera à la politique tarifaire suivante :

* Prix unitaire : 200 €HT
*	Contrat de maintenance annuel 5/7 8-17h (mises à jour incluses): 12% prix d'achat (Contrat annuel à tacite reconduction avec revalorisation basée sur l'indice SYNTEC)

Dans cette optique nous avons utilisé
Les outils suivants :
*	Visual Studio 2019 16.3 ou supérieure
*	GIT
*	Editeur UML : Visual-Paradigm
Les Langages et FrameWork :
*	Langage C#
*	Bibliothèque Net.Core 3.X

Dépôts :
*	25-11-2021 - Version 1 consoles EasySave v1.0 : dans cette première version notre logiciel est réalisé en ligne de console sans interface graphique 
Fonctionnalités :
*	Création un travail de sauvegarde définit par un nom, un chemin source, un chemin de destination et un type de sauvegarde (complète ou différentielle)
*	Création jusqu'à 5 travails de sauvegarde au maximum
*	Affichage les sauvegardes créées
*	Exécution de l'un des travaux de sauvegarde ou l'exécution séquentielle de l'ensemble des travaux
*	Génération des fichiers journaliers et des fichiers d'état
*	Utilisation de notre programme par des utilisateurs anglophones et Francophones

Mode d’emplois :

*	Lors du lancement de notre logiciel un affichage du nom de notre logiciel apparaîtra.
*	L’utilisateur a le choix de langue entre le français et l’anglais.
*	L’utilisateurs à le choix de créer ou exécuter un travail de sauvegarde.
 ![alt text](https://github.com/RayCookie/EasySave/blob/master/easysave/Screen/image%20(2).png)
*	Créer un travail de sauvegarde :
En inscrivant le numéro 2 cela signifie que vous allez ajouter un travail de sauvegarde, vous allez entrer le nom de votre travail de sauvegarde, le chemin source d’où vous souhaitez récupérer le dossier à sauvegarder et spécifier également le chemin du dossier cible. Après avoir entré ces informations, vous devrez choisir est-ce que vous souhaitez avoir une sauvegarde complète ou bien différentielle.
En passant, petit rappel que : 
*	Sauvegarde complète : Copie intégralement le fichier et dossier à chaque exécution d’une sauvegarde complète.
*	Sauvegarde différentielle : Seuls les fichiers modifiés depuis la dernière sauvegarde complète sont sauvegardés.
Le travail de sauvegarde est maintenant créé.
  ![alt text](https://github.com/RayCookie/EasySave/blob/master/easysave/Screen/image%20(3).png)
*	Exécuter un travail de sauvegarde
En inscrivant le numéro 3 cela signifie que vous allez exécuter un travail de sauvegarde, après cela les travaux de sauvegarde s’afficheront il vous sera demander de choisir si :  vous souhaitez exécuter une sauvegarde en particulier ou bien les exécuter toutes séquentiellement.
  ![alt text](https://github.com/RayCookie/EasySave/blob/master/easysave/Screen/image%20(4).png)
*	Quitter l’application
En inscrivant le numéro 0 vous quitterez l’application.

                                                                           
 
