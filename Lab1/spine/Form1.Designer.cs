namespace spine
{
    partial class SplineForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.labelErrorValue = new System.Windows.Forms.Label();
            this.dataGridValues = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxFunctionSeacher = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.likeAsOriginalFunctionBorder = new System.Windows.Forms.RadioButton();
            this.naturalBorders = new System.Windows.Forms.RadioButton();
            this.labelFirstDifferentialValue = new System.Windows.Forms.Label();
            this.labelFirstDifferential = new System.Windows.Forms.Label();
            this.labelSecondDifferentialValue = new System.Windows.Forms.Label();
            this.labelSecondDifferential = new System.Windows.Forms.Label();
            this.dataGridSplineCoef = new System.Windows.Forms.DataGridView();
            this.a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelErrorPoint = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelFirstDifferentialPoint = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSecondDifferentialPoint = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridValues)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSplineCoef)).BeginInit();
            this.SuspendLayout();
            // 
            // graph
            // 
            chartArea1.Name = "ChartArea1";
            this.graph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graph.Legends.Add(legend1);
            this.graph.Location = new System.Drawing.Point(162, 19);
            this.graph.Name = "graph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "real";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "aproximation";
            this.graph.Series.Add(series1);
            this.graph.Series.Add(series2);
            this.graph.Size = new System.Drawing.Size(892, 478);
            this.graph.TabIndex = 0;
            this.graph.Text = "chart";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1110, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(1110, 77);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(1179, 77);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(63, 20);
            this.numericUpDown2.TabIndex = 3;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1107, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Границы";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(1110, 38);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(132, 20);
            this.numericUpDown3.TabIndex = 5;
            this.numericUpDown3.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1107, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Кол-во опорных точек";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(238, 500);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(128, 13);
            this.labelError.TabIndex = 7;
            this.labelError.Text = "Максимальная ошибка:";
            // 
            // labelErrorValue
            // 
            this.labelErrorValue.AutoSize = true;
            this.labelErrorValue.Location = new System.Drawing.Point(238, 517);
            this.labelErrorValue.Name = "labelErrorValue";
            this.labelErrorValue.Size = new System.Drawing.Size(13, 13);
            this.labelErrorValue.TabIndex = 8;
            this.labelErrorValue.Text = "0";
            // 
            // dataGridValues
            // 
            this.dataGridValues.AllowUserToAddRows = false;
            this.dataGridValues.AllowUserToDeleteRows = false;
            this.dataGridValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridValues.Location = new System.Drawing.Point(12, 19);
            this.dataGridValues.Name = "dataGridValues";
            this.dataGridValues.ReadOnly = true;
            this.dataGridValues.RowHeadersWidth = 4;
            this.dataGridValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridValues.Size = new System.Drawing.Size(144, 478);
            this.dataGridValues.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "x";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "y";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 60;
            // 
            // comboBoxFunctionSeacher
            // 
            this.comboBoxFunctionSeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFunctionSeacher.FormattingEnabled = true;
            this.comboBoxFunctionSeacher.Items.AddRange(new object[] {
            "testFunction",
            "sinx",
            "f(x)",
            "f(x)+cos(10x)",
            "f(x)+cos(100x)"});
            this.comboBoxFunctionSeacher.Location = new System.Drawing.Point(1110, 103);
            this.comboBoxFunctionSeacher.Name = "comboBoxFunctionSeacher";
            this.comboBoxFunctionSeacher.Size = new System.Drawing.Size(132, 21);
            this.comboBoxFunctionSeacher.TabIndex = 10;
            this.comboBoxFunctionSeacher.SelectedIndexChanged += new System.EventHandler(this.functionSeacher_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.likeAsOriginalFunctionBorder);
            this.groupBox1.Controls.Add(this.naturalBorders);
            this.groupBox1.Location = new System.Drawing.Point(1060, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 38);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ГУ";
            // 
            // likeAsOriginalFunctionBorder
            // 
            this.likeAsOriginalFunctionBorder.AutoSize = true;
            this.likeAsOriginalFunctionBorder.Location = new System.Drawing.Point(111, 15);
            this.likeAsOriginalFunctionBorder.Name = "likeAsOriginalFunctionBorder";
            this.likeAsOriginalFunctionBorder.Size = new System.Drawing.Size(100, 17);
            this.likeAsOriginalFunctionBorder.TabIndex = 1;
            this.likeAsOriginalFunctionBorder.Text = "Исходной ф-ии";
            this.likeAsOriginalFunctionBorder.UseVisualStyleBackColor = true;
            this.likeAsOriginalFunctionBorder.CheckedChanged += new System.EventHandler(this.likeAsOriginalFunctionBorder_CheckedChanged);
            // 
            // naturalBorders
            // 
            this.naturalBorders.AutoSize = true;
            this.naturalBorders.Checked = true;
            this.naturalBorders.Location = new System.Drawing.Point(7, 15);
            this.naturalBorders.Name = "naturalBorders";
            this.naturalBorders.Size = new System.Drawing.Size(98, 17);
            this.naturalBorders.TabIndex = 0;
            this.naturalBorders.TabStop = true;
            this.naturalBorders.Text = "Естественные";
            this.naturalBorders.UseVisualStyleBackColor = true;
            this.naturalBorders.CheckedChanged += new System.EventHandler(this.naturalBorders_CheckedChanged);
            // 
            // labelFirstDifferentialValue
            // 
            this.labelFirstDifferentialValue.AutoSize = true;
            this.labelFirstDifferentialValue.Location = new System.Drawing.Point(439, 517);
            this.labelFirstDifferentialValue.Name = "labelFirstDifferentialValue";
            this.labelFirstDifferentialValue.Size = new System.Drawing.Size(13, 13);
            this.labelFirstDifferentialValue.TabIndex = 13;
            this.labelFirstDifferentialValue.Text = "0";
            // 
            // labelFirstDifferential
            // 
            this.labelFirstDifferential.AutoSize = true;
            this.labelFirstDifferential.Location = new System.Drawing.Point(439, 500);
            this.labelFirstDifferential.Name = "labelFirstDifferential";
            this.labelFirstDifferential.Size = new System.Drawing.Size(212, 13);
            this.labelFirstDifferential.TabIndex = 12;
            this.labelFirstDifferential.Text = "Максимальная ошибка 1й производной:";
            // 
            // labelSecondDifferentialValue
            // 
            this.labelSecondDifferentialValue.AutoSize = true;
            this.labelSecondDifferentialValue.Location = new System.Drawing.Point(707, 517);
            this.labelSecondDifferentialValue.Name = "labelSecondDifferentialValue";
            this.labelSecondDifferentialValue.Size = new System.Drawing.Size(13, 13);
            this.labelSecondDifferentialValue.TabIndex = 15;
            this.labelSecondDifferentialValue.Text = "0";
            // 
            // labelSecondDifferential
            // 
            this.labelSecondDifferential.AutoSize = true;
            this.labelSecondDifferential.Location = new System.Drawing.Point(707, 500);
            this.labelSecondDifferential.Name = "labelSecondDifferential";
            this.labelSecondDifferential.Size = new System.Drawing.Size(212, 13);
            this.labelSecondDifferential.TabIndex = 14;
            this.labelSecondDifferential.Text = "Максимальная ошибка 2й производной:";
            // 
            // dataGridSplineCoef
            // 
            this.dataGridSplineCoef.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSplineCoef.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.a,
            this.b,
            this.c,
            this.d,
            this.x});
            this.dataGridSplineCoef.Location = new System.Drawing.Point(1067, 203);
            this.dataGridSplineCoef.Name = "dataGridSplineCoef";
            this.dataGridSplineCoef.RowHeadersWidth = 4;
            this.dataGridSplineCoef.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridSplineCoef.Size = new System.Drawing.Size(204, 294);
            this.dataGridSplineCoef.TabIndex = 16;
            // 
            // a
            // 
            this.a.HeaderText = "a";
            this.a.Name = "a";
            this.a.ReadOnly = true;
            this.a.Width = 40;
            // 
            // b
            // 
            this.b.HeaderText = "b";
            this.b.Name = "b";
            this.b.ReadOnly = true;
            this.b.Width = 40;
            // 
            // c
            // 
            this.c.HeaderText = "c";
            this.c.Name = "c";
            this.c.ReadOnly = true;
            this.c.Width = 40;
            // 
            // d
            // 
            this.d.HeaderText = "d";
            this.d.Name = "d";
            this.d.ReadOnly = true;
            this.d.Width = 40;
            // 
            // x
            // 
            this.x.HeaderText = "x";
            this.x.Name = "x";
            this.x.ReadOnly = true;
            this.x.Width = 40;
            // 
            // labelErrorPoint
            // 
            this.labelErrorPoint.AutoSize = true;
            this.labelErrorPoint.Location = new System.Drawing.Point(238, 547);
            this.labelErrorPoint.Name = "labelErrorPoint";
            this.labelErrorPoint.Size = new System.Drawing.Size(13, 13);
            this.labelErrorPoint.TabIndex = 18;
            this.labelErrorPoint.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 530);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "в точке";
            // 
            // labelFirstDifferentialPoint
            // 
            this.labelFirstDifferentialPoint.AutoSize = true;
            this.labelFirstDifferentialPoint.Location = new System.Drawing.Point(439, 547);
            this.labelFirstDifferentialPoint.Name = "labelFirstDifferentialPoint";
            this.labelFirstDifferentialPoint.Size = new System.Drawing.Size(13, 13);
            this.labelFirstDifferentialPoint.TabIndex = 20;
            this.labelFirstDifferentialPoint.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(439, 530);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "в точке";
            // 
            // labelSecondDifferentialPoint
            // 
            this.labelSecondDifferentialPoint.AutoSize = true;
            this.labelSecondDifferentialPoint.Location = new System.Drawing.Point(707, 547);
            this.labelSecondDifferentialPoint.Name = "labelSecondDifferentialPoint";
            this.labelSecondDifferentialPoint.Size = new System.Drawing.Size(13, 13);
            this.labelSecondDifferentialPoint.TabIndex = 22;
            this.labelSecondDifferentialPoint.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(707, 530);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "в точке";
            // 
            // SplineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 563);
            this.Controls.Add(this.labelSecondDifferentialPoint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelFirstDifferentialPoint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelErrorPoint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridSplineCoef);
            this.Controls.Add(this.labelSecondDifferentialValue);
            this.Controls.Add(this.labelSecondDifferential);
            this.Controls.Add(this.labelFirstDifferentialValue);
            this.Controls.Add(this.labelFirstDifferential);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxFunctionSeacher);
            this.Controls.Add(this.dataGridValues);
            this.Controls.Add(this.labelErrorValue);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.graph);
            this.Name = "SplineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spline";
            this.Load += new System.EventHandler(this.SplineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridValues)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSplineCoef)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graph;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelErrorValue;
        private System.Windows.Forms.DataGridView dataGridValues;
        private System.Windows.Forms.ComboBox comboBoxFunctionSeacher;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton likeAsOriginalFunctionBorder;
        private System.Windows.Forms.RadioButton naturalBorders;
        private System.Windows.Forms.Label labelFirstDifferentialValue;
        private System.Windows.Forms.Label labelFirstDifferential;
        private System.Windows.Forms.Label labelSecondDifferentialValue;
        private System.Windows.Forms.Label labelSecondDifferential;
        private System.Windows.Forms.DataGridView dataGridSplineCoef;
        private System.Windows.Forms.DataGridViewTextBoxColumn a;
        private System.Windows.Forms.DataGridViewTextBoxColumn b;
        private System.Windows.Forms.DataGridViewTextBoxColumn c;
        private System.Windows.Forms.DataGridViewTextBoxColumn d;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label labelErrorPoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelFirstDifferentialPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelSecondDifferentialPoint;
        private System.Windows.Forms.Label label7;
    }
}

