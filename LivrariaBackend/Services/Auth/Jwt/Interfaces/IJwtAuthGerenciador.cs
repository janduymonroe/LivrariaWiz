namespace LivrariaBackend.Services.Auth.Jwt.Interfaces
{
    public interface IJwtAuthGerenciador
    {
        JwtAuthModel GerarToken(JwtCredenciais credenciais);
    }
}
