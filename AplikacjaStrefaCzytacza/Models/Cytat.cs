using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplikacjaStrefaCzytacza.Models
{
    public class Cytat
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Kategoria")]
        public int KategoriaId { get; set; }

        [Display(Name = "Cytat")]
        [Required(ErrorMessage = "Podaj cytat")]
        [StringLength(200)]
        public string TekstCytatu { get; set; }

        [Display(Name = "Książka")]
        [Required(ErrorMessage = "Podaj nazwę książki")]
        [StringLength(50)]
        public string NazwaKsiazki { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Podaj autora cytatu")]
        [StringLength(50)]
        public string AutorCytatu { get; set; }

        public virtual Kategoria Kategoria { get; set; }
    }
}