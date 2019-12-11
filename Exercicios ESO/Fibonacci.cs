using System;

class MainClass {
  public static void Main (string[] args) {
    double var1=0;
    double var2=1;
    double varx;
    for(int i=0;i<1000;i++){
      varx= var1+var2;
      var1=var2;
      var2=varx;
      Console.WriteLine (varx);
    }
  }
}
