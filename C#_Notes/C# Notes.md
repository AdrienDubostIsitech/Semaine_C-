DotNet va permettra de gérer allocations memoire, permissions, tout pour arriver à lancer le projet. framework central au application. 
constitué de 2 elements : 
 -  CLR Common langage runtime (composant de machine virtuel)
 - de bibliothèques de classes
VM Debian // Ubuntu ne consomme rien donc framework cross-platform pratique. 
Kubernetes => orchestration de container. Application qui va consommer juste ce qu'il faut de ressources en augmentant ou enlevant les ressources disponibles ( scalabilité )
Azure platforme cloud Microsoft
Quand on fait du cloud on paie à la ressource consommer donc tout déployer sur ubuntu ou debian plus rentable. serveur linux standard pour déployer app web.
open source -> dispo repo public 

Le CLR gere l'environnement d'execution des applications, il permet de combiner des assemblages de codes, quel que soit le langage dans lequel il ont été écrit. Une application en C sharp pourra utiliser une lib en VB (visual basic). Compilateur convertit du code en différents langage intermédiaire (IL). quand on compile = arriver à un executable au sein de l'environnement cible. chaque langage reconnu par framework a son equivalent en Il.

bibliothèque de classe sont représentés dans des espace de noms (namespace).
sensible à la casse.

@ permet de dire devant une variable c'est une variable et non un mot clef
Declaration variable -- reserver une certaine quantité de mémoire en fonction du type

do while => passe au moins une fois dedans

espace de noms permet de mettre une surcouche au dossier et fichier comme des fichiers virtuel à l'intèrieur des fichiers
pour structurer, organiser du code et utiliser ce code aillerus. 
dans l'explorateur d'objet on peut voir des espaces de noms dans lesquels se trouvent des bibliothèque de classe. 
class static => permet d'utiliser les méthodes sans importer 

en C# on distingue les value type bool, int, char, byte et les references type string, class, delegate, Arrays

les type primitif ne peuvent pas être null.

pourquoi y'a des portées dans les langages et à quoi ça sert ?????????
exemple d'usage de classe abstraite et exemple d'usage d'interface pour expliquer différence

"prop" double tab pour créer propriété rapidement 
"for" tab pour faire une boucle for rapidement

constructeur est une méthode du nom de la classe qui s'éxecute à chaque instanciation de la classe. 
le this fait référence à l'instance de l'objet qu'on est entrain de créer

créer un dossier de type library qui contient la totalité des classes 
ou alors créer un projet carrément qui servira de librairie. 


Quand on déclare une classe, on peut initialiser les champs directement à la déclaration.

C# permet de rendre les classes et membres abstraites : 
ne peut pas être instancier et une méthode ne contient pas d'implémentation
définir la forme des classes enfants sans en définir le fond l'implémentation est à la charge des classes enfant
une classe abstraite permet aussi d'avoir des propriétés.
On implémente les membres abstrait avec override. 
public void abstract méthod(); est une signature d'une méthode. 