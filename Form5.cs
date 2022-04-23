using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentRegestration
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            showData();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\amali\Documents\students.mdf;Integrated Security=True;Connect Timeout=30");
        private void showData()
        {
            con.Open();
            string q = "select * from GB";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgv.DataSource = ds.Tables[0];
            con.Close();
        }
        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
