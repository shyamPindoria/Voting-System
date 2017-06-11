﻿namespace Assignment3_Voting_System
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.resultGridView = new System.Windows.Forms.DataGridView();
            this.ResultsOverviewGroupBox = new System.Windows.Forms.GroupBox();
            this.resultsGroupBos = new System.Windows.Forms.GroupBox();
            this.visualPresentationGroupBox = new System.Windows.Forms.GroupBox();
            this.graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.exportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).BeginInit();
            this.ResultsOverviewGroupBox.SuspendLayout();
            this.visualPresentationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
            this.SuspendLayout();
            // 
            // resultGridView
            // 
            this.resultGridView.AllowUserToAddRows = false;
            this.resultGridView.AllowUserToDeleteRows = false;
            this.resultGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGridView.Location = new System.Drawing.Point(4, 17);
            this.resultGridView.Margin = new System.Windows.Forms.Padding(2);
            this.resultGridView.Name = "resultGridView";
            this.resultGridView.ReadOnly = true;
            this.resultGridView.RowTemplate.Height = 24;
            this.resultGridView.Size = new System.Drawing.Size(530, 397);
            this.resultGridView.TabIndex = 0;
            // 
            // ResultsOverviewGroupBox
            // 
            this.ResultsOverviewGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsOverviewGroupBox.Controls.Add(this.resultGridView);
            this.ResultsOverviewGroupBox.Location = new System.Drawing.Point(9, 10);
            this.ResultsOverviewGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.ResultsOverviewGroupBox.Name = "ResultsOverviewGroupBox";
            this.ResultsOverviewGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.ResultsOverviewGroupBox.Size = new System.Drawing.Size(538, 419);
            this.ResultsOverviewGroupBox.TabIndex = 1;
            this.ResultsOverviewGroupBox.TabStop = false;
            this.ResultsOverviewGroupBox.Text = "Results Overview";
            // 
            // resultsGroupBos
            // 
            this.resultsGroupBos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resultsGroupBos.Location = new System.Drawing.Point(9, 434);
            this.resultsGroupBos.Margin = new System.Windows.Forms.Padding(2);
            this.resultsGroupBos.Name = "resultsGroupBos";
            this.resultsGroupBos.Padding = new System.Windows.Forms.Padding(2);
            this.resultsGroupBos.Size = new System.Drawing.Size(538, 102);
            this.resultsGroupBos.TabIndex = 2;
            this.resultsGroupBos.TabStop = false;
            this.resultsGroupBos.Text = "Results";
            // 
            // visualPresentationGroupBox
            // 
            this.visualPresentationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.visualPresentationGroupBox.Controls.Add(this.graph);
            this.visualPresentationGroupBox.Location = new System.Drawing.Point(551, 10);
            this.visualPresentationGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.visualPresentationGroupBox.Name = "visualPresentationGroupBox";
            this.visualPresentationGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.visualPresentationGroupBox.Size = new System.Drawing.Size(291, 414);
            this.visualPresentationGroupBox.TabIndex = 3;
            this.visualPresentationGroupBox.TabStop = false;
            this.visualPresentationGroupBox.Text = "Visual Presentaion";
            // 
            // graph
            // 
            this.graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graph.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea1.Name = "ChartArea1";
            this.graph.ChartAreas.Add(chartArea1);
            this.graph.Location = new System.Drawing.Point(4, 17);
            this.graph.Margin = new System.Windows.Forms.Padding(2);
            this.graph.Name = "graph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graph.Series.Add(series1);
            this.graph.Size = new System.Drawing.Size(283, 397);
            this.graph.TabIndex = 0;
            this.graph.Text = "Result Graph";
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(762, 512);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 545);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.visualPresentationGroupBox);
            this.Controls.Add(this.resultsGroupBos);
            this.Controls.Add(this.ResultsOverviewGroupBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.Button exportButton;
    }
}