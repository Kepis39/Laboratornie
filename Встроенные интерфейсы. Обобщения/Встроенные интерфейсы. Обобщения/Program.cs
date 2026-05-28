using System.Collections;

Console.WriteLine("=== Ввод данных о платежах ===");
Order<string>[] orders = new Order<string>[8];

for (int i = 0; i < orders.Length; i++)
{
    Console.WriteLine($"\nЗапись {i + 1}:");
    Console.Write("Расчетный счет плательщика: ");
    string payer = Console.ReadLine()!;
    Console.Write("Расчетный счет получателя: ");
    string recipient = Console.ReadLine()!;
    Console.Write("Перечисляемая сумма в рублях: ");
    double amount = double.Parse(Console.ReadLine()!.Replace('.', ','));

    orders[i] = new Order<string>(payer, recipient, amount);
}
Array.Sort(orders);
Console.WriteLine("\nЗаписи после сортировки по счету плательщика (IComparable) ===");
foreach (var item in orders) Console.WriteLine(item);
Console.WriteLine();
Array.Sort(orders, new OrderByAmountComparer());
Console.WriteLine("");
foreach (var item in orders) Console.WriteLine(item);
Console.WriteLine();
Order<string> original = orders[0];
Order<string> cloned = (Order<string>)original.Clone();
Console.WriteLine($" {original}");
Console.WriteLine($" {cloned}");
Console.WriteLine($" {original.PayerAccount == cloned.PayerAccount && original.Amount == cloned.Amount}");
Console.WriteLine($" {ReferenceEquals(original, cloned)}");
Console.WriteLine();


Console.Write("Введите расчетный счет плательщика для поиска: ");
string searchAccount = Console.ReadLine()!;

int index = Array.BinarySearch(orders, new Order<string>(searchAccount, "", 0));

if (index >= 0)
{
    Console.WriteLine($"\nНайдена запись: {orders[index]}");
    Console.WriteLine($"Сумма, снятая со счета: {orders[index].Amount:F2} руб.");
}
else
{
    Console.WriteLine("\nРасчетный счет не найден!");
}
foreach (var order in orders) Console.WriteLine(order);
var enumerator = orders.GetEnumerator();
while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current);
}

class Order<T> : ICloneable, IComparable<Order<T>> where T : IComparable<T>
{
    public T PayerAccount { get; set; }       
    public string RecipientAccount { get; set; } 
    public double Amount { get; set; }    
    public Order(T payerAccount, string recipientAccount, double amount)
    {
        PayerAccount = payerAccount;
        RecipientAccount = recipientAccount;
        Amount = amount;
    }

    public object Clone()
    {
        return new Order<T>(PayerAccount, RecipientAccount, Amount);
    }

    public int CompareTo(Order<T>? other)
    {
        if (other == null) return 1;
        return PayerAccount.CompareTo(other.PayerAccount);
    }

    public override string ToString()
    {
        return $"Плательщик: {PayerAccount}, Получатель: {RecipientAccount}, Сумма: {Amount:F2} руб.";
    }
}
class OrderByAmountComparer : IComparer<Order<string>>
{
    public int Compare(Order<string>? x, Order<string>? y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        return x.Amount.CompareTo(y.Amount);
    }
}
