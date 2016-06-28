namespace Mobile
{
    partial class frmTKDTNhanVien
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
            this.ReportViewerDTNV = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReportTKDTNV1 = new Mobile.CrystalReportTKDTNV();
            this.SuspendLayout();
            // 
            // ReportViewerDTNV
            // 
            this.ReportViewerDTNV.ActiveViewIndex = 0;
            this.ReportViewerDTNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewerDTNV.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportViewerDTNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewerDTNV.Location = new System.Drawing.Point(0, 0);
            this.ReportViewerDTNV.Name = "ReportViewerDTNV";
            this.ReportViewerDTNV.ReportSource = this.CrystalReportTKDTNV1;
            this.ReportViewerDTNV.Size = new System.Drawing.Size(813, 498);
            this.ReportViewerDTNV.TabIndex = 0;
            // 
            // frmTKDTNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 498);
            this.Controls.Add(this.ReportViewerDTNV);
            this.Name = "frmTKDTNhanVien";
            this.Text = "frmTKDTNhanVien";
            this.Load += new System.EventHandler(this.frmTKDTNhanVien_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewerDTNV;
        private CrystalReportTKDTNV CrystalReportTKDTNV1;
    }
}