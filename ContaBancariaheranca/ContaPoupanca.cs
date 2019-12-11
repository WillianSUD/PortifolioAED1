class ContaPoupanca : Conta{
  private float tx_rendimento;

  public ContaPoupanca(string t, string n, float tx)
  :base (t, n)
  {
    tx_rendimento = tx;
  }

} 