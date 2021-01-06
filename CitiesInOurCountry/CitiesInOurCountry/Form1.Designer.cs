namespace CitiesInOurCountry
{
    partial class Form1
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
            this.btnAddState = new System.Windows.Forms.Button();
            this.btnAddCity = new System.Windows.Forms.Button();
            this.tvDynamic = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnAddState
            // 
            this.btnAddState.Location = new System.Drawing.Point(70, 42);
            this.btnAddState.Name = "btnAddState";
            this.btnAddState.Size = new System.Drawing.Size(135, 47);
            this.btnAddState.TabIndex = 0;
            this.btnAddState.Text = "Add State";
            this.btnAddState.UseVisualStyleBackColor = true;
            this.btnAddState.Click += new System.EventHandler(this.btnAddState_Click);
            // 
            // btnAddCity
            // 
            this.btnAddCity.Location = new System.Drawing.Point(230, 42);
            this.btnAddCity.Name = "btnAddCity";
            this.btnAddCity.Size = new System.Drawing.Size(114, 49);
            this.btnAddCity.TabIndex = 1;
            this.btnAddCity.Text = "City";
            this.btnAddCity.UseVisualStyleBackColor = true;
            this.btnAddCity.Click += new System.EventHandler(this.btnAddCity_Click);
            // 
            // tvDynamic
            // 
            this.tvDynamic.Location = new System.Drawing.Point(70, 106);
            this.tvDynamic.Name = "tvDynamic";
            this.tvDynamic.Size = new System.Drawing.Size(274, 472);
            this.tvDynamic.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 610);
            this.Controls.Add(this.tvDynamic);
            this.Controls.Add(this.btnAddCity);
            this.Controls.Add(this.btnAddState);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddState;
        private System.Windows.Forms.Button btnAddCity;
        private System.Windows.Forms.TreeView tvDynamic;
    }
}

