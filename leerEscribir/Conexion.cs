using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leerEscribir
{
    class Conexion
    {
        public static SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-80RV8BN;Initial Catalog=NominaBD;Integrated Security=True");
            conn.Open();
            return conn;
        }
    }
}
