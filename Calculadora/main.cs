using System;

class MainClass {
  public static void Main (string[] args) {
    bool flag = true;
    string action;

    while(flag == true){
      Console.WriteLine("Escolha a operação que deseja realizar:\n1. Soma\n2. Subtração\n3. Multipliucação\n4. Divisão\n5. Sair");
      action = Console.ReadLine();
      int[] numeros = new int[2]; 

      
      switch(action){
        case "1":
          numeros = Interacao.Pergunta();
          Console.WriteLine("A resultado da soma é "+Calculadora.Soma(numeros[0], numeros[1])+".");
          Console.ReadKey();
          Console.Clear();
          break;

          case "2":
          numeros = Interacao.Pergunta();
          Console.WriteLine("A resultado da subtração é "+Calculadora.Subtracao(numeros[0], numeros[1])+".");
          Console.ReadKey();
          Console.Clear();
          break;

          case "3":
          numeros = Interacao.Pergunta();
          Console.WriteLine("A resultado da multiplicação é "+Calculadora.Multiplicacao(numeros[0], numeros[1])+".");
          Console.ReadKey();
          Console.Clear();
          break;

          case "4":
          numeros = Interacao.Pergunta();
          Console.WriteLine("A resultado da divisão é "+Calculadora.Divisao(numeros[0], numeros[1])+".");
          Console.ReadKey();
          Console.Clear();
          break;

          case "5":
          Console.Clear();
          Console.WriteLine("Até mais!");
          flag = false;
          break;
          

      }

    }
  }
}