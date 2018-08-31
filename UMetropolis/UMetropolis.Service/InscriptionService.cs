using System;
using System.Collections.Generic;
using UMetropolis.Domaine;
using UMetropolis.Infrastructure;

namespace UMetropolis.Service
{
    public class InscriptionService
    {
        private IDepotCours _depotCours;
        private IDepotEtudiant _depotEtudiant;
        private IServiceSecurite _serviceSecurite;

        public InscriptionService(IDepotCours depotCours, IServiceSecurite serviceSecurite, IDepotEtudiant depotEtudiant)
        {
            _depotCours = depotCours;
            _serviceSecurite = serviceSecurite;
            _depotEtudiant = depotEtudiant;
        }

        public List<Cours> ObtenirListeCours(int id)
        {
            var listeCoursDroit = new List<Cours>();
            if (VerifierAccess(id))
                listeCoursDroit = _depotCours.ObtenirCoursEtudiantDroit(id);

            return listeCoursDroit;
        }

        public bool VerifierAccess(int etudiantId)
        {
            return (_serviceSecurite.EstUtilisateurAuthentifie(etudiantId) && _serviceSecurite.AccesEtudiant(etudiantId));
        }


        public bool ChoisirCours(int etudiantId, int coursId)
        {
            if (VerifierAccess(etudiantId) && 
                ValiderChoixCours(etudiantId, coursId) &&
                VerifierConflitsAgenda(etudiantId, coursId))
                return true;
            return false;
        }

        private bool VerifierConflitsAgenda(int etudiantId, int coursId)
        {
            var etudiant = _depotEtudiant.ObtenirEtudiant(etudiantId);
           // etudiant.ListCoursInscrits = new List<Cours>(); //Todo
            var cours = _depotCours.ObtenirCours(coursId);

            var estSansConflits = ValiderConflitsCours(etudiant.ListCoursInscrits, cours);

            return estSansConflits;

        }

        private bool ValiderConflitsCours(List<Cours> etudiantListCoursInscrits, Cours cours)
        {
           //todo à faire
            return true;
        }

        private bool ValiderChoixCours(int etudiantId, int coursId)
        {
            // todo implémenter la règle BR129
            UMetropolis.Domaine.Trace.Journalise("Cours " + coursId + " a été validé pour étudiant " + etudiantId);
            return true;
        }
    }
}
