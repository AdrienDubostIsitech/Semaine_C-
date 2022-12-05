using System;
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

            if(x is int)
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

            if(x > 23)
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
            if(majorVersion != null)
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



            test1.Student student = new test1.Student();
            student.name = "Kevin"; 
            ChangeValueReference(student);
            Console.WriteLine(student.name); // un type référence on travaille toujours avec le même emplacements mémoire qu'on va modifier. 
            string nameUpper = student.name.ToUpper(); // c'est une copy de la variable il faut donc la stocker dans une autre variable
                                                       // donc dans un autre emplacements mémoire. 
                                                       //string interpolation
            Console.WriteLine($"Bienvenue {student.name}, comment vas-tu ? ");

            int? z = null; 

        }
    }
}
