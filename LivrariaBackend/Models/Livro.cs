using System;

namespace LivrariaBackend.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public string Descricao { get; set; }
        public int ISBN { get; set; }
        public int AnoLancamento { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
