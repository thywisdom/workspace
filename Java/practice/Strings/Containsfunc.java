import java.util.*;

class Containsfunc {

    static boolean Contains(String s, String w) {

        int size = w.length();
        int st = 0;
        for (int i = 0; i < s.length(); i++) {
            if (s.charAt(i) == w.charAt(0)) {
                st = i;
                break;
            }
        }

        int count = 0;
        for (int i = 0; i < size; i++) {

            if (s.charAt(st + i) == w.charAt(i)) {
                count++;
            } else {
                break;
            }

        }
        if (count == size) {
            return true;
        } else {
            return false;
        }

    }

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        String s = in.next();
        String w = in.next();
        System.out.println(Contains(s, w));
        // System.out.println(c[0]);

        in.close();

    }
}
