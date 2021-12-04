using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDA
    {
        public List<Category> GetAll()
        {
            //Khai báo đối tượng SqlConnection và mở kết nối
            // Đối tượng đc truyền vào chuỗi kết nối
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo sqlComnand có kiểu sử lý là  StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Category_GetAll;
            //Đọc dữ liệu, trả về ds các đối tượng Category
            SqlDataReader reader = command.ExecuteReader();
            List<Category> list = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category();
                category.ID = Convert.ToInt32(reader["ID"]);
                category.Name = reader["Name"].ToString();
                category.Type = Convert.ToInt32(reader["Type"]);
                list.Add(category);
            }
            sqlConn.Close();
            return list;
        }
        public int Insert_Update_Delete(Category category, int action)
        {
            //Khai báo đối tượng SqlConnection và mở kết nối
            // Đối tượng đc truyền vào chuỗi kết nối
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo sqlComnand có kiểu sử lý là  StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Category_InsertUpdateDelete;
            //Thêm các tham số số cho thủ tục; Các tham số này chính là cách tham số trong thủ tục
            //ID là tham số có giá trị lấy ra khi thêm và truyền vào khi xóa sửa
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;
            command.Parameters.Add(IDPara).Value = category.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar,200).Value = category.Name;
            command.Parameters.Add("@Type", SqlDbType.Int).Value = category.Type;
            command.Parameters.Add("@Action", SqlDbType.Int).Value = action;
            // Thực thi lệnh
            int result = command.ExecuteNonQuery();
            if (result > 0) // Nếu thành công thì trả về ID đã thêm
                return (int)command.Parameters["@ID"].Value;

            return 0;
        }
    }
}
