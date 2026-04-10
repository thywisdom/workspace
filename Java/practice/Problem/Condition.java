import java.util.Scanner;

class Condition {
    public static void main(String args[]) {
        Scanner sc = new Scanner(System.in);
        int num = sc.nextInt();

        if (num % 2 != 0) {
            System.out.println("No");
        } else {
            System.out.println("Yes");
            if ((num / 2) % 2 == 0) {
                System.out.println(num / 2 + " , " + num / 2);
            } else {
                System.out.println(((num / 2)) + 1 + " , " + ((num / 2) - 1));
            }
        }
    }
}
