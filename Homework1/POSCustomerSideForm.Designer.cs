namespace Homework1
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
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._button12 = new System.Windows.Forms.Button();
            this._button11 = new System.Windows.Forms.Button();
            this._button10 = new System.Windows.Forms.Button();
            this._label1 = new System.Windows.Forms.Label();
            this._label2 = new System.Windows.Forms.Label();
            this._dataGridView1 = new System.Windows.Forms.DataGridView();
            this._column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._button12);
            this._groupBox1.Controls.Add(this._button11);
            this._groupBox1.Controls.Add(this._button10);
            this._groupBox1.Controls.Add(this._label1);
            this._groupBox1.Location = new System.Drawing.Point(12, 12);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(385, 473);
            this._groupBox1.TabIndex = 16;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "Meals";
            // 
            // _button12
            // 
            this._button12.Enabled = false;
            this._button12.Location = new System.Drawing.Point(264, 411);
            this._button12.Name = "_button12";
            this._button12.Size = new System.Drawing.Size(115, 25);
            this._button12.TabIndex = 12;
            this._button12.Text = "Add";
            this._button12.UseVisualStyleBackColor = true;
            this._button12.Click += new System.EventHandler(this.ClickAddButton);
            // 
            // _button11
            // 
            this._button11.Location = new System.Drawing.Point(264, 442);
            this._button11.Name = "_button11";
            this._button11.Size = new System.Drawing.Size(115, 25);
            this._button11.TabIndex = 11;
            this._button11.Text = "Next Page";
            this._button11.UseVisualStyleBackColor = true;
            this._button11.Click += new System.EventHandler(this.ClickChangedPageButton);
            // 
            // _button10
            // 
            this._button10.Enabled = false;
            this._button10.Location = new System.Drawing.Point(143, 442);
            this._button10.Name = "_button10";
            this._button10.Size = new System.Drawing.Size(115, 25);
            this._button10.TabIndex = 9;
            this._button10.Text = "Previous Page";
            this._button10.UseVisualStyleBackColor = true;
            this._button10.Click += new System.EventHandler(this.ClickChangedPageButton);
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this._label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this._label1.Location = new System.Drawing.Point(6, 447);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(64, 20);
            this._label1.TabIndex = 13;
            this._label1.Text = "Page：";
            // 
            // _label2
            // 
            this._label2.Font = new System.Drawing.Font("Microsoft JhengHei", 20F);
            this._label2.ForeColor = System.Drawing.Color.DarkRed;
            this._label2.Location = new System.Drawing.Point(403, 445);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(385, 43);
            this._label2.TabIndex = 14;
            this._label2.Text = "Total：0元";
            this._label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _dataGridView1
            // 
            this._dataGridView1.AccessibleName = "";
            this._dataGridView1.AllowUserToAddRows = false;
            this._dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._column1,
            this._column2});
            this._dataGridView1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this._dataGridView1.Location = new System.Drawing.Point(403, 12);
            this._dataGridView1.Name = "_dataGridView1";
            this._dataGridView1.RowHeadersVisible = false;
            this._dataGridView1.RowTemplate.Height = 24;
            this._dataGridView1.Size = new System.Drawing.Size(385, 424);
            this._dataGridView1.TabIndex = 15;
            // 
            // _column1
            // 
            this._column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._column1.FillWeight = 99.71347F;
            this._column1.HeaderText = "Name";
            this._column1.Name = "_column1";
            // 
            // _column2
            // 
            this._column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._column2.FillWeight = 100.2865F;
            this._column2.HeaderText = "Unit Price";
            this._column2.Name = "_column2";
            // 
            // POSCustomerSideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this._label2);
            this.Controls.Add(this._dataGridView1);
            this.Controls.Add(this._groupBox1);
            this.Name = "POSCustomerSideForm";
            this.Text = "POSCustomerSideForm";
            this._groupBox1.ResumeLayout(false);
            this._groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.DataGridView _dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _column2;
        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.Button _button12;
        private System.Windows.Forms.Button _button11;
        private System.Windows.Forms.Button _button10;
        private System.Windows.Forms.Label _label2;
    }
}