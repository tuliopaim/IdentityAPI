﻿using Identity.API.Extensions.Attributes;
using Identity.Business.Entities;
using Identity.Business.Enumeradores;
using Identity.Business.Interfaces;
using Identity.Business.Interfaces.Services;
using Identity.Business.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Route("api/usuario")]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioService _userService;

        public UsuarioController(
              IUsuarioService userService,
              INotificador notificador) : base(notificador)
        {
            _userService = userService;
        }
        
        [HttpPost("registrar")]
        [ClaimsAuthorize(PermissaoNomeEnum.Usuario, PermissaoValorEnum.C)]
        public async Task<IActionResult> Registrar([FromBody]CriarUsuarioRequest registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _userService.RegistrarUsuario(registerUser);

            return CustomResponse(registerUser);
        }

        [AllowAnonymous]
        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] LoginUsuarioRequest loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var response = await _userService.AutenticarUsuario(loginUser);

            return CustomResponse(response);
        }

        [AllowAnonymous]
        [HttpPost("alterar-senha")]
        public async Task<IActionResult> AlterarSenha([FromBody] AlterarSenhaRequest alterarSenha)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _userService.AlterarSenha(alterarSenha);

            return CustomResponse();
        }
    }
}