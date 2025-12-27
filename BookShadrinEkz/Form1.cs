using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShadrinEkz
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var MakerID = textBox1.Text;
            string comStr = string.Format("SELECT * FROM dbo.View_1 WHERE id={0};", MakerID);
            using (SqlConnection con = new SqlConnection(Program.conString))
            {
                try { 
                con.Open();
                    SqlCommand cmd = new SqlCommand(comStr, con);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) { 
                        string row = null;
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row = reader.GetName(i) + " : " + reader[i] + " ";
                            }
                            listBox1.Items.Add(row);
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
