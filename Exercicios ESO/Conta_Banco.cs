using System;

class MainClass {
  public static void Main (string[] args) {

    string[] nome = new string[20];
    string[] senha = new string[20];
    string[] cpf = new string[20];
    string conta="";
    string desejacriar= "ok";
    int idade = 0;
    string i = "1";
    double saque;
    double deposito;
    int c = 0;

    Console.WriteLine ("Já possui conta? ( Sim ou Não) ");
    conta = Console.ReadLine();
    while ( c <=1){
      if(conta == "sim" || conta == "Sim"){
             Console.WriteLine ("-------------------------------");
             Console.WriteLine ("----LOGIN FEITO POR DIGITAL----");
             Console.WriteLine ("-------------------------------");
             Console.WriteLine ("Escolha uma opção::");
             Console.WriteLine ("1- SACAR");
             Console.WriteLine ("2- DEPOSITAR");
             Console.WriteLine ("3- EXTRATO");
             Console.WriteLine ("4- POUPANÇA");
             i = Console.ReadLine();
              if( i == "2"){
                Console.WriteLine ("Digite o Valor do depósito: ");
                deposito = double.Parse(Console.ReadLine());
                Console.WriteLine ("DEPOSITO autorizado! Valor: "+ deposito);
                Console.WriteLine ("-------------------------------");
                Console.WriteLine ("Escolha uma opção::");
                Console.WriteLine ("1- SACAR");
                Console.WriteLine ("2- DEPOSITAR");
                Console.WriteLine ("3- EXTRATO");
                Console.WriteLine ("4- POUPANÇA");
              }
              
              if ( i == "1"){
                Console.WriteLine ("Digite o Valor do saque");
              saque = double.Parse(Console.ReadLine());
              Console.WriteLine ("Saque autorizado! Valor: "+ saque);
              }
             }

      while ( i != "0"){
      if(conta == "não" || conta == "Não"){
        Console.WriteLine ("Deseja criar uma conta?");
        desejacriar = Console.ReadLine();

      if(desejacriar == "não" || desejacriar == "Não"){
             Console.WriteLine ("Até mais. )");
           }
        if(desejacriar == "Sim" || desejacriar == "sim"){
          Console.WriteLine ("Digite o Seu Nome: ");
          nome[0] = Console.ReadLine();
          Console.WriteLine ("Digite a sua idade:");
           idade = int.Parse(Console.ReadLine());
           Console.WriteLine ("Digite o seu CPF:");
           cpf[0] = Console.ReadLine();
           Console.WriteLine ("Digite uma senha de 4 números: ");
           senha[0] = Console.ReadLine();
           Console.WriteLine (nome[0] +", SUA CONTA FOI CRIADA!! ");
           i = "0";
          }
        }
      }
      
       c=c+1;
       Console.WriteLine ("ÓLA, BEM VINDO AO BANK");
    Console.WriteLine ("Já possui conta? ( Sim ou Não) ");
    conta = Console.ReadLine();
    }
   }
 }
