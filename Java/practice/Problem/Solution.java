import java.util.*;

public class Solution {

    static boolean isPrime(int num) {
        if (num < 2) return false;
        for (int i = 2; i < num; i++) {
            if (num % i == 0)
                return false;
        }
        return true;
    }


    static boolean isPalindrome(int num) {
        int original = num;
        int reversed = 0;

        while (num != 0) {
            int digit = num % 10;
            reversed = reversed * 10 + digit;
            num /= 10;
        }

        return original == reversed;
    }

    static int isPrimePalindrome(int a) {
        int i = a;
        while (true) {
            if (isPrime(i) && isPalindrome(i)) {
                return i; 
            }
            i++;
        }
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int a = sc.nextInt();
        System.out.println("Next Prime Palindrome of " + a + " is: " + isPrimePalindrome(a));
    }
}

