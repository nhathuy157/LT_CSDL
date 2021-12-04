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
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-M1B6BBF\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "EXECUTE InsertCategory @id OUTPUT,@name, @type";
                //Thêm tham số vào đối tượng Command
                sqlCommand.Parameters.Add("@id", SqlDbType.Int);
                sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                sqlCommand.Parameters.Add("@type", SqlDbType.Int);

                sqlCommand.Parameters["@id"].Direction = ParameterDirection.Output;
                //Truyền giá trị vào thủ tục qua tham số
                sqlCommand.Parameters["@name"].Value = txtCategoryName.Text;
                sqlCommand.Parameters["@type"].Value = txtType.Text;

                //Mở kết nối

                sqlConnection.Open();

                int numRowAffected = sqlCommand.ExecuteNonQuery();
                //thông báo kết quả
                if (numRowAffected > 0)
                {
                    

                    MessageBox.Show("Thêm thành công nhóm món ăn",  "Message");

                    this.ResetText();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm nhóm món ăn thất bại");
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
    }
}
