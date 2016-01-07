using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir1
{
    class Liste<T> where T : new()
    {
        class Noeud
        {
            public Noeud succ;

            public T Val;

            public Noeud()
            {
                Val = new T();
                succ = null;
            }

            public Noeud(T val)
            {
                Val = val;
                succ = null;
            }
            public Noeud(Noeud no)
            {

                Val = no.Val;
                if (no.Val != null)
                    succ = no.succ;
                else
                    succ = null;
            }






        }

        private Noeud tete;
        private Noeud dernier;

        public Liste()
        {
            tete = null;
            dernier = null;
        }

        public Liste(Liste<T> autre)
        {
            Noeud temp = autre.tete;
            do
            {
                ajouter(temp.Val);
            } while ((temp = temp.succ) != null);
        }

        public bool est_vide()
        {
            return tete == null;
        }

        public void ajouter(T val)
        {
            if (est_vide())
            {
                tete = dernier = new Noeud(val);
            }
            else
            {
                dernier.succ = new Noeud(val);
                dernier = dernier.succ;
            }
        }

        public T extraire()
        {
            if (est_vide()) throw new Exception("Vide");
            Noeud temp = tete;
            tete = tete.succ;
            return temp.Val;
        }

        public int taille
        {
            get
            {
                int n = 0;
                for (Noeud i = tete; i != null; i = i.succ)
                {
                    n++;
                }
                return n;
            }
        }

        public void inverser()
        {
            Noeud nouvelleTete = new Noeud(tete.Val);
            Noeud parcour = tete;
            //dernier = nouvelleTete;
            while ((parcour = parcour.succ) != null)
            {
                Noeud temp = new Noeud(nouvelleTete);
                nouvelleTete = new Noeud(parcour.Val);
                nouvelleTete.succ = new Noeud(temp);
            }

            tete = new Noeud(nouvelleTete);
            for (Noeud i = tete; i != null; i = i.succ)
            {
                dernier = i;
            }
        }

        public void Vider()
        {
            tete = null;
            dernier = null;
        }

        public void Afficher(TextWriter strm)
        {

            for (Noeud i = tete; i != null; i = i.succ)
            {
                strm.Write(i.Val);
            }

        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Liste<T> p = obj as Liste<T>;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return Equals(p);
        }

        public bool Equals(Liste<T> p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            if (p.taille != taille)
                return false;
            else
            {
                Noeud a = tete;
                Noeud b = p.tete;
                do
                {
                    if (!a.Val.Equals(b.Val))
                        return false;
                } while ((a = a.succ) != null && (b = b.succ) != null);
                return true;
            }


        }

        public static bool operator ==(Liste<T> a, Liste<T> b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Liste<T> a, Liste<T> b)
        {
            return !(a == b);
        }
    }

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
