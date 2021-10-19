using AutoMapper;
using Hyperativa.App.Configuration;
using Hyperativa.App.ViewModels;
using Hyperativa.Business.Interfaces.IRepository;
using Hyperativa.Business.Models;
using Hyperativa.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyperativa.App.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class UsersController : MainController
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository,
                              IMapper mapper)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserViewModel model)
        {
            // Recupera o usuário
            var user = await _userRepository.ObterUsuario(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

      
    }
}
