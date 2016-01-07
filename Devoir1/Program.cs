using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir1
{

    class Program
    {
        static void Main(string[] args)
        {
            Liste<int> lst = new Liste<int>();
            for (int i = 0; i < 10; i++)
            {
                lst.ajouter(i + 1);
            }

            Liste<int> rlst = new Liste<int>(lst);
            Console.WriteLine(lst == rlst);
            rlst.inverser();
            Console.WriteLine(lst == rlst);
            rlst.ajouter(77);
            lst.ajouter(88);

            try
            {
                
                for (int i = rlst.taille; i > 0 ; i--)
                {
                    Console.Write(rlst.extraire());
                }
                Console.WriteLine("");
                for (int i = lst.taille; i > 0; i--)
                {
                    Console.Write(lst.extraire());
                }
                Console.WriteLine("");
            }
            catch (Exception)
            {

                
            }
            
        }
    }
}
