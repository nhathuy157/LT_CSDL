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
    public partial class frmFood : Form
    {
        int categoryID;
        public frmFood()
        {
            InitializeComponent();

        }
        public void LoadFood(int categoryID)
        {
            this.categoryID = categoryID;
            String connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "select Name from Category where ID = " + categoryID;

            sqlConnection.Open();

            string catName = sqlCommand.ExecuteScalar().ToString();
            this.Text = "Danh sách các món ăn thuộc nhóm: " + catName;

            sqlCommand.CommandText = "select * from Food where FoodCategoryID = " + categoryID;

            SqlDataAdapter data = new SqlDataAdapter(sqlCommand);

            DataTable datatb = new DataTable("Food");
            data.Fill(datatb);

            dgvFood.DataSource = datatb;

            sqlConnection.Close();
            sqlConnection.Dispose();
            datatb.Dispose();

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlConnection.Open();
            for (int i=0; i < dgvFood.Rows.Count - 1; i++)
            {
                int id = (int)dgvFood.Rows[i].Cells["ID"].Value; //Lấy giá trị của ID tại hàng tương ứng
                sqlCommand.CommandText = "SELECT * FROM Food WHERE ID = " + id;
                var check = sqlCommand.ExecuteScalar();

                if(check == null)
                {
                    string query = string.Format("INSERT INTO Food(Name, Unit, FoodCategoryID, Price, Notes) " +
                         "VALUES (N'{0}', N'{1}', {2}, {3}, N'{4}')",
                         dgvFood.Rows[i].Cells["Name"].Value,
                         dgvFood.Rows[i].Cells["Unit"].Value,
                         categoryID,
                         dgvFood.Rows[i].Cells["Price"].Value,
                         dgvFood.Rows[i].Cells["Notes"].Value.ToString());

                    sqlCommand.CommandText = query; //Thực hiện lệnh
                    sqlCommand.ExecuteNonQuery(); //Thi hành truy vấn
                    MessageBox.Show("Thêm thành công"); 
                }
                else
                {
                    string query = string.Format("UPDATE Food SET Name = N'{0}', Unit = N'{1}', FoodCategoryID = {2}, Price = {3}, Notes = N'{4}' WHERE ID = {5}"  ,
                         dgvFood.Rows[i].Cells["Name"].Value,
                         dgvFood.Rows[i].Cells["Unit"].Value,
                         categoryID,
                         dgvFood.Rows[i].Cells["Price"].Value,
                         dgvFood.Rows[i].Cells["Notes"].Value.ToString(),
                         id.ToString());

                    sqlCommand.CommandText = query; //Thực hiện lệnh
                    sqlCommand.ExecuteNonQuery(); //Thi hành truy vấn
                    MessageBox.Show("Cập nhật thành công");

                }

            }

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows.Count == 0)
            {
                return;
            }

            var selectedRow = dgvFood.SelectedRows[0];

            string foodID = selectedRow.Cells[0].Value.ToString();

            string connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            string query = "delete from Food where ID = " + foodID;
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            int numOfRowEffected = sqlCommand.ExecuteNonQuery();

            if (numOfRowEffected == 1)
            {
                dgvFood.Rows.Remove(selectedRow);
                MessageBox.Show("Xóa món ăn thành công", "Message");
            }
            else
            {
                MessageBox.Show("Xóa món ăn thất bại", "Message");
                return;
            }
            sqlConnection.Close();

        }
    }
}
