using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dirichletProblem.Functions;

namespace dirichletProblem.getterOfValues
{
    abstract class DifferentialEquation : GetterOfValues
    {
        public Function F;

        public DifferentialEquation()
        {
        }

        public override Table getValues(BorderValues borderValues, int numberOfIteration, double eps, double additional)
        {
            int sizeX = borderValues.sizeX;
            int sizeY = borderValues.sizeY;

            Table res = new Table(sizeX, sizeY);

            res = seidelMethod(borderValues, numberOfIteration, eps, additional);

            return res;
        }

        private Table yackobyMethod(BorderValues borderValues, int numberOfIteration, double eps, double additional = 1)
        {
            double w = additional;
            double a = borderValues.beginX, b = borderValues.endX, c = borderValues.beginY, d = borderValues.endY;
            int n = borderValues.sizeX - 1;
            int m = borderValues.sizeY - 1;
            double Nmax = numberOfIteration;

            double h = borderValues.stepX;
            double k = borderValues.stepY;

            double[] x = new double[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                x[i] = a + i * h;
            }

            double[] y = new double[m + 1];
            for (int i = 0; i < n + 1; i++)
            {
                y[i] = c + i * k;
            }
            double[,] v = new double[n + 1, m + 1];
            double[,] v_next_step = new double[n + 1, m + 1];
            double[,] f = new double[n + 1, m + 1];

            double v_old;
            double v_new;
            double eps_max = 0.0;
            double eps_cur = 0.0;
            int S = 0;
            bool flag = false;

            double h2 = (-n * n) / ((b - a) * (b - a));
            double k2 = (-m * m) / ((d - c) * (d - c));
            double a2 = -2 * (h2 + k2);

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    v[i, j] = 0.0;
                    f[i, j] = F.getValue(x[i], y[j]);
                }
            }
            for (int i = 0; i < n + 1; i++)
            {
                v[i, 0] = borderValues.bottom[i];
                v[i, m] = borderValues.top[i];
            }
            for (int j = 0; j < m + 1; j++)
            {
                v[0, j] = borderValues.left[j];
                v[n, j] = borderValues.right[j];
            }

            while (!flag)
            {
                double currentEpsilon = 0;
                for (int j = 1; j < m; j++)
                {
                    for (int i = 1; i < n; i++)
                    {
                        v_old = v[i, j];
                        v_new = (f[i, j] - h2 * (v[i + 1, j] + v[i - 1, j]) -
                            k2 * (v[i, j + 1] + v[i, j - 1])) / a2;
                        double currentElementEpsilon = Math.Abs(v_old - v_new);
                        if (currentElementEpsilon > currentEpsilon)
                        {
                            currentEpsilon = currentElementEpsilon;
                        }
                        v_next_step[i, j] = v_new;
                    }
                }
                double[,] tmp = v_next_step;
                v_next_step = v;
                v = tmp;

                S++;
                if ((currentEpsilon < eps) || (S >= Nmax))
                {
                    flag = true;
                }
            }


