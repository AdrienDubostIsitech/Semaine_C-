- Introduction à Dotnet :
	
	- DotNet va permettra de gérer allocations memoire, permissions, tout pour arriver à lancer le projet. framework central au application. 
	
	- DotNet constitué de 2 elements : 
		 -  CLR Common langage runtime (composant de machine virtuel)
		 - de bibliothèques de classes
	
	- VM Debian // Ubuntu ne consomme rien donc framework cross-platform pratique. Kubernetes => orchestration de container. Application qui va consommer juste ce qu'il faut de ressources en augmentant ou enlevant les ressources disponibles ( scalabilité )
	
	- Azure platforme cloud Microsoft. Quand on fait du cloud on paie à la ressource consommer donc tout déployer sur ubuntu ou debian plus rentable. serveur linux standard pour déployer app web.
	
	- open source -> dispo repo public 
	
	- Le CLR gere l'environnement d'execution des applications, il permet de combiner des assemblages de codes, quel que soit le langage dans lequel il ont été écrit. Une application en C sharp pourra utiliser une lib en VB (visual basic). Compilateur convertit du code en différents langage intermédiaire (IL). quand on compile = arriver à un executable au sein de l'environnement cible. chaque langage reconnu par framework a son equivalent en Il.
	
- Syntaxe : 
	
	- sensible à la casse.
	
	- @ devant une variable, permet de déclarer que c'est une variable et non un mot clef
	
	- Declaration variable -- reserver une certaine quantité de mémoire en fonction du type
	
	- do while => passe au moins une fois dedans
	
	- une expression ternaire => expression ? variable si vrai : variable si faux
	
	- switch suite de test pouvant être assimilés à des if et de else car on teste la même variable.
	
	- [int? z = null;] : remplace check de la variable null normalement on fait pas il faut gérer derrière l'attribution de la variable. 
	
	- Conversion :  [long r = e; ] intt32 est le int dans le IL propre au framework Dotnet long est Int64 en IL, conversion explicite [int t = (int)r;]*
	
	- Si on convertit un short égale à 300 en un byte sur 8 bit on obtient un resultat qui est coupé 
	
	- "for" tab pour faire une boucle for rapidement
	
	- [DateTime o is DateTime d; ]

- Espaces de Noms : 
	
	- bibliothèque de classe sont représentés dans des espace de noms (namespace).
	
	- espace de noms permet de mettre une surcouche au dossier et fichier comme des fichiers virtuel à l'intèrieur des fichiers pour structurer, organiser du code et utiliser ce code aillerus.  
	
	- dans l'explorateur d'objet on peut voir des espaces de noms dans lesquels se trouvent des bibliothèque de classe. 

