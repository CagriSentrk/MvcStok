//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLKATEGORI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLKATEGORI()
        {
            this.TBLURUNLER = new HashSet<TBLURUNLER>();
        } //"required" komutuyla kategori ad�n�n art�k zorunlu olarak doldurulmas�n� sa�lad�m.Bu sayede bo� bir kategori kaydetmeyecek. 

        public short KATEGORIID { get; set; }
        [Required(ErrorMessage = "Bu alan bo� ge�ilemez.")]
        [StringLength(50, ErrorMessage = "en fazla 50 karakter girin.")]

        public string KATEGORIADI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLURUNLER> TBLURUNLER { get; set; }
    }
}
