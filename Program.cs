using System;

public class Node<T> {
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data) {
        Data = data;
        Next = null;
    }
}

public class LinkedList<T> {
    private Node<T> head;

    public LinkedList() {
        head = null;
    }

    
    public void Add(T data) {
        Node<T> newNode = new Node<T>(data);
        if (head == null) {
            head = newNode;
        } else {
            Node<T> current = head;
            while (current.Next != null) {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    
    public void PrintList() {
        Node<T> current = head;
        while (current != null) {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    
    public bool Remove(T data) {
        if (head == null) return false;

        
        if (head.Data.Equals(data)) {
            head = head.Next;
            return true;
        }

        Node<T> current = head;
        Node<T> previous = null;

        while (current != null && !current.Data.Equals(data)) {
            previous = current;
            current = current.Next;
        }

        
        if (current == null) return false;

        
        previous.Next = current.Next;
        return true;
    }

  
    public int Count() 
     {
        int count = 0;
        Node<T> current = head;
        while (current != null) {
            count++;
            current = current.Next;
        }
        return count;
    }
}

//Sorting Algorithm -- Heap Sort
public class HeapSort {
    
    public void Sort(int[] arr) {
        int n = arr.Length;

        for (int i = n / 2 - 1; i >= 0; i--) {
            Heapify(arr, n, i);
        }
        
        for (int i = n - 1; i > 0; i--) {
            
            Swap(arr, 0, i);
      
            Heapify(arr, i, 0);
        }
    }

    
    private void Heapify(int[] arr, int n, int i) {
        int largest = i; 
        int left = 2 * i + 1; 
        int right = 2 * i + 2; 

        
        if (left < n && arr[left] > arr[largest]) {
            largest = left;
        }

        
        if (right < n && arr[right] > arr[largest]) {
            largest = right;
        }

        
        if (largest != i) {
            Swap(arr, i, largest);

            Heapify(arr, n, largest);
        }
    }
    
    private void Swap(int[] arr, int i, int j) {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}

public class Main {
    public static void Main(string[] args) {
        LinkedList<int> linkedList = new LinkedList<int>();

        
        linkedList.Add(1);
        linkedList.Add(453);
        linkedList.Add(47);
        linkedList.Add(33);

        Console.WriteLine("Linked List:");
        linkedList.PrintList();

        Console.WriteLine("Count of nodes: " + linkedList.Count());

      linkedList.Remove(47);
        Console.WriteLine("47 is removed:");
        linkedList.PrintList();

        Console.WriteLine("Count of nodes after removing a node: " + linkedList.Count());



        //Using HeapSort to sort an array
        int[] arr = { 1142, 181, 13, 500, 6, 798 };
        HeapSort heapSort = new HeapSort();

        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(", ", arr));

        heapSort.Sort(arr);

        Console.WriteLine("Sorted array:");
        Console.WriteLine(string.Join(", ", arr));
    }
}
