//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RezsikApp_WPF.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rezsi
    {


        public Rezsi(int rid, double oraallas, double fizetendo, DateTime datum)
        {
            Rid = rid;
            Oraallas = oraallas;
            Fizetendo = fizetendo;
            Datum = datum;
   
        }

        public int Rid { get; set; }
        public double Oraallas { get; set; }
        public double Fizetendo { get; set; }
        public System.DateTime Datum { get; set; }
        public int FelhasznaloFid { get; set; }
    
        public virtual Felhasznalo Felhasznalo { get; set; }
        public virtual Tipus Tipus { get; set; }
    }
}
