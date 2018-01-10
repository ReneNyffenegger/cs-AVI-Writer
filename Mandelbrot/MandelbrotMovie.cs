using System.Drawing;
using System;

class MandelbrotMovie {
  public static void Main() {
    try {
      Color[] palette = new Color[50];
      for (int i=0; i<50;i++) {
        palette[i]=Color.FromArgb(i*4,255-i*4,50+i*2);
      }
      int w = 600;
      int h = 600;
      AviWriter aw = new AviWriter();
      Bitmap bmp = aw.Open("test.avi", 25,w,h);

      double f                =  1.2;
      double centerX          = -0.7454333;
      double centerY          = -0.1130211;
      double pctAreaNewImage  =  0.9;
      double endWidth_times_2 =  0.0001;

      while (f>endWidth_times_2) {

        MandelBrot.CalcMandelBrot(
          bmp,
          centerX-f,centerY-f,
          centerX+f,centerY+f,
          palette);

        f=Math.Sqrt(pctAreaNewImage*f*f);
        aw.AddFrame();
        Console.Write(".");
      }
      
      aw.Close();
    }
    catch (AviWriter.AviException e) {
      Console.WriteLine("AVI Exception in: " + e.ToString());
    }
  }
}
