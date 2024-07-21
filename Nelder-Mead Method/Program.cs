
namespace Nelder_Mead_Method
{
    class Program
    {
        public static double Rastrigin_function(params double[] x) // minimum (0,0, ..., 0) 0, df: [-5.12; 5.12]
        {
            int n = x.Length;
            double sum = 0;
            for (int i = 0; i < n; i++)
                sum += x[i] * x[i] - 10 * Math.Cos(2 * Math.PI * x[i]);
            return 10 * n + sum;

        }

        public static double Rosenbrock_function(params double[] x) //minimum (1, 1, ..., 1) 0 df: caly przedzial R
        {
            int dimension = x.Length;
            double sum = 0;
            if (dimension != 1)
            {
                for (int i = 0; i < dimension - 1; i++)
                {
                    sum += 100 * Math.Pow((x[i + 1] - (x[i] * x[i])), 2) + Math.Pow((1 - x[i]), 2);
                }
            }
            return sum;
        }

        public static double Sphere_function(params double[] x)// minimum (0,0, ..., 0) 0, df: caly przedzial R
        {
            int dimension = x.Length;
            double sum = 0;
            for (int i = 0; i < dimension; i++)
            {
                sum += x[i] * x[i];
            }
            return sum;
        }
        public static void Main(string[] args)
        {

            double[][] rosen_points = new double[3][];
            for(int i=0; i<rosen_points.Length; i++)
            {
                rosen_points[i] = new double[2];
            }
            rosen_points[0] = [12, 2];
            rosen_points[1] = [1.7, 20];
            rosen_points[2] = [1.2, 2.5];

            var rosen_nm = new Nelder_Mead(0.001f, Rosenbrock_function, rosen_points);
            

            double[][] sphere_points = new double[4][];
            for(int i=0; i<sphere_points.Length; i++)
            {
                sphere_points[i] = new double[3];
            }
            sphere_points[0] = [12, 5, 5];
            sphere_points[1] = [10, -10, -5];
            sphere_points[2] = [-7, 7, 3];
            sphere_points[3] = [5, 5, -5];

            var sphere_nm = new Nelder_Mead(0.00001f, Sphere_function, sphere_points);
            sphere_nm.run();
            rosen_nm.run();
        }


    }
}
