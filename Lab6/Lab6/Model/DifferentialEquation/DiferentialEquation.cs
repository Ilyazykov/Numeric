namespace Lab6.Model.DifferentialEquation
{
    abstract class DiferentialEquation
    {
        //y'=F(x,y)
        //y(x0)=y0
        public double Y0 { get; set; }

        protected DiferentialEquation(double y0)
        {
            Y0 = y0;
        }

        public abstract double F(double x, double y);
        public abstract double GetAnaliticalValue(double x);

        public double GetNumericalValue(double x, double xPrev, double yPrev)
        {
            double dx = x - xPrev;

            double k1 = F(xPrev, yPrev);
            double k2 = F(xPrev + dx/2, yPrev + dx*k1/2);
            double k3 = F(xPrev + dx/2, yPrev + dx*k2/2);
            double k4 = F(xPrev + dx/2, yPrev + dx*k3);

            double y = yPrev + dx*(k1 + 2*k2 + 2*k3 + k4)/6;

            return y;
        }
    }
}
