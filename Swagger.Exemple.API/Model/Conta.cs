using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swagger.Exemple.API.Model
{
    public class Conta
    {
        public int Id { get; private set; }
        public string Usuario { get; private set; }

        public string Senha { get; private set; }

        public List<string> Perfis { get; private set; }

    }
}
