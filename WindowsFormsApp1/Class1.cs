using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class bici
    {
        public string modello;
        public string colore;
        public String FaiUnaPedalata()
        {
            //System.Console.WriteLine("Faccio una pedalata.");
            return "Faccio una pedalata.";
        }

        public int DammiVelocita(int marcia)
        {
            return marcia * 10;
        }
    }
}
