namespace Challenges.Modelos;
internal class Estatistica
{
    public static void Media(double[] array)
    {
        double denominador = array.Length;
        double numerador = 0;
        for (int i = 0; i < array.Length; i++)
        {
            numerador += array[i];
        }

        double media = numerador / denominador;
        Console.WriteLine($"A média aritimética dos valores dentro do array é: {media}");
    }
}
