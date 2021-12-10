namespace LivrariaBackend.InputModels
{
    public class LivroInput
    {
        public string Descricao { get; set; }
        public int ISBN { get; set; }
        public int AnoLancamento { get; set; }
        public int AutorId { get; set; }
    }
}
