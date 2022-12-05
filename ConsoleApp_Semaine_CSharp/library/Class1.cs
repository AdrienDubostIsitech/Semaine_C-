using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using tesnamespace;

namespace ConsoleApp_Semaine_CSharp.library
{
    public class Project // : Student permet d'heriter de la classe student
    {

        protected string filename = "sans titre.npx", path;

        protected DataTable data = new DataTable();

        private bool hasChanged;

        //on peut affecter une valeur a un champ readonly
        // seulement lors de la declaration ou lors de l'instanciation au sein du constructeur.
        public readonly int i = 1;  // on peut remplacer le readonly avec : 
        public int y { get; }

        //une propriété est déclarée de la même manière qu'un champ
        // les propriétées ont des blocs entre accolades
        //get; et set; sont des accesseurs
        public int Myproperty { get; set; }

        //exemple de getter et setter
        //on sécurise des champs private derrière des propriétés protected ou public 
        protected bool HasChanged { get => hasChanged; set => hasChanged = value; }

        //on peut donner un niveau d'accès a un accesseur
        public int ii { get; private set; }

    }
}
