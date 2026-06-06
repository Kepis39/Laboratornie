OurLinkedList list = new OurLinkedList();
Random random = new Random();

for (int i = 0; i < random.Next(10, 20); i++)
{
    list.Add(random.Next(-50, 50));
}

Console.WriteLine("Исходный список:");
list.Print();

list.RemoveAfterNegative();

Console.WriteLine("Список после удаления элементов после отрицательных:");
list.Print();
public class Node
{
    public Node(double data)
    {
        Data = data;
    }
    public double Data { get; set; }
    public Node? Next { get; set; }
    public Node? Prev { get; set; }
}

public class OurLinkedList  
{
    Node? head; 
    Node? tail; 
    int count; 

    public void Add(double data)
    {
        Node node = new Node(data);

        if (head == null)
        {
            head = node;
        }
        else
        {
            tail!.Next = node;
            node.Prev = tail;
        }
        tail = node;

        count++;
    }

    public void RemoveAfterNegative()
    {
        Node? current = head;
        while (current != null)
        {
            if (current.Data < 0)
            {
                Node? toRemove = current.Next;
                if (toRemove != null)
                {
                    current.Next = toRemove.Next;
                    if (toRemove.Next != null)
                        toRemove.Next.Prev = current;
                    else
                        tail = current;
                    count--;
                }
            }
            current = current.Next;
        }
    }

    public void Print()
    {
        if (head == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        Node? current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}
