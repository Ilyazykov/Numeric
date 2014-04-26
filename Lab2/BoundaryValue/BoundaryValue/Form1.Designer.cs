namespace BoundaryValue
{
    partial class Form1
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
            this.btnToDo = new System.Windows.Forms.Button();
            this.numericUpDownNumberOfSteps = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonTestTwo = new System.Windows.Forms.RadioButton();
            this.radioButtonTestOne = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.labelMaxError = new System.Windows.Forms.Label();
            this.labelMaxErrorValue = new System.Windows.Forms.Label();
            this.labelPointMaxError = new System.Windows.Forms.Label();
            this.labelPointMaxErrorValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfSteps)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // graph
            // 
            chartArea1.Name = "ChartArea1";
            this.graph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graph.Legends.Add(legend1);
            this.graph.Location = new System.Drawing.Point(118, 12);
            this.graph.Name = "graph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.LegendText = "Обычный шаг";
            series1.Name = "series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.LegendText = "Половинный шаг";
            series2.Name = "series2";
            this.graph.Series.Add(series1);
            this.graph.Series.Add(series2);
            this.graph.Size = new System.Drawing.Size(881, 465);
            this.graph.TabIndex = 0;
            this.graph.Text = "chart";
            // 
            // btnToDo
            // 
            this.btnToDo.Location = new System.Drawing.Point(12, 199);
            this.btnToDo.Name = "btnToDo";
            this.btnToDo.Size = new System.Drawing.Size(97, 41);
            this.btnToDo.TabIndex = 1;
            this.btnToDo.Text = "Сделать хорошо";
            this.btnToDo.UseVisualStyleBackColor = true;
            this.btnToDo.Click += new System.EventHandler(this.btnToDo_Click);
            // 
            // numericUpDownNumberOfSteps
            // 
            this.numericUpDownNumberOfSteps.Location = new System.Drawing.Point(12, 33);
            this.numericUpDownNumberOfSteps.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownNumberOfSteps.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNumberOfSteps.Name = "numericUpDownNumberOfSteps";
            this.numericUpDownNumberOfSteps.Size = new System.Drawing.Size(97, 20);
            this.numericUpDownNumberOfSteps.TabIndex = 2;
            this.numericUpDownNumberOfSteps.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownNumberOfSteps.ValueChanged += new System.EventHandler(this.numericUpDownNumberOfSteps_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonTestTwo);
            this.groupBox1.Controls.Add(this.radioButtonTestOne);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 134);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Задача";
            // 
            // radioButtonTestTwo
            // 
            this.radioButtonTestTwo.AutoSize = true;
            this.radioButtonTestTwo.Location = new System.Drawing.Point(7, 68);
            this.radioButtonTestTwo.Name = "radioButtonTestTwo";
            this.radioButtonTestTwo.Size = new System.Drawing.Size(82, 17);
            this.radioButtonTestTwo.TabIndex = 2;
            this.radioButtonTestTwo.Text = "Тестовая 2";
            this.radioButtonTestTwo.UseVisualStyleBackColor = true;
            this.radioButtonTestTwo.CheckedChanged += new System.EventHandler(this.radioButtonTestTwo_CheckedChanged);
            // 
            // radioButtonTestOne
            // 
            this.radioButtonTestOne.AutoSize = true;
            this.radioButtonTestOne.Location = new System.Drawing.Point(7, 44);
            this.radioButtonTestOne.Name = "radioButtonTestOne";
            this.radioButtonTestOne.Size = new System.Drawing.Size(82, 17);
            this.radioButtonTestOne.TabIndex = 1;
            this.radioButtonTestOne.Text = "Тестовая 1";
            this.radioButtonTestOne.UseVisualStyleBackColor = true;
            this.radioButtonTestOne.CheckedChanged += new System.EventHandler(this.radioButtonTestOne_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Основная";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButtonMain_CheckedChanged);
            // 
            // labelMaxError
            // 
            this.labelMaxError.AutoSize = true;
            this.labelMaxError.Location = new System.Drawing.Point(128, 487);
            this.labelMaxError.Name = "labelMaxError";
            this.labelMaxError.Size = new System.Drawing.Size(128, 13);
            this.labelMaxError.TabIndex = 4;
            this.labelMaxError.Text = "Максимальная ошибка:";
            // 
            // labelMaxErrorValue
            // 
            this.labelMaxErrorValue.AutoSize = true;
            this.labelMaxErrorValue.Location = new System.Drawing.Point(262, 487);
            this.labelMaxErrorValue.Name = "labelMaxErrorValue";
            this.labelMaxErrorValue.Size = new System.Drawing.Size(13, 13);
            this.labelMaxErrorValue.TabIndex = 5;
            this.labelMaxErrorValue.Text = "0";
            // 
            // labelPointMaxError
            // 
            this.labelPointMaxError.AutoSize = true;
            this.labelPointMaxError.Location = new System.Drawing.Point(128, 500);
            this.labelPointMaxError.Name = "labelPointMaxError";
            this.labelPointMaxError.Size = new System.Drawing.Size(44, 13);
            this.labelPointMaxError.TabIndex = 6;
            this.labelPointMaxError.Text = "в точке";
            // 
            // labelPointMaxErrorValue
            // 
            this.labelPointMaxErrorValue.AutoSize = true;
            this.labelPointMaxErrorValue.Location = new System.Drawing.Point(178, 500);
            this.labelPointMaxErrorValue.Name = "labelPointMaxErrorValue";
            this.labelPointMaxErrorValue.Size = new System.Drawing.Size(13, 13);
            this.labelPointMaxErrorValue.TabIndex = 7;
            this.labelPointMaxErrorValue.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Кол-во интервалов";
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGrid.Location = new System.Drawing.Point(851, 71);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(280, 406);
            this.dataGrid.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "№ узла";
            this.Column1.Name = "Column1";
            this.Column1.Width = 35;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "x";
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "u(x)";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "v(x)";
            this.Column4.Name = "Column4";
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "|u(x)-v(x)|";
            this.Column5.Name = "Column5";
            this.Column5.Width = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 522);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPointMaxErrorValue);
            this.Controls.Add(this.labelPointMaxError);
            this.Controls.Add(this.labelMaxErrorValue);
            this.Controls.Add(this.labelMaxError);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numericUpDownNumberOfSteps);
            this.Controls.Add(this.btnToDo);
            this.Controls.Add(this.graph);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfSteps)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graph;
        private System.Windows.Forms.Button btnToDo;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfSteps;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonTestTwo;
        private System.Windows.Forms.RadioButton radioButtonTestOne;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label labelMaxError;
        private System.Windows.Forms.Label labelMaxErrorValue;
        private System.Windows.Forms.Label labelPointMaxError;
        private System.Windows.Forms.Label labelPointMaxErrorValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}

