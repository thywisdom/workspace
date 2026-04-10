import java.util.*;

class MergeSort {

    public static void mergeSort(int[] arr, int l, int h) {
        if (l < h) {
            int mid = l + (h - l) / 2;
            mergeSort(arr, l, mid);
            mergeSort(arr, mid + 1, h);

            merge(arr, l, mid, h);
        }

    }

    public static void merge(int[] arr, int l, int mid, int h) {

        // finding size
        int n1 = mid - l + 1;
        int n2 = h - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++)
            L[i] = arr[l + i];
        for (int j = 0; j < n2; j++)
            R[j] = arr[mid + j + 1];

        int i = 0, j = 0;
        int k = l;

        while (i < n1 && j < n2) {
            if (L[i] <= R[j]) {
                arr[k] = L[i];
                i++;
            } else {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

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

    public static void display(int[] arr) {

        System.out.print("The sorted Array : ");
        for (int v : arr) {
            System.out.println(" -> " + v);
        }
    }

    public static int Bsearch(int[] arr, int l, int h, int target) {
        int mid = l + (h - l) / 2;
        if (l <= h) {
            if (arr[mid] == target) {
                return mid;
            } else if (arr[mid] > target) {
                return Bsearch(arr, l, mid - 1, target);
            } else {
                return Bsearch(arr, mid + 1, h, target);
            }
        }
        return -1;
    }

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        System.out.println("Enter the array size : ");
        int n = sc.nextInt();
        System.out.print("Enter the elements of above size:");
        int[] arr = new int[n];

        for (int i = 0; i < n; i++) {
            arr[i] = sc.nextInt();
        }

        mergeSort(arr, 0, arr.length - 1);
        display(arr);

        System.out.println();
        System.out.println();

        System.out.print("Enter the element to find : ");
        int target = sc.nextInt();

        System.out.println();
        System.out.println();
        System.out.println(
                "The target element " + target + "is found at index of " + Bsearch(arr, 0, arr.length - 1, target));

        sc.close();
    }
}
