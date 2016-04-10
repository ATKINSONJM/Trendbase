namespace Trenbase.Interface
{
    partial class form_trendbase
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
            this.tc_graphArea = new System.Windows.Forms.TabControl();
            this.tp_SSAS = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_SQLServerAnalyticalServices = new System.Windows.Forms.Button();
            this.btn_AzureMachineLearning = new System.Windows.Forms.Button();
            this.bnt_ownAlgorithm = new System.Windows.Forms.Button();
            this.btn_exportTrends = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.tc_graphArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_graphArea
            // 
            this.tc_graphArea.Controls.Add(this.tp_SSAS);
            this.tc_graphArea.Controls.Add(this.tabPage2);
            this.tc_graphArea.Controls.Add(this.tabPage3);
            this.tc_graphArea.Location = new System.Drawing.Point(309, 0);
            this.tc_graphArea.Name = "tc_graphArea";
            this.tc_graphArea.SelectedIndex = 0;
            this.tc_graphArea.Size = new System.Drawing.Size(695, 535);
            this.tc_graphArea.TabIndex = 0;
            // 
            // tp_SSAS
            // 
            this.tp_SSAS.Location = new System.Drawing.Point(4, 25);
            this.tp_SSAS.Name = "tp_SSAS";
            this.tp_SSAS.Padding = new System.Windows.Forms.Padding(3);
            this.tp_SSAS.Size = new System.Drawing.Size(687, 506);
            this.tp_SSAS.TabIndex = 0;
            this.tp_SSAS.Text = "tabPage1";
            this.tp_SSAS.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(687, 506);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tp_AML";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(687, 506);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tp_TB";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_SQLServerAnalyticalServices
            // 
            this.btn_SQLServerAnalyticalServices.Location = new System.Drawing.Point(13, 35);
            this.btn_SQLServerAnalyticalServices.Name = "btn_SQLServerAnalyticalServices";
            this.btn_SQLServerAnalyticalServices.Size = new System.Drawing.Size(290, 70);
            this.btn_SQLServerAnalyticalServices.TabIndex = 1;
            this.btn_SQLServerAnalyticalServices.Text = "SQL Server Analytical Services";
            this.btn_SQLServerAnalyticalServices.UseVisualStyleBackColor = true;
            this.btn_SQLServerAnalyticalServices.Click += new System.EventHandler(this.btn_SQLServerAnalyticalServices_Click);
            // 
            // btn_AzureMachineLearning
            // 
            this.btn_AzureMachineLearning.Location = new System.Drawing.Point(12, 126);
            this.btn_AzureMachineLearning.Name = "btn_AzureMachineLearning";
            this.btn_AzureMachineLearning.Size = new System.Drawing.Size(290, 70);
            this.btn_AzureMachineLearning.TabIndex = 2;
            this.btn_AzureMachineLearning.Text = "Azure Machine Learning";
            this.btn_AzureMachineLearning.UseVisualStyleBackColor = true;
            this.btn_AzureMachineLearning.Click += new System.EventHandler(this.btn_AzureMachineLearning_Click);
            // 
            // bnt_ownAlgorithm
            // 
            this.bnt_ownAlgorithm.Location = new System.Drawing.Point(13, 216);
            this.bnt_ownAlgorithm.Name = "bnt_ownAlgorithm";
            this.bnt_ownAlgorithm.Size = new System.Drawing.Size(290, 70);
            this.bnt_ownAlgorithm.TabIndex = 3;
            this.bnt_ownAlgorithm.Text = "My Own Algorithm";
            this.bnt_ownAlgorithm.UseVisualStyleBackColor = true;
            this.bnt_ownAlgorithm.Click += new System.EventHandler(this.bnt_ownAlgorithm_Click);
            // 
            // btn_exportTrends
            // 
            this.btn_exportTrends.Location = new System.Drawing.Point(12, 311);
            this.btn_exportTrends.Name = "btn_exportTrends";
            this.btn_exportTrends.Size = new System.Drawing.Size(290, 70);
            this.btn_exportTrends.TabIndex = 4;
            this.btn_exportTrends.Text = "Export Trends";
            this.btn_exportTrends.UseVisualStyleBackColor = true;
            this.btn_exportTrends.Click += new System.EventHandler(this.btn_exportTrends_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(12, 405);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(290, 70);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(12, 544);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(52, 17);
            this.lbl_status.TabIndex = 6;
            this.lbl_status.Text = "label1";
            // 
            // form_trendbase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 570);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_exportTrends);
            this.Controls.Add(this.bnt_ownAlgorithm);
            this.Controls.Add(this.btn_AzureMachineLearning);
            this.Controls.Add(this.btn_SQLServerAnalyticalServices);
            this.Controls.Add(this.tc_graphArea);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "form_trendbase";
            this.Text = "Trendbase";
            this.tc_graphArea.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tc_graphArea;
        private System.Windows.Forms.TabPage tp_SSAS;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_SQLServerAnalyticalServices;
        private System.Windows.Forms.Button btn_AzureMachineLearning;
        private System.Windows.Forms.Button bnt_ownAlgorithm;
        private System.Windows.Forms.Button btn_exportTrends;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label lbl_status;
    }
}

