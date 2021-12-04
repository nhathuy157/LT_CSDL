using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class FoodBL
    {
        FoodDA foodDA = new FoodDA();
        public List<Food> GetAll()
        {
            return foodDA.GetAll();
        }
        //Phương thức lấy về đối tượng food theo khóa chính
        public Food GetByID(int ID)
        {
            //Lấy hết 
            List<Food> list = GetAll();
            foreach (var item in list)
            {
                if (item.ID == ID)
                    return item;
            }
            return null;
        }
        //Phương thức tìm kiếm theo khóa
        public List<Food> Find(string key)
        {
            List<Food> list = GetAll();
            List<Food> result = new List<Food>();
            foreach(var item in list)
            {
                //Nếu từng trường chứa từ khóa
                if(item.ID.ToString().Contains(key)
                    || item.Name.Contains(key)
                    || item.Unit.Contains(key)
                    || item.Price.ToString().Contains(key)
                    || item.Notes.Contains(key))
                    result.Add(item);// thêm vào ds kết quả
                
            }
            return result;
        }
        public int Insert(Food food)
        {
            return foodDA.Insert_Update_Delete(food, 0);
        }
        public int Update(Food food)
        {
            return foodDA.Insert_Update_Delete(food, 1);
        }
        public int Delete(Food food)
        {
            return foodDA.Insert_Update_Delete(food, 2);
        }
    }
}
