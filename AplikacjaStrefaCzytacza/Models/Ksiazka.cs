using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplikacjaStrefaCzytacza.Models
{
    public class Ksiazka
    {
        [Key]
        public int Id { get; set; }



        [ForeignKey("Kategoria")]
        public int KategoriaId { get; set; }

        [Display(Name = "Tytuł książki")]
        [Required(ErrorMessage = "Wprowadź tytuł książki")]
        [StringLength(50)]
        public string NazwaKsiazki { get; set; }

        [Display(Name = "Opis książki")]
        [Required(ErrorMessage = "Wprowadź opis książki")]
        [StringLength(300)]
        public string OpisKsiazki { get; set; }

        [Display(Name = "Autor książki")]
        [Required(ErrorMessage = "Wprowadź autora książki")]
        [StringLength(50)]
        public string Autorksiazki { get; set; }

        [Display(Name = "Ocena")]
        [Range(1, 10, ErrorMessage = "Ocena musi być w przedziale 1-10")]
        public int OcenaKsiazki { get; set; }

        public virtual Kategoria Kategoria { get; set; }
    }
}