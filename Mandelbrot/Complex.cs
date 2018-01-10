using System;

public struct Complex {
  public Complex(double re_, double im_) {
    re = re_;
    im = im_;
  }
  public static Complex operator +(Complex arg1, Complex arg2) {
    return (new Complex(arg1.re + arg2.re, arg1.im + arg2.im));
  }

  public static Complex operator -(Complex arg1) {
    return (new Complex(-arg1.re, -arg1.im));
  }

  public static Complex operator -(Complex arg1, Complex arg2) {
   return (new Complex(arg1.re - arg2.re, arg1.im - arg2.im));
  }

  public static Complex operator *(Complex arg1, Complex arg2) {
    return (new Complex(
               arg1.re * arg2.re - arg1.im * arg2.im, 
               arg1.re * arg2.im + arg2.re * arg1.im));
  }

  public static Complex operator /(Complex arg1, Complex arg2) {
    double c1, c2, d;
    d = arg2.re * arg2.re + arg2.im * arg2.im;
    if (d == 0) {
      return (new Complex(0, 0));
    }
    c1 = arg1.re * arg2.re + arg1.im * arg2.im;
    c2 = arg1.im * arg2.re - arg1.re * arg2.im;
    return (new Complex(c1 / d, c2 / d));
  }

  public double Abs() {
    return (Math.Sqrt(re * re + im * im));
  }

  public double Arg() {
   double ret = 0;
   if (re != 0)
    ret = (180 / Math.PI) * Math.Atan(im / re);
    return (ret);
  }

  public override string ToString() {
    return (String.Format("Complex: ({0}, {1})", re, im));
  }

  private double re;
  private double im;
}
