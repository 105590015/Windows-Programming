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
            this._messageLabel = new System.Windows.Forms.Label();
            this._okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _messageLabel
            // 
            this._messageLabel.AutoSize = true;
            this._messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this._messageLabel.Location = new System.Drawing.Point(126, 81);
            this._messageLabel.Name = "_messageLabel";
            this._messageLabel.Size = new System.Drawing.Size(342, 58);
            this._messageLabel.TabIndex = 0;
            this._messageLabel.Text = "Coming Soon!";
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(263, 180);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.CloseForm);
            // 
            // POSRestaurantSideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 267);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._messageLabel);
            this.Name = "POSRestaurantSideForm";
            this.Text = "POS-Restaurant Side";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _messageLabel;
        private System.Windows.Forms.Button _okButton;
    }
}