using ConectionApp.DBContextMySql;
using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace ConectionApp
{
    public class MetasDiarias
    {
        public DataTable GetMetas(DateTime fecha, string agrup, int val)
        {
            MysqlDBContext _connect = new MysqlDBContext();
            DataTable dt = new DataTable();

            if (_connect.Open())
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "sp_EFICIENCIA_AGRUP";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = _connect.Connection;

                comando.Parameters.Add("fecha", MySqlDbType.DateTime, 19).Value = fecha;
                comando.Parameters.Add("agrup", MySqlDbType.VarChar, 3).Value = agrup;
                comando.Parameters.Add("val", MySqlDbType.Int32, 10).Value = val;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = comando;

                da.Fill(dt);

            }


            return dt;
        }
    }
}
