using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace TrabajoFinalArquitecturaHardware
{
    class Experiment
    {

        Bitmap image;

        int size;
        int bitDepth;

        public const int SIZE_1 = 64;
        public const int SIZE_2 = 160;
        public const int SIZE_3 = 512;
        public const int SIZE_4 = 1500;

        public const int DEPTH_1 = 8;
        public const int DEPTH_2 = 16;
        public const int DEPTH_3 = 32;
        public StreamWriter writer;

        public Experiment()
        {
            size = SIZE_3;
            bitDepth = DEPTH_3;
            getImage();
            int algorithm = 3;
            String fileName = "Algorithm " + algorithm + " Size " + size + " BitDepth " + bitDepth;

            writer = new StreamWriter("./Data/"+fileName+".txt");
            switch (algorithm)
            {
                case 1:
                    {
                        for(int i = 0;i<100; i++)
                        {
                            algorithm1();
                        }
                        writer.Close();
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            algorithm2();
                        }
                        writer.Close();
                        break;
                    }
                case 3:
                    {

                        for (int i = 0; i < 100; i++)
                        {
                            algorithm3();
                        }
                        writer.Close();
                        break;
                    }
                case 4:
                    {

                        for (int i = 0; i < 100; i++)
                        {
                            Console.WriteLine(i);

                            algorithm4();
                        }
                        writer.Close();
                        break;
                    }
                case 5:
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            Console.WriteLine(i);

                            algorithm5();
                        }
                        writer.Close();
                        break;
                    }
            }
        }
        public void getImage()
        {
            String file = "./Images/" + size + "-" + bitDepth + ".bmp";
            image = new Bitmap(file);
        }

        public void algorithm1()
        {
            Bitmap newImage = new Bitmap(image);
            long rows = newImage.Width;
            long columns = newImage.Height;
            Color rgb;
            long time;
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            sw.Start();
            int R, G, B;

            for (int i = 0; i<rows; i++)
            {
                for(int j = 0; j<columns; j++)
                {
                    rgb = newImage.GetPixel(i,j);
                    R = 255 - rgb.R;
                    G = 255 - rgb.G;
                    B = 255 - rgb.B;
                    rgb = Color.FromArgb((R), (G), (B));
                    newImage.SetPixel(i, j,rgb);
                }
            }
            sw.Stop();
            time = (long)(sw.Elapsed.TotalMilliseconds * 1000000);
           // Console.WriteLine("Algorithm 1 - Size "+size+" BitDepth "+ bitDepth+": " + time);
            writer.WriteLine(time);

            newImage.Save("./NewImages/" + size + "-" + bitDepth + ".bmp");
        }

        public void algorithm2()
        {
            Bitmap newImage = new Bitmap(image);
            long rows = newImage.Width;
            long columns = newImage.Height;
            Color rgb;
            long time;
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            sw.Start();
            int R, G, B;
            //SET R
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {

                    rgb = newImage.GetPixel(i, j);
                    R = 255 - rgb.R;
                    rgb = Color.FromArgb((R), (rgb.G), (rgb.B));
                    newImage.SetPixel(i, j, rgb);
                }
            }
            //SET G
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {

                    rgb = newImage.GetPixel(i, j);
                    G = 255 - rgb.G;
                    rgb = Color.FromArgb((rgb.R), (G), (rgb.B));
                    newImage.SetPixel(i, j, rgb);
                }
            }
            //SET B
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns ; j++)
                {

                    rgb = newImage.GetPixel(i, j);
                    B = 255 - rgb.B;
                    rgb = Color.FromArgb((rgb.R), (rgb.G), (B));
                    newImage.SetPixel(i, j, rgb);
                }
            }
            sw.Stop();
            time = (long)(sw.Elapsed.TotalMilliseconds * 1000000);
          //  Console.WriteLine("Algorithm 2 - Size " + size + " BitDepth " + bitDepth + ": " + time);
            writer.WriteLine(time);
            newImage.Save("./NewImages/" + size + "-" + bitDepth + ".bmp");
        }

        public void algorithm3()
        {
            Bitmap newImage = new Bitmap(image);
            long rows = newImage.Width;
            long columns = newImage.Height;
            Color rgb;
            long time;
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            sw.Start();
            int R, G, B;
            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows ; i++)
                {

                    rgb = newImage.GetPixel(i, j);
                    R = 255 - rgb.R;
                    G = 255 - rgb.G;
                    B = 255 - rgb.B;
                    rgb = Color.FromArgb((R), (G), (B));
                    newImage.SetPixel(i, j, rgb);
                }
            }
            sw.Stop();
            time = (long)(sw.Elapsed.TotalMilliseconds * 1000000);
         //   Console.WriteLine("Algorithm 3 - Size " + size + " BitDepth " + bitDepth + ": " + time);
            writer.WriteLine(time);
            newImage.Save("./NewImages/" + size + "-" + bitDepth + ".bmp");
        }

       public void algorithm4()
        {
            Bitmap newImage = new Bitmap(image);
            int rows = newImage.Width;
            int columns = newImage.Height;
            Color rgb;
            long time;
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            sw.Start();
            int R, G, B;
            //SET R
            for (int i = 0; i < rows ; i++)
            {
                for (int j = 0; j < columns; j++)
                {

                    rgb = newImage.GetPixel(i, j);
                    R = 255 - rgb.R;
                    rgb = Color.FromArgb((R), (rgb.G), (rgb.B));
                    newImage.SetPixel(i, j, rgb);
                }
            }
            //SET G AND B
            for (int i = rows-1; i > -1 ; i--)
            {
                for (int j = columns-1; j >-1; j--)
                {

                    rgb = newImage.GetPixel(i, j);
                    G = 255 - rgb.G;
                    B = 255 - rgb.B;

                    rgb = Color.FromArgb((rgb.R), (G), (B));
                    newImage.SetPixel(i, j, rgb);
                }
            }
       
            sw.Stop();
            time = (long)(sw.Elapsed.TotalMilliseconds * 1000000);
        //    Console.WriteLine("Algorithm 4 - Size " + size + " BitDepth " + bitDepth + ": " + time);
            writer.WriteLine(time);
            newImage.Save("./NewImages/" + size + "-" + bitDepth + ".bmp");
        }
  

        public void algorithm5()
        {
            Bitmap newImage = new Bitmap(image);
            long rows = newImage.Width;
            long columns = newImage.Height;
            Color rgb;
            long time;
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            sw.Start();
            int R, G, B;
            for (int i = 0; i < rows - 1; i+=2)
            {
                for (int j = 0; j < columns - 1; j+=2)
                {
                    //i,j
                    rgb = newImage.GetPixel(i, j);
                    R = 255 - rgb.R;
                    G = 255 - rgb.G;
                    B = 255 - rgb.B;
                    rgb = Color.FromArgb((R), (G), (B));
                    newImage.SetPixel(i, j, rgb);

                    // i, j+1
                    rgb = newImage.GetPixel(i, j+1);
                    R = 255 - rgb.R;
                    G = 255 - rgb.G;
                    B = 255 - rgb.B;
                    rgb = Color.FromArgb((R), (G), (B));
                    newImage.SetPixel(i, j+1, rgb);

                    //i+1,j
                     rgb = newImage.GetPixel(i+1, j);
                    R = 255 - rgb.R;
                    G = 255 - rgb.G;
                    B = 255 - rgb.B;
                    rgb = Color.FromArgb((R), (G), (B));
                    newImage.SetPixel(i+1, j, rgb);

                    //i+1,j+1
                    rgb = newImage.GetPixel(i + 1, j+1);
                    R = 255 - rgb.R;
                    G = 255 - rgb.G;
                    B = 255 - rgb.B;
                    rgb = Color.FromArgb((R), (G), (B));
                    newImage.SetPixel(i + 1, j+1, rgb);


                }
            }
            sw.Stop();
            time = (long)(sw.Elapsed.TotalMilliseconds * 1000000);
            //Console.WriteLine("Algorithm 5 - Size " + size + " BitDepth " + bitDepth + ": " + time);
            writer.WriteLine(time);
            newImage.Save("./NewImages/" + size + "-" + bitDepth + ".bmp");
        }


        static void Main(string[] args)
        {
            Experiment experiment = new Experiment();
        }
    }
}
