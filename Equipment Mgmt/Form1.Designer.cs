﻿namespace Equipment_Mgmt
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_equipID = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lbl_employeeName = new System.Windows.Forms.Label();
            this.lbl_scanned = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pic_profile = new System.Windows.Forms.PictureBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_bypass = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_profile)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(283, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(849, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scan IMEI/SN here to verify";
            // 
            // txt_equipID
            // 
            this.txt_equipID.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_equipID.Location = new System.Drawing.Point(166, 140);
            this.txt_equipID.Name = "txt_equipID";
            this.txt_equipID.Size = new System.Drawing.Size(1132, 62);
            this.txt_equipID.TabIndex = 1;
            this.txt_equipID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_equipID.TextChanged += new System.EventHandler(this.txt_equipID_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lbl_employeeName
            // 
            this.lbl_employeeName.AutoSize = true;
            this.lbl_employeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_employeeName.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lbl_employeeName.Location = new System.Drawing.Point(618, 398);
            this.lbl_employeeName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 30);
            this.lbl_employeeName.Name = "lbl_employeeName";
            this.lbl_employeeName.Size = new System.Drawing.Size(519, 73);
            this.lbl_employeeName.TabIndex = 3;
            this.lbl_employeeName.Text = "Employee Name";
            this.lbl_employeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_employeeName.Click += new System.EventHandler(this.lbl_employeeName_Click);
            // 
            // lbl_scanned
            // 
            this.lbl_scanned.AutoSize = true;
            this.lbl_scanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_scanned.Location = new System.Drawing.Point(113, 868);
            this.lbl_scanned.Name = "lbl_scanned";
            this.lbl_scanned.Size = new System.Drawing.Size(21, 20);
            this.lbl_scanned.TabIndex = 6;
            this.lbl_scanned.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 868);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Scanned ID:";
            // 
            // pic_profile
            // 
            this.pic_profile.Image = global::Equipment_Mgmt.Properties.Resources.user;
            this.pic_profile.Location = new System.Drawing.Point(13, 284);
            this.pic_profile.Name = "pic_profile";
            this.pic_profile.Size = new System.Drawing.Size(599, 487);
            this.pic_profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_profile.TabIndex = 4;
            this.pic_profile.TabStop = false;
            this.pic_profile.Click += new System.EventHandler(this.pic_profile_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lbl_title.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_title.Location = new System.Drawing.Point(618, 501);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(3, 0, 3, 30);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(881, 74);
            this.lbl_title.TabIndex = 8;
            this.lbl_title.Text = "Title";
            // 
            // lbl_bypass
            // 
            this.lbl_bypass.Font = new System.Drawing.Font("Elephant", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bypass.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lbl_bypass.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_bypass.Location = new System.Drawing.Point(618, 605);
            this.lbl_bypass.Margin = new System.Windows.Forms.Padding(3, 0, 3, 30);
            this.lbl_bypass.Name = "lbl_bypass";
            this.lbl_bypass.Size = new System.Drawing.Size(881, 74);
            this.lbl_bypass.TabIndex = 9;
            this.lbl_bypass.Text = "...";
            this.lbl_bypass.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 895);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_bypass);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_scanned);
            this.Controls.Add(this.pic_profile);
            this.Controls.Add(this.lbl_employeeName);
            this.Controls.Add(this.txt_equipID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Equipment Verification";
            ((System.ComponentModel.ISupportInitialize)(this.pic_profile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_equipID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lbl_employeeName;
        private System.Windows.Forms.PictureBox pic_profile;
        private System.Windows.Forms.Label lbl_scanned;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_bypass;
    }
}

