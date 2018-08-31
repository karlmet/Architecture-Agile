using System;
using System.Collections.Generic;
using System.Text;

namespace UMetropolis.Pegase.Rapports
{
    public class Journalisation
    {
        public static void Log(string pMessage)
        {
            Console.WriteLine(pMessage);
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt", true);
            file.WriteLine(pMessage);

            file.Close();
        }
    }
}
