using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CH_M3
{
    abstract class Method
    {
        abstract public double Step();
        abstract public double[,] Forward(ref double E2, ref int N, ref double time);
    }

    class Yakobi: Method
    {
        int n,m;
        int Nmax;
        double Emin;
        double h,k,h2,k2,A;
        double[,] V_1;
        double[,] V_0;
        double [,]F;
        bool who_is_old;
        int Nsteps;
        Task t;
        double[] area;

        public Yakobi(double E, int N, int n0, int m0, Task t0, int GY)
        {
            Nmax=N;
            Emin=E;
            n=n0; m=m0;
            t = t0;
            area = t.area();

            h = (area[1] - area[0]) / n;
            k = (area[3] - area[2]) / m;
            h2 = 1 / (h * h);
            k2 = 1 / (k * k);
            A = -2 * (h2 + k2);

            V_0 = new double[n + 1, m + 1];
            V_1 = new double[n + 1, m + 1];
            F = new double[n , m];
            who_is_old = false;


            for (int i = 0; i <=n; i++)
            {
                V_0[i, 0] = t.m3(area[0] + i * h);
                V_1[i, 0] = V_0[i, 0];

                V_0[i, m] = t.m4(area[0] + i * h);
                V_1[i, m] = V_0[i, m];
            }

            for (int i = 0; i <= m; i++)
            {
                V_0[0, i] = t.m1(area[2] + i * k);
                V_1[0, i] = V_0[0,i];

                V_0[n, i] = t.m2(area[2] + i * k);
                V_1[n, i] = V_0[n, i];
            }
           
            if (GY == 0)
                for (int i = 1; i < n; i++)
                    for (int j = 1; j < m; j++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = 0;
                    }

            if (GY == 1)
                for (int i = 1; i < n; i++)
                {
                    double D = (V_0[i, m] - V_0[i, 0]) / m;
                    for (int j = 1; j < m; j++)
                    {
                        double C = (V_0[n, j] - V_0[0, j]) / n;
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = (V_0[0, j] + i * C + V_0[i, 0] + j * D) / 2;

                    }
                }

            if (GY == 2)
                for (int j = 1; j < m; j++)
                {
                    double C=(V_0[n, j] - V_0[0, j]) / n;
                    for (int i = 1; i < n; i++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = V_0[0, j] + i * C;
                    }
                }
           
            if (GY == 3)
                for (int i = 1; i < n; i++)
                {
                    double D = (V_0[i, m] - V_0[i, 0]) / m;
                    for (int j = 1; j < m; j++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = V_0[i, 0] + j * D;
                    }
                }
           

        }

        public override double Step() 
        {
            double[,] V_new;
            double[,] V_old;
            if (who_is_old) { V_new = V_0; V_old = V_1; }
            else { V_new = V_1; V_old = V_0; }
            who_is_old = !who_is_old;
            double Es = 0;


            for (int j = 1; j < m; j++) 
                for (int i = 1; i < n; i++)
                {
                    V_new[i, j] = (-F[i, j] - h2 * (V_old[i-1, j] + V_old[i+1, j]) - k2 * (V_old[i, j-1] + V_old[i, j+1]))/A;
                    if (Math.Abs(V_new[i, j] - V_old[i, j]) > Es) Es = Math.Abs(V_new[i, j] - V_old[i, j]);
                }

            return Es;
        }

        public override double[,] Forward(ref double E2, ref int N, ref double time)
        {
            Nsteps=0;
            double Es = 100;
            Stopwatch t = new Stopwatch();
            t.Start();
            do
            {
                Es = Step();
                Nsteps++;
            }
            while ((Nsteps < Nmax) && (Es > Emin));
            t.Stop();
            time = t.ElapsedMilliseconds / 1000;

            double[,] V;
            if (who_is_old) { V = V_1; }
            else { V = V_0; }

          
            E2 = Es;
            N = Nsteps;


            return V;
           
        }

    }

    class OverRelax : Method
    {
        int n, m;
        int Nmax;
        double Emin;
        double h, k, h2, k2, A;
        
        double[,] V;
        double[,] F;
        
        int Nsteps;
        Task t;
        double[] area;
        double w, w1;

        public OverRelax(double E, int N, int n0, int m0, Task t0, int GY, double w0)
        {
            Nsteps = 0;
            Nmax = N;
            Emin = E;
            n = n0; m = m0;
            t = t0;
            area = t.area();
            w = w0;
            w1 = w-1;

            h = (area[1] - area[0]) / n;
            k = (area[3] - area[2]) / m;
            h2 = 1 / (h * h);
            k2 = 1 / (k * k);
            A = -2 * (h2 + k2);

            V = new double[n + 1, m + 1];
            
            F = new double[n, m];
            


            for (int i = 0; i <= n; i++)
            {
                V[i, 0] = t.m3(area[0] + i * h);
                V[i, m] = t.m4(area[0] + i * h);
                
            }

            for (int i = 0; i <= m; i++)
            {
                V[0, i] = t.m1(area[2] + i * k);
                V[n, i] = t.m2(area[2] + i * k);
               
            }

            if (GY == 0)
                for (int i = 1; i < n; i++)
                    for (int j = 1; j < m; j++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V[i, j] = 0;
                    }
            if (GY == 1)
                for (int i = 1; i < n; i++)
                {
                    double D = (V[i, m] - V[i, 0]) / m;
                    for (int j = 1; j < m; j++)
                    {
                        double C = (V[n, j] - V[0, j]) / n;
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V[i, j] = (V[0, j] + i * C + V[i, 0] + j * D) / 2;

                    }
                }
            if (GY == 2)
                for (int j = 1; j < m; j++)
                {
                    double C = (V[n, j] - V[0, j]) / n;
                    for (int i = 1; i < n; i++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V[i, j] = V[0, j] + i * C;
                    }
                }

            if (GY == 3)
                for (int i = 1; i < n; i++)
                {
                    double D = (V[i, m] - V[i, 0]) / m;
                    for (int j = 1; j < m; j++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V[i, j] = V[i, 0] + j * D;
                    }
                }

        }

        public override double Step()
        {
           
            return 0;
        }

       
        public override double[,] Forward(ref double E2, ref int N, ref double time)
        {
            
            double Es = 100;
            Stopwatch t = new Stopwatch();
            t.Start();

            for (Nsteps = 0; Nsteps < Nmax; Nsteps++)
            {

                Es = 0;
                for (int j = 1; j < m; j++)
                    for (int i = 1; i < n; i++)
                    {
                        double V_old = V[i, j];
                        V[i, j] = (-F[i, j] - h2 * (V[i - 1, j] + V[i + 1, j]) - k2 * (V[i, j - 1] + V[i, j + 1])) * w / A - w1 * V[i, j];
                        if (V[i, j] - V_old > Es) Es = V[i, j] - V_old;
                        if (-V[i, j] + V_old > Es) Es = -V[i, j] + V_old;

                    }
                if (Es < Emin) break;

            }
            
          t.Stop();

            time = t.ElapsedMilliseconds / 1000;

            E2 = Es;
            N = Nsteps;

            return V;

        }

    }

    class MinDiscrepancy : Method
    {
        int n, m;
        int Nmax;
        double Emin;
        double h, k, h2, k2, A;
        double[,] V_1;
        double[,] V_0;
        double[,] r, Ar;
        double[,] F;
        bool who_is_old;
        int Nsteps;
        Task t;
        double[] area;

        public MinDiscrepancy(double E, int N, int n0, int m0, Task t0, int GY)
        {
            Nmax = N;
            Emin = E;
            n = n0; m = m0;
            t = t0;
            area = t.area();

            h = (area[1] - area[0]) / n;
            k = (area[3] - area[2]) / m;
            h2 = 1 / (h * h);
            k2 = 1 / (k * k);
            A = -2 * (h2 + k2);

            V_0 = new double[n + 1, m + 1];
            V_1 = new double[n + 1, m + 1];
            r = new double[n + 1, m + 1];
            Ar = new double[n, m];
            F = new double[n, m];
            who_is_old = false;


            for (int i = 0; i <= n; i++)
            {
                V_0[i, 0] = t.m3(area[0] + i * h);
                V_1[i, 0] = V_0[i, 0];
                r[i, 0] = 0;

                V_0[i, m] = t.m4(area[0] + i * h);
                V_1[i, m] = V_0[i, m];
                r[i, m] = 0;

            }

            for (int i = 0; i <= m; i++)
            {
                V_0[0, i] = t.m1(area[2] + i * k);
                V_1[0, i] = V_0[0, i];
                r[0, i] = 0;

                V_0[n, i] = t.m2(area[2] + i * k);
                V_1[n, i] = V_0[n, i];
                r[n, i] = 0;
            }

            if (GY == 0)
                for (int i = 1; i < n; i++)
                    for (int j = 1; j < m; j++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = 0;
                    }

            if (GY == 1)
                for (int i = 1; i < n; i++)
                {
                    double D = (V_0[i, m] - V_0[i, 0]) / m;
                    for (int j = 1; j < m; j++)
                    {
                        double C = (V_0[n, j] - V_0[0, j]) / n;
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = (V_0[0, j] + i * C + V_0[i, 0] + j * D) / 2;

                    }
                }

            if (GY == 2)
                for (int j = 1; j < m; j++)
                {
                    double C = (V_0[n, j] - V_0[0, j]) / n;
                    for (int i = 1; i < n; i++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = V_0[0, j] + i * C;
                    }
                }

            if (GY == 3)
                for (int i = 1; i < n; i++)
                {
                    double D = (V_0[i, m] - V_0[i, 0]) / m;
                    for (int j = 1; j < m; j++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = V_0[i, 0] + j * D;
                    }
                }


        }

        public override double Step()
        {
            double[,] V_new;
            double[,] V_old;
           
            if (who_is_old) { V_new = V_0; V_old = V_1; }
            else { V_new = V_1; V_old = V_0; }
            who_is_old = !who_is_old;
            double Es = 0;
            double tay1 = 0; 
            double tay2 = 0;
            double tay_s;

            for (int j = 1; j < m; j++)
                for (int i = 1; i < n; i++)
                {
                    r[i, j] = F[i, j] + h2 * (V_old[i - 1, j] + V_old[i + 1, j]) + k2 * (V_old[i, j - 1] + V_old[i, j + 1]) + A * V_old[i, j];
                }

            for (int j = 1; j < m; j++)
                for (int i = 1; i < n; i++)
                {
                    Ar[i, j] = h2 * (r[i - 1, j] + r[i + 1, j]) + k2 * (r[i, j - 1] + r[i, j + 1]) + A * r[i, j];
                    tay1 = tay1 + Ar[i, j] * r[i, j];
                    tay2 = tay2 + Ar[i, j] * Ar[i, j];
                }
            tay_s = tay1 / tay2;

            for (int j = 1; j < m; j++)
                for (int i = 1; i < n; i++)
                {
                    V_new[i, j] = V_old[i, j] - tay_s * r[i, j];
                    if (Math.Abs(V_new[i, j] - V_old[i, j]) > Es) Es = Math.Abs(V_new[i, j] - V_old[i, j]);
                }

            return Es;
        }

        public override double[,] Forward(ref double E2, ref int N, ref double time)
        {
            Nsteps = 0;
            double Es = 100;
            Stopwatch t = new Stopwatch();
            t.Start();
            do
            {
                Es = Step();
                Nsteps++;
            }
            while ((Nsteps < Nmax) && (Es > Emin));
            t.Stop();
            time = t.ElapsedMilliseconds / 1000;

            double[,] V;
            if (who_is_old) { V = V_1; }
            else { V = V_0; }


            E2 = Es;
            N = Nsteps;


            return V;

        }

    }

    class MinDisNoRect : Method
    {
        int n, m, n2, m2;
        int Nmax;
        double Emin;
        double h, k, h2, k2, A;
        double[,] V_1;
        double[,] V_0;
        double[,] r, Ar;
        double[,] F;
        bool who_is_old;
        int Nsteps;
        Task t;
        double[] area;

        public MinDisNoRect(double E, int N, int n0, int m0, Task t0, int GY)
        {
            Nmax = N;
            Emin = E;
            n = n0; m = m0;
            t = t0;
            area = t.area();

            h = (area[1] - area[0]) / n;
            k = (area[3] - area[2]) / m;
            h2 = 1 / (h * h);
            k2 = 1 / (k * k);
            A = -2 * (h2 + k2);

            V_0 = new double[n + 1, m + 1];
            V_1 = new double[n + 1, m + 1];
            r = new double[n + 1, m + 1];
            Ar = new double[n, m];
            F = new double[n, m];
            who_is_old = false;

            n2 = (int)(n / 2);
            m2 = (int)(m / 2);

            if (t.test())
            {
                for (int i = 0; i <= n; i++)
                {
                    V_0[i, m] = t.m4(area[0] + i * h);
                    V_1[i, m] = V_0[i, m];
                    r[i, m] = 0;
                }//верхний полный кусок

                for (int i = n2 + 1; i <= n; i++)
                {
                    V_0[i, 0] = t.m3(area[0] + i * h);
                    V_1[i, 0] = V_0[i, 0];
                    r[i, 0] = 0;
                }//нижний неполный кусок


                for (int i = 0; i <= m; i++)
                {
                    V_0[n, i] = t.m2(area[2] + i * k);
                    V_1[n, i] = V_0[n, i];
                    r[n, i] = 0;
                }//правый полный кусок

                for (int i = m2 + 1; i <= m; i++)
                {
                    V_0[0, i] = t.m1(area[2] + i * k);
                    V_1[0, i] = V_0[0, i];
                    r[0, i] = 0;

                }//левый неполный кусок


                for (int i = 0; i <= n2; i++)
                {
                    V_0[i, m2] = t.U(area[0] + i * h, area[2] + m2 * k);
                    V_1[i, m2] = V_0[i, m2];
                    r[i, m2] = 0;

                }//горизонтальный вырезанный кусок

                for (int i = 0; i <= m2; i++)
                {
                    V_0[n2, i] = t.U(area[0] + n2 * h, area[2] + i * k);
                    V_1[n2, i] = V_0[n2, i];
                    r[n2, i] = 0;

                }//вертикальный вырезанный кусок

                
            }
            else
            {
                for (int i = 0; i <= n; i++)
                {
                    V_0[i, 0] = t.m3(area[0] + i * h);
                    V_1[i, 0] = V_0[i, 0];
                    r[i, 0] = 0;

                    V_0[i, m] = t.m4(area[0] + i * h);
                    V_1[i, m] = V_0[i, m];
                    r[i, m] = 0;

                }

                for (int i = 0; i <= m; i++)
                {
                    V_0[0, i] = t.m1(area[2] + i * k);
                    V_1[0, i] = V_0[0, i];
                    r[0, i] = 0;

                    V_0[n, i] = t.m2(area[2] + i * k);
                    V_1[n, i] = V_0[n, i];
                    r[n, i] = 0;
                }

                for (int i = 1; i < n; i++)
                {
                    double D = (V_0[i, m] - V_0[i, 0]) / m;
                    for (int j = 1; j < m; j++)
                    {
                        double C = (V_0[n, j] - V_0[0, j]) / n;
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = (V_0[0, j] + i * C + V_0[i, 0] + j * D) / 2;
                        r[i, j] = 0;
                        V_1[i, j] = V_0[i, j];

                    }
                }
                for (int i = 0; i < n2; i++)
                    for (int j = 0; j < m2; j++)
                    {
                        V_0[i, j] = 0;
                        V_1[i, j] = 0;
                    }
            }

            //начальное приближение (которое я по исключительной тупости назвала граничным)  
            if (GY == 0)
            {
                for (int i = 1; i < n; i++)
                    for (int j = m2 + 1; j < m; j++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = 0;
                    }
                for (int i = n2 + 1; i < n; i++)
                    for (int j = 1; j < m2 + 1; j++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = 0;
                    }
            }
            //---------------------Это было прекрасное нулевое начальное приближение-----------------------//

            if (GY == 1)
            {
                for (int j = m2 + 1; j < m; j++)
                {
                    double C = (V_0[n, j] - V_0[0, j]) / n;
                    for (int i = 1; i <= n2; i++)
                    {
                        double D = (V_0[i, m] - V_0[i, m2]) / m2;
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = (V_0[0, j] + i * C + V_0[i, m2] + (j - m2) * D) / 2;
                    }

                    for (int i = n2 + 1; i < n; i++)
                    {
                        double D = (V_0[i, m] - V_0[i, 0]) / m;
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = (V_0[0, j] + i * C + V_0[i, 0] + j * D) / 2;
                    }
                }


                for (int j = 1; j <= m2; j++)
                {
                    double C = (V_0[n, j] - V_0[n2, j]) / (n2);
                    for (int i = n2 + 1; i < n; i++)
                    {
                        double D = (V_0[i, m] - V_0[i, 0]) / m;
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = (V_0[n2, j] + (i - n2) * C + V_0[i, 0] + j * D) / 2;
                    }
                }
            }

            //-------------------Ужасное среднее было это----------------------//

            if (GY == 2)
            {
                for (int j = m2 + 1; j < m; j++)
                {
                    double C = (V_0[n, j] - V_0[0, j]) / n;
                    for (int i = 1; i < n; i++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = V_0[0, j] + i * C;
                    }
                }

                for (int j = 1; j <= m2; j++)
                {
                    double C = (V_0[n, j] - V_0[n2, j]) / (n2);
                    for (int i = n2 + 1; i < n; i++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = V_0[n2, j] + (i - n2) * C;
                    }
                }
            }

            //---------------------Это была интерполяция по х-----------------------//

            if (GY == 3)
            {
                for (int i = 1; i <= n2; i++)
                {
                    double D = (V_0[i, m] - V_0[i, m2]) / m2;
                    for (int j = m2 + 1; j < m; j++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = V_0[i, m2] + (j - m2) * D;
                    }
                }

                for (int i = n2 + 1; i < n; i++)
                {
                    double D = (V_0[i, m] - V_0[i, 0]) / m;
                    for (int j = 1; j < m; j++)
                    {
                        F[i, j] = t.f(area[0] + i * h, area[2] + j * k);
                        V_0[i, j] = V_0[i, 0] + j * D;
                    }
                }
            }
            //--------------Это была интерполяция по у------------------------//


        }

        public override double Step()
        {
            double[,] V_new;
            double[,] V_old;

            if (who_is_old) { V_new = V_0; V_old = V_1; }
            else { V_new = V_1; V_old = V_0; }
            who_is_old = !who_is_old;
            double Es = 0;
            double tay1 = 0;
            double tay2 = 0;
            double tay_s;

            for (int j = 1; j < m; j++)
                for (int i = n2 + 1; i < n; i++)
                {
                    r[i, j] = F[i, j] + h2 * (V_old[i - 1, j] + V_old[i + 1, j]) + k2 * (V_old[i, j - 1] + V_old[i, j + 1]) + A * V_old[i, j];
                }//обход правого прямоугольника 

            for (int j = m2 + 1; j < m; j++)
                for (int i = 1; i <= n2; i++)
                {
                    r[i, j] = F[i, j] + h2 * (V_old[i - 1, j] + V_old[i + 1, j]) + k2 * (V_old[i, j - 1] + V_old[i, j + 1]) + A * V_old[i, j];
                }//обход левого верхнего квадрата 


            for (int j = 1; j < m; j++)
                for (int i = n2 + 1; i < n; i++)
                {
                    Ar[i, j] = h2 * (r[i - 1, j] + r[i + 1, j]) + k2 * (r[i, j - 1] + r[i, j + 1]) + A * r[i, j];
                    tay1 = tay1 + Ar[i, j] * r[i, j];
                    tay2 = tay2 + Ar[i, j] * Ar[i, j];
                }

            for (int j = m2 + 1; j < m; j++)
                for (int i = 1; i <= n2; i++)
                {
                    Ar[i, j] = h2 * (r[i - 1, j] + r[i + 1, j]) + k2 * (r[i, j - 1] + r[i, j + 1]) + A * r[i, j];
                    tay1 = tay1 + Ar[i, j] * r[i, j];
                    tay2 = tay2 + Ar[i, j] * Ar[i, j];
                }
            tay_s = tay1 / tay2;

            for (int j = 1; j < m; j++)
                for (int i = n2 + 1; i < n; i++)
                {
                    V_new[i, j] = V_old[i, j] - tay_s * r[i, j];
                    if (Math.Abs(V_new[i, j] - V_old[i, j]) > Es) Es = Math.Abs(V_new[i, j] - V_old[i, j]);
                }

            for (int j = m2 + 1; j < m; j++)
                for (int i = 1; i <= n2; i++)
                {
                    V_new[i, j] = V_old[i, j] - tay_s * r[i, j];
                    if (Math.Abs(V_new[i, j] - V_old[i, j]) > Es) Es = Math.Abs(V_new[i, j] - V_old[i, j]);
                }

            return Es;
        }

        public override double[,] Forward(ref double E2, ref int N, ref double time)
        {
            Nsteps = 0;
            double Es = 100;
            Stopwatch t = new Stopwatch();
            t.Start();
            do
            {
                Es = Step();
                Nsteps++;
            }
            while ((Nsteps < Nmax) && (Es > Emin));
            t.Stop();
            time = t.ElapsedMilliseconds / 1000;

            double[,] V;
            if (who_is_old) { V = V_1; }
            else { V = V_0; }


            E2 = Es;
            N = Nsteps;


            return V;

        }

    }
}

