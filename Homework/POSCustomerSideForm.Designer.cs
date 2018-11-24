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
            this._mealGroupBox = new System.Windows.Forms.GroupBox();
            this._describePanel = new System.Windows.Forms.Panel();
            this._describeBox = new System.Windows.Forms.RichTextBox();
            this._addButton = new System.Windows.Forms.Button();
            this._nextButton = new System.Windows.Forms.Button();
            this._previousButton = new System.Windows.Forms.Button();
            this._pageLabel = new System.Windows.Forms.Label();
            this._totalPriceLabel = new System.Windows.Forms.Label();
            this._checkDataGridView = new System.Windows.Forms.DataGridView();
            this._deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._priceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._mealGroupBox.SuspendLayout();
            this._describePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._checkDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _mealGroupBox
            // 
            this._mealGroupBox.Controls.Add(this._describePanel);
            this._mealGroupBox.Controls.Add(this._addButton);
            this._mealGroupBox.Controls.Add(this._nextButton);
            this._mealGroupBox.Controls.Add(this._previousButton);
            this._mealGroupBox.Controls.Add(this._pageLabel);
            this._mealGroupBox.Location = new System.Drawing.Point(12, 12);
            this._mealGroupBox.Name = "_mealGroupBox";
            this._mealGroupBox.Size = new System.Drawing.Size(385, 473);
            this._mealGroupBox.TabIndex = 16;
            this._mealGroupBox.TabStop = false;
            this._mealGroupBox.Text = "Meals";
            // 
            // _describePanel
            // 
            this._describePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._describePanel.Controls.Add(this._describeBox);
            this._describePanel.Location = new System.Drawing.Point(6, 341);
            this._describePanel.Name = "_describePanel";
            this._describePanel.Size = new System.Drawing.Size(373, 64);
            this._describePanel.TabIndex = 15;
            // 
            // _describeBox
            // 
            this._describeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._describeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._describeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._describeBox.Location = new System.Drawing.Point(0, 0);
            this._describeBox.Name = "_describeBox";
            this._describeBox.ReadOnly = true;
            this._describeBox.Size = new System.Drawing.Size(371, 62);
            this._describeBox.TabIndex = 14;
            this._describeBox.Text = "";
            // 
            // _addButton
            // 
            this._addButton.Enabled = false;
            this._addButton.Location = new System.Drawing.Point(264, 411);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(115, 25);
            this._addButton.TabIndex = 12;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.ClickAddButton);
            // 
            // _nextButton
            // 
            this._nextButton.Location = new System.Drawing.Point(264, 442);
            this._nextButton.Name = "_nextButton";
            this._nextButton.Size = new System.Drawing.Size(115, 25);
            this._nextButton.TabIndex = 11;
            this._nextButton.Text = "Next Page";
            this._nextButton.UseVisualStyleBackColor = true;
            this._nextButton.Click += new System.EventHandler(this.ClickChangedPageButton);
            // 
            // _previousButton
            // 
            this._previousButton.Enabled = false;
            this._previousButton.Location = new System.Drawing.Point(143, 442);
            this._previousButton.Name = "_previousButton";
            this._previousButton.Size = new System.Drawing.Size(115, 25);
            this._previousButton.TabIndex = 9;
            this._previousButton.Text = "Previous Page";
            this._previousButton.UseVisualStyleBackColor = true;
            this._previousButton.Click += new System.EventHandler(this.ClickChangedPageButton);
            // 
            // _pageLabel
            // 
            this._pageLabel.AutoSize = true;
            this._pageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this._pageLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this._pageLabel.Location = new System.Drawing.Point(6, 447);
            this._pageLabel.Name = "_pageLabel";
            this._pageLabel.Size = new System.Drawing.Size(64, 20);
            this._pageLabel.TabIndex = 13;
            this._pageLabel.Text = "Page：";
            // 
            // _totalPriceLabel
            // 
            this._totalPriceLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 20F);
            this._totalPriceLabel.ForeColor = System.Drawing.Color.DarkRed;
            this._totalPriceLabel.Location = new System.Drawing.Point(403, 445);
            this._totalPriceLabel.Name = "_totalPriceLabel";
            this._totalPriceLabel.Size = new System.Drawing.Size(385, 43);
            this._totalPriceLabel.TabIndex = 14;
            this._totalPriceLabel.Text = "Total：0元";
            this._totalPriceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _checkDataGridView
            // 
            this._checkDataGridView.AccessibleName = "";
            this._checkDataGridView.AllowUserToAddRows = false;
            this._checkDataGridView.AllowUserToResizeColumns = false;
            this._checkDataGridView.AllowUserToResizeRows = false;
            this._checkDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._checkDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteColumn,
            this._nameColumn,
            this._priceColumn});
            this._checkDataGridView.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this._checkDataGridView.Location = new System.Drawing.Point(403, 12);
            this._checkDataGridView.Name = "_checkDataGridView";
            this._checkDataGridView.RowHeadersVisible = false;
            this._checkDataGridView.RowTemplate.Height = 24;
            this._checkDataGridView.Size = new System.Drawing.Size(385, 424);
            this._checkDataGridView.TabIndex = 15;
            this._checkDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDelete);
            // 
            // _deleteColumn
            // 
            this._deleteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._deleteColumn.HeaderText = "Delete";
            this._deleteColumn.Name = "_deleteColumn";
            this._deleteColumn.ReadOnly = true;
            this._deleteColumn.Text = "X";
            this._deleteColumn.UseColumnTextForButtonValue = true;
            // 
            // _nameColumn
            // 
            this._nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._nameColumn.FillWeight = 99.71347F;
            this._nameColumn.HeaderText = "Name";
            this._nameColumn.Name = "_nameColumn";
            this._nameColumn.ReadOnly = true;
            // 
            // _priceColumn
            // 
            this._priceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._priceColumn.FillWeight = 100.2865F;
            this._priceColumn.HeaderText = "Unit Price";
            this._priceColumn.Name = "_priceColumn";
            this._priceColumn.ReadOnly = true;
            // 
            // POSCustomerSideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this._totalPriceLabel);
            this.Controls.Add(this._checkDataGridView);
            this.Controls.Add(this._mealGroupBox);
            this.Name = "POSCustomerSideForm";
            this.Text = "POS-Customer Side";
            this._mealGroupBox.ResumeLayout(false);
            this._mealGroupBox.PerformLayout();
            this._describePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._checkDataGridView)).EndInit();
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
        private System.Windows.Forms.RichTextBox _describeBox;
        private System.Windows.Forms.Panel _describePanel;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _priceColumn;
    }
}