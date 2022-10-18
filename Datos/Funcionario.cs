using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Funcionario
    {
        public string Rut
        {
            get => rut;
            set => rut = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Salario
        {
            get => salario;
            set => salario = value;
        }
        public List<RegistroAsistencia> RegistrosAsistencias
        {
            get => registrosAsistencias;
            set => registrosAsistencias = value;
        }
        private string rut;
        private string nombre;
        private int salario;
        private List<RegistroAsistencia> registrosAsistencias;
        




    }


}
