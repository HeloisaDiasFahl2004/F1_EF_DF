//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace F1_EF_DF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            this.CarPilots = new HashSet<CarPilot>();
        }
    
        public int IdCar { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public int Unit { get; set; }
        public int IdTeam { get; set; }
    
        public virtual Team Team { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarPilot> CarPilots { get; set; }
        public override string ToString()
        {
            return "\nId Carro: "+this.IdCar+"\nId Equipe: "+this.IdTeam+"\nAno Carro: " + this.Year+"\nModelo Carro: "+this.Model+"\nUnidade Carro: "+this.Unit;
        }
    }
}