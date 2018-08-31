using System.Collections.Generic;
using UMetropolis.Domaine;

namespace UMetropolis.Pegase.Rapports
{
    public interface IDepotCours
    {
        List<Cours> ObtenirCoursEtudiantDroit(int id);
        Cours ObtenirCours(int coursId);
        List<Cours> ObtenirCoursConfirme();
        void MarqueCoursFacture(List<Cours> listeCours);
    }
}