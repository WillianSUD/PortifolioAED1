using System;

static class Interacao{
  public static int[] Pergunta(){
    int num1;
    int num2;
    Console.WriteLine("Digite um numero: ");
    num1 = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite outro número: ");
    num2 = int.Parse(Console.ReadLine());
    var numeros = new int[] {num1, num2};
    return numeros;
  }
}