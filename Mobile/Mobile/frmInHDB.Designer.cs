namespace Mobile
{
    partial class frmInHDB
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
            this.crvHDB = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReportHDB1 = new Mobile.CrystalReportHDB();
            this.SuspendLayout();
            // 
            // crvHDB
            // 
            this.crvHDB.ActiveViewIndex = 0;
            this.crvHDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvHDB.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvHDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvHDB.Location = new System.Drawing.Point(0, 0);
            this.crvHDB.Name = "crvHDB";
            this.crvHDB.ReportSource = this.CrystalReportHDB1;
            this.crvHDB.Size = new System.Drawing.Size(939, 461);
            this.crvHDB.TabIndex = 0;
            // 
            // frmInHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 461);
            this.Controls.Add(this.crvHDB);
            this.Name = "frmInHDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Hóa Đơn Bán";
            this.Load += new System.EventHandler(this.frmInHDB_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvHDB;
        private CrystalReportHDB CrystalReportHDB1;
    }
}