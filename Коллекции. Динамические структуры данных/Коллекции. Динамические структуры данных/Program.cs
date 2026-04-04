//вариант 8 средние
using System.Collections;

Stack stack = new Stack();
stack.Push("sdf");
stack.Push("2");
stack.Push("ssd4");
stack.Push("hello");
foreach (string s in stack) Console.WriteLine(s + " ");
Console.WriteLine();
stack.Pop();
stack.Pop();
foreach (string s in stack) Console.WriteLine(s + " ");
int min = int.MaxValue;
foreach (string s in stack)
{
   if(int.TryParse(s, out min))
    {
        min = s.Length; break;
    }
}
Console.WriteLine($"{min}");