using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UMetropolis.Domaine
{
    public class Trace
    {
        private static TraceSource _source = new TraceSource("DomainLog");

        public static void Journalise(string message)
        {
            _source.TraceEvent(TraceEventType.Information,0,message);
        }

    }
}