- Constante : 
	- Mot-clef : const (ne permet pas de réassignation (=))
	
	- Les constante ne peuvent pas être modifié au runtime (pendant l'execution) en js, quand on utilise un const sur tableau on peut utiliser les fonctions pour ajouter / modifier ou delete mais on ne peut pas utiliser "=" pas de réassignation
	
- Enum
	
	- enumérations permet de déclarer un type qui regroupe des valeur constantes. On peut donner une type de retour à l'énumération. Dans js, il faut surtout pas donner des objets, des int, des string dans un même tableau car si on veut controler la données et qu'on boucle dessus ça casse
	
	-  On peut caster la valeur de l'enum : [int NombreJour = (int)MonJour;] weekend peut avoir une des deux valeurs : [JourSemaine weekend = JourSemaine.Dimanche | JourSemaine.Samedi;]

- Creation de type 
	
	- un type référence on travaille toujours avec le même emplacements mémoire qu'on va modifier. [string nameUpper = student.name.ToUpper();] C'est une copy de la variable il faut donc la stocker dans une autre variable donc dans un autre emplacements mémoire.
	
	- string interpolation [Console.WriteLine($"Bienvenue {student.name}, comment vas-tu ? ");]
	
	- en C# on distingue les value type bool, int, char, byte et les references type string, class, delegate, Arrays. Les type primitif ne peuvent pas être null. Les value type ne peuvent être modifié si on les passe en paramètre d'une fonction car la fonction va créer une copie qui va être supprimé en fin de fonction. La varibale sera inchangé.  Les reference type eux vont modifier leur valeur si on les passent en argument d'une fonction.
	
- Class
	
	- créer un dossier de type library qui contient la totalité des classes ou alors créer un projet carrément qui servira de librairie. 
	
	- constructeur est une méthode du nom de la classe qui s'éxecute à chaque instanciation de la classe.
	
	- Les membres d'une classe : méthodes, propriétés sont placées entre les accolades 
	
	- class public par défaut alors qu'un membre est private par défaut 
	
	- atributs et modificateurs de classe (niveau d'accès) sont placés avant le mot class  
	
	- Quand on déclare une classe, on peut initialiser les champs directement à la déclaration.
	
	- le this fait référence à l'instance de l'objet qu'on est entrain de créer
	
	- On implémente les membres abstrait avec override. 
	
	- public void abstract méthod(); est une signature d'une méthode. 
	
	- "prop" double tab pour créer propriété rapidement 
	
	- class static => permet d'utiliser les méthodes sans importer 
	
	- une propriété est déclarée de la même manière qu'un champ les propriétées ont des blocs entre accolades get; et set; sont des accesseurs
	
	-  On peut affecter une valeur a un champ readonly seulement lors de la declaration ou lors de l'instanciation au sein du constructeur. [public readonly int i = 1;]  On peut remplacer le readonly avec :  [public int y { get; }]

- Struct : 
	
	-  une struct ne supporte pas l'héritage 
	
	- Elles peuvent pas posséder tout les membres d'une classe à l'exception d'un constructeur sans paramètres, destructeur ou membres virtuels.
	
	- Une struct ressemble à une classe mais c'est un value type et non un reference type (un peu comme une classe primitive)
	
- Niveau d'accès
	
	- public : autorise l'acces a touts les types et a tout les projet
	
	- private : Autorise l'acces uniquement pour les autres membres du type
	
	- internal : Disponible uniquement dans l'espace de nom du type donnée (donc de la classe etc...)
	
	- protected : acces pour les membres du type et pour tout les autres type héritant ce celui-ci même en dehors de l'espace de nom(assembly)
	
	- protected internal : a regarde soi-même si interessé 

- Héritage de Classe : 
	
	- héritage et implémentation d'interface se placent après le nom de la classe.
	
	- héritage permet d'acceder aux membres et méthodes public ou protected de la classe mère pour structurer la classe fille.
	
	- le mot clef "base(value)" appelé comme une méthode permet d'appeler le constructeur de la classe mère.

- Classe Abstraite : 
	- C# permet de rendre les classes et membres abstraites : ne peut pas être instancier et une méthode ne contient pas d'implémentation définir la forme des classes enfants sans en définir le fond l'implémentation est à la charge des classes enfant une classe abstraite permet aussi d'avoir des propriétés.

- CLI Dotnet :
	- dotnet new --list // tout les projet possible
	- dotnet new webapi -o nomduDossier // créer une api web ASP.NET avec le dossier nommé 

-  Types Générique :
	- Les types generique permettent de combiner la reutilisabilité du code et la securité du code 
	- le typage permet de controler les entrées sorties pour renvoyer de bonne information et controler les données.
	- .NET expose ces collection dans l'espace de nom```
	```
	C#
	System.Collections.Generic
	
	List<T>
	
	Dictionary<TKey, TValue>
	```
	- Dans une collection classique comme ArrayList le type des objets n'est pas conserve, ils sont stockes en faisant une conversion vers le type Object 
	- On peut créer ses propres type génériques :
	```
	public class MagicClass<T> {
		protected List<T> myList; 
	}
	```
	- Le parametre T accepte un type au moment de l'instanciation : 
		```
			MagicClass<int>	magic = new MagicClass<int>(); 
		```
	- Un type générique peut faire référence a plusieurs classes : 
		``` C#
			public class UneClasseGenerique<T, U>
			public class UneClasseGenerique<T> // surcharge 
			public class UneClasseGenerique<U> // erreur ne compile pas
		```
	- Surcharge = même signature mais nombre d'arguments différents

- Lambda : 


-  Delegate : 

pourquoi y'a des portées dans les langages et à quoi ça sert ?????????
exemple d'usage de classe abstraite et exemple d'usage d'interface pour expliquer différence




 









