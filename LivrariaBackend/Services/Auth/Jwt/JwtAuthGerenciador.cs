using LivrariaBackend.Services.Auth.Jwt.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LivrariaBackend.Services.Auth.Jwt
{
    public class JwtAuthGerenciador : IJwtAuthGerenciador
    {
        private readonly JwtConfiguracoes _jwtConfiguracoes;

        public JwtAuthGerenciador(IOptions<JwtConfiguracoes> jwtConfiguracoes)
        {
            _jwtConfiguracoes = jwtConfiguracoes.Value;
        }

        public JwtAuthModel GerarToken(JwtCredenciais credenciais)
        {
            var declaracoes = new List<Claim>
            {
                new Claim (ClaimTypes.Email, credenciais.Email),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim (ClaimTypes.Role.ToString(), Convert.ToString(credenciais.Role))
            };

            var chave = Encoding.ASCII.GetBytes(_jwtConfiguracoes.Segredo);

            var jwtToken = new JwtSecurityToken(
                    _jwtConfiguracoes.Emissor,
                    _jwtConfiguracoes.Audiencia,
                    declaracoes,
                    expires: DateTime.Now.AddMinutes(_jwtConfiguracoes.ValorMinutos),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature)
                );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return new JwtAuthModel
            {
                TokenAcesso = accessToken,
                TipoToken = "bearer",
                ExpiraEm = _jwtConfiguracoes.ValorMinutos * 60
            };

        }
    }
}
