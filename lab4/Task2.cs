
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

        static public void Main()
        {

            int[,] gold = new int[,] { { 10, 33, 13, 15 },
                                   { 22, 21, 4, 1 },
                                   { 5, 0, 2, 3 },
                                   { 0, 6, 14, 2 } };


            int m = 4, n = 4;
            Console.Write(getMaxGold(gold, n, m));
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
        static public int MinProduct(int[] arr)
        {
            throw new NotImplementedException();
        }
    }
}
