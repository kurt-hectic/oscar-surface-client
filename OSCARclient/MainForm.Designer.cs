namespace WMOOSCARClient
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblExcel = new System.Windows.Forms.Label();
            this.tbExcelName = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.tbXmlView = new System.Windows.Forms.TextBox();
            this.tbOutputDir = new System.Windows.Forms.TextBox();
            this.btnBrowserOutput = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblExcel
            // 
            resources.ApplyResources(this.lblExcel, "lblExcel");
            this.lblExcel.Name = "lblExcel";
            // 
            // tbExcelName
            // 
            resources.ApplyResources(this.tbExcelName, "tbExcelName");
            this.tbExcelName.Name = "tbExcelName";
            this.tbExcelName.TextChanged += new System.EventHandler(this.tbExcelName_TextChanged);
            // 
            // btnBrowser
            // 
            resources.ApplyResources(this.btnBrowser, "btnBrowser");
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnConvert
            // 
            resources.ApplyResources(this.btnConvert, "btnConvert");
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnSaveAs
            // 
            resources.ApplyResources(this.btnSaveAs, "btnSaveAs");
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // tbXmlView
            // 
            resources.ApplyResources(this.tbXmlView, "tbXmlView");
            this.tbXmlView.Name = "tbXmlView";
            this.tbXmlView.ReadOnly = true;
            // 
            // tbOutputDir
            // 
            resources.ApplyResources(this.tbOutputDir, "tbOutputDir");
            this.tbOutputDir.Name = "tbOutputDir";
            // 
            // btnBrowserOutput
            // 
            resources.ApplyResources(this.btnBrowserOutput, "btnBrowserOutput");
            this.btnBrowserOutput.Name = "btnBrowserOutput";
            this.btnBrowserOutput.UseVisualStyleBackColor = true;
            this.btnBrowserOutput.Click += new System.EventHandler(this.btnBrowserOutput_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowserOutput);
            this.Controls.Add(this.tbOutputDir);
            this.Controls.Add(this.tbXmlView);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.tbExcelName);
            this.Controls.Add(this.lblExcel);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExcel;
        private System.Windows.Forms.TextBox tbExcelName;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.TextBox tbXmlView;
        private System.Windows.Forms.TextBox tbOutputDir;
        private System.Windows.Forms.Button btnBrowserOutput;
        private System.Windows.Forms.Label label2;
    }
}