            Table res = new Table(v, x, y, S, eps_max);
            return res;
        }

        private Table seidelMethod(BorderValues borderValues, int numberOfIteration, double eps, double additional = 1)
        {
            double w = additional;
            double a = borderValues.beginX, b = borderValues.endX, c = borderValues.beginY, d = borderValues.endY;
            int n = borderValues.sizeX - 1;
            int m = borderValues.sizeY - 1;
            double Nmax = numberOfIteration;

            double h = borderValues.stepX;
            double k = borderValues.stepY;

            double[] x = new double[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                x[i] = a + i * h;
            }

            double[] y = new double[m + 1];
            for (int i = 0; i < n + 1; i++)
            {
                y[i] = c + i * k;
            }
            double[,] v = new double[n + 1, m + 1];
            double[,] f = new double[n + 1, m + 1];

            double v_old;
            double v_new;
            double eps_max = 0.0;
            double eps_cur = 0.0;
            int S = 0;
            bool flag = false;

            double h2 = (-n * n) / ((b - a) * (b - a));
            double k2 = (-m * m) / ((d - c) * (d - c));
            double a2 = -2 * (h2 + k2);

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    v[i, j] = 0.0;
                    f[i, j] = F.getValue(x[i], y[j]);
                }
            }
            for (int i = 0; i < n + 1; i++)
            {
                v[i, 0] = borderValues.bottom[i];
                v[i, m] = borderValues.top[i];
            }
            for (int j = 0; j < m + 1; j++)
            {
                v[0, j] = borderValues.left[j];
                v[n, j] = borderValues.right[j];
            }

            while (!flag)
            {
                eps_max = 0;
                for (int j = 1; j < m; j++)
                    for (int i = 1; i < n; i++)
                    {
                        v_old = v[i, j];
                        v_new = -w * (h2 * (v[i + 1, j] + v[i - 1, j]) + k2 * (v[i, j + 1] + v[i, j - 1]));
                        v_new = v_new + (1 - w) * a2 * v[i, j] + w * f[i, j];
                        v_new = v_new / a2;
                        eps_cur = Math.Abs(v_old - v_new);
                        if (eps_cur > eps_max)
                        {
                            eps_max = eps_cur;
                        }
                        v[i, j] = v_new;
                    }
                S++;
                if ((eps_max < eps) || (S >= Nmax))
                {
                    flag = true;
                }
            }

            Table res = new Table(v, x, y, S, eps_max);
            return res;
        }

        //public void initStartZeroApproximation()
        //{
        //    for (int j = 1; j < _numDimY; j++)
        //    {
        //        for (int i = 1; i < _numDimX; i++)
        //        {
        //            V[i, j] = 0.0;
        //        }
        //    }
        //}

        //public void initStartApproximationLinearInterpolationOnX()
        //{
        //    for (int j = 1; j < _numDimY; j++)
        //    {
        //        double step = (V[_numDimX, j] - V[0, j]) / _numDimX;
        //        for (int i = 1; i < _numDimX; i++)
        //        {
        //            V[i, j] = XLeftCondition_mu1_Test(YLeftBorder + j * stepK) + step * i;
        //        }
        //    }
        //}

        //public void initStartApproximationLinearInterpolationOnY()
        //{
        //    for (int i = 1; i < _numDimX; i++)
        //    {
        //        double step = (V[i, _numDimY] - V[i, 0]) / _numDimY;
        //        for (int j = 1; j < _numDimY; j++)
        //        {
        //            V[i, j] = YDownConditions_mu3_Test(XLeftBorder + stepH * i) + step * j;
        //        }
        //    }
        //}

        //public void initStartApproximationMeanValue()
        //{
        //    double[,] V_intX = new double[NumNodesX, NumNodesY];
        //    double[,] V_intY = new double[NumNodesX, NumNodesY];

        //    for (int j = 1; j < _numDimY; j++)
        //    {
        //        double step = (V[_numDimX, j] - V[0, j]) / _numDimX;
        //        for (int i = 1; i < _numDimX; i++)
        //        {
        //            V_intX[i, j] = XLeftCondition_mu1_Test(YLeftBorder + j * stepK) + step * i;
        //        }
        //    }

        //    for (int i = 1; i < _numDimX; i++)
        //    {
        //        double step = (V[i, _numDimY] - V[i, 0]) / _numDimY;
        //        for (int j = 1; j < _numDimY; j++)
        //        {
        //            V_intY[i, j] = YDownConditions_mu3_Test(XLeftBorder + stepH * i) + step * j;
        //        }
        //    }

        //    for (int j = 1; j < _numDimY; j++)
        //    {
        //        for (int i = 1; i < _numDimX; i++)
        //        {
        //            V[i, j] = (V_intX[i, j] + V_intY[i, j]) / 2;
        //        }
        //    }
        //}
    }
}