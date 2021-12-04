﻿using System;
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
    public partial class FoodInfoForm : Form
    {
        public FoodInfoForm()
        {
            InitializeComponent();
        }

        private void FoodInfoForm_Load(object sender, EventArgs e)
        {
            this.InitValues();
        }
        private void InitValues()
        {
            string connectionString = @"Data Source=DESKTOP-M1B6BBF\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SELECT ID, Name FROM Category";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();

            sqlConnection.Open();
            //Lấy dữ liệu từ csdl đưa vào DataTable
            adapter.Fill(ds, "Category");

            //Hiện thị nhóm món ăn
            cbbCatName.DataSource = ds.Tables["Category"];
            cbbCatName.DisplayMember = "Name";
            cbbCatName.ValueMember = "ID";

            //Đóng kết nối và giải phóng bộ nhớ
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
        private void ResetText()
        {
            txtID.ResetText();
            txtName.ResetText();
            txtNotes.ResetText();
            txtUnit.ResetText();
            cbbCatName.ResetText();
            nud_Price.ResetText();

        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-M1B6BBF\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "EXECUTE InsertFood @id OUTPUT,@name, @unit, @foodCategoryID,@price, @notes";

                //Thêm tham số vào đối tượng Command
                sqlCommand.Parameters.Add("@id", SqlDbType.Int);
                sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                sqlCommand.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                sqlCommand.Parameters.Add("@foodCategoryId",SqlDbType.Int );
                sqlCommand.Parameters.Add("@price", SqlDbType.Int);
                sqlCommand.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                sqlCommand.Parameters["@id"].Direction = ParameterDirection.Output;
                //Truyền giá trị vào thủ tục qua tham số
                sqlCommand.Parameters["@name"].Value = txtName.Text;
                sqlCommand.Parameters["@unit"].Value = txtName.Text;
                sqlCommand.Parameters["@foodCategoryId"].Value = cbbCatName.SelectedValue;
                sqlCommand.Parameters["@price"].Value = nud_Price.Text;
                sqlCommand.Parameters["@notes"].Value = txtNotes.Text;

                //Mở kết nối

                sqlConnection.Open();

                int numRowAffected = sqlCommand.ExecuteNonQuery();
                //thông báo kết quả
                if(numRowAffected >0)
                {
                    string foodID = sqlCommand.Parameters["@id"].Value.ToString();

                    MessageBox.Show("Thêm thành công món ăn, Food ID =" + foodID, "Message");
                    
                    this.ResetText();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm món ăn thất bại");
                }
                

            }
            catch(SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }

        }
        public void DisplayFoodInfo(DataRowView rowView)
        {
            try
            {
                txtID.Text = rowView["ID"].ToString();
                txtName.Text = rowView["Name"].ToString();
                txtUnit.Text = rowView["Unit"].ToString();
                txtNotes.Text = rowView["Notes"].ToString();
                nud_Price.Text = rowView["Price"].ToString();

                cbbCatName.SelectedIndex = -1;
                // Chọn nhóm món ăn tương ứng
                for (int index =0; index < cbbCatName.Items.Count; index++)
                {
                    DataRowView cat = cbbCatName.Items[index] as DataRowView;
                    if(cat["ID"].ToString() == rowView["FoodCategoryID"].ToString())
                    {
                        cbbCatName.SelectedIndex = index;
                        break;
                    }
                }
                
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
                this.Close();
            }
        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            
            try
            {
                string connectionString = @"Data Source=DESKTOP-M1B6BBF\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "EXECUTE Food_Update @id ,@name, @unit, @foodCategoryID, @price, @notes";

                //Thêm tham số vào đối tượng Command
                sqlCommand.Parameters.Add("@id", SqlDbType.Int);
                sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                sqlCommand.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                sqlCommand.Parameters.Add("@foodCategoryId", SqlDbType.Int);
                sqlCommand.Parameters.Add("@price", SqlDbType.Int);
                sqlCommand.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                //Truyền giá trị vào thủ tục qua tham số

                sqlCommand.Parameters["@id"].Value = int.Parse(txtID.Text);
                sqlCommand.Parameters["@name"].Value = txtName.Text;
                sqlCommand.Parameters["@unit"].Value = txtUnit.Text;
                sqlCommand.Parameters["@foodcategoryId"].Value = cbbCatName.SelectedValue;
                sqlCommand.Parameters["@price"].Value = nud_Price.Value;
                sqlCommand.Parameters["@notes"].Value = txtNotes.Text;

                sqlConnection.Open();

                int numRowAffected = sqlCommand.ExecuteNonQuery();

                if(numRowAffected > 0)
                {
                    MessageBox.Show("Cập nhật món ăn thành công", "Message");
                    this.ResetText();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật món ăn thất bại");
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
        private void foodForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbCatName.SelectedIndex;
            cbbCatName.SelectedIndex = -1;
            cbbCatName.SelectedIndex = index;
            InitValues();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            addCategory.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
            addCategory.Show(this);
        }
    }
}
