# Semaine_C#

#Le dossier C#Notes contient mes notes Obsidian de la semaine.
#Le dossier ConsoleApp_semaine_CSharp contient les rappels de cours et syntaxe en C#
#ConsoleGameApp est le projet console en C#
#GameApp_Console_Test est le projet de test unitaire. Il ne contient malheureusement rien j�ai juste eu le temps de lire la documentation. 

#Le projet ConsoleGameApp est un d�mineur. Quand on lance en debug, on obtient un menu avec plusieurs options�: 
- A pour lancer le jeu.
- H pour afficher l�aide du jeu (je devais y �crire les r�gles du d�mineur mais je n�ai pas eu le temps) Le but est d�ouvrir toutes les cases du champ sans tomber sur des mines. Il faudra s�lectionner une case sur le champ avec une lettre repr�sentant sa position en x et un chiffre repr�sentant sa position en y. vous pourrez ensuite ouvrir la case ou poser un drapeau dessus si vous pensez qu�une bombe se cache dans cette case. Les cases sont not�es ��X�� quand elles sont ferm�es et ��F�� quand on pose un drapeau dessus. Quand on ouvre une case qui n�est pas une bombe le chiffre repr�sente le nombre bombe pr�sentent autour de la bombe dans les 4 directions (haut, bas, gauche, droite). Si vous tombait sur une bombe vous revenez au menu principal si vous ouvrait toutes les cases sans bombes vous avez gagn�! Votre score est le temps que vous avez mis pour r�soudre le champ de mines. Il est inscrit dans un fichier json�: ConsoleGameApp\bin\Debug\net5.0\HighScore.json
- Q pour quitter l�application 


