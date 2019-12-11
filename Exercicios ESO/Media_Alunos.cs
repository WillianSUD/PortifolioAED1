
using System;

class MainClass {
  public static void Main (string[] args) {
    int num=0;
    double n1;
    double n2;
    double media;
    double mediafinal=0;
    int cont=0;
    while(num<10){
    Console.WriteLine ("Digite a nota 1:");
    n1= double.Parse(Console.ReadLine());
    Console.WriteLine ("Digite a nota 2:");
    n2= double.Parse(Console.ReadLine());
    media= (n1+n2)/2;
    mediafinal= mediafinal+media;
    if(media>5){
      cont = cont+1;
    }
    num=num+1;
    }
    Console.WriteLine ("*************************************");
    if(cont==0){
    Console.WriteLine ("Não há alunos com nota acima de 5.");
    }
    if(cont!=0){
    Console.WriteLine ("Existem "+cont+ " alunos acima da média.");
    }
    Console.WriteLine ("A média total foi: "+mediafinal/num); 
  }
}
