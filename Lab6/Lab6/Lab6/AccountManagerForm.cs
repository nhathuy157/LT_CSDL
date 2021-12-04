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
    public partial class AccountManagerForm : Form
    {
        
        public AccountManagerForm()
        {
            InitializeComponent();
        }

        private void AccountManagerForm_Load(object sender, EventArgs e)
        {
            this.LoadRoleAccount();
        }
        private void LoadRoleAccount()
        {
            this.Text = "Danh sách tài khoản";
            string connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SELECT * FROM Account";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            //Mở kết nối
            sqlConnection.Open();
            //Lấy dữ liệu từ csdl đưa vào DataTable
            adapter.Fill(dt);
            //Đóng kết nối và giải phóng bộ nhớ
            sqlConnection.Close();
            sqlConnection.Dispose();
           

        }

        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            if (cbbRole.SelectedItem == "Nhóm")
            {
                this.dgvAccount.DataSource = null;
                sqlCommand.CommandText = "SELECT  RoleID, Account.AccountName, Password, FullName, Email, Tell, DateCreated FROM Account, RoleAccount " +
                    " WHERE Account.AccountName = RoleAccount.AccountName" +
                    " ORDER BY RoleAccount.RoleID";

                sqlConnection.Open();

                this.Text = "Danh sách toàn bộ tài khoản";

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                DataTable table = new DataTable("Food");
                adapter.Fill(table);

                dgvAccount.DataSource = table;

                
                dgvAccount.Columns[0].ReadOnly = true;

                sqlConnection.Close();
            }
            else
            {
                this.dgvAccount.DataSource = null;
                sqlCommand.CommandText = "SELECT Actived, Account.AccountName, Password, FullName, Email, Tell, DateCreated FROM Account, RoleAccount " +
                    " WHERE Account.AccountName = RoleAccount.AccountName" +
                    " ORDER BY RoleAccount.Actived";

                sqlConnection.Open();

                this.Text = "Danh sách toàn bộ tài khoản";

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                DataTable table = new DataTable("Account");
                adapter.Fill(table);

                dgvAccount.DataSource = table;

                
                dgvAccount.Columns[0].ReadOnly = true;

                sqlConnection.Close();
            }



        }

        private void btn_RsPass_Click(object sender, EventArgs e)
        {

        }
    }
}
