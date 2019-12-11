static void Main(string[] args)
{
    double[] xValues = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7, 8.8, 9.9, 10.0 };
    double[] yValues = { 1.0, 2.9, 3.8, 4.7, 5.6, 6.5, 7.4, 8.3, 9.2, 10.1 };

    double xMedia = 0;
    double yMedia = 0;
    for (int index = 0; index < xValues.Length; index++)
    {
        xMedia += xValues[index];
        yMedia += yValues[index];
    }
    xMedia = xMedia / xValues.Length;
    yMedia = yMedia / yValues.Length;

    double dividendo = 0; 
    double divisor = 0; 
    for (int index = 0; index < xValues.Length; index++)
    {
        dividendo += (xValues[index] - xMedia) * (yValues[index] - yMedia);
        // a soma do quadrado da dispersão das variáveis independentes (do eixo x)
        divisor += Math.Pow(xValues[index] - xMedia, 2);
    }

    double a = dividendo / divisor;
    double b = yMedia - a * xMedia;

    Console.WriteLine("y = ax + b");
    Console.WriteLine("a = {0} = a inclinação da linha de tendência.", Math.Round(a, 2));
    Console.WriteLine("b = {0} = o ponto onde a linha de tendência atinge o eixo y.", Math.Round(b, 2));
}
