using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoundaryValue
{
    public partial class Form1 : Form
    {
        double ksi = 0.525;

        GetterListOfValues one;
        GetterListOfValues two;

        BoundaryValue boundaryValue;
        Graphic graphicOne;
        Graphic graphicTwo;

        int numberOfSteps = 5;

        
        public Form1()
        {
            InitializeComponent();

            one = new MainEquation(ksi);
            two = new MainEquation(ksi);

            graphicOne = new Graphic(5);
            graphicTwo = new Graphic(10);
            boundaryValue = new BoundaryValue(0.0, 0.0, 1.0, 1.0);
        }

        void drawGraphics()
        {
            graph.Series["series1"].Points.Clear();
            graph.Series["series2"].Points.Clear();

            for (int i = 0; i <= graphicOne.numberOfIntervals; i++)
            {
                graph.Series["series1"].Points.AddXY(graphicOne.x[i], graphicOne.y[i]);
            }

            for (int i = 0; i <= graphicTwo.numberOfIntervals; i++)
            {
                graph.Series["series2"].Points.AddXY(graphicTwo.x[i], graphicTwo.y[i]);
            }
        }

        private void btnToDo_Click(object sender, EventArgs e)
        {
            graphicOne.getFrom(one, boundaryValue);
            graphicTwo.getFrom(two, boundaryValue);

            drawGraphics();
            getMax();
            fillTable();
        }

        private void fillTable()
        {
            dataGrid.RowCount = graphicOne.numberOfIntervals + 1;

            for (int i = 0; i < graphicOne.numberOfIntervals+1; ++i)
            {
                dataGrid.Rows[i].Cells[0].Value = i;
                dataGrid.Rows[i].Cells[1].Value = graphicOne.x[i];
                dataGrid.Rows[i].Cells[2].Value = graphicOne.y[i];
                if (radioButton1.Checked)
                {
                    dataGrid.Rows[i].Cells[3].Value = graphicTwo.y[i*2];
                    dataGrid.Rows[i].Cells[4].Value = Math.Abs(graphicOne.y[i] - graphicTwo.y[i*2]);
                }
                else
                {
                    dataGrid.Rows[i].Cells[3].Value = graphicTwo.y[i];
                    dataGrid.Rows[i].Cells[4].Value = Math.Abs(graphicOne.y[i] - graphicTwo.y[i]);
                }   
            }
        }

        private void getMax()
        {
            Tuple<double,double> temp = graphicOne.getMax(graphicTwo);
            labelMaxErrorValue.Text = temp.Item2.ToString();
            labelPointMaxErrorValue.Text = temp.Item1.ToString();
        }

        private void numericUpDownNumberOfSteps_ValueChanged(object sender, EventArgs e)
        {
            numberOfSteps = (int)numericUpDownNumberOfSteps.Value;

            graphicOne = new Graphic(numberOfSteps);

            if (radioButton1.Checked)
            {
                graphicTwo = new Graphic(numberOfSteps * 2);
            }
            else
            {
                graphicTwo = new Graphic(numberOfSteps);
            }
        }

        private void radioButtonMain_CheckedChanged(object sender, EventArgs e)
        {
            one = new MainEquation(ksi);
            two = new MainEquation(ksi);

            graphicOne = new Graphic(numberOfSteps);
            graphicTwo = new Graphic(numberOfSteps*2);

            graph.Series["series1"].LegendText = "Обычный шаг";
            graph.Series["series2"].LegendText = "Половинный шаг";
        }

        private void radioButtonTestOne_CheckedChanged(object sender, EventArgs e)
        {
            one = new TestOneEquation(ksi);
            two = new FunctionYStar(ksi);

            graphicOne = new Graphic(numberOfSteps);
            graphicTwo = new Graphic(numberOfSteps);

            graph.Series["series1"].LegendText = "Аппроксимация";
            graph.Series["series2"].LegendText = "Реальная функция";
        }

        private void radioButtonTestTwo_CheckedChanged(object sender, EventArgs e)
        {
            one = new TestTwoEquation();
            two = new FunctionTestTwo();

            graphicOne = new Graphic(numberOfSteps);
            graphicTwo = new Graphic(numberOfSteps);

            graph.Series["series1"].LegendText = "Аппроксимация";
            graph.Series["series2"].LegendText = "Реальная функция";
        }
    }
}