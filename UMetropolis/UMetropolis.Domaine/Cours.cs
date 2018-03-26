using System;
using System.Collections.Generic;
using System.Text;

namespace UMetropolis.Domaine
{
    public class Cours
    {
        public int Id { get; set; }
        public int Jours { get; set; }
        public TimeSpan Duree { get; set; }
        public int Heure  { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
    }
}
