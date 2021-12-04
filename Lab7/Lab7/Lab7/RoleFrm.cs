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
    public partial class RoleFrm : Form
    {
        string name;
        public RoleFrm(string _name)
        {
            InitializeComponent();
            this.name = _name;
            DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
            checkCol.Name = "Role";
            checkCol.HeaderText = "Role";

            dgvRole.Columns.Add(checkCol);
            Load_Role();
            

        }
        public void Load_Role()
        {
            
            this.Text = "Danh sách vai trò";
            string connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SELECT *  FROM Role";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            //Mở kết nối
            sqlConnection.Open();
            //
           
            
            //Lấy dữ liệu từ csdl đưa vào DataTable
            adapter.Fill(dt);
            dgvRole.DataSource = dt;
            
            //
            setRoleToG(dt);
            setSize(dt);
            
           /* sqlCommand.CommandText = $"Select RoleID from RoleAccount where AccountName = N'{name}' ";
            SqlDataReader rd = sqlCommand.ExecuteReader();
            while (rd.Read())
            {
                foreach (DataGridViewRow item in dgvRole.Rows)
                {
                    if(rd["RoleID"].ToString() == item.ToString())
                    {
                        item.Cells[1].Value = true;
                    }
                }
            }*/
            
            //Đóng kết nối và giải phóng bộ nhớ
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
        void setRoleToG(DataTable table)
        {
            dgvRole.DataSource = table;
            
            dgvRole.Columns[0].HeaderCell.Value = "";
            dgvRole.Columns[1].HeaderCell.Value = "Mã vai trò";
            dgvRole.Columns[2].HeaderCell.Value = "Tên vai trò";
            dgvRole.Columns[3].HeaderCell.Value = "Đường dẫn";
            dgvRole.Columns[4].HeaderCell.Value = "Ghi chú";
            
        }
        void setSize(DataTable table)
        {
            dgvRole.DataSource = table;
            dgvRole.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRole.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRole.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRole.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRole.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-M1B6BBF\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "EXECUTE InsertRole @id output, @RoleName, @Path, @Notes";

                //Thêm tham số vào đối tượng Command
                sqlCommand.Parameters.Add("@id", SqlDbType.NVarChar, 100);
                sqlCommand.Parameters.Add("@RoleName", SqlDbType.NVarChar, 200);
                sqlCommand.Parameters.Add("@Path", SqlDbType.NVarChar, 1000);
                sqlCommand.Parameters.Add("@Notes", SqlDbType.NVarChar, 1000);

                sqlCommand.Parameters["@id"].Direction = ParameterDirection.Output;
                
                ////Truyền giá trị vào thủ tục qua tham số

                //sqlCommand.Parameters["@id"].Value = int.Parse(txtID.Text);
                sqlCommand.Parameters["@RoleName"].Value = txt_Role.Text;
                sqlCommand.Parameters["@Path"].Value = txt_Path.Text;
                sqlCommand.Parameters["@Notes"].Value = txt_Note.Text;
                

                //Mở kết nối

                sqlConnection.Open();

                int numRowAffected = sqlCommand.ExecuteNonQuery();
                //thông báo kết quả
                if (numRowAffected > 0)
                {
                    //string foodID = sqlCommand.Parameters["@id"].Value.ToString();

                    MessageBox.Show("Thêm thành công vai trò", "Message");
                    this.Load_Role();
                    
                    this.ResetForm();
                    

                }
                else
                {
                    MessageBox.Show("Thêm vai trò thất bại", "Message");
                }


            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-M1B6BBF\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "EXECUTE Role_Update @ID, @RoleName, @Path, @Notes";

                //Thêm tham số vào đối tượng Command
                sqlCommand.Parameters.Add("@id", SqlDbType.Int);
                sqlCommand.Parameters.Add("@RoleName", SqlDbType.NVarChar, 1000);
                sqlCommand.Parameters.Add("@Path", SqlDbType.NVarChar, 2000);
                sqlCommand.Parameters.Add("@Notes", SqlDbType.NVarChar, 1000);


                //Truyền giá trị vào thủ tục qua tham số
                if (dgvRole.SelectedRows.Count <= 0) return;
                DataGridViewRow row = dgvRole.SelectedRows[0];
                sqlCommand.Parameters["@ID"].Value = row.Cells[1].Value.ToString();
                sqlCommand.Parameters["@RoleName"].Value = txt_Role.Text;
                sqlCommand.Parameters["@Path"].Value = txt_Path.Text;
                sqlCommand.Parameters["@Notes"].Value = txt_Note.Text;
               
                sqlConnection.Open();

                int numRowAffected = sqlCommand.ExecuteNonQuery();

                if (numRowAffected > 0)
                {
                    MessageBox.Show("Cập nhật vai trò thành công", "Message");
                    this.Load_Role();
                    this.ResetForm();
                    //this.Load_Account();
                }
                else
                {
                    MessageBox.Show("Cập nhật vai trò thất bại");
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ResetForm()
        {
            txt_Role.Text = "";
            txt_Path.Text = "";
            txt_Note.Text = "";
           
        }

        private void dgvRole_Click(object sender, EventArgs e)
        {
            int index = dgvRole.CurrentRow.Index;
            if (index != null)
            {
                txt_Role.Text = dgvRole.Rows[index].Cells["RoleName"].Value.ToString();
                txt_Path.Text = dgvRole.Rows[index].Cells["Path"].Value.ToString();
                txt_Note.Text = dgvRole.Rows[index].Cells["Notes"].Value.ToString();
                

                btnUpdate.Enabled = true;

            }
        }
       
    }
}
