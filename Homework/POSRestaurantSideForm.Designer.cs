namespace Homework
{
    partial class POSRestaurantSideForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tabControl = new System.Windows.Forms.TabControl();
            this._manageMealTabPage = new System.Windows.Forms.TabPage();
            this._mealDetailGroupBox = new System.Windows.Forms.GroupBox();
            this._enterMealButton = new System.Windows.Forms.Button();
            this._mealDescriptionTextBox = new System.Windows.Forms.TextBox();
            this._mealDescriptionLabel = new System.Windows.Forms.Label();
            this._browseButton = new System.Windows.Forms.Button();
            this._imagePathTextBox = new System.Windows.Forms.TextBox();
            this._imagePathLabel = new System.Windows.Forms.Label();
            this._categoryComboBox = new System.Windows.Forms.ComboBox();
            this._mealCategoryLabel = new System.Windows.Forms.Label();
            this._unitLabel = new System.Windows.Forms.Label();
            this._mealPriceTextBox = new System.Windows.Forms.TextBox();
            this._mealPriceLabel = new System.Windows.Forms.Label();
            this._mealNameTextBox = new System.Windows.Forms.TextBox();
            this._mealNameLabel = new System.Windows.Forms.Label();
            this._deleteMealButton = new System.Windows.Forms.Button();
            this._addMealButton = new System.Windows.Forms.Button();
            this._mealListBox = new System.Windows.Forms.ListBox();
            this._manageCategoryTabPage = new System.Windows.Forms.TabPage();
            this._categoryDetailGroupBox = new System.Windows.Forms.GroupBox();
            this._enterCategoryButton = new System.Windows.Forms.Button();
            this._mealUsingThisCategoryList = new System.Windows.Forms.ListBox();
            this._mealUsingThisCategoryLabel = new System.Windows.Forms.Label();
            this._categoryNameTextBox = new System.Windows.Forms.TextBox();
            this._categoryNameLabel = new System.Windows.Forms.Label();
            this._deleteCategoryButton = new System.Windows.Forms.Button();
            this._addCategoryButton = new System.Windows.Forms.Button();
            this._categoryListBox = new System.Windows.Forms.ListBox();
            this._tabControl.SuspendLayout();
            this._manageMealTabPage.SuspendLayout();
            this._mealDetailGroupBox.SuspendLayout();
            this._manageCategoryTabPage.SuspendLayout();
            this._categoryDetailGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._manageMealTabPage);
            this._tabControl.Controls.Add(this._manageCategoryTabPage);
            this._tabControl.Location = new System.Drawing.Point(9, 10);
            this._tabControl.Margin = new System.Windows.Forms.Padding(2);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(681, 349);
            this._tabControl.TabIndex = 0;
            this._tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.ChangeTabPage);
            // 
            // _manageMealTabPage
            // 
            this._manageMealTabPage.Controls.Add(this._mealDetailGroupBox);
            this._manageMealTabPage.Controls.Add(this._deleteMealButton);
            this._manageMealTabPage.Controls.Add(this._addMealButton);
            this._manageMealTabPage.Controls.Add(this._mealListBox);
            this._manageMealTabPage.Location = new System.Drawing.Point(4, 22);
            this._manageMealTabPage.Margin = new System.Windows.Forms.Padding(2);
            this._manageMealTabPage.Name = "_manageMealTabPage";
            this._manageMealTabPage.Padding = new System.Windows.Forms.Padding(2);
            this._manageMealTabPage.Size = new System.Drawing.Size(673, 323);
            this._manageMealTabPage.TabIndex = 0;
            this._manageMealTabPage.Text = "Meal Manager";
            this._manageMealTabPage.UseVisualStyleBackColor = true;
            // 
            // _mealDetailGroupBox
            // 
            this._mealDetailGroupBox.Controls.Add(this._enterMealButton);
            this._mealDetailGroupBox.Controls.Add(this._mealDescriptionTextBox);
            this._mealDetailGroupBox.Controls.Add(this._mealDescriptionLabel);
            this._mealDetailGroupBox.Controls.Add(this._browseButton);
            this._mealDetailGroupBox.Controls.Add(this._imagePathTextBox);
            this._mealDetailGroupBox.Controls.Add(this._imagePathLabel);
            this._mealDetailGroupBox.Controls.Add(this._categoryComboBox);
            this._mealDetailGroupBox.Controls.Add(this._mealCategoryLabel);
            this._mealDetailGroupBox.Controls.Add(this._unitLabel);
            this._mealDetailGroupBox.Controls.Add(this._mealPriceTextBox);
            this._mealDetailGroupBox.Controls.Add(this._mealPriceLabel);
            this._mealDetailGroupBox.Controls.Add(this._mealNameTextBox);
            this._mealDetailGroupBox.Controls.Add(this._mealNameLabel);
            this._mealDetailGroupBox.Location = new System.Drawing.Point(270, 6);
            this._mealDetailGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this._mealDetailGroupBox.Name = "_mealDetailGroupBox";
            this._mealDetailGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this._mealDetailGroupBox.Size = new System.Drawing.Size(400, 314);
            this._mealDetailGroupBox.TabIndex = 3;
            this._mealDetailGroupBox.TabStop = false;
            this._mealDetailGroupBox.Text = "groupBox1";
            // 
            // _enterMealButton
            // 
            this._enterMealButton.Location = new System.Drawing.Point(340, 285);
            this._enterMealButton.Margin = new System.Windows.Forms.Padding(2);
            this._enterMealButton.Name = "_enterMealButton";
            this._enterMealButton.Size = new System.Drawing.Size(56, 24);
            this._enterMealButton.TabIndex = 12;
            this._enterMealButton.Text = "button1";
            this._enterMealButton.UseVisualStyleBackColor = true;
            this._enterMealButton.Click += new System.EventHandler(this.EnterMeal);
            // 
            // _mealDescriptionTextBox
            // 
            this._mealDescriptionTextBox.AccessibleName = "_mealDescriptionTextBox";
            this._mealDescriptionTextBox.Enabled = false;
            this._mealDescriptionTextBox.Location = new System.Drawing.Point(4, 141);
            this._mealDescriptionTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._mealDescriptionTextBox.Multiline = true;
            this._mealDescriptionTextBox.Name = "_mealDescriptionTextBox";
            this._mealDescriptionTextBox.Size = new System.Drawing.Size(392, 135);
            this._mealDescriptionTextBox.TabIndex = 11;
            this._mealDescriptionTextBox.TextChanged += new System.EventHandler(this.JudgeModifyMealData);
            // 
            // _mealDescriptionLabel
            // 
            this._mealDescriptionLabel.AutoSize = true;
            this._mealDescriptionLabel.Location = new System.Drawing.Point(4, 125);
            this._mealDescriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._mealDescriptionLabel.Name = "_mealDescriptionLabel";
            this._mealDescriptionLabel.Size = new System.Drawing.Size(86, 13);
            this._mealDescriptionLabel.TabIndex = 10;
            this._mealDescriptionLabel.Text = "Meal Description";
            // 
            // _browseButton
            // 
            this._browseButton.Enabled = false;
            this._browseButton.Location = new System.Drawing.Point(340, 87);
            this._browseButton.Margin = new System.Windows.Forms.Padding(2);
            this._browseButton.Name = "_browseButton";
            this._browseButton.Size = new System.Drawing.Size(56, 24);
            this._browseButton.TabIndex = 9;
            this._browseButton.Text = "Browse";
            this._browseButton.UseVisualStyleBackColor = true;
            this._browseButton.Click += new System.EventHandler(this.BrowsePath);
            // 
            // _imagePathTextBox
            // 
            this._imagePathTextBox.AccessibleName = "_imagePathTextBox";
            this._imagePathTextBox.Enabled = false;
            this._imagePathTextBox.Location = new System.Drawing.Point(149, 90);
            this._imagePathTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._imagePathTextBox.Name = "_imagePathTextBox";
            this._imagePathTextBox.Size = new System.Drawing.Size(187, 20);
            this._imagePathTextBox.TabIndex = 8;
            this._imagePathTextBox.TextChanged += new System.EventHandler(this.JudgeModifyMealData);
            // 
            // _imagePathLabel
            // 
            this._imagePathLabel.AutoSize = true;
            this._imagePathLabel.Location = new System.Drawing.Point(4, 93);
            this._imagePathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._imagePathLabel.Name = "_imagePathLabel";
            this._imagePathLabel.Size = new System.Drawing.Size(142, 13);
            this._imagePathLabel.TabIndex = 7;
            this._imagePathLabel.Text = "Meal Image Relative Path (*)";
            // 
            // _categoryComboBox
            // 
            this._categoryComboBox.AccessibleName = "_categoryComboBox";
            this._categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._categoryComboBox.Enabled = false;
            this._categoryComboBox.FormattingEnabled = true;
            this._categoryComboBox.Location = new System.Drawing.Point(305, 58);
            this._categoryComboBox.Margin = new System.Windows.Forms.Padding(2);
            this._categoryComboBox.Name = "_categoryComboBox";
            this._categoryComboBox.Size = new System.Drawing.Size(92, 21);
            this._categoryComboBox.TabIndex = 6;
            this._categoryComboBox.TextChanged += new System.EventHandler(this.JudgeModifyMealData);
            // 
            // _mealCategoryLabel
            // 
            this._mealCategoryLabel.AutoSize = true;
            this._mealCategoryLabel.Location = new System.Drawing.Point(212, 60);
            this._mealCategoryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._mealCategoryLabel.Name = "_mealCategoryLabel";
            this._mealCategoryLabel.Size = new System.Drawing.Size(88, 13);
            this._mealCategoryLabel.TabIndex = 5;
            this._mealCategoryLabel.Text = "Meal Category (*)";
            // 
            // _unitLabel
            // 
            this._unitLabel.AutoSize = true;
            this._unitLabel.Location = new System.Drawing.Point(181, 60);
            this._unitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._unitLabel.Name = "_unitLabel";
            this._unitLabel.Size = new System.Drawing.Size(19, 13);
            this._unitLabel.TabIndex = 4;
            this._unitLabel.Text = "元";
            // 
            // _mealPriceTextBox
            // 
            this._mealPriceTextBox.AccessibleName = "_mealPriceTextBox";
            this._mealPriceTextBox.Enabled = false;
            this._mealPriceTextBox.Location = new System.Drawing.Point(79, 58);
            this._mealPriceTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._mealPriceTextBox.Name = "_mealPriceTextBox";
            this._mealPriceTextBox.Size = new System.Drawing.Size(98, 20);
            this._mealPriceTextBox.TabIndex = 3;
            this._mealPriceTextBox.TextChanged += new System.EventHandler(this.JudgeModifyMealData);
            // 
            // _mealPriceLabel
            // 
            this._mealPriceLabel.AutoSize = true;
            this._mealPriceLabel.Location = new System.Drawing.Point(4, 60);
            this._mealPriceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._mealPriceLabel.Name = "_mealPriceLabel";
            this._mealPriceLabel.Size = new System.Drawing.Size(70, 13);
            this._mealPriceLabel.TabIndex = 2;
            this._mealPriceLabel.Text = "Meal Price (*)";
            // 
            // _mealNameTextBox
            // 
            this._mealNameTextBox.AccessibleName = "_mealNameTextBox";
            this._mealNameTextBox.Enabled = false;
            this._mealNameTextBox.Location = new System.Drawing.Point(82, 25);
            this._mealNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._mealNameTextBox.Name = "_mealNameTextBox";
            this._mealNameTextBox.Size = new System.Drawing.Size(314, 20);
            this._mealNameTextBox.TabIndex = 1;
            this._mealNameTextBox.TextChanged += new System.EventHandler(this.JudgeModifyMealData);
            // 
            // _mealNameLabel
            // 
            this._mealNameLabel.AutoSize = true;
            this._mealNameLabel.Location = new System.Drawing.Point(4, 28);
            this._mealNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._mealNameLabel.Name = "_mealNameLabel";
            this._mealNameLabel.Size = new System.Drawing.Size(74, 13);
            this._mealNameLabel.TabIndex = 0;
            this._mealNameLabel.Text = "Meal Name (*)";
            // 
            // _deleteMealButton
            // 
            this._deleteMealButton.Enabled = false;
            this._deleteMealButton.Location = new System.Drawing.Point(146, 296);
            this._deleteMealButton.Margin = new System.Windows.Forms.Padding(2);
            this._deleteMealButton.Name = "_deleteMealButton";
            this._deleteMealButton.Size = new System.Drawing.Size(120, 24);
            this._deleteMealButton.TabIndex = 2;
            this._deleteMealButton.Text = "Delete Selected Meal";
            this._deleteMealButton.UseVisualStyleBackColor = true;
            this._deleteMealButton.Click += new System.EventHandler(this.DeleteMeal);
            // 
            // _addMealButton
            // 
            this._addMealButton.Location = new System.Drawing.Point(4, 296);
            this._addMealButton.Margin = new System.Windows.Forms.Padding(2);
            this._addMealButton.Name = "_addMealButton";
            this._addMealButton.Size = new System.Drawing.Size(112, 24);
            this._addMealButton.TabIndex = 1;
            this._addMealButton.Text = "Add New Meal";
            this._addMealButton.UseVisualStyleBackColor = true;
            this._addMealButton.Click += new System.EventHandler(this.ChangeAddMealMode);
            // 
            // _mealListBox
            // 
            this._mealListBox.AccessibleName = "_mealListBox";
            this._mealListBox.FormattingEnabled = true;
            this._mealListBox.Location = new System.Drawing.Point(4, 5);
            this._mealListBox.Margin = new System.Windows.Forms.Padding(2);
            this._mealListBox.Name = "_mealListBox";
            this._mealListBox.Size = new System.Drawing.Size(261, 277);
            this._mealListBox.TabIndex = 0;
            this._mealListBox.Click += new System.EventHandler(this.ChangeEditMealMode);
            // 
            // _manageCategoryTabPage
            // 
            this._manageCategoryTabPage.Controls.Add(this._categoryDetailGroupBox);
            this._manageCategoryTabPage.Controls.Add(this._deleteCategoryButton);
            this._manageCategoryTabPage.Controls.Add(this._addCategoryButton);
            this._manageCategoryTabPage.Controls.Add(this._categoryListBox);
            this._manageCategoryTabPage.Location = new System.Drawing.Point(4, 22);
            this._manageCategoryTabPage.Margin = new System.Windows.Forms.Padding(2);
            this._manageCategoryTabPage.Name = "_manageCategoryTabPage";
            this._manageCategoryTabPage.Padding = new System.Windows.Forms.Padding(2);
            this._manageCategoryTabPage.Size = new System.Drawing.Size(673, 323);
            this._manageCategoryTabPage.TabIndex = 1;
            this._manageCategoryTabPage.Text = "Category Manager";
            this._manageCategoryTabPage.UseVisualStyleBackColor = true;
            // 
            // _categoryDetailGroupBox
            // 
            this._categoryDetailGroupBox.Controls.Add(this._enterCategoryButton);
            this._categoryDetailGroupBox.Controls.Add(this._mealUsingThisCategoryList);
            this._categoryDetailGroupBox.Controls.Add(this._mealUsingThisCategoryLabel);
            this._categoryDetailGroupBox.Controls.Add(this._categoryNameTextBox);
            this._categoryDetailGroupBox.Controls.Add(this._categoryNameLabel);
            this._categoryDetailGroupBox.Location = new System.Drawing.Point(270, 6);
            this._categoryDetailGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this._categoryDetailGroupBox.Name = "_categoryDetailGroupBox";
            this._categoryDetailGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this._categoryDetailGroupBox.Size = new System.Drawing.Size(400, 314);
            this._categoryDetailGroupBox.TabIndex = 4;
            this._categoryDetailGroupBox.TabStop = false;
            this._categoryDetailGroupBox.Text = "groupBox1";
            // 
            // _enterCategoryButton
            // 
            this._enterCategoryButton.Location = new System.Drawing.Point(340, 285);
            this._enterCategoryButton.Margin = new System.Windows.Forms.Padding(2);
            this._enterCategoryButton.Name = "_enterCategoryButton";
            this._enterCategoryButton.Size = new System.Drawing.Size(56, 24);
            this._enterCategoryButton.TabIndex = 4;
            this._enterCategoryButton.Text = "button1";
            this._enterCategoryButton.UseVisualStyleBackColor = true;
            this._enterCategoryButton.Click += new System.EventHandler(this.EnterCategory);
            // 
            // _mealUsingThisCategoryList
            // 
            this._mealUsingThisCategoryList.FormattingEnabled = true;
            this._mealUsingThisCategoryList.Location = new System.Drawing.Point(7, 77);
            this._mealUsingThisCategoryList.Margin = new System.Windows.Forms.Padding(2);
            this._mealUsingThisCategoryList.Name = "_mealUsingThisCategoryList";
            this._mealUsingThisCategoryList.Size = new System.Drawing.Size(390, 199);
            this._mealUsingThisCategoryList.TabIndex = 3;
            // 
            // _mealUsingThisCategoryLabel
            // 
            this._mealUsingThisCategoryLabel.AutoSize = true;
            this._mealUsingThisCategoryLabel.Location = new System.Drawing.Point(4, 60);
            this._mealUsingThisCategoryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._mealUsingThisCategoryLabel.Name = "_mealUsingThisCategoryLabel";
            this._mealUsingThisCategoryLabel.Size = new System.Drawing.Size(135, 13);
            this._mealUsingThisCategoryLabel.TabIndex = 2;
            this._mealUsingThisCategoryLabel.Text = "Meal(s) Using this Category";
            // 
            // _categoryNameTextBox
            // 
            this._categoryNameTextBox.AccessibleName = "_categoryNameTextBox";
            this._categoryNameTextBox.Enabled = false;
            this._categoryNameTextBox.Location = new System.Drawing.Point(103, 25);
            this._categoryNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._categoryNameTextBox.Name = "_categoryNameTextBox";
            this._categoryNameTextBox.Size = new System.Drawing.Size(294, 20);
            this._categoryNameTextBox.TabIndex = 1;
            this._categoryNameTextBox.TextChanged += new System.EventHandler(this.JudgeModifyCategoryData);
            // 
            // _categoryNameLabel
            // 
            this._categoryNameLabel.AutoSize = true;
            this._categoryNameLabel.Location = new System.Drawing.Point(4, 28);
            this._categoryNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._categoryNameLabel.Name = "_categoryNameLabel";
            this._categoryNameLabel.Size = new System.Drawing.Size(93, 13);
            this._categoryNameLabel.TabIndex = 0;
            this._categoryNameLabel.Text = "Category Name (*)";
            // 
            // _deleteCategoryButton
            // 
            this._deleteCategoryButton.Enabled = false;
            this._deleteCategoryButton.Location = new System.Drawing.Point(127, 296);
            this._deleteCategoryButton.Margin = new System.Windows.Forms.Padding(2);
            this._deleteCategoryButton.Name = "_deleteCategoryButton";
            this._deleteCategoryButton.Size = new System.Drawing.Size(139, 24);
            this._deleteCategoryButton.TabIndex = 3;
            this._deleteCategoryButton.Text = "Delete Selected Category";
            this._deleteCategoryButton.UseVisualStyleBackColor = true;
            this._deleteCategoryButton.Click += new System.EventHandler(this.DeleteCategory);
            // 
            // _addCategoryButton
            // 
            this._addCategoryButton.Location = new System.Drawing.Point(4, 296);
            this._addCategoryButton.Margin = new System.Windows.Forms.Padding(2);
            this._addCategoryButton.Name = "_addCategoryButton";
            this._addCategoryButton.Size = new System.Drawing.Size(112, 24);
            this._addCategoryButton.TabIndex = 2;
            this._addCategoryButton.Text = "Add New Category";
            this._addCategoryButton.UseVisualStyleBackColor = true;
            this._addCategoryButton.Click += new System.EventHandler(this.ChangeAddCategoryMode);
            // 
            // _categoryListBox
            // 
            this._categoryListBox.AccessibleName = "_categoryListBox";
            this._categoryListBox.FormattingEnabled = true;
            this._categoryListBox.Location = new System.Drawing.Point(4, 5);
            this._categoryListBox.Margin = new System.Windows.Forms.Padding(2);
            this._categoryListBox.Name = "_categoryListBox";
            this._categoryListBox.Size = new System.Drawing.Size(261, 277);
            this._categoryListBox.TabIndex = 0;
            this._categoryListBox.Click += new System.EventHandler(this.ChangeEditCategoryMode);
            // 
            // POSRestaurantSideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 368);
            this.Controls.Add(this._tabControl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "POSRestaurantSideForm";
            this.Text = "POS-Restaurant Side";
            this._tabControl.ResumeLayout(false);
            this._manageMealTabPage.ResumeLayout(false);
            this._mealDetailGroupBox.ResumeLayout(false);
            this._mealDetailGroupBox.PerformLayout();
            this._manageCategoryTabPage.ResumeLayout(false);
            this._categoryDetailGroupBox.ResumeLayout(false);
            this._categoryDetailGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _manageMealTabPage;
        private System.Windows.Forms.GroupBox _mealDetailGroupBox;
        private System.Windows.Forms.Label _mealNameLabel;
        private System.Windows.Forms.Button _deleteMealButton;
        private System.Windows.Forms.Button _addMealButton;
        private System.Windows.Forms.ListBox _mealListBox;
        private System.Windows.Forms.TabPage _manageCategoryTabPage;
        private System.Windows.Forms.Button _enterMealButton;
        private System.Windows.Forms.TextBox _mealDescriptionTextBox;
        private System.Windows.Forms.Label _mealDescriptionLabel;
        private System.Windows.Forms.Button _browseButton;
        private System.Windows.Forms.TextBox _imagePathTextBox;
        private System.Windows.Forms.Label _imagePathLabel;
        private System.Windows.Forms.ComboBox _categoryComboBox;
        private System.Windows.Forms.Label _mealCategoryLabel;
        private System.Windows.Forms.Label _unitLabel;
        private System.Windows.Forms.TextBox _mealPriceTextBox;
        private System.Windows.Forms.Label _mealPriceLabel;
        private System.Windows.Forms.TextBox _mealNameTextBox;
        private System.Windows.Forms.ListBox _categoryListBox;
        private System.Windows.Forms.GroupBox _categoryDetailGroupBox;
        private System.Windows.Forms.Button _enterCategoryButton;
        private System.Windows.Forms.ListBox _mealUsingThisCategoryList;
        private System.Windows.Forms.Label _mealUsingThisCategoryLabel;
        private System.Windows.Forms.TextBox _categoryNameTextBox;
        private System.Windows.Forms.Label _categoryNameLabel;
        private System.Windows.Forms.Button _deleteCategoryButton;
        private System.Windows.Forms.Button _addCategoryButton;
    }
}