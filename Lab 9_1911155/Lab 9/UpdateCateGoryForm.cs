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
    public partial class UpdateCateGoryForm : Form
    {
        private RestaurantContext _dbContext;
        private int _categoryId;
        public UpdateCateGoryForm(int? categoryId = null)
        {
            InitializeComponent();

            _dbContext = new RestaurantContext();
            _categoryId = categoryId ?? 0;
        }
        private Category GetCategoryById (int categoryId)
        {
            //nếu id truyền hợp le75, ta tìm thông tin theo id
            //nếu không thì trả về null, cho biết không tìm thấy
            return categoryId > 0 ? _dbContext.Categories.Find(categoryId) : null;
        }
        private void Showcategory()
        {
            //Lấy thông tin
            var category= GetCategoryById(_categoryId);

            //Nếu không tìm thấy thì return
            if (category == null) return;
            //Nếu tìm thấy thì hiện lên form
            txtCategoryId.Text = category.Id.ToString();
            txtCategoryName.Text = category.Name.ToString();
            cbbCategoryType.SelectedIndex = (int)category.Type;

        }
        private void UpdateCateGoryForm_Load(object sender, EventArgs e)
        {
            Showcategory(); 
        }
        private Category GetUpdateCategory()
        {
            //Tạo đối tượng category đã nhập
            var category = new Category()
            {
                Name= txtCategoryName.Text.Trim(),
                Type = (CategoryType)cbbCategoryType.SelectedIndex

            };
            //Gán giá trị ID ban đầu(Cập nhật)
            if(_categoryId >0)
            {
                category.Id = _categoryId;
            }
            return category;
        }
        private bool ValidateUserInput()
        {
            //Kiểm tra tên món ăn được nhập hay chưa 
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên nhóm thức ăn không được để trống", "Thông báo");
                return false;
            }
            if(cbbCategoryType.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn loại nhóm thức ăn", "Thông báo");
                   return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Kiểm tra đầu vào 
            if(ValidateUserInput())
            {
                //Lấy thông tin
                var newCategory =   GetUpdateCategory();
                // Tìm nhóm món ăn có trong Data 
                var oldCategory = GetCategoryById(_categoryId);
                //nếu chưa có
                if(oldCategory == null)
                {
                    _dbContext.Categories.Add(newCategory);
                }
                else
                {
                    oldCategory.Name = newCategory.Name;
                    oldCategory.Type = newCategory.Type;    
                }
                _dbContext.SaveChanges();

                DialogResult = DialogResult.OK;
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
