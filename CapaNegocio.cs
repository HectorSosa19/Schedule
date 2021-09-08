using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class N_Agenda

    {
        D_Agenda objDato = new D_Agenda();
        public List<E_Agenda> ListarAgenda(string buscar)
        {
            return objDato.ListarAgenda(buscar);

        }

        public void InsertandoAgenda(E_Agenda Agenda)
        {
            objDato.InsertarAgenda(Agenda);

        }
        public void EditandoAgenda(E_Agenda Agenda)
        {
            objDato.EditarAgenda(Agenda);

        }
        public void EliminandoAgenda(E_Agenda Agenda)
        {
            objDato.EliminarAgenda(Agenda);
        }
    }
}
