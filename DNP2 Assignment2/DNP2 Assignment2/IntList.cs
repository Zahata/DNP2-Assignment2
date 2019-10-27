using System;
using System.Collections.Generic;
// Delegate types to describe predicates on ints and actions on ints.
public delegate bool IntPredicate(int x);
public delegate void IntAction(int x);
// Integer lists with Act and Filter operations.
// An IntList containing the element 7 9 13 may be constructed as
// new IntList(7, 9, 13) due to the params modifier.
class IntList : List<int>
{
    public IntList(params int[] elements) : base(elements) { }
    public void Act(IntAction f)
    {
        foreach (int i in this)
        {
            f(i);
        }
    }
    public IntList Filter(IntPredicate p)
    {
        IntList res = new IntList();
        foreach (int i in this)
            if (p(i))
                res.Add(i);
        return res;
    }
}
class Program
{
    public static void Main(String[] args)
    {
        IntList intList = new IntList();
        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.Add(4);
        intList.Add(5);
        intList.Add(6);
        intList.Add(7);
        intList.Add(8);
        intList.Add(9);
        intList.Add(25);
        intList.Add(27);
        intList.Add(30);

        intList.Act(Console.WriteLine);
        Console.WriteLine();
        intList.Filter(delegate (int x) { return x % 2 == 0; }).Act(Console.WriteLine);
        Console.WriteLine();
        // First way of using anonymous method to print numbers greather than 25
        intList.Filter(delegate (int x) { return x >= 25; }).Act(Console.WriteLine);
        Console.WriteLine();
        // Second way of using anonymous method to print numbers greather than 25
        intList.Filter(x => x >= 25).Act(Console.WriteLine);

        Console.ReadKey();
    }
}