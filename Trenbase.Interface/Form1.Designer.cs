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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tc_graphArea = new System.Windows.Forms.TabControl();
            this.tp_SSAS = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart_AzureMachineLearning = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_SQLServerAnalyticalServices = new System.Windows.Forms.Button();
            this.btn_AzureMachineLearning = new System.Windows.Forms.Button();
            this.bnt_ownAlgorithm = new System.Windows.Forms.Button();
            this.btn_exportTrends = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.chart_myOwnAlgorithm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_SQLServerAnalyticalServices = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tc_graphArea.SuspendLayout();
            this.tp_SSAS.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_AzureMachineLearning)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_myOwnAlgorithm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_SQLServerAnalyticalServices)).BeginInit();
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
            this.tp_SSAS.Controls.Add(this.chart_SQLServerAnalyticalServices);
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
            this.tabPage2.Controls.Add(this.chart_AzureMachineLearning);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(687, 506);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart_AzureMachineLearning
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_AzureMachineLearning.ChartAreas.Add(chartArea2);
            this.chart_AzureMachineLearning.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart_AzureMachineLearning.Legends.Add(legend2);
            this.chart_AzureMachineLearning.Location = new System.Drawing.Point(3, 3);
            this.chart_AzureMachineLearning.Name = "chart_AzureMachineLearning";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_AzureMachineLearning.Series.Add(series2);
            this.chart_AzureMachineLearning.Size = new System.Drawing.Size(681, 500);
            this.chart_AzureMachineLearning.TabIndex = 0;
            this.chart_AzureMachineLearning.Text = "Azure Machine Learning";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chart_myOwnAlgorithm);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(687, 506);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
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
            // chart_myOwnAlgorithm
            // 
            chartArea3.Name = "ChartArea1";
            this.chart_myOwnAlgorithm.ChartAreas.Add(chartArea3);
            this.chart_myOwnAlgorithm.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chart_myOwnAlgorithm.Legends.Add(legend3);
            this.chart_myOwnAlgorithm.Location = new System.Drawing.Point(3, 3);
            this.chart_myOwnAlgorithm.Name = "chart_myOwnAlgorithm";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart_myOwnAlgorithm.Series.Add(series3);
            this.chart_myOwnAlgorithm.Size = new System.Drawing.Size(681, 500);
            this.chart_myOwnAlgorithm.TabIndex = 0;
            this.chart_myOwnAlgorithm.Text = "My Own Algorithm";
            // 
            // chart_SQLServerAnalyticalServices
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_SQLServerAnalyticalServices.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_SQLServerAnalyticalServices.Legends.Add(legend1);
            this.chart_SQLServerAnalyticalServices.Location = new System.Drawing.Point(6, 3);
            this.chart_SQLServerAnalyticalServices.Name = "chart_SQLServerAnalyticalServices";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_SQLServerAnalyticalServices.Series.Add(series1);
            this.chart_SQLServerAnalyticalServices.Size = new System.Drawing.Size(450, 424);
            this.chart_SQLServerAnalyticalServices.TabIndex = 0;
            this.chart_SQLServerAnalyticalServices.Text = "chart1";
            // 
            // form_trendbase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 570);
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
            this.tp_SSAS.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_AzureMachineLearning)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_myOwnAlgorithm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_SQLServerAnalyticalServices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_graphArea;
        private System.Windows.Forms.TabPage tp_SSAS;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_SQLServerAnalyticalServices;
        private System.Windows.Forms.Button btn_AzureMachineLearning;
        private System.Windows.Forms.Button bnt_ownAlgorithm;
        private System.Windows.Forms.Button btn_exportTrends;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_AzureMachineLearning;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_myOwnAlgorithm;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart_SQLServerAnalyticalServices;
    }
}

