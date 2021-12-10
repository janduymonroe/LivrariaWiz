using LivrariaBackend.Services.Auth;
using System;

namespace LivrariaBackend.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public RolesUsuario RolesUsuario { get; set; }
        public int Role { get; set; }
    }
}
