using System;
using UMetropolis.Infrastructure;
using UMetropolis.Pegase.Rapports;
using IDepotCours = UMetropolis.Pegase.Rapports.IDepotCours;

namespace Rapports
{
    public class ConfirmationCours
    {
        private IServiceFacturation aServiceFacturation ;
        private IDepotCours aDepotCours;


        public ConfirmationCours(IServiceFacturation ServiceFacturation, IDepotCours DepotCours)
        {
            aServiceFacturation = ServiceFacturation;
            aDepotCours = DepotCours;
        }


        public void ConcilierFacturation()
        {
          var oListeCoursConfirme = aDepotCours.ObtenirCoursConfirme();
            if (oListeCoursConfirme.Count > 0)
            {
                aServiceFacturation.FacturerCoursConfirmer(oListeCoursConfirme);
                UMetropolis.Domaine.Trace.Journalise("Nombre de cours facturé:" + oListeCoursConfirme.Count);
                Journalisation.Log("Appel au service de facturation réussi");
            }            
        }
    }
}
