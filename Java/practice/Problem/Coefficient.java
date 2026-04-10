import java.io.*;
import java.util.*;

public class Coefficient {



    public static int calculateCoefficient(String s) {
        int n = s.length();
        int firstOne = -1, lastOne = -1;
        int firstZero = -1, lastZero = -1;

        for (int i = 0; i < n; i++) {
            if (s.charAt(i) == '1') {
                if (firstOne == -1) firstOne = i;
                lastOne = i;
            } else {
                if (firstZero == -1) firstZero = i;
                lastZero = i;
            }
        }

        int a = 0;
        if (firstOne != -1) {
            for (int i = firstOne; i <= lastOne; i++) {
                if (s.charAt(i) == '0') {
                    a++;
                }
            }
        }

        int b = 0;
        if (firstZero != -1) {
            for (int i = firstZero; i <= lastZero; i++) {
                if (s.charAt(i) == '1') {
                    b++;
                }
            }
        }

        return a + b;
    }

    public static int getOps(String s, String t) {
        int n = s.length();
        int ops = 0;
        boolean inGroup = false;
        for (int i = 0; i < n; i++) {
            if (s.charAt(i) != t.charAt(i)) {
                if (!inGroup) {
                    ops++;
                    inGroup = true;
                }
            } else {
                inGroup = false;
            }
        }
        return ops;
    }

    public static int minOpsToSort(String s) {
        int n = s.length();
        int minOps = n;


        for (int k = 0; k <= n; k++) {
            StringBuilder target = new StringBuilder();
            for (int i = 0; i < k; i++) target.append('0');
            for (int i = k; i < n; i++) target.append('1');
            minOps = Math.min(minOps, getOps(s, target.toString()));
        }

        for (int k = 0; k <= n; k++) {
            StringBuilder target = new StringBuilder();
            for (int i = 0; i < k; i++) target.append('1');
            for (int i = k; i < n; i++) target.append('0');
            minOps = Math.min(minOps, getOps(s, target.toString()));
        }
        return minOps;
    }


    public static String flip(String s, int i, int j) {
        char[] chars = s.toCharArray();
        for (int k = i; k <= j; k++) {
            chars[k] = (chars[k] == '0' ? '1' : '0');
        }
        return new String(chars);
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int p = sc.nextInt();
        sc.nextLine();
        String s = sc.nextLine();

        int m = minOpsToSort(s);


        if (p >= m) {
            System.out.println(0);
            return;
        }

        int minCoeff = calculateCoefficient(s);
        if (p >= 1) {

            for (int i = 0; i < n; i++) {
                for (int j = i; j < n; j++) {
                    String sPrime = flip(s, i, j);
                    minCoeff = Math.min(minCoeff, calculateCoefficient(sPrime));
                }
            }
        }



        System.out.println(minCoeff);
    }
}
