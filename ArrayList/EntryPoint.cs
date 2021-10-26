using System;
using MyArrayList;

namespace EntryPoint
{
    class EntryPoint
    {

        static void Main(string[] args)
        {
            ArrayList arr = new ArrayList(new int[] { 7, 6, 2, 4, 1 });
            //Console.WriteLine(arr.Length);
            arr.AddFirst(new ArrayList(new int[] { 3, 3, 3, 999 }));
            arr.Sort();
            arr.Print();
            ////arr.AddLast(1);
            ////arr.AddLast(2);
            //arr.Print();
            //Console.ReadKey();
            //arr.AddFirst(3);
            //arr.Print();
            //arr.AddAt(2, 4);
            //arr.Print();
            //arr.RemoveLast();
            //arr.Print();
            //arr.RemoveFirst();
            //arr.Print();
            //Console.ReadKey();
            Type t = arr.GetType();
            foreach (var method in t.GetMethods())
            {
                Console.WriteLine(method.Name);
            }

        }
    }
}
