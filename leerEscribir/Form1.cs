using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace leerEscribir
{
    public partial class Form1 : Form
    {
        private string fileName = @"C:\Users\Esmeralda\Desktop\Nomina.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void writeFileLine(string pLine)
        {
            using (System.IO.StreamWriter w = File.AppendText(fileName))
            {
                w.WriteLine(pLine);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = Conexion.getConnection();
                SqlDataReader reader;
                string sSql = "select * from NominaFerreteria";

                SqlCommand ocmd = new SqlCommand(sSql, conn);

                reader = ocmd.ExecuteReader();
                while (reader.Read())
                {
                    writeFileLine(reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3));

                }
                reader.Close();
                ocmd.Dispose();
                conn.Close();
                MessageBox.Show("Archivo Generado");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al leer la nomina" + ex);
            }
        }
    }
}
