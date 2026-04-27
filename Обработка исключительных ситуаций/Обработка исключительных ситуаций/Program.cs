try
{
    Console.WriteLine("Введите катет прямоугольного треугольника А: ");
    double A = double.Parse(Console.ReadLine()!);
    Console.WriteLine("Введите катет прямоугольного треугольника B: ");
    double B = double.Parse(Console.ReadLine()!);
    Console.WriteLine("Введите гипотенузу прямоугольного треугольника С: ");
    double C = int.Parse(Console.ReadLine()!);

    if (B == 0) throw new PointException("SinA =", new MyPoint(A, C, B));
    double angleA = Math.Asin(A / C);
    Console.WriteLine($"{angleA:F2}");

}
catch (PointException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");


}


class MyPoint
{
    public double A { get; set; }
    public double C { get; set; }
    public double B { get; set; }

    public MyPoint(double a, double c, double b)
    {
        A = a;
        C = c;
        B = b;
    }


    public override string ToString()
    {
        return $"({A}{C}{B})";
    }


}
class PointException : Exception
{
    public MyPoint Value { get; }
    public PointException(string? message, MyPoint val) : base(message)
    {
        Value = val;
    }
}
