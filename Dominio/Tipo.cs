﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        
        // Sobreescribimos el metodo ToString para que retorne la descipción
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
