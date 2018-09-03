using System;
using System.Collections.Generic;
using System.Text;
using UMetropolis.Domaine;

namespace UMetropolis.Infrastructure
{
    public class DepotCours : IDepotCours
    {
        public List<Cours> ObtenirCoursEtudiantDroit(int id)
        {
            throw new NotImplementedException();
        }

        public Cours ObtenirCours(int coursId)
        {
            throw new NotImplementedException();
        }

        public bool ValiderPrioriteCours(int coursId)
        {
            throw new NotImplementedException();
        }

        public bool ValiderCoursMaitrise(int etudiantId)
        {
            throw new NotImplementedException();
        }
    }
}
