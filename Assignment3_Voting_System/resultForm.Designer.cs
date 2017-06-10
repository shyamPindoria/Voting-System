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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.resultGridView.Location = new System.Drawing.Point(5, 21);
            this.resultGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resultGridView.Name = "resultGridView";
            this.resultGridView.RowTemplate.Height = 24;
            this.resultGridView.Size = new System.Drawing.Size(583, 489);
            this.resultGridView.TabIndex = 0;
            // 
            // ResultsOverviewGroupBox
            // 
            this.ResultsOverviewGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsOverviewGroupBox.AutoSize = true;
            this.ResultsOverviewGroupBox.Controls.Add(this.resultGridView);
            this.ResultsOverviewGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ResultsOverviewGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResultsOverviewGroupBox.Name = "ResultsOverviewGroupBox";
            this.ResultsOverviewGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResultsOverviewGroupBox.Size = new System.Drawing.Size(595, 516);
            this.ResultsOverviewGroupBox.TabIndex = 1;
            this.ResultsOverviewGroupBox.TabStop = false;
            this.ResultsOverviewGroupBox.Text = "Results Overview";
            // 
            // resultsGroupBos
            // 
            this.resultsGroupBos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resultsGroupBos.Location = new System.Drawing.Point(12, 534);
            this.resultsGroupBos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resultsGroupBos.Name = "resultsGroupBos";
            this.resultsGroupBos.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resultsGroupBos.Size = new System.Drawing.Size(595, 126);
            this.resultsGroupBos.TabIndex = 2;
            this.resultsGroupBos.TabStop = false;
            this.resultsGroupBos.Text = "Results";
            // 
            // visualPresentationGroupBox
            // 
            this.visualPresentationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.visualPresentationGroupBox.Controls.Add(this.graph);
            this.visualPresentationGroupBox.Location = new System.Drawing.Point(613, 12);
            this.visualPresentationGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.visualPresentationGroupBox.Name = "visualPresentationGroupBox";
            this.visualPresentationGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.visualPresentationGroupBox.Size = new System.Drawing.Size(509, 510);
            this.visualPresentationGroupBox.TabIndex = 3;
            this.visualPresentationGroupBox.TabStop = false;
            this.visualPresentationGroupBox.Text = "Visual Presentaion";
            // 
            // graph
            // 
            this.graph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.graph.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.Name = "ChartArea1";
            this.graph.ChartAreas.Add(chartArea4);
            this.graph.Location = new System.Drawing.Point(5, 18);
            this.graph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graph.Name = "graph";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.graph.Series.Add(series4);
            this.graph.Size = new System.Drawing.Size(483, 486);
            this.graph.TabIndex = 0;
            this.graph.Text = "Result Graph";
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 671);
            this.Controls.Add(this.visualPresentationGroupBox);
            this.Controls.Add(this.resultsGroupBos);
            this.Controls.Add(this.ResultsOverviewGroupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ResultForm";
            this.Text = "Voting System";
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).EndInit();
            this.ResultsOverviewGroupBox.ResumeLayout(false);
            this.visualPresentationGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resultGridView;
        private System.Windows.Forms.GroupBox ResultsOverviewGroupBox;
        private System.Windows.Forms.GroupBox resultsGroupBos;
        private System.Windows.Forms.GroupBox visualPresentationGroupBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart graph;
    }
}