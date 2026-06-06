Console.Write("Введите количество чисел в первом списке: ");
int n1 = int.Parse(Console.ReadLine()!);
Console.WriteLine("Введите числа первого списка через пробел:");
string[] first = Console.ReadLine()!.Split(' ');
List<int> list1 = first.Select(int.Parse).ToList();

Console.Write("Введите количество чисел во втором списке: ");
int n2 = int.Parse(Console.ReadLine()!);
Console.WriteLine("Введите числа второго списка через пробел:");
string[] second = Console.ReadLine()!.Split(' ');
List<int> list2 = second.Select(int.Parse).ToList();

List<int> common = list1.Intersect(list2).OrderBy(x => x).ToList();

Console.WriteLine("Числа, входящие в оба списка в порядке возрастания:");
foreach (int num in common)
    Console.Write(num + " ");
Console.WriteLine();



string word = "pythonist";
Dictionary<char, int> letterCount = new Dictionary<char, int>();

foreach (char c in word)
{
    if (letterCount.ContainsKey(c))
        letterCount[c]++;
    else
        letterCount.Add(c, 1);
}

Console.WriteLine("Словарь букв строки 'pythonist':");
foreach (var (k, v) in letterCount)
{
    Console.WriteLine(k + " -> " + v);
}
