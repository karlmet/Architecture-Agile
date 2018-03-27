using System.Collections.Generic;

namespace UMetropolis.Domaine
{
    public class Professeur
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<Cours> ChargeDeCours { get; set; }
    }
}