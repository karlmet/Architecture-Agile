﻿using System.Collections.Generic;
using UMetropolis.Domaine;

namespace UMetropolis.Infrastructure
{
    public interface IDepotCours
    {
        List<Cours> ObtenirCoursEtudiantDroit(int id);
    }
}