namespace QuanLySinhVien
{
    partial class Khoa_Lop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Khoa_Lop));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDSKhoa = new System.Windows.Forms.ComboBox();
            this.cboDSLop = new System.Windows.Forms.ComboBox();
            this.btnDS = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(139, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "KHOA-LỚP";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDSLop);
            this.groupBox1.Controls.Add(this.cboDSKhoa);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(19, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Danh Sách Khoa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(248, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Danh Sách Lớp:";
            // 
            // cboDSKhoa
            // 
            this.cboDSKhoa.FormattingEnabled = true;
            this.cboDSKhoa.Location = new System.Drawing.Point(23, 52);
            this.cboDSKhoa.Name = "cboDSKhoa";
            this.cboDSKhoa.Size = new System.Drawing.Size(114, 21);
            this.cboDSKhoa.TabIndex = 2;
            this.cboDSKhoa.SelectedIndexChanged += new System.EventHandler(this.cboDSKhoa_SelectedIndexChanged);
            // 
            // cboDSLop
            // 
            this.cboDSLop.FormattingEnabled = true;
            this.cboDSLop.Location = new System.Drawing.Point(244, 52);
            this.cboDSLop.Name = "cboDSLop";
            this.cboDSLop.Size = new System.Drawing.Size(121, 21);
            this.cboDSLop.TabIndex = 3;
            // 
            // btnDS
            // 
            this.btnDS.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDS.ForeColor = System.Drawing.Color.Blue;
            this.btnDS.Image = ((System.Drawing.Image)(resources.GetObject("btnDS.Image")));
            this.btnDS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDS.Location = new System.Drawing.Point(58, 204);
            this.btnDS.Name = "btnDS";
            this.btnDS.Size = new System.Drawing.Size(137, 29);
            this.btnDS.TabIndex = 2;
            this.btnDS.Text = "Danh Sách SV";
            this.btnDS.UseVisualStyleBackColor = true;
            this.btnDS.Click += new System.EventHandler(this.btnDS_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(220, 204);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(132, 29);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.button2_Click);
            // 
            // Khoa_Lop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 250);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDS);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Khoa_Lop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khoa_Lop";
            this.Load += new System.EventHandler(this.Khoa_Lop_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDSLop;
        private System.Windows.Forms.ComboBox cboDSKhoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDS;
        private System.Windows.Forms.Button btnThoat;
    }
}