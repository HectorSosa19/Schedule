using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;
using CapaNegocio;


namespace CapaDatos
{
    public class D_Agenda
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Agenda_Base_de_datos_.Properties.Settings.AgendaElectronicaConnectionString"].ConnectionString);
        public List<E_Agenda>ListarAgenda(String buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("SP_BuscarAgenda", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@Buscar", buscar);
            leerFilas = cmd.ExecuteReader();
            List<E_Agenda> Listar = new List<E_Agenda>();
            while (leerFilas.Read())
            {
                Listar.Add(new E_Agenda
                {
                    IdAgenda = leerFilas.GetInt32(0),
                    CodigoAgenda = leerFilas.GetString(1),
                    Nombre = leerFilas.GetString(2),
                    Apellido = leerFilas.GetString(3),
                    Cedula=leerFilas.GetString(4),
                    Correo= leerFilas.GetString(5),
                    Direccion=leerFilas.GetString(6)

                });
            }

            conexion.Close();
            leerFilas.Close();
            return Listar;

        }
        public void InsertarAgenda(E_Agenda Agenda)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarAgenda", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@Nombre", Agenda.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", Agenda.Apellido);
            cmd.Parameters.AddWithValue("@Cedula", Agenda.Cedula);
            cmd.Parameters.AddWithValue("@Correo", Agenda.Correo);
            cmd.Parameters.AddWithValue("@Direccion", Agenda.Direccion);
            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void EditarAgenda(E_Agenda Agenda)
        {
            SqlCommand cmd = new SqlCommand("SP_EditarCategoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdAgenda", conexion);
            cmd.Parameters.AddWithValue("@Nombre", Agenda.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", Agenda.Apellido);
            cmd.Parameters.AddWithValue("@Cedula", Agenda.Cedula);
            cmd.Parameters.AddWithValue("@Correo", Agenda.Correo);
            cmd.Parameters.AddWithValue("@Direccion", Agenda.Direccion);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void EliminarAgenda(E_Agenda Agenda)
        {
            SqlCommand cmd = new SqlCommand("SP_EliminarAgenda", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdAgenda", Agenda.IdAgenda);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

    }
}
    

