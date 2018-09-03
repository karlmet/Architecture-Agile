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

        private bool ValiderConflitsCours(List<Cours> etudiantListCoursInscrits, Cours coursAValider)
        {
            foreach (var coursInscrit in etudiantListCoursInscrits)
            {
                if (coursInscrit.Jours == coursAValider.Jours && coursInscrit.Heure == coursAValider.Heure)
                    return false;
            }
            return true;
        }

        private bool ValiderChoixCours(int etudiantId, int coursId)
        {
            bool validerRegleExclusion = _depotEtudiant.EtudiantExcluPotentiel(etudiantId);
            bool validerCoursLimite = _depotCours.ValiderPrioriteCours(coursId);
            bool validerCoursExclusifMaitrise = _depotCours.ValiderCoursMaitrise(etudiantId);
            bool statutEtudiantMaitrise = _depotEtudiant.EstInscritMaitrise(etudiantId);

            if (validerCoursExclusifMaitrise && !statutEtudiantMaitrise)
                return false;

            if (validerRegleExclusion | validerCoursLimite)
                return false;

            UMetropolis.Domaine.Trace.Journalise("la règle BR129 pour le cours " + coursId + " a été validé pour étudiant " + etudiantId);
            return true;
        }
    }
}
