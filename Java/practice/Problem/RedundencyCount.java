import java.util.Scanner;

public class RedundencyCount {

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        System.out.print("Enter the Array Size :  ");
        System.out.println();

        int n = sc.nextInt();

        System.out.println();

        int[] arr = new int[n];

        System.out.println("Enter the elements:   ");
        for (int i = 0; i < n; i++) {

            arr[i] = sc.nextInt();

        }

        int[] ar = new int[256];

        for (int i = 0; i < arr.length; i++) {

            ar[arr[i]]++;
        }
        System.out.println();
        for (int j = 0; j < ar.length; j++) {
            if (ar[j] != 0) {
                System.out.println("The number " + j + " Repeated for " + ar[j] + " times");
            }
        }

        sc.close();
    }
}
