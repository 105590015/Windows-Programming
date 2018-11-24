namespace Homework
{
    partial class StartUpForm
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
            this._customerButton = new System.Windows.Forms.Button();
            this._restaurantButton = new System.Windows.Forms.Button();
            this._exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _customerButton
            // 
            this._customerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this._customerButton.Location = new System.Drawing.Point(12, 12);
            this._customerButton.Name = "_customerButton";
            this._customerButton.Size = new System.Drawing.Size(572, 77);
            this._customerButton.TabIndex = 0;
            this._customerButton.Text = "Start the Customer Program(Frontend)";
            this._customerButton.UseVisualStyleBackColor = true;
            this._customerButton.Click += new System.EventHandler(this.OpenCustomerForm);
            // 
            // _restaurantButton
            // 
            this._restaurantButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this._restaurantButton.Location = new System.Drawing.Point(12, 95);
            this._restaurantButton.Name = "_restaurantButton";
            this._restaurantButton.Size = new System.Drawing.Size(572, 77);
            this._restaurantButton.TabIndex = 1;
            this._restaurantButton.Text = "Start the Restaurant Program(Backend)";
            this._restaurantButton.UseVisualStyleBackColor = true;
            this._restaurantButton.Click += new System.EventHandler(this.OpenRestaurantForm);
            // 
            // _exitButton
            // 
            this._exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this._exitButton.Location = new System.Drawing.Point(407, 178);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(177, 77);
            this._exitButton.TabIndex = 2;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this.Exit);
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 267);
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this._restaurantButton);
            this.Controls.Add(this._customerButton);
            this.Name = "StartUpForm";
            this.Text = "StartUp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _customerButton;
        private System.Windows.Forms.Button _restaurantButton;
        private System.Windows.Forms.Button _exitButton;
    }
}