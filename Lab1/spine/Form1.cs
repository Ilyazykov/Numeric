using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace spine
{
    public partial class SplineForm : Form
    {
        double begin = -1;
        double end = 1;

        double graphInterval = 0.1;

        AnchorPoints anchorPoints = new AnchorPoints(5);

        PointsOfRealFunction RealFunction = new PointsOfRealFunction();
        PointsOfAproximation Aproximation = new PointsOfAproximation();

        RealSplineImagine spline = new RealSplineImagine(); //TODO убрать пережитки старого строя
        Function function = new SecondVariantFunction();    //TODO убрать пережитки старого строя

        //FunctionOnInterval spline;
        //FunctionOnInterval realFunction;

        public SplineForm()
        {
            InitializeComponent();
            graphInterval = (end - begin) * 3.0 / ((double)(graph.Width) * 2.0);

            comboBoxFunctionSeacher.SelectedIndex = 2;
        }

        private void getGraphParameters()
        {
            anchorPoints.getAnchorPoints(begin, end, function);

            spline = new RealSplineImagine(begin, end);
            spline.spline.BuildSpline(anchorPoints.x, anchorPoints.y, anchorPoints.number, anchorPoints.secondDifferentialBegin, anchorPoints.secondDifferentialEnd);

            Aproximation.getAproximation(spline, graphInterval);

            RealFunction.getRealFunction(begin, end, function, graphInterval);
        }

        private void drawGraph()
        {
            graph.Series["real"].Points.Clear();
            graph.Series["aproximation"].Points.Clear();

            for (int i = 0; i < RealFunction.x.Count; i++)
            {
                graph.Series["real"].Points.AddXY
                    (RealFunction.x[i], RealFunction.y[i]);
                graph.Series["aproximation"].Points.AddXY
                    (Aproximation.x[i], Aproximation.y[i]);
            }
        }

        private void fillTableOfValues()
        {
            dataGridValues.RowCount = RealFunction.x.Count;
            dataGridValues.ColumnCount = 2;
            int i;
            for (i = 0; i < RealFunction.x.Count; ++i) 
            {
                dataGridValues.Rows[i].Cells[0].Value = Aproximation.x[i];
                dataGridValues.Rows[i].Cells[1].Value = Aproximation.y[i];
            }
        }

        private void fillTableOfSplineCoef()
        {
            dataGridSplineCoef.RowCount = anchorPoints.number;
            dataGridSplineCoef.ColumnCount = 5;
            for (int i = 0; i < anchorPoints.number; ++i)
            {
                int y = 0;
                for (char a = 'a'; a <= 'd'; ++a)
                {
                    dataGridSplineCoef.Rows[i].Cells[y].Value = spline.spline.getCoef(a, i);
                    y++;
                }
                dataGridSplineCoef.Rows[i].Cells[4].Value = spline.spline.getCoef('x', i);
            }
        }

        private void showErrorValue()
        {
            Point errorValue = Aproximation.getMaximumDifferenceWith(RealFunction);
            labelErrorValue.Text = errorValue.y.ToString();
            labelErrorPoint.Text = errorValue.x.ToString();
        }

        private void showFirstDifferentialValue()
        {
            Point errorValue = spline.getMaximumFirstDifferentialDifferenceWith(function, begin, end, graphInterval);
            labelFirstDifferentialValue.Text = errorValue.y.ToString();
            labelFirstDifferentialPoint.Text = errorValue.x.ToString();
        }

        private void showSecondDifferentialValue()
        {
            Point errorValue = spline.getMaximumSecondDifferentialDifferenceWith(function, begin, end, graphInterval);
            labelSecondDifferentialValue.Text = errorValue.y.ToString();
            labelSecondDifferentialPoint.Text = errorValue.x.ToString();
        }

        private void showErrors()
        {
            showErrorValue();
            showFirstDifferentialValue();
            showSecondDifferentialValue();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getGraphParameters();
            drawGraph();

            fillTableOfValues();
            fillTableOfSplineCoef();

            showErrors();
        }



        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            anchorPoints.number = (int)numericUpDown3.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            begin = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            end = (int)numericUpDown2.Value;
        }

        private void naturalBorders_CheckedChanged(object sender, EventArgs e)
        {
            int n = anchorPoints.number;
            anchorPoints = new AnchorPoints(n);
        }

        private void likeAsOriginalFunctionBorder_CheckedChanged(object sender, EventArgs e)
        {
            int n = anchorPoints.number;
            anchorPoints = new AnchorPointsAndDifferentialBorder(n);
        }

        private void functionSeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = (string)comboBoxFunctionSeacher.SelectedItem;

            switch (selected)
            {
                case "testFunction":
                    function = new TestFunction();
                    break;
                case "sinx":
                    function = new SinusFunction();
                    break;
                case "f(x)":
                    function = new SecondVariantFunction();
                    break;
                case "f(x)+cos(10x)":
                    function = new SecondVariantFunctionPlusCos10();
                    break;
                case "f(x)+cos(100x)":
                    function = new SecondVariantFunctionPlusCos100();
                    break;
                default:
                    break;
            }
        }

        private void SplineForm_Load(object sender, EventArgs e)
        {

        }
    }
}
