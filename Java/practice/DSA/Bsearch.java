public class Bsearch {
  static int BTsearch(int arr[], int l, int h, int target) {
    if (l > h) {
      return -1;
    }
    int mid = l + (h - l) / 2;
    if (arr[mid] == target) {
      return mid;
    } else if (target > arr[mid]) {
      l = mid + 1;
      BTsearch(arr, l, h, target);
    } else {
      h = mid - 1;
    }

    return mid;
  }

  public static void main(String[] args) {
    int arr[] = { 5, 5, 6, 7, 9, 10, 11, 12, 13, 14, 15 };
    int l = 0;
    int h = arr.length - 1;
    int a = BTsearch(arr, l, h, 7);
    if (a == -1) {
      System.out.println("Element not found");
      return;
    }
    System.out.println("Element found at " + a);
  }
}
