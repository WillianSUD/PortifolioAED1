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

class Conta{
  private string titular;
  private string numero;
  private float saldo;

  public Conta(string titular, string n){
    this.titular = titular;
    this.numero = n;
    this.saldo = 0f;
  }

  public bool Sacar(float vlr_saque){
    if(saldo >= vlr_saque && vlr_saque > 0){
      saldo -= vlr_saque;
      return true;
    }
    return false; 
  }

  public bool Depositar(float vlr_deposito){
    if(vlr_deposito > 0){
      saldo += vlr_deposito;
      return true;
    }
    return false;
  }

  public string GetSaldo(){
    return string.Format("R$ {0}",saldo);
  }
}

class ContaCorrente : Conta{
  private float tx_movimentacao;

  public ContaCorrente(string t, string n, float tx)
  :base (t, n)
  {
    tx_movimentacao = tx;
  }

  public new bool Sacar(float vlr_saque){
    float aux = vlr_saque + tx_movimentacao;
    return base.Sacar(aux);
  }
} 

class ContaPoupanca : Conta{
  private float tx_rendimento;

  public ContaPoupanca(string t, string n, float tx)
  :base (t, n)
  {
    tx_rendimento = tx;
  }
} 
