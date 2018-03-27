using System;
using System.Collections.Generic;
using System.Text;

namespace UMetropolis.Domaine
{
    public class Cours
    {
        public int Id { get; set; }
        public int Jours { get; set; }
        public TimeSpan Duree { get; set; }
        public int Heure  { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public Professeur ProfesseurCourant { get; set; }
        public Session SessionCourante { get; set; }
        public int NombreMaximumEtudiant { get; set; }
        public List<Etudiant> EtudiantsInscrits { get; set; }
        public List<Cours> CoursPrerquis { get; set; }


    }
}
