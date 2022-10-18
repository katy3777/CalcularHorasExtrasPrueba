using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RegistroAsistencia {
        private DateTime _entrada;
        private DateTime _salida;

        public DateTime Entrada
        {
            get => _entrada;
            set => _entrada = value;
        }

        public DateTime Salida
        {
            get => _salida;
            set => _salida = value;
        }
    }
}