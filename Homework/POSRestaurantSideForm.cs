using System;
using System.IO;
using System.Windows.Forms;

namespace Homework
{
    public partial class POSRestaurantSideForm : Form
    {
        private RestaurantFormMealPresentationModel _restaurantFormMealPresentationModel;
        private RestaurantFormCategoryPresentationModel _restaurantFormCategoryPresentationModel;
        const string TEXT = "Text";
        const string ENABLE = "Enabled";
        const string NAME = "Name";
        public POSRestaurantSideForm(Model model)
        {
            InitializeComponent();
            _restaurantFormMealPresentationModel = new RestaurantFormMealPresentationModel(model);
            _restaurantFormCategoryPresentationModel = new RestaurantFormCategoryPresentationModel(model);
            _mealDetailGroupBox.DataBindings.Add(TEXT, _restaurantFormMealPresentationModel, "MealGroupBoxTitle");
            _enterMealButton.DataBindings.Add(TEXT, _restaurantFormMealPresentationModel, "EnterMealButtonText");
            _enterMealButton.DataBindings.Add(ENABLE, _restaurantFormMealPresentationModel, "EnterMealEnable");
            _deleteMealButton.DataBindings.Add(ENABLE, _restaurantFormMealPresentationModel.GetModel().GetComputeModel(), "DeleteMealEnable");
            _browseButton.DataBindings.Add(ENABLE, _restaurantFormMealPresentationModel, "BrowseEnable");
            _mealNameTextBox.DataBindings.Add(ENABLE, _restaurantFormMealPresentationModel, "MealNameEnable");
            _mealPriceTextBox.DataBindings.Add(ENABLE, _restaurantFormMealPresentationModel, "MealPriceEnable");
            _categoryComboBox.DataBindings.Add(ENABLE, _restaurantFormMealPresentationModel, "CategoryComboBoxEnable");
            _imagePathTextBox.DataBindings.Add(ENABLE, _restaurantFormMealPresentationModel, "ImagePathEnable");
            _mealDescriptionTextBox.DataBindings.Add(ENABLE, _restaurantFormMealPresentationModel, "MealDescriptionEnable");
            _categoryDetailGroupBox.DataBindings.Add(TEXT, _restaurantFormCategoryPresentationModel, "CategoryGroupBoxTitle");
            _enterCategoryButton.DataBindings.Add(TEXT, _restaurantFormCategoryPresentationModel, "EnterCategoryButtonText");
            _enterCategoryButton.DataBindings.Add(ENABLE, _restaurantFormCategoryPresentationModel, "EnterCategoryEnable");
            _deleteCategoryButton.DataBindings.Add(ENABLE, _restaurantFormCategoryPresentationModel.GetModel().GetComputeModel(), "DeleteCategoryEnable");
            _categoryNameTextBox.DataBindings.Add(ENABLE, _restaurantFormCategoryPresentationModel, "CategoryNameEnable");
            _mealListBox.DataSource = _restaurantFormMealPresentationModel.GetModel().MealsList;
            _mealListBox.DisplayMember = NAME;
            _mealListBox.ClearSelected();
            _restaurantFormMealPresentationModel.GetModel().GetComputeModel().SetSelectedMealOfRestaurant(-1);
            _restaurantFormMealPresentationModel.GetModel().GetComputeModel().SetSelectedCategoryOfRestaurant(-1);
            _categoryComboBox.DataSource = _restaurantFormMealPresentationModel.GetModel().CategoriesList;
            _categoryComboBox.DisplayMember = NAME;
            _categoryListBox.DataSource = _restaurantFormCategoryPresentationModel.GetModel().CategoriesList;
            _categoryListBox.DisplayMember = NAME;
            _categoryListBox.ClearSelected();
            _mealUsingThisCategoryList.DataSource = _restaurantFormCategoryPresentationModel.GetModel().MealsUsingThisCategoryList;
            _mealUsingThisCategoryList.DisplayMember = NAME;
        }

