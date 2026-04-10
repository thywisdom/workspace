using System;
using System.Reflection;
using System.Text.RegularExpressions;


using Sortings;
using Search;
using Tree;

using Exceptions;

public class OrderProcessor
{
    public void PlaceOrder (int orderAmount)
    {
        if(orderAmount < 0)
        {
            throw new InvalidOrderException("The OrderAmount cannot be Negative , add some more ordrs");
        }

        Console.WriteLine($"Order placed successfully. Amount: {orderAmount}");
    }
}

public class SetAge
{
    public void UpdateAge (int age)
    {
        if(age < 0 || age > 120)
        {
            throw new InvalidAgeException(age, "Age must be between 0 and 120.");
        }

        Console.WriteLine($"Age set successfully. Age: {age}");
    }
}



class Program
{
    public static void Main()
    {
        try
        {   
            // SetAge ageSetter = new SetAge();
            // ageSetter.UpdateAge(130);

            OrderProcessor order = new OrderProcessor();
            order.PlaceOrder(-1);
            

            // int n = int.Parse(Console.ReadLine());
            // int[] record = Array.ConvertAll(Console.ReadLine().Trim().Split(),int.Parse);

            // BSTree tree = new BSTree();

            // foreach ( int data in record)
            // {
            //     tree.Insert(data);
            // }

            // Console.WriteLine("\n");
            // Console.Write(" INORDER --> ");
            // tree.Inorder(tree.Root);

            // Console.WriteLine("\n");
            // Console.Write(" PREORDER --> ");
            // tree.Preorder(tree.Root);

            // Console.WriteLine("\n");
            // Console.Write(" POSTORDER --> ");
            // tree.Postorder(tree.Root);

            // Console.WriteLine("\n");


        // int[] numbers = { 34, 7, 23, 32, 5, 62, 2};

        // Console.WriteLine("Original array: " + string.Join(", ", numbers));

        // QuickSort sorter = new QuickSort();
        // sorter.Quicksort(numbers, 0, numbers.Length - 1);

        // MergeSort sorter = new MergeSort();
        // sorter.Mergesort(numbers,0,numbers.Length-1);

        // Bubblesort sorter = new Bubblesort();
        // sorter.BubbleSort(numbers);

        // Selectionsort sorter = new Selectionsort();
        // sorter.SelectionSort(numbers);

        // Insertionsort sorter = new Insertionsort();
        // sorter.InsertionSort(numbers);

        // Heapsort sorter = new Heapsort();
        // Binarysearch searcher = new Binarysearch();
        // Linearsearch searcher = new Linearsearch();

        // sorter.HeapSort(numbers);
        

        // Console.WriteLine("Sorted array: " + string.Join(", ", numbers));
        
        //Console.WriteLine("Element found at Index: " + searcher.BinarySearch(numbers,0,numbers.Length,32));
        // Console.WriteLine("Element found at Index: " + searcher.LinearSearch(numbers,34));

         /*  string? s = Console.ReadLine();

        string f = Regex.Replace(s,"[^A-Za-z ]",string.Empty);
        var S = f.Trim().Split(' ',StringSplitOptions.RemoveEmptyEntries); 
        var R = string.Join(",",S);

        Console.WriteLine($"{R}");

        string?[] num = Console.ReadLine().Trim().Split(' '); 

        int[] res = num.Select(int.Parse).OrderByDescending(n => n).ToArray();
        int[] res = Array.ConvertAll(Console.ReadLine().Trim().Split(),int.Parse);

        Console.WriteLine(string.Join("  ",res.OrderBy(n => n)));
        Console.WriteLine(res.Sum(n => n)); */


        } catch(Exception e)

        {
            Console.WriteLine(e.Message);
        }

    }
}