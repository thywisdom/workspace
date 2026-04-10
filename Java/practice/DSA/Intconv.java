import java.util.*;

class Intconv {

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        System.out.println("Enter teh size of array  : ");
        int n = sc.nextInt();

        System.out.println("Enter the elements : ");

        int arr[] = new int[n];
        for (int i = 0; i < n; i++) {

            arr[i] = sc.nextInt();
        }
        System.out.println(arr.toString());

        sc.close();
    }
}
