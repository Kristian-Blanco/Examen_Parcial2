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
    class TipoDAO : Conexion
    {

        SqlCommand comando = new SqlCommand();

        public bool InsertarTipo(Tipos tipos)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO TIPO_SOPORTE ");
                sql.Append(" VALUES (@Tipo); ");
                //sql.Append(" VALUES (@Nombre, @Email, @Direccion, @Tipo,@Estado); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();

                //comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = DBNull.Value;
                //comando.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = DBNull.Value;
                //comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 100).Value = DBNull.Value;
                //comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 100).Value = DBNull.Value;


                comando.Parameters.Add("@Tipo", SqlDbType.NVarChar, 50).Value = tipos.Tipo;


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

        public DataTable GetTipo()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM TIPO_SOPORTE");

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


