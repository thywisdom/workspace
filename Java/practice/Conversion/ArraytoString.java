import java.util.*;

public class ArraytoString {
    public static void main(String[] args) {

        int arr[] = { 1, 8, 9, 6, 9 };
        int ar[][] = { { 1, 2 }, { 3, 4 }, { 5, 6 } };

        System.out.println(Arrays.toString(arr));
        System.out.println(Arrays.deepToString(ar));

        String[] str = { "suman", "learns", "hardwork", "Java" };
        String[][] st = { { "Apple", "Orange" }, { "cat", "dog" }, { "food", "money" } };
        String[][][] s = { { { "K", "a" }, { "m", "e" }, { "s", "h" } }, { { "s", "a", "x" }, { "e", "l" } } };

        System.out.println(Arrays.toString(str));
        System.out.println(Arrays.deepToString(st));

        System.out.println(Arrays.deepToString(s));
        System.out.println(s);
    }
}
