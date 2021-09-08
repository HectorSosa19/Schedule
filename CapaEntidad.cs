using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace CapaEntidad
{
    public class E_Agenda
    {
        private int _IdAgenda;
        private string _CodigoAgenda;
        private string _Nombre;
        private string _Apellido;
        private string _Cedula;
        private string _Correo;
        private string _Direccion;

        public int IdAgenda { get => _IdAgenda; set => _IdAgenda = value; }
        public string CodigoAgenda { get => _CodigoAgenda; set => _CodigoAgenda = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
    }
}
