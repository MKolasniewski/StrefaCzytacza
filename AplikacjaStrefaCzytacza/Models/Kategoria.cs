using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplikacjaStrefaCzytacza.Models
{
    public class Kategoria
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Kategoria")]
        [Required(ErrorMessage = "Wprowadź kategorię")]
        [StringLength(50)]
        public string NazwaKategorii { get; set; }

        [Display(Name = "Opis kategorii")]
        [Required(ErrorMessage = "Wprowadź opis kategorii")]
        [StringLength(300)]
        public string OpisKategorii { get; set; }

        public virtual ICollection<Ksiazka> Ksiazkas { get; set; }
        public virtual ICollection<Cytat> Cytats { get; set; }
    }
}