namespace Mobile
{
    partial class frmInPhieuBaoHanh
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
            this.crvPhieuBaoHanh = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReportPhieuBH1 = new Mobile.CrystalReportPhieuBH();
            this.SuspendLayout();
            // 
            // crvPhieuBaoHanh
            // 
            this.crvPhieuBaoHanh.ActiveViewIndex = 0;
            this.crvPhieuBaoHanh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPhieuBaoHanh.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvPhieuBaoHanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPhieuBaoHanh.Location = new System.Drawing.Point(0, 0);
            this.crvPhieuBaoHanh.Name = "crvPhieuBaoHanh";
            this.crvPhieuBaoHanh.ReportSource = this.CrystalReportPhieuBH1;
            this.crvPhieuBaoHanh.Size = new System.Drawing.Size(901, 511);
            this.crvPhieuBaoHanh.TabIndex = 0;
            // 
            // frmInPhieuBaoHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 511);
            this.Controls.Add(this.crvPhieuBaoHanh);
            this.Name = "frmInPhieuBaoHanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Phiếu Bảo Hành";
            this.Load += new System.EventHandler(this.frmInPhieuBaoHanh_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPhieuBaoHanh;
        private CrystalReportPhieuBH CrystalReportPhieuBH1;
    }
}