using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace Lab8
{
    public partial class Food : Form
    {
        List<Category> listCategory = new List<Category>();
        List<DataAccess.Food> listFood =new List<DataAccess.Food>();
        DataAccess.Food foodCurrent = new DataAccess.Food();
        public Food()
        {
            InitializeComponent();
        }
        public int InsertFood()
        {
            DataAccess.Food food = new DataAccess.Food();
            food.ID = 0;
            if (txtName.Text == "" || txtUnit.Text == "" || txtPrice.Text == "")
                MessageBox.Show("Chua nhap du lieu cho cac o, vui long nhap lai");
            else
            {
                food.Name = txtName.Text;
                food.Unit = txtUnit.Text;
                food.Notes = txtPrice.Text;

                int price = 0;
                try
                {
                    price = int.Parse(txtPrice.Text);
                }
                catch
                {
                    price = 0;
                }
                food.Price = price;
                food.FoodCategoryID = int.Parse(cbbCategory.SelectedValue.ToString());
                FoodBL foodBL = new FoodBL();
                return foodBL.Insert(food);
            }
            return -1;

        }
        public int UpdateFood()
        {
            //Khai báo đối tượng Food và lấy đối tượng hiện hành
            DataAccess.Food food = foodCurrent;
            if (txtName.Text == "" || txtUnit.Text == "" || txtPrice.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
            else
            {
                //Nhận giá trị Name, Unit, và Notes khi người dùng sửa
                food.Name = txtName.Text;
                food.Unit = txtUnit.Text;
                food.Notes = txtNotes.Text;
                //Giá trị price là giá trị số nên cần bắt lỗi khi người dùng nhập sai
                int price = 0;
                try
                {
                    // Chuyển giá trị từ kiểu văn bản qua kiểu int
                    price = int.Parse(txtPrice.Text);
                }
                catch
                {
                    // Nếu sai, gán giá = 0
                    price = 0;
                }
                food.Price = price;
                // Giá trị FoodCategoryID được lấy từ ComboBox
                food.FoodCategoryID = int.Parse(cbbCategory.SelectedValue.ToString());
                // Khao báo đối tượng FoodBL từ tầng Business
                FoodBL foodBL = new FoodBL();
                // Cập nhật dữ liệu trong bảng
                return foodBL.Update(food);
            }
            return -1;
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPrice.Text = "0";
            txtUnit.Text = "";
            txtNotes.Text = "";
            if(cbbCategory.Items.Count > 0)
                cbbCategory.SelectedIndex = 0;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmFood_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadFoodDataToListView();

        }
        private void LoadCategory()
        {
            CategoryBL categoryBL = new CategoryBL(); //Gọi đối tượng từ Business
            listCategory = categoryBL.GetAll(); //Lấy dữ liệu gán cho biến toàn cục list
            cbbCategory.DataSource = listCategory;
            cbbCategory.ValueMember = "ID"; // Lấy ID
            cbbCategory.DisplayMember = "Name"; // Hiển thị tên
        }
        private void LoadFoodDataToListView()
        {
            FoodBL foodBL = new FoodBL();
            //Lấy dữ liệu
            listFood = foodBL.GetAll();
            int count = 1; // biến số thứ tự
            lsvFood.Items.Clear(); // Xóa dữ liệu trong list
            //Đưa dữ liệu vào listView
            foreach(var food in listFood)
            {
                // số thứ tự
                ListViewItem item = lsvFood.Items.Add(count.ToString());
                //Đưa dữ liệu vào cốt tiếp theo
                item.SubItems.Add(food.Name);
                item.SubItems.Add(food.Unit);
                item.SubItems.Add(food.Price.ToString());

                //Lấy name category ID để hiển thị
                string foodName = listCategory.Find(x => x.ID == food.FoodCategoryID).Name;
                item.SubItems.Add(foodName);
                //Đưa dữ liệu note vào cột cuối
                item.SubItems.Add(food.Notes);
                count++;

            }

        }
       

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //Gọi phương thức thêm dữ liệu
            int result = InsertFood();
            if(result > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công");
                LoadFoodDataToListView();
            }
            else
            {
                MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
            }
            

        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            int result = UpdateFood();
            if (result > 0) // Nếu cập nhật thành công
            {
                MessageBox.Show("Cập nhật dữ liệu thành công");
                LoadFoodDataToListView();
            }
            
            else MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá tên thực phảm  này?", "Thông báo",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Khai báo đối tượng FoodBL từ BusinessLogic
                FoodBL foodBL = new FoodBL();
                if (foodBL.Delete(foodCurrent) > 0)
                {
                    MessageBox.Show("Xoá thực phẩm thành công");
                    LoadFoodDataToListView();
                }
                else MessageBox.Show("Xoá không thành công");
            }

        }

        private void lsvFood_Click(object sender, EventArgs e)
        {
            //Duyệt toàn bộ dữ liệu trong listView
            for (int i = 0; i < lsvFood.Items.Count; i++)
            {
                //Lấy Dòng được chọn
                if (lsvFood.Items[i].Selected)
                {
                    //gán vào các textbox
                    foodCurrent = listFood[i];
                    txtName.Text = foodCurrent.Name;
                    txtUnit.Text = foodCurrent.Unit;
                    txtPrice.Text = foodCurrent.Price.ToString();
                    txtNotes.Text = foodCurrent.Notes;
                    //lấy index của cbb theo FoodCategoryID
                    cbbCategory.SelectedIndex = listCategory.FindIndex(x => x.ID == foodCurrent.FoodCategoryID);

                }
            }
        }
    }
}
