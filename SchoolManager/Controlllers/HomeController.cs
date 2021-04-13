using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.Models;
using SchoolManager.Repositories;
using SchoolManager.Services;

namespace SchoolManager.Controlllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        [HttpPost] 
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = UseRepository.Get(model.UserName, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválido" });

            var token = TokenService.GenerateToken(user);

            user.Password = string.Empty;
            return new 
            {
                user = user,
                token = token
            };
        }


        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";


        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);


        [HttpGet]
        [Route("student")]
        [Authorize(Roles = "student, teacher")]
        public string Student() => "Estudantes";

        [HttpGet]
        [Route("teacher")]
        [Authorize(Roles = "teacher")]
        public string Teacher() => "Professores";



    }
}
