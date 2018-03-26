using System;
using System.Collections.Generic;

namespace UMetropolis.Domaine
{
    public class Etudiant
    {

        public int Id { get; private set; }
        public List<Cours> ListCoursInscrits { get; set; }


        public Etudiant(int id)
        {
            Id = id;
        }

    }
}
