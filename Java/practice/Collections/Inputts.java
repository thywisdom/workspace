import java.util.Arrays;
import java.util.Scanner;
import java.util.TreeSet;

class Inputts {

    public static void main(String args[]) {
        Scanner sc = new Scanner(System.in);

        String s = sc.nextLine().trim();
        //s = s.replaceAll("\\[|\\]|\\{|\\}", "");
        s = s.replaceAll("[a-z]", "");
        String[] arr = s.split("");
        Integer[] n = new Integer[arr.length];

        int i = 0;
        for (String var : arr) {
            n[i] = Integer.parseInt(var);
            i++;
        }
        //System.out.println(arr);

        i = 0;
        for (int num : n) i = i + num;

        System.out.println(i);
        System.out.println(Arrays.toString(n));

        //Arrays.sort(n);
        TreeSet<Integer> set = new TreeSet<>(Arrays.asList(n));
        System.out.println(set.contains(1));
        System.out.println(set);
        Arrays.sort(n);
        System.out.println(Arrays.toString(n));
        sc.close();
    }
}
