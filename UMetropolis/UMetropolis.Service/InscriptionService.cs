using System;
using System.Collections.Generic;
using UMetropolis.Domaine;
using UMetropolis.Infrastructure;

namespace UMetropolis.Service
{
    public class InscriptionService
    {
        private IDepotCours _depotCours;
        private IServiceSecurite _serviceSecurite;

        public InscriptionService(IDepotCours depotCours, IServiceSecurite serviceSecurite)
        {
            _depotCours = depotCours;
            _serviceSecurite = serviceSecurite;
        }

        public List<Cours> ObtenirListeCours(int id)
        {
            var listeCoursDroit = _depotCours.ObtenirCoursEtudiantDroit(id);
            

            return listeCoursDroit;
        }

        public bool VerifierAccess(int etudiantId)
        {
            return (_serviceSecurite.EstUtilisateurAuthentifie(etudiantId) && _serviceSecurite.AccesEtudiant(etudiantId));
        }
    }
}
