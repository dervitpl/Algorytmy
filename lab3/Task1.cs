namespace task_1
{
    public class Task1
    {
        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 6, 9, 4, 3 };
            //int[] arr = { 1, 3, 2, 8, 2 };
            Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 0));          //false
            Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 6));          //true
            Console.WriteLine(IsInArrayRecursive(new int[] { }, 0, arr.Length - 1, 5));          //false
            Console.WriteLine(Factorial(3));
            Console.WriteLine(SumMod3(arr, arr.Length - 1, 0));
            Console.WriteLine(IndexOfSumOfOthers(arr, arr.Length - 1, 0));
        }
        public static bool IsInArray(int[] arr, int value)
        {
            return IsInArrayRecursive(arr, 0, arr.Length, value);
        }
        /**
         * REKURENCJA
         */
        //Zaimplementuj funkcję, która strategią dziel i zwyciężaj zwróci prawdę jeśli w tablicy
        //'arr' znajduje się wartość parametru 'value'.
        //Przykład
        //int[] arr = { 1, 2, 6 ,9 ,4, 3};
        //Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 0);          //false
        //Console.WriteLine(IsInArrayRecursive(arr, 0, arr.Length - 1, 6);          //true
        //Console.WriteLine(IsInArrayRecursive(new int[]{}, 0, arr.Length - 1, 5);          //false
        public static bool IsInArrayRecursive(int[] arr, int left, int right, int value)
        {
            if (left == arr.Length)
            {
                return false;
            }
            else if (left > right)
            {
                return false;
            }
            else if (value == arr[right])
            {
                return true;
            }
            else
            {
                return IsInArrayRecursive(arr, 0, right - 1, value);
            }
        }


        //Zdefiniuj funkcję rekurecyjną, która oblicza sumę elementów tablicy podzielnych przez 3
        //Nie można używać instrukcji iteracyjnych!!! Wartość funkcja dla pustej tablicy wynosi 0.
        //Można założyć, że tablica nie będzie równa null. Zdefiniuj funkcję pomocniczą która będzie wywoływana
        //rekurencyjnie wewnątrz SumMod3.
        public static long SumMod3(int[] arr, int index, int result)
        {

            if (arr[index] % 3 == 0)
            {
                result += arr[index];
            }
            else if (index == 0)
            {
                return result;
            }
            return SumMod3(arr, index - 1, result);
        }

        //Zdefiniuj funkcję rekurencyjną, która oblicza silnię liczby.
        public static long Factorial(int num)
        {
            if (num == 0)
            {
                return 1;
            }
            else
            {
                return num * Factorial(num - 1);
            }

        }

        /**
         * ALGORYTMY I ZŁOŻONOŚĆ
         */
        //Zdefiniuj funkcję, która zwróci indeks liczby, która jest równa sumie pozostałych elementów tablicy
        //Przykład
        //int[] arr = {1, 3, 2, 8, 2};
        //int index = IndexOfSumOfOthers(arr);
        //funkcja w `index` powinna zwrócić 3, gdyż pod tym indeksem jest 8 równe sumie 1 + 3 + 2 + 2.
        //Jeśli w tablicy nie ma takiej liczby lub tablica jest pusta to funkcja pownna zwrócić -1.
        public static int IndexOfSumOfOthers(int[] arr, int index, int result)
        {
            int num = arr[index];
            if (num == (SumOfArray(arr, arr.Length - 1, 0) - arr[index]))
            {
                return index;
            }
            else if (index == 0)
            {
                return -1;
            }
            return IndexOfSumOfOthers(arr, index - 1, result);
        }
        public static int SumOfArray(int[] arr, int index, int result)
        {
            result += arr[index];

            if (index == 0)
            {
                return result;
            }
            return SumOfArray(arr, index - 1, result);
        }
    }
}