using System;

class MainClass {
  public static void Main (string[] args) {

  Conta cc = new ContaCorrente("Jose", "2343", 4.50f);  
  ContaPoupanca cp = new ContaPoupanca("Joao", "5345", 0.03f);
  cc.Depositar(1000.0f);
  cc.Sacar(100.0f);
  cp.Depositar(1000.0f);
  cp.Sacar(100.0f);

   Conta[] contas = new Conta[]{ cc, cp};

    foreach(Conta c in contas){
      Console.WriteLine(c.GetSaldo());
    }
  }
}