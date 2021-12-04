using Lab_9.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_9
{
    public partial class UpdateFoodForm : Form
    {
        private RestaurantContext _dbContext;
        private int _foodId;
        public UpdateFoodForm(int? foodId = null)
        {
            _dbContext = new RestaurantContext();
            _foodId = foodId ?? 0;
            InitializeComponent();
        }
        private void LoadCategoriesToCbb()
        {
            //Lấy danh mục thức ăn và sắp xếp tăng theo tên
            var categories = _dbContext.Categories
                .OrderBy(x => x.Name).ToList();
            //Nạp danh mục vào cbb, hiển thị cho người dùng Name, lấy giá trị thì lấy ID
            cbbFoodCategory.DisplayMember = "Name";
            cbbFoodCategory.ValueMember = "Id";
            cbbFoodCategory.DataSource = categories;
        }
        private Food GetFoodById(int foodId)
        {
            //Tìm món ăn theo mã số
            return foodId > 0? _dbContext.Foods.Find(foodId) : null;
        }
        private void ShowFoodInFor()
        {
            //Tìm món ăn theo mã số đã được truyền vào form
            var food = GetFoodById(_foodId);

            if (food == null) return;

            txtFoodId.Text = food.Id.ToString();
            txtFoodName.Text = food.Name;
            cbbFoodCategory.SelectedValue = food.FoodCategoryId;
            txtUnit.Text = food.Unit;
            nudFoodFrice.Value = food.Price;
            txtNotes.Text = food.Notes;
        }
        private bool ValidateUserInput()
        {
            if(string.IsNullOrWhiteSpace(txtFoodName.Text))
            {
                MessageBox.Show("Tên món ăn, đồng uống không được để trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                MessageBox.Show("Giá món ăn, đồng uống không được để trống", "Thông báo");
                return false;

            }
            if (nudFoodFrice.Value.Equals("0"))
            {
                MessageBox.Show("Giá món ăn, đồng uống phải lớn hơn 0", "Thông báo");
                return false;

            }
            if(cbbFoodCategory.SelectedIndex < 0)
            {

                MessageBox.Show("Bạn chưa chọn nhóm món ăn", "Thông báo");
                return false;
            }
            return true;
        }
        private Food GetUpdateFood()
        {
            var food = new Food()
            {
                Name = txtFoodName.Text.Trim(),
                FoodCategoryId = (int)cbbFoodCategory.SelectedValue,
                Unit = txtUnit.Text,
                Price = (int)nudFoodFrice.Value,
                Notes = txtNotes.Text
            };
            if(_foodId > 0)
            {
                food.Id = _foodId;
            }
            return food;
        }

        private void UpdateFoodForm_Load(object sender, EventArgs e)
        {
            LoadCategoriesToCbb();
            ShowFoodInFor();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUserInput())
            {
                var newFood = GetUpdateFood();

                var oldFood = GetFoodById(_foodId);

                if (oldFood == null)
                {
                    _dbContext.Foods.Add(newFood);
                }
                else
                {
                    oldFood.Name = newFood.Name;
                    oldFood.FoodCategoryId = newFood.FoodCategoryId;
                    oldFood.Unit = newFood.Unit;
                    oldFood.Price = newFood.Price;
                    oldFood.Notes = newFood.Notes;
                }
                _dbContext.SaveChanges();
                DialogResult = DialogResult.OK; 
            }
            
        }
    }
}
