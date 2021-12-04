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
    public partial class DiaryFrm : Form
    {
        string account;
        
        
        public DiaryFrm(string account)
        {
            InitializeComponent();
            this.account = account;
            //ListView Header
            /*Lv_Date.GridLines = true;
            Lv_Date.View = View.Details;
            Lv_Date.Columns.Add("Ngày", 169);*/
        }
        public void Load_Diary()
        {
            
            try
            {
                string connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlConnection.Open();

                sqlCommand.CommandText = $"select distinct(CheckoutDate) from Bills where Account = N'{account}'";

                

                sqlCommand.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    
                    lb_date.Items.Add(reader["CheckoutDate"].ToString());
                    
                }
                sqlConnection.Close();
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

        private void Lv_Date_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
        }
        void setBillsToG(DataTable table)
        {

            dvg_Bills.Columns[0].ReadOnly = true;
            dvg_Bills.Columns[0].HeaderCell.Value = "Mã hóa đơn thanh toán";
            dvg_Bills.Columns[1].HeaderCell.Value = "Tên hóa đơn thanh toán";
            dvg_Bills.Columns[2].HeaderCell.Value = "Mã bàn";
            dvg_Bills.Columns[3].HeaderCell.Value = "Số tiền";
            dvg_Bills.Columns[4].HeaderCell.Value = "Giảm gá";
            dvg_Bills.Columns[5].HeaderCell.Value = "Thuế";
            dvg_Bills.Columns[6].HeaderCell.Value = "Trạng thái";
            dvg_Bills.Columns[7].HeaderCell.Value = "Ngày lập";
            dvg_Bills.Columns[8].HeaderCell.Value = "Tài khoản lập";
            //

        }
        void setSize(DataTable table)
        {
            dvg_Bills.DataSource = table;
            dvg_Bills.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dvg_Bills.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dvg_Bills.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dvg_Bills.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dvg_Bills.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dvg_Bills.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dvg_Bills.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dvg_Bills.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dvg_Bills.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void lb_date_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Danh sách hóa đơn";
                String connectionString = "server=DESKTOP-M1B6BBF\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlConnection.Open();

                sqlCommand.CommandText = "EXECUTE Bills_GetByDate @date";
                //Thêm tham số vào đối tượng Command
                sqlCommand.Parameters.Add("@date", SqlDbType.SmallDateTime);
                //Truyền giá trị vào thủ tục qua tham số
                sqlCommand.Parameters["@date"].Value = lb_date.SelectedItem.ToString();

                sqlCommand.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable table = new DataTable("Bills");
                adapter.Fill(table);

                dvg_Bills.DataSource = table;
                dvg_Bills.Columns[0].ReadOnly = true;

                sqlConnection.Close();
                sqlCommand.Dispose();
                setBillsToG(table);
                setSize(table);

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
