﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Negocio
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
}
