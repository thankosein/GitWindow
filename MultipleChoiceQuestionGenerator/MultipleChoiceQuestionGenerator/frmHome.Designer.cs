namespace MultipleChoiceQuestionGenerator
{
    partial class frmHome
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
            this.meuMain = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUpSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAnsC = new System.Windows.Forms.TextBox();
            this.txtAnsB = new System.Windows.Forms.TextBox();
            this.txtAnsA = new System.Windows.Forms.TextBox();
            this.txtQuest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnsA = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAnsC = new System.Windows.Forms.Button();
            this.btnAnsB = new System.Windows.Forms.Button();
            this.meuMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // meuMain
            // 
            this.meuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.meuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.setUpToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.meuMain.Location = new System.Drawing.Point(0, 0);
            this.meuMain.Name = "meuMain";
            this.meuMain.Size = new System.Drawing.Size(1429, 28);
            this.meuMain.TabIndex = 0;
            this.meuMain.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // setUpToolStripMenuItem
            // 
            this.setUpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setUpSubjectToolStripMenuItem,
            this.questionsToolStripMenuItem});
            this.setUpToolStripMenuItem.Name = "setUpToolStripMenuItem";
            this.setUpToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.setUpToolStripMenuItem.Text = "Set Up";
            // 
            // setUpSubjectToolStripMenuItem
            // 
            this.setUpSubjectToolStripMenuItem.Name = "setUpSubjectToolStripMenuItem";
            this.setUpSubjectToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.setUpSubjectToolStripMenuItem.Text = "Subject";
            this.setUpSubjectToolStripMenuItem.Click += new System.EventHandler(this.setUpSubjectToolStripMenuItem_Click);
            // 
            // questionsToolStripMenuItem
            // 
            this.questionsToolStripMenuItem.Name = "questionsToolStripMenuItem";
            this.questionsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.questionsToolStripMenuItem.Text = "Questions";
            this.questionsToolStripMenuItem.Click += new System.EventHandler(this.questionsToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAnsC);
            this.panel1.Controls.Add(this.btnAnsB);
            this.panel1.Controls.Add(this.btnAnsA);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.txtAnsC);
            this.panel1.Controls.Add(this.txtAnsB);
            this.panel1.Controls.Add(this.txtAnsA);
            this.panel1.Controls.Add(this.txtQuest);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Pyidaungsu", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1429, 565);
            this.panel1.TabIndex = 2;
            // 
            // txtAnsC
            // 
            this.txtAnsC.Location = new System.Drawing.Point(118, 170);
            this.txtAnsC.Name = "txtAnsC";
            this.txtAnsC.Size = new System.Drawing.Size(1237, 28);
            this.txtAnsC.TabIndex = 13;
            // 
            // txtAnsB
            // 
            this.txtAnsB.Location = new System.Drawing.Point(118, 128);
            this.txtAnsB.Name = "txtAnsB";
            this.txtAnsB.Size = new System.Drawing.Size(1237, 28);
            this.txtAnsB.TabIndex = 12;
            // 
            // txtAnsA
            // 
            this.txtAnsA.Location = new System.Drawing.Point(118, 86);
            this.txtAnsA.Name = "txtAnsA";
            this.txtAnsA.Size = new System.Drawing.Size(1237, 28);
            this.txtAnsA.TabIndex = 11;
            // 
            // txtQuest
            // 
            this.txtQuest.Location = new System.Drawing.Point(118, 44);
            this.txtQuest.Name = "txtQuest";
            this.txtQuest.Size = new System.Drawing.Size(1237, 28);
            this.txtQuest.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 22);
            this.label5.TabIndex = 6;
            this.label5.Text = "C:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "B:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "A:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Question:";
            // 
            // btnAnsA
            // 
            this.btnAnsA.Location = new System.Drawing.Point(262, 236);
            this.btnAnsA.Name = "btnAnsA";
            this.btnAnsA.Size = new System.Drawing.Size(112, 42);
            this.btnAnsA.TabIndex = 15;
            this.btnAnsA.Text = "A";
            this.btnAnsA.UseVisualStyleBackColor = true;
            this.btnAnsA.Click += new System.EventHandler(this.btnAnsA_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(118, 236);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 42);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnAnsC
            // 
            this.btnAnsC.Location = new System.Drawing.Point(549, 236);
            this.btnAnsC.Name = "btnAnsC";
            this.btnAnsC.Size = new System.Drawing.Size(112, 42);
            this.btnAnsC.TabIndex = 17;
            this.btnAnsC.Text = "C";
            this.btnAnsC.UseVisualStyleBackColor = true;
            this.btnAnsC.Click += new System.EventHandler(this.btnAnsA_Click);
            // 
            // btnAnsB
            // 
            this.btnAnsB.Location = new System.Drawing.Point(405, 236);
            this.btnAnsB.Name = "btnAnsB";
            this.btnAnsB.Size = new System.Drawing.Size(112, 42);
            this.btnAnsB.TabIndex = 16;
            this.btnAnsB.Text = "B";
            this.btnAnsB.UseVisualStyleBackColor = true;
            this.btnAnsB.Click += new System.EventHandler(this.btnAnsA_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 593);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.meuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.meuMain;
            this.Name = "frmHome";
            this.Text = "Multiple Choice Question Generator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.meuMain.ResumeLayout(false);
            this.meuMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip meuMain;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUpSubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questionsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAnsC;
        private System.Windows.Forms.TextBox txtAnsB;
        private System.Windows.Forms.TextBox txtAnsA;
        private System.Windows.Forms.TextBox txtQuest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnsC;
        private System.Windows.Forms.Button btnAnsB;
        private System.Windows.Forms.Button btnAnsA;
        private System.Windows.Forms.Button btnStart;
    }
}