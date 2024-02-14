using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZGYA_Villámlások_20240212.src
{
    internal class VillamNap
    {
        public int Nap { get; set; }
        public List<int> Orak { get; set; }

        public VillamNap(int nap, string orak)
        {
            this.Nap = nap;
            this.Orak = new List<int>();
            string[] nyers = orak.Split(';');
            foreach (string s in nyers) 
            {
                this.Orak.Add(int.Parse(s));
            }
        }

        public override string ToString()
        {
            return string.Join(" ", Orak);
        }

    }
}
