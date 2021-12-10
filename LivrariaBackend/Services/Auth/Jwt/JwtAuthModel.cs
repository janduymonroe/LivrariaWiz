namespace LivrariaBackend.Services.Auth.Jwt
{
    public class JwtAuthModel
    {
        public string TokenAcesso { get; set; }
        public string TipoToken { get; set; }
        public int ExpiraEm { get; set; }
    }
}
