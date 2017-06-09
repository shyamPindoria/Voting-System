namespace Assignment3_Voting_System
{
    partial class ResultForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.resultGridView = new System.Windows.Forms.DataGridView();
            this.ResultsOverviewGroupBox = new System.Windows.Forms.GroupBox();
            this.resultsGroupBos = new System.Windows.Forms.GroupBox();
            this.visualPresentationGroupBox = new System.Windows.Forms.GroupBox();
            this.graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).BeginInit();
            this.ResultsOverviewGroupBox.SuspendLayout();
            this.visualPresentationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
            this.SuspendLayout();
            // 
            // resultGridView
            // 
            this.resultGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGridView.Location = new System.Drawing.Point(6, 21);
            this.resultGridView.Name = "resultGridView";
            this.resultGridView.RowTemplate.Height = 24;
            this.resultGridView.Size = new System.Drawing.Size(583, 489);
            this.resultGridView.TabIndex = 0;
            // 
            // ResultsOverviewGroupBox
            // 
            this.ResultsOverviewGroupBox.Controls.Add(this.resultGridView);
            this.ResultsOverviewGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ResultsOverviewGroupBox.Name = "ResultsOverviewGroupBox";
            this.ResultsOverviewGroupBox.Size = new System.Drawing.Size(595, 516);
            this.ResultsOverviewGroupBox.TabIndex = 1;
            this.ResultsOverviewGroupBox.TabStop = false;
            this.ResultsOverviewGroupBox.Text = "Results Overview";
            // 
            // resultsGroupBos
            // 
            this.resultsGroupBos.Location = new System.Drawing.Point(12, 534);
            this.resultsGroupBos.Name = "resultsGroupBos";
            this.resultsGroupBos.Size = new System.Drawing.Size(595, 125);
            this.resultsGroupBos.TabIndex = 2;
            this.resultsGroupBos.TabStop = false;
            this.resultsGroupBos.Text = "Results";
            // 
            // visualPresentationGroupBox
            // 
            this.visualPresentationGroupBox.Controls.Add(this.graph);
            this.visualPresentationGroupBox.Location = new System.Drawing.Point(613, 12);
            this.visualPresentationGroupBox.Name = "visualPresentationGroupBox";
            this.visualPresentationGroupBox.Size = new System.Drawing.Size(510, 510);
            this.visualPresentationGroupBox.TabIndex = 3;
            this.visualPresentationGroupBox.TabStop = false;
            this.visualPresentationGroupBox.Text = "visual Presentaion";
            // 
            // graph
            // 
            this.graph.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea2.Name = "ChartArea1";
            this.graph.ChartAreas.Add(chartArea2);
            this.graph.Location = new System.Drawing.Point(6, 18);
            this.graph.Name = "graph";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.graph.Series.Add(series2);
            this.graph.Size = new System.Drawing.Size(482, 486);
            this.graph.TabIndex = 0;
            this.graph.Text = "Result Graph";
            // 
            // resultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 671);
            this.Controls.Add(this.visualPresentationGroupBox);
            this.Controls.Add(this.resultsGroupBos);
            this.Controls.Add(this.ResultsOverviewGroupBox);
            this.Name = "resultForm";
            this.Text = "Voting System";
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).EndInit();
            this.ResultsOverviewGroupBox.ResumeLayout(false);
            this.visualPresentationGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resultGridView;
        private System.Windows.Forms.GroupBox ResultsOverviewGroupBox;
        private System.Windows.Forms.GroupBox resultsGroupBos;
        private System.Windows.Forms.GroupBox visualPresentationGroupBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart graph;
    }
}