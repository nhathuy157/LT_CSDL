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

namespace Lab7
{
    public partial class Form1 : Form
    {
        private DataTable foodTable;
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadCategory()
        {
            string connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SELECT ID, Name FROM Category";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            //Mở kết nối
            sqlConnection.Open();
            //Lấy dữ liệu từ csdl đưa vào DataTable
            adapter.Fill(dt);
            //Đóng kết nối và giải phóng bộ nhớ
            sqlConnection.Close();
            sqlConnection.Dispose();
            //Đưa dữ liệu vào Combo Box
            cbbCategory.DataSource = dt;
            //Hiển thị
            cbbCategory.DisplayMember = "Name";
            //Nhưng khi lấy giá trị thì lấy ID của nhóm
            cbbCategory.ValueMember = "ID";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadCategory();
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedIndex == -1) return;

            string connectionString = @"Data Source=DESKTOP-M1B6BBF\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SELECT * FROM Food WHERE FoodCategoryID =@categoryId";

            //Truyền tham số
            sqlCommand.Parameters.Add("@categoryId", SqlDbType.Int);

            if(cbbCategory.SelectedValue is DataRowView)
            {
                DataRowView rowView = cbbCategory.SelectedValue as DataRowView;
                sqlCommand.Parameters["@categoryId"].Value = rowView["ID"];
            }
            else
            {
                sqlCommand.Parameters["@categoryId"].Value = cbbCategory.SelectedValue;
            }


            //Mở kết nối
            sqlConnection.Open();

            // Tạo bộ điều phiếu dữ liệu
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            foodTable = new DataTable();

            //Lấy dữ liệu từ csdl vào DataTable
            adapter.Fill(foodTable);

            //Đóng kết nối và giải phóng bộ nhớ
            sqlConnection.Close();
            sqlConnection.Dispose();

            //Đưa dữ liệu vào data gdv
            dgvFoodList.DataSource = foodTable;

            //Tính số lượng mẫu tín
            lblQuantity.Text = foodTable.Rows.Count.ToString();
            lblCatName.Text = cbbCategory.Text;
            setFoodToG(foodTable);
            setSize(foodTable);
        }

        private void tsmCalculateQuantity_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-M1B6BBF\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SELECT @numSaleFood = sum(Quantity) " +
                "FROM BillDetails " +
                "WHERE FoodID = @foodId";

            // Lấy thông tin
            if(dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];

                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                //Truyền tham số
                sqlCommand.Parameters.Add("@foodId", SqlDbType.Int);
                sqlCommand.Parameters["@foodId"].Value = rowView["ID"];

                sqlCommand.Parameters.Add("@numSaleFood", SqlDbType.Int);
                sqlCommand.Parameters["@numSaleFood"].Direction = ParameterDirection.Output;

                sqlConnection.Open();
                //Thực thi truy vấn và lấy dữ liệu
                sqlCommand.ExecuteNonQuery();

                string result = sqlCommand.Parameters["@numSaleFood"].Value.ToString();
                MessageBox.Show("Tổng số lượng món " + rowView["Name"] + " Đã bán:" + result + " " + rowView["Unit"]);

                sqlConnection.Close();
            }
            sqlCommand.Dispose();
            sqlConnection.Dispose();


        }
        void setFoodToG(DataTable table)
        {
            dgvFoodList.DataSource = table;
            dgvFoodList.Columns[0].ReadOnly = true;
            dgvFoodList.Columns[0].HeaderCell.Value = "Mã món ăn";
            dgvFoodList.Columns[1].HeaderCell.Value = "Tên món ăn";
            dgvFoodList.Columns[2].HeaderCell.Value = "Đơn vị";
            dgvFoodList.Columns[3].HeaderCell.Value = "Nhóm món ăn";
            dgvFoodList.Columns[4].HeaderCell.Value = "Giá";
            dgvFoodList.Columns[5].HeaderCell.Value = "Ghi chú";
            dgvFoodList.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        void setSize(DataTable table)
        {
            dgvFoodList.DataSource = table;
            dgvFoodList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFoodList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFoodList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFoodList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFoodList.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFoodList.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void tsmAddFood_Click(object sender, EventArgs e)
        {
            FoodInfoForm foodForm = new FoodInfoForm();
            foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
            foodForm.Show(this);

        }
        void foodForm_FormClosed(object sender,FormClosedEventArgs e)
        {
            int index = cbbCategory.SelectedIndex;
            cbbCategory.SelectedIndex = -1;
            cbbCategory.SelectedIndex = index;
        }

        private void tsmUpdateFood_Click(object sender, EventArgs e)
        {
            //Lấy thông tin món ăn đc chọn
            if(dgvFoodList.SelectedRows.Count >0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                FoodInfoForm foodForm = new FoodInfoForm();
                foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
                foodForm.Show(this);
                foodForm.DisplayFoodInfo(rowView);
            }
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (foodTable == null) return;
            //Tạo bộ lọc và sắp xếp
            string filterExpression = " Name like '%" + txtSearchByName.Text + "%'";
            string sortExpression = "Price DESC";
            DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;

            //Tạo đối tượng xem để xem dữ liệu trong bảng dữ liệu foodTable
            // Lọc theo tên and sắp xếp giảm dần theo giá
            DataView foodView = new DataView(foodTable, filterExpression, sortExpression, rowStateFilter);

            //Gán foodTable dưới dạng Data Source of dgv
            dgvFoodList.DataSource = foodView;



        }

        private void oderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm();
            ordersForm.Show(this);
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountForm frm = new AccountForm();
            frm.Show(this);
        }
    }
}
