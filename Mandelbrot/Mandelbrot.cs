using System.Drawing;

class MandelBrot {
  static public void CalcMandelBrot(
                       Bitmap bmp, 
                       double xCoordFrom, double yCoordFrom, 
                       double xCoordTo,   double yCoordTo,
                       Color[] palette) {
    int width =bmp.Width;
    int height=bmp.Height;

    int iterMax = palette.Length;
    
    for (int x=0; x<width; x++) {
      double xCoord=xCoordFrom+(xCoordTo-xCoordFrom)/width*x;
      for (int y=0; y<height; y++) {
        double yCoord=yCoordFrom+(yCoordTo-yCoordFrom)/height*y;
        
        int cnt=0;
        
        Complex c = new Complex(xCoord,yCoord);
        Complex z = new Complex(     0,     0);
        Complex z2= new Complex(     0,     0); 
        while ((z2.Abs()<2.0) && (cnt < iterMax)) {
          z = z2 + c;
          z2=z*z;
          cnt++;
        }
        if (cnt == iterMax) {
          bmp.SetPixel(x,y,Color.FromArgb(0,0,0));
        }
        else {
          bmp.SetPixel(x,y,palette[cnt]);
        }
      }
    }
  }
}
