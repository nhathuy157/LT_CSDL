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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<Category> GetCategories()
        {
            // Khởi tạo
            var dbContext = new RestaurantContext();
            // Lấy ds tất cả nhóm thức ăn và sắp xếp theo tên
            return dbContext.Categories.OrderBy(x => x.Name).ToList();
        }
        private void ShowCategories()
        {
            tvwCategory.Nodes.Clear();
            //tạo ds
            //Tên của các loại này đc hiện thị trên các nút mức 2
            var cateMap = new Dictionary<CategoryType, string>()        
            {
                [CategoryType.Food] = "Đồ Ăn",
                [CategoryType.Drink] = "Thức Uống"
                
                
            };
            // nút gốc
            var rootNode = tvwCategory.Nodes.Add("Tất cả");
            // Lấy ds nhóm đồ ăn, thức uống
            var categories = GetCategories();
            //Duyệt qua các loại nhóm món ăn
            foreach (var cateType in cateMap)
            {
                //Tạo các nút tương ứng
                var childNode = rootNode.Nodes.Add(cateType.Key.ToString(), cateType.Value);
                childNode.Tag = cateType.Key;
                //Duyệt
                foreach(var category in categories)
                {
                    //Nếu nhóm đang xét k cùng loại thì bỏ wa
                    if (category.Type != cateType.Key) continue;

                    //Ngược lại, tạo các nút tương ứng
                    var grantChildNode = childNode.Nodes.Add(category.Id.ToString(), category.Name);
                    grantChildNode.Tag = category;

                }

            }
            tvwCategory.ExpandAll();
            tvwCategory.SelectedNode = rootNode;
        }
        private List<FoodModel> GetFoodByCategory(int? categoryId)
        {
            var dbContext = new RestaurantContext();
            var foods = dbContext.Foods.AsQueryable();
            if(categoryId != null && categoryId > 0)
            {
                foods = foods.Where(x => x.FoodCategoryId == categoryId);
            }
            return foods
                .OrderBy(x => x.Name)
                .Select(x => new FoodModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Notes = x.Notes,
                    CategoryName = x.Category.Name
                })
                .ToList();
        }
        private List<FoodModel> GetFoodByCategoryType(CategoryType cateType)
        {
            var dbContext = new RestaurantContext();
            return dbContext.Foods
                .Where(x => x.Category.Type == cateType) // Tìm theo loại nhóm món ăn
                .OrderBy(x => x.Name) // Sắp xếp theo tên
                .Select(x => new FoodModel()// ds chứa đầy đủ thông tin về món ăn
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Notes = x.Notes,
                    CategoryName = x.Category.Name

                })
                .ToList();
        }
        private void ShowFoodsForNode(TreeNode node)
        {
            lvwFoods.Items.Clear();

            if (node == null) return;
            List<FoodModel> foods = null;
            if(node.Level == 1)
            {
                var categoryType = (CategoryType)node.Tag;
                foods = GetFoodByCategoryType(categoryType);
            }
            else
            {
                var category = node.Tag as Category;
                foods = GetFoodByCategory(category?.Id);
            }
            ShowFoodOnListView(foods);
        }
        private void ShowFoodOnListView(List<FoodModel> foods)
        {
            //Duyệt qua từng phần tử
            foreach(var foodItem in foods)
            {
                //tạo item 
                var item = lvwFoods.Items.Add(foodItem.Id.ToString());

                // hiển thị
                item.SubItems.Add(foodItem.Name);
                item.SubItems.Add(foodItem.Unit);
                item.SubItems.Add(foodItem.Price.ToString("##,###"));
                item.SubItems.Add(foodItem.CategoryName);
                item.SubItems.Add(foodItem.Notes);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowCategories();

        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var dialog = new UpdateCateGoryForm();
            if(dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowCategories();
            }
            
        }

        private void tvwCategory_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null || e.Node.Level < 2 || e.Node.Tag == null) return;
            var category = e.Node.Tag as Category;
            var dialog = new UpdateCateGoryForm(category?.Id);
            if(dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowCategories();
            }
        }

        private void btnReloadCategory_Click(object sender, EventArgs e)
        {
            ShowCategories();
           
        }

        private void tvwCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowFoodsForNode(e.Node);
        }

        private void btnReloadFood_Click(object sender, EventArgs e)
        {
            ShowFoodsForNode(tvwCategory.SelectedNode);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lvwFoods.SelectedItems.Count == 0) return;

            var dbContext = new RestaurantContext();
            var selectedFoodId = int.Parse(lvwFoods.SelectedItems[0].Text);
            var selectedFood = dbContext.Foods.Find(selectedFoodId);

            if(selectedFood != null)
            {
                dbContext.Foods.Remove(selectedFood);
                dbContext.SaveChanges();

                lvwFoods.Items.Remove(lvwFoods.SelectedItems[0]);
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            var dialog = new UpdateFoodForm();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowFoodsForNode(tvwCategory.SelectedNode);
            }
        }

        private void lvwFoods_DoubleClick(object sender, EventArgs e)
        {
            if (lvwFoods.SelectedItems.Count == 0) return;

            var foodId = int.Parse(lvwFoods.SelectedItems[0].Text);
            var dialog = new UpdateFoodForm(foodId);
            if(dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowFoodsForNode(tvwCategory.SelectedNode);
            }
        }
    }
}
