using System;
class MainClass {
  public static void Main (string[] args) {
    double trab_hora;
    double qtd_hora;
    double salario;
    double IR;
    double INSS;
    double sindicato;
    double salarioliquido;
    Console.WriteLine ("Quanto você ganha por hora? ");
    trab_hora = double.Parse(Console.ReadLine());
    Console.WriteLine ("Quantas horas você trabalha por mês? ");
    qtd_hora=double.Parse(Console.ReadLine());
    salario= trab_hora*qtd_hora;
    IR=salario*0.11;
    INSS=salario*0.08;
    sindicato=salario*0.05;
    salarioliquido=salario - (IR+INSS+sindicato);
    Console.WriteLine ("-----------------------------------");
    Console.WriteLine ("*Salario Bruto: R$"+ salario);
    Console.WriteLine ("*IR (11%): R$"+ IR);
    Console.WriteLine ("*INSS (8%): R$"+ INSS);
    Console.WriteLine ("*Sindicato (5%): R$"+sindicato);
    Console.WriteLine ("-----------------------------------");
    Console.WriteLine ("Salario Liquido: R$"+ salarioliquido);
  }
}
