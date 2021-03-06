﻿using System;
using System.Collections.Generic;
using System.Text;
using UMetropolis.Domaine;

namespace UMetropolis.Infrastructure
{
    public interface IDepotEtudiant
    {
        Etudiant ObtenirEtudiant(int etudiantId);

        bool EtudiantExcluPotentiel(int etudiantId);
        bool EstInscritMaitrise(int etudiantId);
    }
}
