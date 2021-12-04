using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CategoryBL
    {
        //Đối tượng CategoryDA từ DataAccess
        CategoryDA categoryDA = new CategoryDA();
        //Phương thức lấy dữ liệu
        public List<Category> GetAll()
        {
            return categoryDA.GetAll();
        }
        //Phương thức thêm dữ liệu
        public int Insert(Category category)
        {
            return categoryDA.Insert_Update_Delete(category, 0);

        }
        //Cập nhật
        public int Update(Category category)
        {
            return categoryDA.Insert_Update_Delete(category, 1);

        }
        //Xóa
        public int Delete(Category category)
        {
            return categoryDA.Insert_Update_Delete(category, 2);

        }
    }
}
