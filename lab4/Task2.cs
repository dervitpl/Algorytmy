
namespace task_2
{
    public class Task2
    {
        /// <summary>
        /// W tablicy gold znajdują się dodatnie liczby reprezetujące złoto. 
        /// Górnik zbiera złoto z komórek, zaczyna od dowolnej komórki górnego wiersza (n) i 
        /// i porusza się w dół do dolnego wiersza (0). Może przejść tylko do komórki po prawej lub
        /// do komórki na przekątnej: w prawo w górę lub w prawo w dół, ale ostatecznie musi znaleźć się w dolnym wierszu (0).
        /// Zaimplementuj algorytm, który wyznaczy największa liczbę złota zebraną przez górnika.
        /// </summary>
        /// <param name="gold">Dwuwymiarowa tablica liczb dodatnich</param>
        /// <returns>Liczba zebranego złota</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <summary>
        // Przykłady
        // Wejście: gold[][] = {{1, 3, 3},
        //     {2, 1, 4},
        //     {0, 6, 4}};
        // Wyjście: 12
        // {(1,0)->(2,1)->(1,2)}
        //
        // Wejście: gold[][] = { {1, 3, 1, 5},
        //     {2, 2, 4, 1},
        //     {5, 0, 2, 3},
        //     {0, 6, 1, 2}};
        // Wyjście: 16
        //     (2,0) -> (1,1) -> (1,2) -> (0,3) LUB
        //     (2,0) -> (3,1) -> (2,2) -> (2,3)
        //
        // Wejście : gold[][] = {{10, 33, 13, 15},
        //                       {22, 21, 04, 1},
        //                       {5, 0, 2, 3},
        //                       {0, 6, 14, 2}};
        // Wyjście: 83 
        // Uwaga!!!
        // Najłatwiej zrealizować algorytm w postaci rekurencyjnej.
        // Memoizacja zmniejszy złożoność czasową.
        public static int CollectGold(int[,] gold, int x, int y, int n, int m)

        {
            if ((x < 0) || (x == n) || (y == m))
            {
                return 0;
            }
            int rightUpperDiagonal = CollectGold(gold, x - 1, y + 1, n, m);
            int right = CollectGold(gold, x, y + 1, n, m);
            int rightLowerDiagonal = CollectGold(gold, x + 1, y + 1, n, m);
            return gold[x, y] + Math.Max(Math.Max(rightUpperDiagonal, rightLowerDiagonal), right);
        }

        static public int getMaxGold(int[,] gold, int n, int m)
        {
            int maxGold = 0;

            for (int i = 0; i < n; i++)
            {

                int goldCollected = CollectGold(gold, i, 0, n, m);
                maxGold = Math.Max(maxGold, goldCollected);
            }

            return maxGold;
        }

        static  void Main()
        {
            //task1
            int[,] gold = new int[,] { { 10, 33, 13, 15 },
                                   { 22, 21, 4, 1 },
                                   { 5, 0, 2, 3 },
                                   { 0, 6, 14, 2 } };


            int m = 4, n = 4;
            Console.WriteLine(getMaxGold(gold, n, m));
            //task2
            int[] a = new int[] { -2, -1, 10, 10000, -1 };
            int y = 5;

            Console.WriteLine(MinProduct(a, y));

        }

        /// <summary>
        /// Zaimplementuj funkcję, która wyznaczy najmniejszy ilocz wybranych liczb z tablicy arr.
        /// Iloczyn może składać się z jednej liczby.
        /// Przykład 1
        /// Wejscie: int[] arr = [0, 2, 4, 6]
        /// Wyjście: 0
        /// 
        /// Przykład 2
        /// Wejscie: int[] arr = [-2, -1, 10, 10_000, -1]
        /// Wyjście: -200_000
        /// 
        /// Przykład 3
        /// Wejscie: int[] arr = [2, 1, 10, 10_000, 1]
        /// Wyjście: 1
        /// </summary>
        /// <param name="arr">tablica liczb całkowitych</param>
        /// <returns>najmniejszy iloczyn tablicy wejściowej arr</returns>
        static int MinProduct(int[] a, int y)
        {
            if (y == 1)
                return a[0];
            int maxujemny = int.MinValue;
            int maxdodatni = int.MinValue;
            int licz_ujemny = 0, licz_zero = 0;
            int iloczyn = 1;

            for (int i = 0; i < y; i++)
            {
                // dla zera
                if (a[i] == 0)
                {
                    licz_zero++;
                    continue;
                }

                // liczy negatywne i wyznacza najmniejszy
                if (a[i] < 0)
                {
                    licz_ujemny++;
                    maxujemny = Math.Max(maxujemny, a[i]);
                }

                // najmniejszy dodatni
                if (a[i] > 0 && a[i] < maxdodatni)
                {
                    maxdodatni = a[i];
                }

                iloczyn *= a[i];
            }

 
            if (licz_zero == y
                || (licz_ujemny == 0 && licz_zero > 0))
                return 0;

            if (licz_ujemny == 0)
                return maxdodatni;


            if (licz_ujemny % 2 == 0 && licz_ujemny != 0)
            {
                iloczyn = iloczyn / maxujemny;
            }

            return iloczyn;
        }
    }
}
