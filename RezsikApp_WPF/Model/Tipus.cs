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
    
    public partial class Tipus
    {
        public int Tid { get; set; }
        public string T_Nev { get; set; }
    
        public virtual Rezsi Rezsi { get; set; }
    }
}
