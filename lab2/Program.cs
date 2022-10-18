using System.Threading.Tasks.Dataflow;

public class App
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Repeat("#", 5));
        Console.WriteLine(RepeatRecursive("#", 5));
        Console.WriteLine(string.Join(",", Change(10)));
        Console.WriteLine(QuickFib(46));
        int[] arr = { 3, 5, 1, 7, 9, 4 };

        BubleSort(arr);
        Console.WriteLine(string.Join(" ", arr));
        
    }

    public static string Repeat (string s , int n )
    {
        string result = "";
        for(int i = 0; i < n; i++)
        {
            result = result + s;
        }
        return result;
    }
    public static int ArraySum(int[] arr, int start, int end)
    {
        throw new ArgumentException;
    }
    public static string RepeatRecursive( string s , int n)
    {
        if (n <= 0)
        {
            return "";
        }
        return RepeatRecursive(s, n - 1) + s;
    }

    //reszta dla 1 2 5
    public static int[] Change(int amount)
    {
        int[] arr = new int[3];
        arr[2] = amount / 5;
        amount = amount - arr[2] * 5;
        arr[1] = amount / 2;
        amount = amount - arr[1] * 2;
        arr[0] = amount / 1;
        amount = amount - arr[0] * 1;
        return arr;
    }

    public static long Fib(int n)
    {
        if (n < 2)
        {
            return n; 
        }
        Console.WriteLine($"Fib({n - 2}) + Fib({n - 1 })");
        return Fib(n - 2) + Fib(n - 1);
    }

    public static long FibMem(int n, long[] mem)
    {
        if (n < 2)
        {
            return n;
        }
        if (mem[n - 1] == 0)
        {
            mem[n - 1] = FibMem(n - 1, mem);
        }
        if (mem[n - 2] == 0)
        {
            mem[n - 2] = FibMem(n - 2, mem);
        }
        return mem[n - 2] + mem[n - 1];
    }
    public static long QuickFib(int n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException("Numer wyrazu nie może być ujemny!");
        }
        return FibMem(n, new long[n]);
    }

    public static void BubleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = arr.Length - 1; j > i; j--)
            {
                if (arr[j] < arr[j -1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                }
            }
        }
    }

}

