using Examen2.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2.Modelos.DAO
{
    public class TicketDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();
     
        public bool InsertarTicket(Ticket ticket)
        {
            bool inserto = false;
            try
            {
                MiConexion.Close();
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO TICKET ");
                sql.Append(" VALUES (@Nombre, @Email, @Direccion); ");

                //  sql.Append(" VALUES (@Nombre, @Email, @Direccion, @Tipo,@Estado); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = ticket.Nombre;
                comando.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = ticket.Email;
                comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 100).Value = ticket.Direccion;
                 

               // comando.Parameters.Add("@Tipo", SqlDbType.NVarChar, 100).Value = DBNull.Value;
               //// tipoDAO.InsertarTipo(Tipos);


               // comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 100).Value = DBNull.Value;
               // //estadoDAO.InsertarEstado(Estado);

                comando.ExecuteNonQuery();
                inserto = true;
                return true;
                MiConexion.Close();
            }
            catch (Exception ex)
            {
                inserto = false;
            }
            return inserto;
        }

        public DataTable GetTicket()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM  TICKET  ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                MiConexion.Close();
            }
            catch (Exception)
            {
            }
            return dt;
        }
    }
}
