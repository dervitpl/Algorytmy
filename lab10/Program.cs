﻿//kacper mucha
namespace task_7;

public class Node<T> where T : IComparable<T>
{
    public T Value { get; set; }
    public Node<T> Left { get; set; }
    public Node<T> Right { get; set; }
}

public class BTree<T> where T : IComparable<T>
{
    public Node<T> Root { get; set; }

    public void Print()
    {
        InnerPrint(Root, 0);
    }

    public bool Contains(T value)
    {
        return InnerContains(Root, value);
    }

    public bool InnerContains(Node<T>? node, T value)
    {
        if (node == null)
        {
            return false;
        }
        int compare = node.Value.CompareTo(value);
        if (compare == 0)
        {
            return true;
        }
        if (compare > 0)
        {
            return InnerContains(node.Left, value);
        }
        else
        {
            return InnerContains(node.Right, value);
        }
    }

    private void InnerPrint(Node<T>? node, int level)
    {
        if (node == null)
        {
            return;
        }
        Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", level))}{node.Value}");
        InnerPrint(node.Left, level + 1);
        InnerPrint(node.Right, level + 1);
    }
    /**
     * Metoda przegląda drzewo w kolejności preorder, czyli
     * odwiedzamy wartość bieżącego węzła
     * odwiedzamy lewe podrzewo węzła
     * odwiedzamy prawe poddrzewo węzła
     * Przykład
     * Wyświetlenie wartości wszystkich węzłów
     * tree.Preorder(value => Console.WriteLine(value));
     */
    public void Preorder(Action<T> action)
    {
        InnerPreorder(action, Root);
    }
    /**
     * Metoda rekurencyjna przeglądania preorder dowolnego podrzewa wskazywanego przez `node`
     */
    public void InnerPreorder(Action<T> action, Node<T>? node)
    {
        if (node == null)
        {
            return;
        }
        action.Invoke(node.Value);
        InnerPreorder(action, node.Left);
        InnerPreorder(action, node.Right);
    }
}

public class Task7
{
    /**
     * Zadanie 1 (3 pkt.)
     * Zaimplementuj funkcję, która na podstawie posortowanej tablicy elementów typu T
     * zbuduje drzewo BST.
     * Przykład
     * Wejście:
     * int[] arr = {1, 3, 5, 7, 8, 9, 12, 15, 18, 22, 26, 67, 89};
     * Wyjście:
     *                                     12
     *                             5                22
     *                         1      8        15        67  
     *                           3  7   9        18    26  89
     * Wskazówka!!
     * Zdefiniuj metodę rekurencyjną innerBuild, która wyszukuje element środkowy i rekurencyjnie dołącza do lewego i prawego potomka węzły
     * zwracane przez wywołania rekurencyjne dla lewej i prawej części tablicy.
     */
    public static BTree<T> BuildTree<T>(T[] arr) where T : IComparable<T>
    {
        var btree = new BTree<T>();

        btree.Root = InnerBuild(arr, 0, arr.Length - 1);

        return btree;
    }

    private static Node<T> InnerBuild<T>(T[] arr, int start, int end) where T : IComparable<T>
    {
        if (start > end)
        {
            return null;
        }

        int mid = start + (end - start) / 2;
        var node = new Node<T> { Value = arr[mid] };

        node.Left = InnerBuild(arr, start, mid - 1);
        node.Right = InnerBuild(arr, mid + 1, end);

        return node;
    }
    /**
     * Zadanie 2 (1 pkt.)
     * Zdefiniuj metodę, która zwraca true, jeśli przekazane drzewo binarne spełnia warunek drzewa BST
     * Wskazówka
     * Zdefiniuj rekurencyjną metodę pomocniczą, która sprawdza, czy dane podrzewo jest typu BST.
     */
    public static bool IsValidBST<T>(BTree<T> tree) where T : IComparable<T>
    {
        return IsValidBST(tree.Root, default(T), default(T));
    }

    private static bool IsValidBST<T>(Node<T>? node, T lowerBound, T upperBound) where T : IComparable<T>
    {
        if (node == null)
        {
            return true;
        }

        if (lowerBound != null && node.Value.CompareTo(lowerBound) <= 0)
        {
            return false;
        }
        if (upperBound != null && node.Value.CompareTo(upperBound) >= 0)
        {
            return false;
        }

        return IsValidBST(node.Left, lowerBound, node.Value) && IsValidBST(node.Right, node.Value, upperBound);
    }


    /**
    * Zadanie 3 (2 pkt.)
    * Zaimplementuj metodę, która zwraca największy i najmniejszy element drzewa BST
    * w postaci krotki (min, max).
    */
    public static (T min, T max) MinAndMaxInBST<T>(BTree<T> tree) where T : IComparable<T>
    {
        return MinAndMaxInBST(tree.Root);
    }

    private static (T min, T max) MinAndMaxInBST<T>(Node<T>? node) where T : IComparable<T>
    {
        if (node == null)
        {
            return default;
        }

        var (leftMin, leftMax) = MinAndMaxInBST(node.Left);
        var (rightMin, rightMax) = MinAndMaxInBST(node.Right);

        T min = node.Value;
        T max = node.Value;

        if (leftMin != null)
        {
            min = leftMin;
        }
        if (rightMin != null)
        {
            min = rightMin;
        }
        if (leftMax != null)
        {
            max = leftMax;
        }
        if (rightMax != null)
        {
            max = rightMax;
        }

        return (min, max);
    }

    /**
    * Zadanie 4 (2 pkt.)
    * Zaimplementuj metodę zwracającą liczbę węzłów potomnych węzła, który zwiera wartość value
    * Jeśli w drzewie nie ma węzła z value to należy zwrócić 0.
    * Przykład
    * Wejście:
    * 
    *                                     12
    *                             7                22
    *                         3      9        15        67  
    *                     1     5      8         18  26    89
    * CountNodes(tree, 7)
    * Wyjście:
    * 5
    * Wskazówka
    * Wykorzystaj metodę InnerPreorder(action, node), która odwiedzi każdy węzeł potomny węzła `node`.
    */
    public static int CountNodes<T>(BTree<T> tree, T value) where T : IComparable<T>
    {
        int count = 0;
        tree.InnerPreorder((node) =>
        {
            if (node.Value.CompareTo(value) == 0)
            {
                count++;
            }
        }, tree.Root);
        return count;
    }


    /**
     * Zadanie 5 (2 pkt.)
     * Zaimplementuj metodę, która zwraca elementy z zakresu od start do end
     * części wspólnej dwu drzew a i b. Metoda nie może modyfikować drzew a i b!
     * Przykład
     * Wejście
     *   SortedSet<int> a = new SortedSet<int>()
     *   {
     *       1, 2, 4, 5, 6, 8, 9, 34
     *   };
     *   SortedSet<int> b = new SortedSet<int>()
     *   {
     *       0, 2, 7, 8, 9, 11, 3, 1
     *   };
     *   var set = Task7.Range(a, b, 2, 8);
     *   Console.WriteLine(string.Join(" ", set));
     * Wyjście 
     *   2 8
     */
    public static SortedSet<T> Range<T>(SortedSet<T> a, SortedSet<T> b, T start, T end)
    {
        SortedSet<T> result = new SortedSet<T>(a);
        result.IntersectWith(b);
        return result.GetViewBetween(start, end);
    }


}