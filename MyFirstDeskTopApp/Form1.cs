using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyFirstDeskTopApp
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
            
        }
        static string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public DataTable SelectBuyer()
        {
            //Connection Database
            SqlConnection conn = new SqlConnection(ConnString);
            DataTable dt = new DataTable();

            try
            {
                //Writing SQL Query
                string sql = "SELECT * FROM BuyerInfo";

                //Creating Sql Using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Creating SQL DataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }

            return dt;

        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            InsertDialog d = new InsertDialog();
            d.ShowDialog();

        }

        private void ReloadData_Click(object sender, EventArgs e)
        {
            DataTable dt = this.SelectBuyer();
            Form1DataGrid.DataSource = dt;
        }
    }
}