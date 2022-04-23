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
    public partial class Form7 : Form
    {
        public Form7()
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
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            int phone = Convert.ToInt32(txtPhone.Text);
            con.Open();
            string q = "insert into GB values('" + id + "','" + txtName.Text + "','" + txtLname.Text + "','" + phone + "','" + txtCity.Text + "')";

            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Saved");
            showData();
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            string qr = "Delete from GB where id = '" + txtID.Text + "' ";
            SqlCommand cmd = new SqlCommand(qr, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted");
            showData();
        }
    }
}
