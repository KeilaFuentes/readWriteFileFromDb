using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace leerEscribir
{
    public partial class Form2 : Form
    {
        private string fileName = @"C:\Users\Esmeralda\Desktop\Nomina.txt";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string line;
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Cedula");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Cargo");
            dt.Columns.Add("Salario");


            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                string[] registro = line.Split(',');
                DataRow fila = dt.NewRow();
                fila["Cedula"] = registro[0];
                fila["Nombre"] = registro[1];
                fila["Cargo"] = registro[2];
                fila["Salario"] = registro[2];
                dt.Rows.Add(fila);
            }

            file.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
    }
}
