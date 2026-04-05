//Вариант 18
Random random = new Random();
int[] tickets = new int[20];
for (int i = 0; i < 20; i++)
{
    tickets[i] = random.Next(100000, 1000000);
}
Func<int, int> FirstSumThreeDigits = (num) =>
{
    int hundreds = num / 100;     
    int tens = num / 10 % 10;      
    int ones = num % 10;           
    return hundreds + tens + ones; 
};

Func<int, int> LastSumThreeDigits = (num) =>
{

    int hundreds = num / 100;    
    int tens = num / 10 % 10;    
    int ones = num % 10;           
    return hundreds + tens + ones; 
};

Func<int, bool> isLucky = (t) => 
    FirstSumThreeDigits(t / 1000) == LastSumThreeDigits(t % 1000);

Func<int[], int?> FindN =  (int[] arr) =>
{
    int? n = null;
    for (int i = 0; i < arr.Length; i++)
    {
        if (isLucky(arr[i]))
        {
            if (n == null || arr[i] > n)
                n = arr[i];
        }
    } return n;
};


Func<int[], int?> FindM = (int[] arr) =>
{
    int? m = null;
    for (int i = 0; i < arr.Length; i++)
    {
        if (isLucky(arr[i]))
        {
            if (m == null || arr[i] < m)
                m = arr[i];
        }
    }
    return m;
};




for (int i = 0; i < tickets.Length; i++)
{
    if (isLucky(tickets[i]))
    {
        Console.WriteLine("Номер билета" + " " + tickets[i]+ " " +"Счастилвый билет" );
        
  
        
    }
    else
    {
        Console.WriteLine("Номер билета" + " " + tickets[i] + " " + "Несчастливый билет" );
    }
}
int? N = FindN(tickets);
int? M = FindM(tickets);

if( N != null )
{
    Console.WriteLine("Больший счастливый билет (N): " + " " + N);
   
}
else
{
    Console.WriteLine("Счастливых билетов не найдено");
}

if( M != null)
{
    Console.WriteLine("Меньший счастливый билет (N): " + " " + M);
}
else
{
    Console.WriteLine("Счастливых билетов не найдено");
}
