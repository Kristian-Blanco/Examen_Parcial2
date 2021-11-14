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
    public class EstadoDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool InsertarEstado(Estado estado)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO ESTADO ");
                
                sql.Append(" VALUES (@Estado); ");
                //sql.Append(" VALUES (@Nombre, @Email, @Direccion, @Tipo,@Estado); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();

                //comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = DBNull.Value;
                //comando.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = DBNull.Value;
                //comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 100).Value = DBNull.Value;
                //comando.Parameters.Add("@Tipo", SqlDbType.NVarChar, 100).Value = DBNull.Value;

                comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 100).Value = estado.Estados;

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

        public DataTable GetEstado()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM ESTADO ");

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
