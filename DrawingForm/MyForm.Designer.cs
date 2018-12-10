namespace DrawingForm
{
    partial class MyForm
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
            this._canvas = new DrawingForm.DoubleBufferedPanel();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._diamondButton = new System.Windows.Forms.Button();
            this._clearButton = new System.Windows.Forms.Button();
            this._lineButton = new System.Windows.Forms.Button();
            this._canvas.SuspendLayout();
            this._tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _canvas
            // 
            this._canvas.AutoSize = true;
            this._canvas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._canvas.BackColor = System.Drawing.Color.LightYellow;
            this._canvas.Controls.Add(this._tableLayoutPanel);
            this._canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._canvas.Location = new System.Drawing.Point(0, 0);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(800, 450);
            this._canvas.TabIndex = 1;
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.AutoSize = true;
            this._tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this._tableLayoutPanel.ColumnCount = 3;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this._tableLayoutPanel.Controls.Add(this._diamondButton, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._clearButton, 2, 0);
            this._tableLayoutPanel.Controls.Add(this._lineButton, 1, 0);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel.MinimumSize = new System.Drawing.Size(0, 58);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 1;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(800, 58);
            this._tableLayoutPanel.TabIndex = 0;
            // 
            // _diamondButton
            // 
            this._diamondButton.AutoSize = true;
            this._diamondButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._diamondButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._diamondButton.Location = new System.Drawing.Point(20, 3);
            this._diamondButton.Margin = new System.Windows.Forms.Padding(20, 3, 10, 3);
            this._diamondButton.Name = "_diamondButton";
            this._diamondButton.Size = new System.Drawing.Size(236, 52);
            this._diamondButton.TabIndex = 2;
            this._diamondButton.Text = "Diamond";
            this._diamondButton.UseVisualStyleBackColor = true;
            // 
            // _clearButton
            // 
            this._clearButton.AutoSize = true;
            this._clearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._clearButton.Location = new System.Drawing.Point(542, 3);
            this._clearButton.Margin = new System.Windows.Forms.Padding(10, 3, 20, 3);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(238, 52);
            this._clearButton.TabIndex = 0;
            this._clearButton.Text = "Clear";
            this._clearButton.UseVisualStyleBackColor = true;
            // 
            // _lineButton
            // 
            this._lineButton.AutoSize = true;
            this._lineButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._lineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lineButton.Location = new System.Drawing.Point(281, 3);
            this._lineButton.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(236, 52);
            this._lineButton.TabIndex = 3;
            this._lineButton.Text = "Line";
            this._lineButton.UseVisualStyleBackColor = true;
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._canvas);
            this.Name = "MyForm";
            this.Text = "Drawing";
            this._canvas.ResumeLayout(false);
            this._canvas.PerformLayout();
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _clearButton;
        private DoubleBufferedPanel _canvas;
        private System.Windows.Forms.Button _diamondButton;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.Button _lineButton;
    }
}

