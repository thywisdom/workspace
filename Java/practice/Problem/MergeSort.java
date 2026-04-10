import java.util.Scanner;

public class MergeSort {

    static void MergeSort(int[] arr, int l, int h) {
        if (l < h) {
            int n = arr.length - 1;

            int mid = l + (h - l) / 2;

            MergeSort(arr, l, mid);
            MergeSort(arr, mid + 1, h);

            Merge(arr, l, mid, h);
        }
    }

    static void Merge(int[] arr, int l, int mid, int h) {

        // finding total size of our temprary array
        int n1 = mid - l + 1;
        int n2 = h - mid;

        // creating temprary array to match
        int L[] = new int[n1];
        int R[] = new int[n2];

        // Copying the elements in the temprary
        for (int i = 0; i < n1; i++) {
            L[i] = arr[l + i];
        }
        for (int j = 0; j < n2; j++) {
            R[j] = arr[mid + j + 1];
        }

        // initiating index variables
        int i = 0, j = 0, k = l;

        while (i < n1 && j < n2) {
            if (L[i] <= R[j]) {
                arr[k] = L[i];
                i++;
                k++;
            } else {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // checking and copying remain leftover elements in respective array

        while (i < n1) {
            arr[k] = L[i];
            i++;
            k++;
        }
        while (j < n2) {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    static void display(int[] arr) {
        for (int val : arr) {

            System.out.print(" --> " + val);
        }
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.println("Enter the array size : ");
        int n = sc.nextInt();

        System.out.print("Enter the numbers : ");
        int arr[] = new int[n];

        for (int i = 0; i < n; i++) {
            arr[i] = sc.nextInt();

        }
        System.out.println("/n");
        MergeSort(arr, 0, arr.length - 1);

        display(arr);

        sc.close();

    }
}
