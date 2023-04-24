using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstDeskTopApp
{
    public partial class InsertDialog : Form
    {
        static string myConneStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
           
        public InsertDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void InsertDialog_Load(object sender, EventArgs e)
        {

        }

        private void InsertDataBtn_Click(object sender, EventArgs e)
        {
            InsertDialog id = new InsertDialog();
            SqlConnection conn = new SqlConnection(myConneStr);

            try
            {
                string sql = "INSERT INTO BuyerInfo(BuyerName, PICName, BuyerContactno,BuyerAddressLine1,BuyerAddressLine2) VALUES (@BuyerName, @PICName, @BuyerContactno,@BuyerAddressLine1,@BuyerAddressLine2)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@BuyerName",BuyerName.Text);
                cmd.Parameters.AddWithValue("@PICName",PICName.Text);
                cmd.Parameters.AddWithValue("@BuyerContactno", BuyerContact.Text);
                cmd.Parameters.AddWithValue("@BuyerAddressLine1", BuyerAdd1.Text);
                cmd.Parameters.AddWithValue("@BuyerAddressLine2", BuyerAdd2.Text);
                conn.Open();

                int row = cmd.ExecuteNonQuery();

                // If the query will run successfully then value of rows will greater than zero else it value will be 0.\
                if (row > 0)
                {
                    MessageBox.Show("User Added");
                }
                else
                {
                    MessageBox.Show("User Not Added");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
