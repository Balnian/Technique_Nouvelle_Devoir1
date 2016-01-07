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
            rlst.inverser();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(rlst.extraire());
            }
        }
    }
}
