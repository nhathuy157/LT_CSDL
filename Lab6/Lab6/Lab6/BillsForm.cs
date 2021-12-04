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

namespace Lab6
{
    public partial class BillsForm : Form
    {
        bool check = false;
        string query;
        public BillsForm()
        {
            InitializeComponent();
            Load_Bills();
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {

        }
        private void Load_Bills()
        {
            if (check == false)
            {
                query = "SELECT * FROM Bills";
            }
            this.Text = "Danh sách hóa đơn";
            //this.billsID = billsID;
            String connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlConnection.Open();

            sqlCommand.CommandText = query;
            sqlCommand.ExecuteNonQuery();


            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable table = new DataTable("Bills");
            adapter.Fill(table);

            dgvBills.DataSource = table;
            dgvBills.Columns[0].ReadOnly = true;

            sqlConnection.Close();
            sqlCommand.Dispose();

        }

        private void btn_View_Click(object sender, EventArgs e)
        {

            string fromTime = dtpFrom.Value.ToShortDateString();
            string toTime = dtpTo.Value.ToShortDateString();
            query = $"set dateformat dmy select * from Bills where '{fromTime}' <= CHECKOUTDATE and CHECKOUTDATE <= '{toTime}'";
            check = true;
            Load_Bills();

        }

        private void dgvBills_DoubleClick(object sender, EventArgs e)
        {
            BillDetailsForm billDetail = new BillDetailsForm();
            string billID = dgvBills.SelectedRows[0].Cells[0].Value.ToString();
            billDetail.LoadBillDetails(int.Parse(billID));
            billDetail.Show();
        }
    }
}
