using System;
using System.Collections.Generic;
using System.Text;

namespace UMetropolis.Service
{
    public interface IServiceSecurite
    {
        bool EstUtilisateurAuthentifie(int idUtilisateur);
        bool AccesEtudiant(int idUtilisateur);
        bool AccesProfesseur(int idUtilisateur);
        bool AccesAdministrateur(int idUtilisateur);

    }
}
