﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Identity.Business.Entities
{
    public class Usuario : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<UsuarioPerfil> UsuarioPerfis { get; set; }
        public virtual ICollection<UsuarioPermissao> UsuarioPermissoes { get; set; }
        public DateTime DataDeCriacao { get; private set; }
    }
}