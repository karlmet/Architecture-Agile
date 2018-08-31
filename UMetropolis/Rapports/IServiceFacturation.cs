using System;
using System.Collections.Generic;
using System.Text;
using UMetropolis.Domaine;

namespace UMetropolis.Pegase.Rapports
{
    public interface IServiceFacturation
    {
        void FacturerCoursConfirmer(List<Cours> ListeCours);
    }
}
