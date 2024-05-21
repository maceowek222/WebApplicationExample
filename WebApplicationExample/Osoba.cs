using System.ComponentModel.DataAnnotations;

namespace WebApplicationExample
{
    public class Osoba
    {
        [Key]
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Adres { get; set; }



    }
}
