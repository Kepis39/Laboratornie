//Вариант 8 средний уровень
using System;
using System.Collections.Generic;
Random random = new Random();
List<double> numbers = new List<double>();
List<double> filtred = new List<double>();

for (double i = 0; i < 9; i++)
{
    numbers.Add( random.NextDouble()* 100);
}
Console.WriteLine($"Текущий массив ");
foreach (double num in numbers)
{
    if (Math.Abs(num) > 10)
    {
        
        filtred.Add(num);
    }
    Console.WriteLine($"{num:F2}");
}
Console.WriteLine($"Новый массив ");
for (int i = 0; i < filtred.Count; i++)
{
    Console.WriteLine($" {filtred[i]:F2}");
}

