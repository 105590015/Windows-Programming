namespace Homework
{
    partial class POSCustomerSideForm
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
            this.components = new System.ComponentModel.Container();
            this._mealGroupBox = new System.Windows.Forms.GroupBox();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._descriptionPanel = new System.Windows.Forms.Panel();
            this._descriptionBox = new System.Windows.Forms.RichTextBox();
            this._addButton = new System.Windows.Forms.Button();
            this._nextButton = new System.Windows.Forms.Button();
            this._previousButton = new System.Windows.Forms.Button();
            this._pageLabel = new System.Windows.Forms.Label();
            this._totalPriceLabel = new System.Windows.Forms.Label();
            this._checkDataGridView = new System.Windows.Forms.DataGridView();
            this._deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._quantityDataGridViewTextBoxColumn = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this._subtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._orderListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._modelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._mealGroupBox.SuspendLayout();
            this._descriptionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._checkDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._orderListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._modelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _mealGroupBox
            // 
            this._mealGroupBox.Controls.Add(this._tabControl);
            this._mealGroupBox.Controls.Add(this._descriptionPanel);
            this._mealGroupBox.Controls.Add(this._addButton);
            this._mealGroupBox.Controls.Add(this._nextButton);
            this._mealGroupBox.Controls.Add(this._previousButton);
            this._mealGroupBox.Controls.Add(this._pageLabel);
            this._mealGroupBox.Location = new System.Drawing.Point(9, 10);
            this._mealGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._mealGroupBox.Name = "_mealGroupBox";
            this._mealGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._mealGroupBox.Size = new System.Drawing.Size(304, 414);
            this._mealGroupBox.TabIndex = 16;
            this._mealGroupBox.TabStop = false;
            this._mealGroupBox.Text = "Meals";
            // 
            // _tabControl
            // 
            this._tabControl.Location = new System.Drawing.Point(4, 17);
            this._tabControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(296, 285);
            this._tabControl.TabIndex = 16;
            this._tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.ChangeTabPage);
            // 
            // _descriptionPanel
            // 
            this._descriptionPanel.AccessibleName = "";
            this._descriptionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._descriptionPanel.Controls.Add(this._descriptionBox);
            this._descriptionPanel.Location = new System.Drawing.Point(4, 306);
            this._descriptionPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._descriptionPanel.Name = "_descriptionPanel";
            this._descriptionPanel.Size = new System.Drawing.Size(297, 52);
            this._descriptionPanel.TabIndex = 15;
            // 
            // _descriptionBox
            // 
            this._descriptionBox.AccessibleDescription = "";
            this._descriptionBox.AccessibleName = "_descriptionBox";
            this._descriptionBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._descriptionBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._descriptionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._descriptionBox.Location = new System.Drawing.Point(0, 0);
            this._descriptionBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._descriptionBox.Name = "_descriptionBox";
            this._descriptionBox.ReadOnly = true;
            this._descriptionBox.Size = new System.Drawing.Size(295, 50);
            this._descriptionBox.TabIndex = 14;
            this._descriptionBox.Text = "";
            // 
            // _addButton
            // 
            this._addButton.Enabled = false;
            this._addButton.Location = new System.Drawing.Point(214, 363);
            this._addButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(86, 20);
            this._addButton.TabIndex = 12;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.ClickAddButton);
            // 
            // _nextButton
            // 
            this._nextButton.Location = new System.Drawing.Point(214, 388);
            this._nextButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._nextButton.Name = "_nextButton";
            this._nextButton.Size = new System.Drawing.Size(86, 20);
            this._nextButton.TabIndex = 11;
            this._nextButton.Text = "Next Page";
            this._nextButton.UseVisualStyleBackColor = true;
            this._nextButton.Click += new System.EventHandler(this.ClickChangedPageButton);
            // 
            // _previousButton
            // 
            this._previousButton.Enabled = false;
            this._previousButton.Location = new System.Drawing.Point(123, 388);
            this._previousButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._previousButton.Name = "_previousButton";
            this._previousButton.Size = new System.Drawing.Size(86, 20);
            this._previousButton.TabIndex = 9;
            this._previousButton.Text = "Previous Page";
            this._previousButton.UseVisualStyleBackColor = true;
            this._previousButton.Click += new System.EventHandler(this.ClickChangedPageButton);
            // 
            // _pageLabel
            // 
            this._pageLabel.AccessibleName = "_pageLabel";
            this._pageLabel.AutoSize = true;
            this._pageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this._pageLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this._pageLabel.Location = new System.Drawing.Point(4, 389);
            this._pageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._pageLabel.Name = "_pageLabel";
            this._pageLabel.Size = new System.Drawing.Size(55, 17);
            this._pageLabel.TabIndex = 13;
            this._pageLabel.Text = "Page：";
            // 
            // _totalPriceLabel
            // 
            this._totalPriceLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 20F);
            this._totalPriceLabel.ForeColor = System.Drawing.Color.DarkRed;
            this._totalPriceLabel.Location = new System.Drawing.Point(317, 391);
            this._totalPriceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._totalPriceLabel.Name = "_totalPriceLabel";
            this._totalPriceLabel.Size = new System.Drawing.Size(410, 35);
            this._totalPriceLabel.TabIndex = 14;
            this._totalPriceLabel.Text = "Total：0元";
            this._totalPriceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _checkDataGridView
            // 
            this._checkDataGridView.AccessibleDescription = "";
            this._checkDataGridView.AccessibleName = "_checkDataGridView";
            this._checkDataGridView.AllowUserToAddRows = false;
            this._checkDataGridView.AllowUserToResizeColumns = false;
            this._checkDataGridView.AllowUserToResizeRows = false;
            this._checkDataGridView.AutoGenerateColumns = false;
            this._checkDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._checkDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteColumn,
            this._nameDataGridViewTextBoxColumn,
            this._categoryDataGridViewTextBoxColumn,
            this._priceDataGridViewTextBoxColumn,
            this._quantityDataGridViewTextBoxColumn,
            this._subtotalDataGridViewTextBoxColumn});
            this._checkDataGridView.DataSource = this._orderListBindingSource;
            this._checkDataGridView.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this._checkDataGridView.Location = new System.Drawing.Point(317, 10);
            this._checkDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._checkDataGridView.Name = "_checkDataGridView";
            this._checkDataGridView.RowHeadersVisible = false;
            this._checkDataGridView.RowTemplate.Height = 24;
            this._checkDataGridView.Size = new System.Drawing.Size(410, 379);
            this._checkDataGridView.TabIndex = 15;
            this._checkDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDelete);
            this._checkDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.RefreshTotalPrice);
            // 
            // _deleteColumn
            // 
            this._deleteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._deleteColumn.FillWeight = 80F;
            this._deleteColumn.HeaderText = "Delete";
            this._deleteColumn.Name = "_deleteColumn";
            this._deleteColumn.Text = "X";
            this._deleteColumn.UseColumnTextForButtonValue = true;
            // 
            // _nameDataGridViewTextBoxColumn
            // 
            this._nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this._nameDataGridViewTextBoxColumn.FillWeight = 120F;
            this._nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this._nameDataGridViewTextBoxColumn.Name = "_nameDataGridViewTextBoxColumn";
            this._nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _categoryDataGridViewTextBoxColumn
            // 
            this._categoryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this._categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this._categoryDataGridViewTextBoxColumn.Name = "_categoryDataGridViewTextBoxColumn";
            this._categoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _priceDataGridViewTextBoxColumn
            // 
            this._priceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this._priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this._priceDataGridViewTextBoxColumn.Name = "_priceDataGridViewTextBoxColumn";
            this._priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _quantityDataGridViewTextBoxColumn
            // 
            this._quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this._quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this._quantityDataGridViewTextBoxColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._quantityDataGridViewTextBoxColumn.Name = "_quantityDataGridViewTextBoxColumn";
            this._quantityDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._quantityDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _subtotalDataGridViewTextBoxColumn
            // 
            this._subtotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._subtotalDataGridViewTextBoxColumn.DataPropertyName = "Subtotal";
            this._subtotalDataGridViewTextBoxColumn.HeaderText = "Subtotal";
            this._subtotalDataGridViewTextBoxColumn.Name = "_subtotalDataGridViewTextBoxColumn";
            this._subtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _orderListBindingSource
            // 
            this._orderListBindingSource.DataMember = "OrdersList";
            this._orderListBindingSource.DataSource = this._modelBindingSource;
            // 
            // _modelBindingSource
            // 
            this._modelBindingSource.DataSource = typeof(Homework.Model);
            // 
            // POSCustomerSideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 433);
            this.Controls.Add(this._totalPriceLabel);
            this.Controls.Add(this._checkDataGridView);
            this.Controls.Add(this._mealGroupBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "POSCustomerSideForm";
            this.Text = "POS-Customer Side";
            this._mealGroupBox.ResumeLayout(false);
            this._mealGroupBox.PerformLayout();
            this._descriptionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._checkDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._orderListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._modelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _mealGroupBox;
        private System.Windows.Forms.DataGridView _checkDataGridView;
        private System.Windows.Forms.Label _pageLabel;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _nextButton;
        private System.Windows.Forms.Button _previousButton;
        private System.Windows.Forms.Label _totalPriceLabel;
        private System.Windows.Forms.RichTextBox _descriptionBox;
        private System.Windows.Forms.Panel _descriptionPanel;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.BindingSource _orderListBindingSource;
        private System.Windows.Forms.BindingSource _modelBindingSource;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _priceDataGridViewTextBoxColumn;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn _quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _subtotalDataGridViewTextBoxColumn;
    }
}