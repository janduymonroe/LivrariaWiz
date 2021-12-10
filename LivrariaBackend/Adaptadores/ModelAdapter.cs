using LivrariaBackend.Models;
using LivrariaBackend.Services.Auth.Jwt;
using System;

namespace LivrariaBackend.Adaptadores
{
    public static class ModelAdapter
    {
        public static JwtCredenciais ParaJwtCredenciais(this Usuario usuario)
        {
            if(usuario == null)
            {
                throw new ArgumentNullException();
            }

            return new JwtCredenciais
            {
                Email = usuario.Email,
                Senha = usuario.Senha,
                Role = usuario.Role
            };
        }
    }
}
