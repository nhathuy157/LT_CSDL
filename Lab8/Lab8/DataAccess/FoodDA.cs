using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FoodDA
    {
        public List<Food> GetAll()
        {
            //Khai báo đối tượng SqlConnection và mở kết nối
            // Đối tượng đc truyền vào chuỗi kết nối
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo sqlComnand có kiểu sử lý là  StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Food_GetAll;
            //Đọc dữ liệu, trả về ds các đối tượng Category
            SqlDataReader reader = command.ExecuteReader();
            List<Food> list = new List<Food>();
            while (reader.Read())
            {
                Food food = new Food();
                food.ID = Convert.ToInt32(reader["ID"]);
                food.Name = reader["Name"].ToString();
                food.Unit = reader["Unit"].ToString();
                food.FoodCategoryID = Convert.ToInt32(reader["FoodCategoryID"]);
                food.Price = Convert.ToInt32(reader["Price"]);
                food.Notes = reader["Notes"].ToString();
                
                list.Add(food);
            }
            sqlConn.Close();
            return list;
        }
        public int Insert_Update_Delete(Food food, int action)
        {
            //Khai báo đối tượng SqlConnection và mở kết nối
            // Đối tượng đc truyền vào chuỗi kết nối
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo sqlComnand có kiểu sử lý là  StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Food_InsertUpdateDelete;
            //Thêm các tham số số cho thủ tục; Các tham số này chính là cách tham số trong thủ tục
            //ID là tham số có giá trị lấy ra khi thêm và truyền vào khi xóa sửa
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;
            command.Parameters.Add(IDPara).Value = food.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = food.Name;
            command.Parameters.Add("@Unit", SqlDbType.NVarChar,1000).Value = food.Unit;
            command.Parameters.Add("@FoodCategoryID", SqlDbType.NVarChar, 100).Value = food.FoodCategoryID;
            command.Parameters.Add("@Price", SqlDbType.Int).Value = food.Price;
            command.Parameters.Add("@Notes", SqlDbType.NVarChar, 1000).Value = food.Notes;
            command.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            // Thực thi lệnh
            int result = command.ExecuteNonQuery();
            if (result > 0) // Nếu thành công thì trả về ID đã thêm
                return (int)command.Parameters["@ID"].Value;

            return 0;
        }
    }
}
