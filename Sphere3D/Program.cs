using System;
using System.Text;
using System.Threading;

namespace Sphere3D
{
    class Program
    {
        static float Clamp(float value, float min, float max) => Math.Max(Math.Min(value, max), min);
        static float Repeat(float value, float min, float max) => value <= min ? max : (value >= max ? min : value);
        static char Lit(float value)
        {
            //string gradient = " .:,=a#@";
            //string gradient = ".'`^\",:; Il!i >< ~+_ -?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";
            string gradient = " .-:=+a#%@";
            return gradient[gradient.Length - 1 - (int)(Clamp(value, 0, gradient.Length - 1))];
        }
        static float VectorLength(float x, float y) => x * x + y * y;
        static void Main(string[] args)
        {
            Console.Title = "3d Sphere";

            int screenWidth = 120;
            int screenHeight = 30;
            float characherRatio = 11f / 20f;
            char bgcharacher = ' ';

            float sphereRadius = 0.8f;
            float rotationStep = 0.035f;

            (float x, float y) lightPosition = (-1, -1.9f);
            float lightRadius = 0.85f;

            for (int h = 0; h < 10000; h++)
            {
                Console.SetCursorPosition(0, 0);
                //lightPosition.x = Repeat(lightPosition.x + rotationStep, -3.25f, 3.25f);
                //lightPosition.y = (float)Math.Sin(h * 0.05f) / 20f - 2;

                lightPosition.x = (float)Math.Sin(h * 0.05f);
                lightPosition.y = (float)Math.Sin(h * 0.1f) / 20f - 2;
                for (int j = 0; j < screenHeight; j++)
                {
                    StringBuilder s = new StringBuilder();
                    for (int i = 0; i < screenWidth; i++)
                    {
                        float x = ((float)i / screenWidth * 2f - 1) / characherRatio;
                        float y = (float)j / screenHeight * 2f - 1;
                        
                        float light = VectorLength(MathF.Abs(x - lightPosition.x), MathF.Abs(y - lightPosition.y)) * 1f/lightRadius;
                        char c = x * x + y * y <= sphereRadius ? Lit(light) : bgcharacher;

                        s.Append(c);
                    }
                    Console.Write(s.ToString());
                }

                Thread.Sleep(15);
            }
        }
    }
}
