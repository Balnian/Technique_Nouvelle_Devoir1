using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir1
{
    class Liste<T> where T :new()
    {
        class Noeud<U> where U :T, new()
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


        }

        private Noeud<T> tete;
        private Noeud<T> dernier;

        public Liste()
        {
            tete = null;
            dernier = null;
        }

        public Liste(Liste<T> autre )
        {

        }

        public bool est_vide()
        {
            return tete == null;
        }

        public void ajouter(T val)
        {
            if(est_vide())
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

        public int taille()
        {
            int n = 0;
            for (Noeud<T> i = tete; i != null; i = i.succ)
            {
                n++;
            }
            return n;
        }

        public void inverser()
        {
            Noeud<T> nouvelleTete=new Noeud<T>();
            while(tete!=null)
            {
                Noeud<T> temp = new Noeud<T>(tete.Val);
                temp.succ = nouvelleTete;
                temp = tete;
                tete = temp.succ;
            }
            tete = nouvelleTete;
        }
    }
}
