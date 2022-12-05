using System;
using System.Collections; 
using test1 = tesnamespace;
using test2 = testnamespace2; 


namespace ConsoleApp_Semaine_CSharp
{

    class Program
    {
        static void ChangeValue(int x)
        {
            x = 5;
            Console.WriteLine(x); 
        }

        // public : autorise l'acces a touts les types et a tout les projet
        // private : Autorise l'acces uniquement pour les autres membres du type
        // internal : Disponible uniquement dans l'espace de nom du type donnée (donc de la classe etc...)
        // protected : acces pour les membres du type et pour tout les autres type héritant
        //ce celui-ci même en dehors de l'espace de nom(assembly)
        // protected internal : a regarde soi-même si interessé 


        //atributs et modificateurs de classe (niveau d'accès) sont placés avant le mot class
        //héritage et implémentation d'interface se placent après le nom de la classe. 
        class MaClasse // public par défaut 
        {
            //Les membres d'une classe : méthodes, propriétés sont placées entre les accolades
            public int MyProperty { get; set; }
            int k { get; set; } // privé par défaut

        }

        //une struct ne supporte pas héritage
        //Elles peuvent posseder tout les membres d'une classe à  l'exception d'un constructeur sans paramètres, d'un destructeur et de membres virtuel. 
        struct Geopoint //ressemble à une classe mais c'est un value type et non un reference type (un peu comme une classe primitive)
        {
            double Lat;

            double Long;
            public Geopoint(double Long, double Lat)
            {
                this.Long = Long;
                this.Lat = Lat; 
            }
        }

        enum JourSemaine: int
        {
            Lundi, 
            Mardi, 
            Mercredi, 
            Jeudi = 3, 
            Vendredi, 
            Samedi, 
            Dimanche
        }

        static void ChangeValueReference(test1.Student student)
        {
            student.name = "Julien";
            Console.WriteLine(student.name); 
        }

        static void Main(string[] args) {
            Console.WriteLine("Je ne marche pas c'est un prank");
            int x = 5;
            bool @true;
            @true = false;

            if (x is int)
            {
                Console.WriteLine("Je suis bien un int");
            }
            else
            {
                Console.WriteLine("Je suis pas un int");
            }
            //DateTime o is DateTime d; 


            //Declaration variable -- reserver une certaine quantité de mémoire en fonction du type
            bool b_a = false, b_b = false;

            if (x > 23)
            {
                x -= 3;
            }
            else if (x == 23)
            {
                x -= 1;
            }
            else
            {
                x += 4;
            }

            string majorVersion = null;
            if (majorVersion != null)
            {
                Console.WriteLine("je suis une version nulle");
            }
            else
            {
                Console.WriteLine("je suis une version non nulle");

            }

            //une expression ternaire => expression ? variable si vrai : variable si faux

            //switch suite de test pouvant être assimilés à des if et de else car on teste la même variable. 


            //Class1.cs et Class2.cs implémente deux classes du même nom.
            test1.maclasseA classA = null;
            test2.maclasseB classB = null;

            int i = 1; // bool, char, int, byte type primitif
            Console.WriteLine(i); //1
            ChangeValue(i); //5
            Console.WriteLine(i); // 1 la variable i est inchangé car je passe une valeur qui sera effacé de la memoire en fin de fonction.
                                  // Pour modifier i il faut passer par référence C'est ce qu'on appelle les value type. 



            test1.Student student = new test1.Student("Dorian");
            student.name = "Kevin";
            ChangeValueReference(student);
            Console.WriteLine(student.name); // un type référence on travaille toujours avec le même emplacements mémoire qu'on va modifier. 
            string nameUpper = student.name.ToUpper(); // c'est une copy de la variable il faut donc la stocker dans une autre variable
                                                       // donc dans un autre emplacements mémoire. 
                                                       //string interpolation
            Console.WriteLine($"Bienvenue {student.name}, comment vas-tu ? ");

            int? z = null; //remplace check de la variable null normalement on fait pas il faut gérer derrière l'attribution de la variable. 
            Console.WriteLine(z);
            int e = 4;
            long r = e; //Int32 est le int dans le IL propre au framework Dotnet
                        //long est Int64 en IL 

            //conversion explicite

            int t = (int)r;

            // exemple problème de conversion
            short n = 300;
            byte o = (byte)n;
            Console.WriteLine(o);

            //les constante ne peuvent pas être modifié au runtime (pendant l'execution)
            //en js, quand on utilise un const sur tableau on peut utiliser les fonctions pour ajouter / modifier ou delete
            // mais on ne peut pas utiliser "=" pas de réassignation

            JourSemaine MonJour = JourSemaine.Jeudi;
            Console.WriteLine(MonJour);
            //On peut caster la valeur de l'enum
            int NombreJour = (int)MonJour;
            Console.WriteLine(NombreJour);
            // weekend peut avoir une des deux valeurs
            JourSemaine weekend = JourSemaine.Dimanche | JourSemaine.Samedi;
            Console.WriteLine(weekend);

            //enumérations permet de déclarer un type qui regroupe des valeur constantes.
            //On peut donner une type de retour à l'énumération.
            //Dans js, il faut surtout pas donner des objets, des int, des string dans un même tableau
            //car si on veut controler la données et qu'on boucle dessus ça casse

            //Déclare Tableau
            int[] monTableau;
            //Initialise un tableau a taille limite
            monTableau = new int[50];

            //Déclare Tableau 
            int[] monTableauSansLimite;
            //initialise tableau a taille illimité
            monTableauSansLimite = new int[] { };


            //[ligne, colonne]
            int[,] tmd = new int[2, 2];
            int[,,] tmmd = new int[5, 3, 2];

            int[][] temd = new int[2][];
            temd[0] = new int[] { 2, 5 };
            temd[1] = new int[] { 2, 5, 12, 21 };

/*            for (int b = 0; b < temd.Length; i++)
            {
                for (int j = 0; j < temd[b].Length; i++)
                {
                   // Console.WriteLine(temd[b][j]); 
                }
            }*/


            //ArrayList

            ArrayList arrayList = new ArrayList();
            //ici on type la list
            arrayList.Add(new object());
            arrayList.Add("TEST");
            //c'est à nous de vérifier le type de l'objet qu'on insert
            foreach (object item in arrayList)
            {
                if(item.GetType() == typeof(object))
                {
                    Console.WriteLine(item);
                }
                
            }

            Geopoint g = new Geopoint(1, 45); 

        }
    }
}
