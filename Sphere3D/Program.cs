using System;
using System.Text;
using System.Threading;

namespace Sphere3D
{
    static class Math3D
    {
        public static double rad2deg = 57.295779513082313;
        public static double deg2rad = 1.0 / rad2deg;

        public enum Axis
        {
            X = 1, Y = 2, Z = 4
        }

        public static float Clamp(float value, float min, float max) => Math.Max(Math.Min(value, max), min);
        public static float Repeat(float value, float min, float max) => value <= min ? max : (value >= max ? min : value);
        public static double Asin(double ratio) => Math.Asin(ratio) * rad2deg;
    }
    class Light
    {
        public Point point;
        public double radius;

        public Light(Point _point, double _radius)
        {
            point = _point;
            radius = _radius;
        }

        /*public static char Lit(float value)
        {
            //string gradient = " .:,=a#@";
            //string gradient = ".'`^\",:; Il!i >< ~+_ -?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";
            string gradient = " .-:=+a#%@";
            return gradient[gradient.Length - 1 - (int)(Clamp(value, 0, gradient.Length - 1))];
        }*/
    }
    struct Point
    {
        public static Point zero { get { return new Point(0, 0, 0); } }

        public double x;
        public double y;
        public double z;

        public Point(double _x, double _y, double _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public override string ToString() => $"Point {x} : {y} : {z}";

        public static Vector operator -(Point a, Point b) => new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
    }
    struct Vector
    {
        public double x;
        public double y;
        public double z;

        public double sqrmagnitude { get { return x * x + y * y + z * z; } }
        public double magnitude { get { return Math.Pow(sqrmagnitude, 0.5); } }
        public Vector normilized { get { double m = magnitude; return new Vector(x / magnitude, y / magnitude, z / magnitude); } }


        public Vector(double _x, double _y, double _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public void Normilize() => this = normilized;

        public override string ToString() => $"Vector {x} : {y} : {z}";

        public static Vector operator +(Vector a, Vector b) =>
            new Vector(a.x + b.x, a.y + b.y, a.z + b.z);

        public static Vector operator -(Vector a, Vector b) =>
            new Vector(a.x - b.x, a.y - b.y, a.z - b.z);

        public static Vector operator *(Vector a, double value) => 
            new Vector(a.x * value, a.y * value, a.z * value);

        public static Vector operator *(Vector a, Vector b) =>
            new Vector(a.x * b.x, a.y * b.y, a.z * b.z);

        public Vector RotateAround(Point origin, double angle)
        {
            double radius = magnitude;
            angle *= Math3D.deg2rad;

            double deltax = radius * Math.Sin(angle);
            double deltay = Math.Tan(angle / 2.0) * deltax; 

            Console.WriteLine(angle);
            Console.WriteLine(deltax);
            Console.WriteLine(deltay);

            Point p = new Point(origin.x + x + deltax, origin.y + y - deltay, origin.z);

            Vector v = p - origin;
            return v;

            /*if (axis == Math3D.Axis.X)
            {
                // YZ
                double x = this.x + Math.Sin(angle);
                this.x = x;
            }
            if (axis == Math3D.Axis.Y)
            {
                double y = this.y + Math.Cos(angle);
                this.y = y;
            }
            if (axis == Math3D.Axis.Z)
            {
                double z = this.z + Math.Sin(angle);
                this.z = z;
            }*/
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            /*Vector light = new Vector(0, -1, 12);
            Vector normal = new Vector(0, 2, 10).normilized;

            Vector a = light;
            Vector b = normal;*/

            Vector k = new Vector(0, 10, 0);
            var v = k.RotateAround(Point.zero, 80);
            Console.WriteLine(v.normilized);

            //Console.WriteLine(Math3D.Asin(0.5));
            //double angle = MathF.Acos((float)(a.x * b.x + a.y * b.y + a.z * b.z)) / (MathF.Sqrt((float)(a.x * a.x + a.y * a.y + a.z * a.z)) * MathF.Sqrt((float)(b.x * b.x + b.y * b.y + b.z * b.z)));

            //Console.WriteLine($"{angle}");




            /*Console.Title = "3d Sphere";

            int screenWidth = 120;
            int screenHeight = 30;
            float characherRatio = 11f / 20f;
            char bgcharacher = ' ';

            for (int h = 0; h < 10000; h++)
            {
                Console.SetCursorPosition(0, 0);
                
                Thread.Sleep(15);
            }*/
        }
    }
}