        //進入編輯餐點模式
        private void ChangeEditMealMode(object sender, EventArgs e)
        {
            _restaurantFormMealPresentationModel.ChangeEditMealMode(_mealListBox.SelectedIndex);
            _mealNameTextBox.Text = _restaurantFormMealPresentationModel.GetMealName();
            _mealPriceTextBox.Text = _restaurantFormMealPresentationModel.GetMealPrice();
            _categoryComboBox.Text = _restaurantFormMealPresentationModel.GetMealCategory();
            _imagePathTextBox.Text = _restaurantFormMealPresentationModel.GetMealImagePath();
            _mealDescriptionTextBox.Text = _restaurantFormMealPresentationModel.GetMealDescription();
            _restaurantFormMealPresentationModel.GetModel().GetComputeModel().SetSelectedMealOfRestaurant(_mealListBox.SelectedIndex);
        }

        //進入新增餐點模式
        private void ChangeAddMealMode(object sender, EventArgs e)
        {
            _restaurantFormMealPresentationModel.ChangeAddMealMode();
            _mealNameTextBox.Text = _restaurantFormMealPresentationModel.GetMealName();
            _mealPriceTextBox.Text = _restaurantFormMealPresentationModel.GetMealPrice();
            _categoryComboBox.Text = _restaurantFormMealPresentationModel.GetMealCategory();
            _imagePathTextBox.Text = _restaurantFormMealPresentationModel.GetMealImagePath();
            _mealDescriptionTextBox.Text = _restaurantFormMealPresentationModel.GetMealDescription();
            _mealListBox.ClearSelected();
            _restaurantFormMealPresentationModel.GetModel().GetComputeModel().SetSelectedMealOfRestaurant(-1);
        }

        //瀏覽圖片位址
        private void BrowsePath(object sender, EventArgs e)
        {
            const string FILTER = "Image|*.png;*.jpg;*.jpeg";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            openFileDialog.InitialDirectory = path;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = FILTER;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
                _imagePathTextBox.Text = _restaurantFormMealPresentationModel.GetModel().GetComputeModel().TransformRelativePath(openFileDialog.FileName);
            else
                _imagePathTextBox.Text = "";
        }

        //判斷是否修改餐點數值
        public void JudgeModifyMealData(object sender, EventArgs e)
        {
            _restaurantFormMealPresentationModel.JudgeModifyData(_mealNameTextBox.Text, _mealPriceTextBox.Text, _categoryComboBox.Text, _imagePathTextBox.Text, _mealDescriptionTextBox.Text);
        }

        //判斷是否修改類別名稱
        public void JudgeModifyCategoryData(object sender, EventArgs e)
        {
            _restaurantFormCategoryPresentationModel.JudgeModifyData(_categoryNameTextBox.Text);
        }

        //儲存或新增餐點
        private void EnterMeal(object sender, EventArgs e)
        {
            const string ADD = "Add";
            _restaurantFormMealPresentationModel.SetMealName(_mealNameTextBox.Text);
            _restaurantFormMealPresentationModel.SetMealPrice(_mealPriceTextBox.Text);
            _restaurantFormMealPresentationModel.SetMealCategory(_categoryComboBox.Text);
            _restaurantFormMealPresentationModel.SetMealImagePath(_imagePathTextBox.Text);
            _restaurantFormMealPresentationModel.SetMealDescription(_mealDescriptionTextBox.Text);
            _restaurantFormMealPresentationModel.EnterMeal(_mealListBox.SelectedIndex);
            if (((Button)sender).Text == ADD)
            {
                MealBindingManager.Position = MealBindingManager.Count - 1;
                _restaurantFormMealPresentationModel.ChangeEditMealMode(_mealListBox.SelectedIndex);
            }    
        }

        //刪除餐點
        private void DeleteMeal(object sender, EventArgs e)
        {
            _restaurantFormMealPresentationModel.GetModel().DeleteMeal(_mealListBox.SelectedIndex);
            _restaurantFormMealPresentationModel.ClearMealData();
            _mealNameTextBox.Text = _restaurantFormMealPresentationModel.GetMealName();
            _mealPriceTextBox.Text = _restaurantFormMealPresentationModel.GetMealPrice();
            _categoryComboBox.Text = _restaurantFormMealPresentationModel.GetMealCategory();
            _imagePathTextBox.Text = _restaurantFormMealPresentationModel.GetMealImagePath();
            _mealDescriptionTextBox.Text = _restaurantFormMealPresentationModel.GetMealDescription();
            _mealListBox.ClearSelected();
            _restaurantFormMealPresentationModel.GetModel().GetComputeModel().SetSelectedMealOfRestaurant(-1);
        }

