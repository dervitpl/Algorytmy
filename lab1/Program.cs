
namespace AlgorytmyLab1
{
    public class Lab1
    {
        public static void Main(string[] args)
        {
            int[] arr1 = { 23, 1, 56, 345, 1, 5, 67, 11 };
            int index = FindTwoDigitMin(arr1);
            if (index == 7)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            int[] arr2 = { };
            index = FindTwoDigitMin(arr2);
            if (index == -1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            int[] arr3 = { 1, 3, 4, 123, 1234 };
            index = FindTwoDigitMin(arr3);
            if (index == -1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
        }
        public static int FindTwoDigitMin(int[] arr)
        {

            if (arr == null || arr.Length == 0)
            {
                return -1;
            }
            int minValue = 99;
            int index = -1;
            foreach (int num in arr)
            {
                index++;
                if (num <= minValue && num >= 10 && num <= 99)
                {
                    minValue = num;
                }
            }
            if (minValue == 99)
            {
                return -1;
            }
            return index;
        }

    }
    
}