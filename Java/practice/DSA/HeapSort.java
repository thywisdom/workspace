import java.util.*;

public class HeapSort {

    public static void heapSort(int[] arr) {

        int n = arr.length;
        for (int i = n / 2 - 1; i >= 0; i--) {

            heapify(arr, n, i);
        }

        for (int i = n - 1; i > 0; i--) {

            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            heapify(arr, n, 0);
        }

    }

    public static void heapify(int[] arr, int n, int i) {

        int largest = i;
        int L = 2 * i + 1;
        int R = 2 * i + 2;

        if (L < n && arr[L] > arr[largest]) {
            largest = L;
        }
        if (R < n && arr[R] > arr[largest]) {
            largest = R;
        }

        if (largest != i) {
            int swap;
            swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            heapify(arr, n, largest);
        }

    }

    public static void display(int[] arr) {

        System.out.println();
        System.out.println();
        for (int v : arr) {
            System.out.print(" -> " + v);
        }

    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.println("Enter the size of the  Array : ");
        int n = sc.nextInt();

        System.out.print(" Enter the elements : ");
        int arr[] = new int[n];

        for (int i = 0; i < n; i++) {
            arr[i] = sc.nextInt();
        }

        heapSort(arr);
        display(arr);

        sc.close();
    }
}
