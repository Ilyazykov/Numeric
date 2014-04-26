using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CH_M3
{
    public partial class Form11 : Form
    {
        int N;
        int M;
        Task task;
      
        double[,] V;
        double[,] U;
        double[,] U_V;
        double[,] V_2;
        double E2, E3, E2_2;
        int Nst, Nst_2, GY;
        double[] area;
        Method method;
        double time1, time2;

        public Form11()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Table(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox3.Text));
            task = new TestTask9();
            GY = 1;
            comboBox1.SelectedIndex = 3;
            comboBox2.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            M=Convert.ToInt32(textBox3.Text);
            N=Convert.ToInt32(textBox4.Text);

            if ((M < 2) || (N < 2)) { MessageBox.Show("Неправильно задано разбиение", "Ошибка", MessageBoxButtons.OK); return; }

            double E1 = Convert.ToDouble(textBox2.Text);
            int Nmax = Convert.ToInt32(textBox1.Text);
            if ((E1 < 0) || (Nmax < 0)) { MessageBox.Show("Неправильно заданы условия остановки", "Ошибка", MessageBoxButtons.OK); return; }


            groupBox1.Enabled = true;


            if (comboBox1.SelectedIndex == 0)
            {
                method = new OverRelax(E1, Nmax, N, M, task, GY, 1.0);
            } 
            if (comboBox1.SelectedIndex == 1)
            {  
                double w = Convert.ToDouble(numericUpDown1.Value);
                method = new OverRelax(E1, Nmax, N, M, task, GY, w); 
            }
            if (comboBox1.SelectedIndex == 2)
            {
                method = new Yakobi(E1, Nmax, N, M, task, GY);
            }
            if (comboBox1.SelectedIndex == 3)
            {
                if (checkBox2.Checked) method = new MinDisNoRect(E1, Nmax, N, M, task, GY);
                else method = new MinDiscrepancy(E1, Nmax, N, M, task, GY);
            }

            V = method.Forward(ref E2, ref Nst, ref time1);
            area=task.area();

            if (task.test())
            {
                double h = (area[1] - area[0]) / N;
                double k = (area[3] - area[2]) / M;
                 E3=0;
                 U = new double[N + 1, M + 1];
                 U_V = new double[N + 1, M + 1];


                 if (checkBox2.Checked) 
                 {
                    int n2 = (int)(N / 2);
                    int m2 = (int)(M / 2);


                    for (int j = 0; j <= M; j++)
                        for (int i = n2; i <= N; i++)
                         {
                             U[i, j] = task.U(area[0] + i * h, area[2] + j * k);
                             U_V[i, j] = Math.Abs(U[i, j] - V[i, j]);
                             if (U_V[i, j] > E3) E3 = U_V[i, j];
                         }

                    for (int j = m2; j <= M; j++)
                        for (int i = 0; i <= n2; i++)
                        {
                            U[i, j] = task.U(area[0] + i * h, area[2] + j * k);
                            U_V[i, j] = Math.Abs(U[i, j] - V[i, j]);
                            if (U_V[i, j] > E3) E3 = U_V[i, j];
                        }

                 }
                 else
                     for (int i = 0; i <= N; i++)
                        for (int j = 0; j <= M; j++)
                        {
                            U[i, j] = task.U(area[0] + i * h, area[2] + j * k);
                            U_V[i, j] = Math.Abs(U[i, j] - V[i, j]);
                            if (U_V[i, j]>E3) E3 = U_V[i, j];
                        }

              label2.Text = Nst.ToString();
              label3.Text = E2.ToString();
              label9.Text = E3.ToString();
              label12.Text = "max|v(x,y)-u(x,y)|";
            }

            else
            {

                if (comboBox1.SelectedIndex == 0) method = new OverRelax(E1, Nmax, N, M, task, GY, 1.0); 
                
                if (comboBox1.SelectedIndex == 1)
                {
                    double w = Convert.ToDouble(numericUpDown1.Value);
                    method = new OverRelax(E1, Nmax, N, M, task, GY, w);
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    method = new Yakobi(E1, Nmax, N * 2, M * 2, task, GY);
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    if (checkBox2.Checked) method = new MinDisNoRect(E1, Nmax, 2 * N, 2 * M, task, GY);
                    else method = new MinDiscrepancy(E1, Nmax, 2*N, 2*M, task, GY);
                }

                V_2 = method.Forward(ref E2_2, ref Nst_2, ref time2);

                double h = (area[1] - area[0]) / N;
                double k = (area[3] - area[2]) / M;
                E3 = 0;
                
                U_V = new double[N + 1, M + 1];
                if (checkBox2.Checked)
                {
                    int n2 = (int)(N / 2);
                    int m2 = (int)(M / 2);


                    for (int j = 0; j <= M; j++)
                        for (int i = n2 + 1; i <= N; i++)
                        {
                            U_V[i, j] = Math.Abs(V_2[2 * i, 2 * j] - V[i, j]);
                            if (U_V[i, j] > E3) E3 = U_V[i, j];
                        }

                    for (int j = m2 + 1; j <= M; j++)
                        for (int i = 0; i <= n2; i++)
                        {
                            U_V[i, j] = Math.Abs(V_2[2 * i, 2 * j] - V[i, j]);
                            if (U_V[i, j] > E3) E3 = U_V[i, j];
                        }
                }
                else
                    for (int i = 0; i <= N; i++)
                        for (int j = 0; j <= M; j++)
                        {
                            U_V[i, j] = Math.Abs(V_2[2 * i, 2 * j] - V[i, j]);
                            if (U_V[i, j] > E3) E3 = U_V[i, j];
                        }

                
                label2.Text = Nst.ToString();
                label3.Text = E2.ToString();
                label9.Text = E3.ToString();
                label12.Text = "max|v(x,y)-v2(x,y)|";
            }
            radioButton3_CheckedChanged(this, e);

        }

        private void Table(int n, int m)
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn Column;
            Column = new DataGridViewTextBoxColumn();
            Column.Width = 60;
            dataGridView1.Columns.Add(Column);
            for (int i = 1; i <= n + 1; i++)
            {
                Column = new DataGridViewTextBoxColumn();
                Column.Width = 60;
                dataGridView1.Columns.Add(Column);
                dataGridView1.Columns[i].HeaderText = i - 1 + "";

            }
            dataGridView1.Rows.Add();
            for (int j = 1; j <= m + 1; j++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[j].HeaderCell.Value = m - j + 1 + "";

            }


            dataGridView1[0, 0].Value = "Y\\X";
            dataGridView1.Columns[0].HeaderText = "i";
            dataGridView1.Rows[0].HeaderCell.Value = "j";
        }

        private void VTable()
        {
            DataGridView dgv = dataGridView1;
            dgv.DefaultCellStyle.Format = "#,##0.###";

            double h = (area[1] - area[0]) / N;
            double k = (area[3] - area[2]) / M;

            if (dgv.Enabled == true)
            {
                Table(N, M);
                for (int i = 0; i <= N; i++)
                {
                    dgv[i + 1, 0].Value = area[0] + i * h;
                    for (int j = 0; j <= M; j++)
                    {
                        dgv[i + 1, M - j + 1].Value = V[i, j];
                        dgv[0, M - j + 1].Value = area[2] + j * k;
                    }
                }
            }
        }

        private void UTable()
        {
            DataGridView dgv = dataGridView1;
            dgv.DefaultCellStyle.Format = "#,##0.###";

            if (task.test())
            {
                if (dgv.Enabled == true)
                {
                    double h = (area[1] - area[0]) / N;
                    double k = (area[3] - area[2]) / M;
                    Table(N, M);

                    for (int i = 0; i <= N; i++)
                    {
                        dgv[i + 1, 0].Value = area[0] + i * h;
                        for (int j = 0; j <= M; j++)
                        {
                            dgv[i + 1, M - j + 1].Value = U[i, j];
                            dgv[0, M - j + 1].Value = area[2] + j * k;
                        }
                    }
                }
            }
            else
            {
                if (dgv.Enabled == true)
                {
                    double h = (area[1] - area[0]) / (2 * N);
                    double k = (area[3] - area[2]) / (2 * M);
                    Table(2 * N, 2 * M);

                    for (int i = 0; i <= 2 * N; i++)
                    {
                        dgv[i + 1, 0].Value = area[0] + i * h;
                        for (int j = 0; j <= 2 * M; j++)
                        {
                            dgv[i + 1, 2 * M - j + 1].Value = V_2[i, j];
                            dgv[0, 2 * M - j + 1].Value = area[2] + j * k;
                        }
                    }
                }
            }

        }

        private void U_VTable()
        {
            DataGridView dgv = dataGridView1;
            dgv.DefaultCellStyle.Format = "#.##0e+0";

            if (dgv.Enabled == true)
            {
                Table(N, M);

                double h = (area[1] - area[0]) / N;
                double k = (area[3] - area[2]) / M;
                for (int i = 0; i <= N; i++)
                {
                    dgv[i + 1, 0].Value = area[0] + i * h;
                    for (int j = 0; j <= M; j++)
                    {
                        dgv[i + 1, M - j + 1].Value = U_V[i, j];
                        dgv[0, M - j + 1].Value = area[2] + j * k;
                    }
                }
            }

                dgv.Columns[0].DefaultCellStyle.Format = "#,##0.###";
                dgv.Columns[1].DefaultCellStyle.Format = "#,##0.###";
                dgv.Columns[N+1].DefaultCellStyle.Format = "#,##0.###";

                dgv.Rows[0].DefaultCellStyle.Format = "#,##0.###";
                dgv.Rows[1].DefaultCellStyle.Format = "#,##0.###";
                dgv.Rows[M+1].DefaultCellStyle.Format = "#,##0.###";
           
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }


        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) VTable();
            if (radioButton4.Checked) UTable();
            if (radioButton5.Checked) U_VTable();
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked) GY = 0;
            if (radioButton8.Checked) GY = 1;
            if (radioButton9.Checked) GY = 2;
            if (radioButton10.Checked) GY = 3;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label11.Enabled = true;
                numericUpDown1.Enabled = false;
                numericUpDown1.Value = (Decimal)1.0;
                checkBox2.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label11.Enabled = true; 
                numericUpDown1.Enabled = true;
                checkBox2.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                label11.Enabled = false;
                numericUpDown1.Enabled = false;
                checkBox2.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 3) 
            { 
                label11.Enabled = false; 
                numericUpDown1.Enabled = false;
                checkBox2.Enabled = true; 
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                radioButton3.Text = "V[i]";
                radioButton4.Text = "U[i]";
                radioButton5.Text = "|V[i]-U[i]|";
                task = new TestTask2();
            }

            if (comboBox2.SelectedIndex == 1)
            {
                radioButton3.Text = "V[i]";
                radioButton4.Text = "V2[i]";
                radioButton5.Text = "|V[i]-V2[i]|";
                task = new MainTask2();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}