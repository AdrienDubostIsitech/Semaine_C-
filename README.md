# Semaine_C#

#Le dossier C#Notes contient mes notes Obsidian de la semaine.
#Le dossier ConsoleApp_semaine_CSharp contient les rappels de cours et syntaxe en C#
#ConsoleGameApp est le projet console en C#
#GameApp_Console_Test est le projet de test unitaire. Il ne contient malheureusement rien j’ai juste eu le temps de lire la documentation. 

#Le projet ConsoleGameApp est un démineur. Quand on lance en debug, on obtient un menu avec plusieurs options : 
- A pour lancer le jeu.
- H pour afficher l’aide du jeu (je devais y écrire les règles du démineur mais je n’ai pas eu le temps) Le but est d’ouvrir toutes les cases du champ sans tomber sur des mines. Il faudra sélectionner une case sur le champ avec une lettre représentant sa position en x et un chiffre représentant sa position en y. vous pourrez ensuite ouvrir la case ou poser un drapeau dessus si vous pensez qu’une bombe se cache dans cette case. Les cases sont notées « X » quand elles sont fermées et « F » quand on pose un drapeau dessus. Quand on ouvre une case qui n’est pas une bombe le chiffre représente le nombre bombe présentent autour de la bombe dans les 4 directions (haut, bas, gauche, droite). Si vous tombait sur une bombe vous revenez au menu principal si vous ouvrait toutes les cases sans bombes vous avez gagné ! Votre score est le temps que vous avez mis pour résoudre le champ de mines. Il est inscrit dans un fichier json : ConsoleGameApp\bin\Debug\net5.0\HighScore.json
- Q pour quitter l’application 

#Le projet WebAPIC# contient une API DOTNET. Cette API a pour objectif de classer les super-heros par film et par pouvoir. 
Malheuresemet je n'ai pas pu terminé l'API. Dans HeroController.cs, dans la fonction createHero quand je rajoute un héros, j'observe que sur swagger j'ajoute bien les films et le super pouvoir du héros mais son Nom du héros et son véritable nom reste vide. Je n'ai réussi à trouver où est-ce que j'override cet variable m'empechant de terminer l'API. La suite aurait été de transférer le code présent dans les fonctions du controller dans les fonctions présentes dans le dossier Services/impl. J'aurais enusite essayé de créer des routes un peu plus "avancées permettant de rechercher des super-héros en fonctions de leur films, de leur pouvoir, de leur indice de puissance etc...

#Question :  Quelle est la différence entre une classe abstraite et une interface ?
Une classe abstraite servent à factoriser du code. Une classe implémentant les méthodes manquantes mais n'est pas obligé de réimplémenter les méthodes déjà implémentées dans le parent. En revanche, une interface permet seulement de déclarées des méthodes. Une classe implémentant une interface doit obligatoirement implémenter toutes les méthodes déclarées dans cette interface. De plus une classe ne peut hériter que d'une classe abstraite mais peut implémenter plusieurs interface.
Par exemple, Si on crée un jeu de rôle, une classe joueur pourrait implémenter une classe abstraite Personnage ou Entity qui implémenterait des méthodes propres à chaque Entité du jeu (joueur / pnj /ennemy) et qui déclarerait des méthodes abstraites à implémenter différemment suivant les classes filles. D'un autre côté, On pourrait avoir plusieurs interface correspondant aux classes possibles : Guerrier, Mage, Assassin etc... Les joueurs pourraient implémenter une ou plusieurs implémentant ensuite les méthodes présentes dans le contrat d'implémentation.
