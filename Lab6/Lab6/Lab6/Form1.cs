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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
            string connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            //Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //Thiết lập lệnh truy vấn
            string query = "SELECT ID, Name, Type FROM Category";
            //Mở kết nối tới csdl
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            //Thực thi lệnh bằng phương thức ExcuteReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //Gọi hàm hiển thị dữ liệu lên màn hình
            this.DisplayCategory(sqlDataReader);

            sqlConnection.Close();
            
        }
        private void DisplayCategory(SqlDataReader reader)
        {
            lvCategory.Items.Clear();
            while (reader.Read())
            {
                //Tạo một dòng mới trong LV
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                lvCategory.Items.Add(item);
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Type"].ToString());

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtType.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin");
            }
            else
            {
                string connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = $"INSERT INTO Category(Name, [Type]) VALUES (N'{txtName.Text}', " +
                    $"{int.Parse(txtType.Text)})";

                sqlConnection.Open();

                int numOfRowsEffected = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (numOfRowsEffected == 1)
                {


                    txtName.Text = "";
                    txtID.Text = "";
                    txtType.Text = "";
                    MessageBox.Show("Thêm nhóm món ăn thành công");
                    btnLoad.PerformClick();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra vui lòng thử lại");
                }

            }
           
           
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            String connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            string name = txtName.Text;
            string type = txtType.Text == "Thức uống" ? "0" : "1";
            string id = txtID.Text;

            sqlCommand.CommandText = $"update Category set Name = N'{name}', [Type] = {type} where ID = {id}";
            sqlConnection.Open();
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];

                item.SubItems[1].Text = txtName.Text;
                item.SubItems[2].Text = txtType.Text;

         
                txtName.Text = "";
                txtID.Text = "";
                txtType.Text = "";

                btn_Update.Enabled = false;
                btn_Delete.Enabled = false;


                MessageBox.Show("Cập nhật nhóm món ăn thành công");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra vui lòng thử lại");
            }

        }

        private void lvCategory_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvCategory.SelectedItems[0];

            txtID.Text = item.Text;
            txtName.Text = item.SubItems[1].Text;
            txtType.Text = item.SubItems[1].Text == "0" ? "Thức uống" : "Đồ ăn";

            btn_Update.Enabled = true;
            btn_Delete.Enabled = true;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            String connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            
            sqlCommand.CommandText = "delete from Category " + "where ID = " + txtID.Text;

            sqlConnection.Open();

            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            if (numOfRowsEffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];
                lvCategory.Items.Remove(item);

              
                txtName.Text = "";
                txtID.Text = "";
                txtType.Text = "";

                btn_Update.Enabled = false;
                btn_Delete.Enabled = false;


                MessageBox.Show("Xóa nhóm món ăn thành công");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra vui lòng thử lại");
            }

        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count > 0)
                btn_Delete.PerformClick();
        }

        private void tsmViewFood_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                frmFood frmFood = new frmFood();
                frmFood.Show(this);
                frmFood.LoadFood(Convert.ToInt32(txtID.Text));
            }
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
                BillsForm billsForm = new BillsForm();
                billsForm.ShowDialog();
        }

        private void btn_Acc_Click(object sender, EventArgs e)
        {
            AccountManagerForm accountManagerForm = new AccountManagerForm();
            accountManagerForm.ShowDialog();
        }
    }
}