        //進入編輯類別模式
        private void ChangeEditCategoryMode(object sender, EventArgs e)
        {
            _restaurantFormCategoryPresentationModel.ChangeEditCategoryMode(_categoryListBox.SelectedIndex);
            _categoryNameTextBox.Text = _restaurantFormCategoryPresentationModel.GetCategoryName();
            _restaurantFormMealPresentationModel.GetModel().GetComputeModel().SetSelectedCategoryOfRestaurant(_categoryListBox.SelectedIndex);
        }

        //進入新增類別模式
        private void ChangeAddCategoryMode(object sender, EventArgs e)
        {
            _restaurantFormCategoryPresentationModel.ChangeAddCategoryMode();
            _categoryNameTextBox.Text = _restaurantFormCategoryPresentationModel.GetCategoryName();
            _categoryListBox.ClearSelected();
            _restaurantFormMealPresentationModel.GetModel().GetComputeModel().SetSelectedCategoryOfRestaurant(-1);
        }

        //儲存或新增類別
        private void EnterCategory(object sender, EventArgs e)
        {
            const string ADD = "Add";
            _restaurantFormCategoryPresentationModel.SetCategoryName(_categoryNameTextBox.Text);
            _restaurantFormCategoryPresentationModel.EnterCategory(_categoryListBox.SelectedIndex);
            if (((Button)sender).Text == ADD)
            {
                CategoryBindingManager.Position = CategoryBindingManager.Count - 1;
                _restaurantFormCategoryPresentationModel.ChangeEditCategoryMode(_categoryListBox.SelectedIndex);
            }   
        }

        //刪除類別
        private void DeleteCategory(object sender, EventArgs e)
        {
            _restaurantFormCategoryPresentationModel.GetModel().DeleteCategory(_categoryListBox.SelectedIndex);
            _restaurantFormCategoryPresentationModel.ClearCategoryData();
            _categoryNameTextBox.Text = _restaurantFormCategoryPresentationModel.GetCategoryName();
            _categoryListBox.ClearSelected();
            _restaurantFormMealPresentationModel.GetModel().GetComputeModel().SetSelectedCategoryOfRestaurant(-1);
        }

        //改變TabPage
        public void ChangeTabPage(object sender, EventArgs e)
        {
            _mealListBox.ClearSelected();
            _restaurantFormMealPresentationModel.GetModel().GetComputeModel().SetSelectedMealOfRestaurant(-1);
            _restaurantFormMealPresentationModel.GetModel().GetComputeModel().SetDeleteMealEnable(false);
            ResetSelectedMeal();
            _restaurantFormMealPresentationModel.ClearMealData();
            _mealNameTextBox.Text = _restaurantFormMealPresentationModel.GetMealName();
            _mealPriceTextBox.Text = _restaurantFormMealPresentationModel.GetMealPrice();
            _categoryComboBox.Text = _restaurantFormMealPresentationModel.GetMealCategory();
            _imagePathTextBox.Text = _restaurantFormMealPresentationModel.GetMealImagePath();
            _mealDescriptionTextBox.Text = _restaurantFormMealPresentationModel.GetMealDescription();
            _categoryListBox.ClearSelected();
            _restaurantFormMealPresentationModel.GetModel().GetComputeModel().SetSelectedCategoryOfRestaurant(-1);
            _restaurantFormCategoryPresentationModel.GetModel().GetComputeModel().SetDeleteCategoryEnable(false);
            _restaurantFormCategoryPresentationModel.ClearCategoryData();
            _categoryNameTextBox.Text = _restaurantFormCategoryPresentationModel.GetCategoryName();
        }

        //重設選擇的餐點
        public void ResetSelectedMeal()
        {
            try
            {
                _categoryComboBox.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        //餐點資料連結管理
        private BindingManagerBase MealBindingManager
        {
            get
            {
                return BindingContext[_restaurantFormMealPresentationModel.GetModel().MealsList];
            }
        }

        //類別資料連結管理
        private BindingManagerBase CategoryBindingManager
        {
            get
            {
                return BindingContext[_restaurantFormCategoryPresentationModel.GetModel().CategoriesList];
            }
        }
    }
}
