public class Node<T>(T value)
{
    public T Value { get; set; } = value;
     
    public Node<T>? Next { get; set; } = null; 
    public Node<T>? Previous { get; set; } = null;
}

public class Deque<T>
{
    private Node<T>? frontNode; //front Node
    private Node<T>? backNode;  //back Node 
    public Deque()
    {
        frontNode = null;
        backNode = null;
    }

    //add an element to the front of the deque
    public void AddFront(T value)
    {
        var newNode = new Node<T>(value);
        if (frontNode == null)
        {
            frontNode = newNode;
            backNode = newNode;
        }
        else
        {
            newNode.Next = frontNode;
            frontNode.Previous = newNode;
            frontNode = newNode;
        }
    }

    //add an element to the back of the deque
    public void AddBack(T value)
    {
        var newNode = new Node<T>(value);
        if (backNode == null)
        {
            frontNode = newNode;
            backNode = newNode;
        }
        else
        {
            newNode.Previous = backNode;
            backNode.Next = newNode;
            backNode = newNode;
        }
    }

    //remove an element from the front of the deque
    public T RemoveFront()
    {
        if (frontNode == null) 
        throw new InvalidOperationException("Deque is empty");

        var frontValue = frontNode.Value;
        frontNode = frontNode.Next;

        if (frontNode == null)
        {
            backNode = null;
        }
        else
        {
            frontNode.Previous = null;
        }

        return frontValue;
    }

    //remove an element from the back of the deque
    public T RemoveBack()
    {
        if (backNode == null) 
        throw new InvalidOperationException("Deque is empty");

        var backValue = backNode.Value;
        backNode = backNode.Previous;

        if (backNode == null)
        {
            frontNode = null;
        }
        else
        {
            backNode.Next = null;
        }

        return backValue;
    }


    public bool IsEmpty()
    {
        return frontNode == null;
    }

   //check if the front of the deque is empty
    public T PeekFront()
    {
        if (frontNode == null) 
        throw new InvalidOperationException("Deque is empty");
        return frontNode.Value;
    }
    //check if theback of the deque is empty
    public T PeekBack()
    {
        if (backNode == null) 
        throw new InvalidOperationException("Deque is empty");
        return backNode.Value;
    }
}

class Program
{
    static void Main()
    {
        var deque = new Deque<int>();

        //adding elements to the list
        deque.AddFront(2);
        deque.AddBack(2);

        //display the current state of the deque in the List
        Console.WriteLine("Current deque state of the List:");
        Console.WriteLine("Front: " + deque.PeekFront());
        Console.WriteLine("Back: " + deque.PeekBack());

        while (true)
        {
            Console.WriteLine("\nChoose an Option:");
            Console.WriteLine("1. Add to the front");
            Console.WriteLine("2. Add to the back");
            Console.WriteLine("3. Remove from the front");
            Console.WriteLine("4. Remove from the back");
            Console.WriteLine("5. Type exit to exit the program");
            Console.Write("Make a choice: ");
            string userInput = Console.ReadLine().Trim().ToLower();

            if (userInput == "exit")
            {
                break;
            }

            try
            {
                switch (userInput)
                {
                    case "1":
                        Console.Write("Enter the value to add to the front: ");
                        int addFrontValue = int.Parse(s: Console.ReadLine());
                        deque.AddFront(addFrontValue);
                        Console.WriteLine("Added " + addFrontValue + " to the front");
                        break;

                    case "2":
                        Console.Write("Enter the value to add to the back: ");
                        int addBackValue = int.Parse(Console.ReadLine());
                        deque.AddBack(addBackValue);
                        Console.WriteLine("Added " + addBackValue + " to the back");
                        break;

                    case "3":
                        //if the deque is not empty
                        if (!deque.IsEmpty())
                        {
                            Console.WriteLine("Removed from front: " + deque.RemoveFront());
                        }
                        else
                        {
                            Console.WriteLine("The deque is empty");
                        }
                        break;

                    case "4":
                        //if the deque is not empty
                        if (!deque.IsEmpty())
                        {
                            Console.WriteLine("Removed from back: " + deque.RemoveBack());
                        }
                        else
                        {
                            Console.WriteLine("The deque is empty");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. select 1, 2, 3, 4, or type 'exit'");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid choice. select 1, 2, 3, 4, or type 'exit'");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            //display the current state of the deque of the List after adding or removing
            if (!deque.IsEmpty())
            {
                Console.WriteLine("Current deque state:");
                Console.WriteLine("Front: " + deque.PeekFront());
                Console.WriteLine("Back: " + deque.PeekBack());
            }
            else
            {
                Console.WriteLine("The deque does not contain anything");
            }
        }
    }
}
    

