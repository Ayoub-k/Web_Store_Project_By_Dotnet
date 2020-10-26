using System;
using System.Collections.Generic;
using System.Linq;

namespace Finalproject.Models
{

    public class Panier
    {
        public List<Livre> livres{get;set;}
        public String email {get;set;}
        public int Qnt {get;set;}
        public void Ajouter(Livre livre)
        {
            foreach(Livre liv in livres)
            {
                if(livre.Id==liv.Id)
                { 
                    return ;
                }
            }
            livres.Add(livre);
        }

        public void Supprimer(Livre livre)
        {
            foreach(Livre liv in livres)
            {
                if(livre.Id==liv.Id)
                {
                    livres.Remove(livre);
                }
            }
        }   
    }
}