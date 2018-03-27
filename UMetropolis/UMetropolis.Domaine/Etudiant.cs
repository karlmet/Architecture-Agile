using System;
using System.Collections.Generic;
using System.Xml;

namespace UMetropolis.Domaine
{
    public class Etudiant
    {

        public int Id { get; private set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Session SessionCourante { get; set; }
        public Agenda Agenda { get; set; }

        public List<Cours> ListCoursInscrits { get; set; }

        public Etudiant(int id)
        {
            Id = id;
        }

    }
}
