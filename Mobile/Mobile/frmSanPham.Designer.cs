namespace Mobile
{
    partial class frmSanPham
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTimTenSanPham = new System.Windows.Forms.TextBox();
            this.txtTimMaSanPham = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.radiobtnTenSP = new System.Windows.Forms.RadioButton();
            this.radiobtnMaSP = new System.Windows.Forms.RadioButton();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTimTenSanPham);
            this.groupBox2.Controls.Add(this.txtTimMaSanPham);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.radiobtnTenSP);
            this.groupBox2.Controls.Add(this.radiobtnMaSP);
            this.groupBox2.Location = new System.Drawing.Point(43, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(830, 155);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // txtTimTenSanPham
            // 
            this.txtTimTenSanPham.Location = new System.Drawing.Point(378, 55);
            this.txtTimTenSanPham.Name = "txtTimTenSanPham";
            this.txtTimTenSanPham.Size = new System.Drawing.Size(168, 20);
            this.txtTimTenSanPham.TabIndex = 1;
            // 
            // txtTimMaSanPham
            // 
            this.txtTimMaSanPham.Location = new System.Drawing.Point(378, 27);
            this.txtTimMaSanPham.Name = "txtTimMaSanPham";
            this.txtTimMaSanPham.Size = new System.Drawing.Size(168, 20);
            this.txtTimMaSanPham.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKiem.Location = new System.Drawing.Point(378, 102);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(167, 25);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // radiobtnTenSP
            // 
            this.radiobtnTenSP.AutoSize = true;
            this.radiobtnTenSP.Location = new System.Drawing.Point(288, 56);
            this.radiobtnTenSP.Name = "radiobtnTenSP";
            this.radiobtnTenSP.Size = new System.Drawing.Size(93, 17);
            this.radiobtnTenSP.TabIndex = 6;
            this.radiobtnTenSP.TabStop = true;
            this.radiobtnTenSP.Text = "Tên sản phẩm";
            this.radiobtnTenSP.UseVisualStyleBackColor = true;
            this.radiobtnTenSP.CheckedChanged += new System.EventHandler(this.radiobtnTenSP_CheckedChanged);
            // 
            // radiobtnMaSP
            // 
            this.radiobtnMaSP.AutoSize = true;
            this.radiobtnMaSP.Location = new System.Drawing.Point(288, 28);
            this.radiobtnMaSP.Name = "radiobtnMaSP";
            this.radiobtnMaSP.Size = new System.Drawing.Size(89, 17);
            this.radiobtnMaSP.TabIndex = 5;
            this.radiobtnMaSP.TabStop = true;
            this.radiobtnMaSP.Text = "Mã sản phẩm";
            this.radiobtnMaSP.UseVisualStyleBackColor = true;
            this.radiobtnMaSP.CheckedChanged += new System.EventHandler(this.radiobtnMaSP_CheckedChanged);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(785, 475);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(87, 36);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(226)))), ((int)(((byte)(238)))));
            this.dgvSanPham.Location = new System.Drawing.Point(41, 228);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.Size = new System.Drawing.Size(832, 242);
            this.dgvSanPham.TabIndex = 38;
            this.dgvSanPham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(313, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 31);
            this.label1.TabIndex = 39;
            this.label1.Text = "DANH MỤC SẢN PHẨM";
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 523);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.label1);
            this.Name = "frmSanPham";
            this.Text = "Cập Nhật Sản Phẩm";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTimTenSanPham;
        private System.Windows.Forms.TextBox txtTimMaSanPham;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.RadioButton radiobtnTenSP;
        private System.Windows.Forms.RadioButton radiobtnMaSP;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Label label1;
    }
}