# Semaine_C#

#Le dossier C#Notes contient mes notes Obsidian de la semaine.
#Le dossier ConsoleApp_semaine_CSharp contient les rappels de cours et syntaxe en C#
#ConsoleGameApp est le projet console en C#
#GameApp_Console_Test est le projet de test unitaire. Il ne contient malheureusement rien j’ai juste eu le temps de lire la documentation. 

#Le projet ConsoleGameApp est un démineur. Quand on lance en debug, on obtient un menu avec plusieurs options : 
- A pour lancer le jeu.
- H pour afficher l’aide du jeu (je devais y écrire les règles du démineur mais je n’ai pas eu le temps) Le but est d’ouvrir toutes les cases du champ sans tomber sur des mines. Il faudra sélectionner une case sur le champ avec une lettre représentant sa position en x et un chiffre représentant sa position en y. vous pourrez ensuite ouvrir la case ou poser un drapeau dessus si vous pensez qu’une bombe se cache dans cette case. Les cases sont notées « X » quand elles sont fermées et « F » quand on pose un drapeau dessus. Quand on ouvre une case qui n’est pas une bombe le chiffre représente le nombre bombe présentent autour de la bombe dans les 4 directions (haut, bas, gauche, droite). Si vous tombait sur une bombe vous revenez au menu principal si vous ouvrait toutes les cases sans bombes vous avez gagné ! Votre score est le temps que vous avez mis pour résoudre le champ de mines. Il est inscrit dans un fichier json : ConsoleGameApp\bin\Debug\net5.0\HighScore.json
- Q pour quitter l’application 


