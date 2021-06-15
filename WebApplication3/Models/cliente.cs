using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        public string nombres { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string dni { get; set; }
        public string ciudad { get; set; }
    }
}

