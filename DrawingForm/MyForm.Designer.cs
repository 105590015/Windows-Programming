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
            this._bottomTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._saveButton = new System.Windows.Forms.Button();
            this._loadButton = new System.Windows.Forms.Button();
            this._topTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._ellipseButton = new System.Windows.Forms.Button();
            this._redoButton = new System.Windows.Forms.Button();
            this._undoButton = new System.Windows.Forms.Button();
            this._clearButton = new System.Windows.Forms.Button();
            this._lineButton = new System.Windows.Forms.Button();
            this._diamondButton = new System.Windows.Forms.Button();
            this._canvas.SuspendLayout();
            this._bottomTableLayoutPanel.SuspendLayout();
            this._topTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _canvas
            // 
            this._canvas.AutoSize = true;
            this._canvas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._canvas.BackColor = System.Drawing.Color.LightYellow;
            this._canvas.Controls.Add(this._bottomTableLayoutPanel);
            this._canvas.Controls.Add(this._topTableLayoutPanel);
            this._canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._canvas.Location = new System.Drawing.Point(0, 0);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(800, 450);
            this._canvas.TabIndex = 1;
            // 
            // _bottomTableLayoutPanel
            // 
            this._bottomTableLayoutPanel.AutoSize = true;
            this._bottomTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._bottomTableLayoutPanel.ColumnCount = 4;
            this._bottomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71F));
            this._bottomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this._bottomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this._bottomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this._bottomTableLayoutPanel.Controls.Add(this._saveButton, 1, 0);
            this._bottomTableLayoutPanel.Controls.Add(this._loadButton, 3, 0);
            this._bottomTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._bottomTableLayoutPanel.Location = new System.Drawing.Point(0, 412);
            this._bottomTableLayoutPanel.MinimumSize = new System.Drawing.Size(100, 38);
            this._bottomTableLayoutPanel.Name = "_bottomTableLayoutPanel";
            this._bottomTableLayoutPanel.RowCount = 1;
            this._bottomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._bottomTableLayoutPanel.Size = new System.Drawing.Size(800, 38);
            this._bottomTableLayoutPanel.TabIndex = 1;
            // 
            // _saveButton
            // 
            this._saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._saveButton.Location = new System.Drawing.Point(571, 3);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(106, 32);
            this._saveButton.TabIndex = 0;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            // 
            // _loadButton
            // 
            this._loadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._loadButton.Location = new System.Drawing.Point(691, 3);
            this._loadButton.Name = "_loadButton";
            this._loadButton.Size = new System.Drawing.Size(106, 32);
            this._loadButton.TabIndex = 1;
            this._loadButton.Text = "Load";
            this._loadButton.UseVisualStyleBackColor = true;
            // 
            // _topTableLayoutPanel
            // 
            this._topTableLayoutPanel.AutoSize = true;
            this._topTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._topTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this._topTableLayoutPanel.ColumnCount = 11;
            this._topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this._topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this._topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this._topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this._topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this._topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.5F));
            this._topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this._topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.5F));
            this._topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this._topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this._topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this._topTableLayoutPanel.Controls.Add(this._ellipseButton, 0, 0);
            this._topTableLayoutPanel.Controls.Add(this._redoButton, 10, 0);
            this._topTableLayoutPanel.Controls.Add(this._undoButton, 8, 0);
            this._topTableLayoutPanel.Controls.Add(this._clearButton, 6, 0);
            this._topTableLayoutPanel.Controls.Add(this._lineButton, 4, 0);
            this._topTableLayoutPanel.Controls.Add(this._diamondButton, 2, 0);
            this._topTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._topTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._topTableLayoutPanel.MinimumSize = new System.Drawing.Size(0, 38);
            this._topTableLayoutPanel.Name = "_topTableLayoutPanel";
            this._topTableLayoutPanel.RowCount = 1;
            this._topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._topTableLayoutPanel.Size = new System.Drawing.Size(800, 38);
            this._topTableLayoutPanel.TabIndex = 0;
            // 
            // _ellipseButton
            // 
            this._ellipseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ellipseButton.Location = new System.Drawing.Point(3, 3);
            this._ellipseButton.Name = "_ellipseButton";
            this._ellipseButton.Size = new System.Drawing.Size(106, 32);
            this._ellipseButton.TabIndex = 4;
            this._ellipseButton.Text = "Ellipse";
            this._ellipseButton.UseVisualStyleBackColor = true;
            // 
            // _redoButton
            // 
            this._redoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._redoButton.Location = new System.Drawing.Point(691, 3);
            this._redoButton.Name = "_redoButton";
            this._redoButton.Size = new System.Drawing.Size(106, 32);
            this._redoButton.TabIndex = 6;
            this._redoButton.Text = "Redo";
            this._redoButton.UseVisualStyleBackColor = true;
            // 
            // _undoButton
            // 
            this._undoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._undoButton.Location = new System.Drawing.Point(571, 3);
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(106, 32);
            this._undoButton.TabIndex = 5;
            this._undoButton.Text = "Undo";
            this._undoButton.UseVisualStyleBackColor = true;
            // 
            // _clearButton
            // 
            this._clearButton.AutoSize = true;
            this._clearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._clearButton.Location = new System.Drawing.Point(407, 3);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(106, 32);
            this._clearButton.TabIndex = 0;
            this._clearButton.Text = "Clear";
            this._clearButton.UseVisualStyleBackColor = true;
            // 
            // _lineButton
            // 
            this._lineButton.AutoSize = true;
            this._lineButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._lineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lineButton.Location = new System.Drawing.Point(243, 3);
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(106, 32);
            this._lineButton.TabIndex = 3;
            this._lineButton.Text = "Line";
            this._lineButton.UseVisualStyleBackColor = true;
            // 
            // _diamondButton
            // 
            this._diamondButton.AutoSize = true;
            this._diamondButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._diamondButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._diamondButton.Location = new System.Drawing.Point(123, 3);
            this._diamondButton.Name = "_diamondButton";
            this._diamondButton.Size = new System.Drawing.Size(106, 32);
            this._diamondButton.TabIndex = 2;
            this._diamondButton.Text = "Diamond";
            this._diamondButton.UseVisualStyleBackColor = true;
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._canvas);
            this.MinimumSize = new System.Drawing.Size(600, 150);
            this.Name = "MyForm";
            this.Text = "Drawing";
            this._canvas.ResumeLayout(false);
            this._canvas.PerformLayout();
            this._bottomTableLayoutPanel.ResumeLayout(false);
            this._topTableLayoutPanel.ResumeLayout(false);
            this._topTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _clearButton;
        private DoubleBufferedPanel _canvas;
        private System.Windows.Forms.Button _diamondButton;
        private System.Windows.Forms.TableLayoutPanel _topTableLayoutPanel;
        private System.Windows.Forms.Button _lineButton;
        private System.Windows.Forms.Button _ellipseButton;
        private System.Windows.Forms.Button _undoButton;
        private System.Windows.Forms.Button _redoButton;
        private System.Windows.Forms.TableLayoutPanel _bottomTableLayoutPanel;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _loadButton;
    }
}

