using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir1
{
    class Liste<T> where T : new()
    {
        class Noeud<U> where U : T, new()
        {
            public Noeud<U> succ;

            public U Val;

            public Noeud()
            {
                Val = new U();
                succ = null;
            }

            public Noeud(U val)
            {
                Val = val;
                succ = null;
            }
            public Noeud(Noeud<U> no)
            {

                Val = no.Val;
                if (no.Val != null)
                    succ = no.succ;
                else
                    succ = null;
            }


        }

        private Noeud<T> tete;
        private Noeud<T> dernier;

        public Liste()
        {
            tete = null;
            dernier = null;
        }

        public Liste(Liste<T> autre)
        {
            Noeud<T> temp = autre.tete;
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
                tete = dernier = new Noeud<T>(val);
            }
            else
            {
                dernier.succ = new Noeud<T>(val);
                dernier = dernier.succ;
            }
        }

        public T extraire()
        {
            if (est_vide()) throw new Exception("Vide");
            Noeud<T> temp = tete;
            tete = tete.succ;
            return temp.Val;
        }

        public int taille
        {
            get
            {
                int n = 0;
                for (Noeud<T> i = tete; i != null; i = i.succ)
                {
                    n++;
                }
                return n;
            }
        }

        public void inverser()
        {
            Noeud<T> nouvelleTete = new Noeud<T>(tete.Val);
            Noeud<T> parcour = tete;
            //dernier = nouvelleTete;
            while ((parcour = parcour.succ) != null)
            {
                Noeud<T> temp = new Noeud<T>(nouvelleTete);
                nouvelleTete = new Noeud<T>(parcour.Val);
                nouvelleTete.succ = new Noeud<T>(temp);
            }

            tete = new Noeud<T>(nouvelleTete);
            for (Noeud<T> i = tete; i != null; i = i.succ)
            {
                dernier = i;
            }
        }
    }
}
