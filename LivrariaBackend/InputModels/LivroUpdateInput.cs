namespace LivrariaBackend.InputModels
{
    public class LivroUpdateInput
    {
        public int LivroId { get; set; }
        public string Descricao { get; set; }
        public int AnoLancamento { get; set; }
    }
}
