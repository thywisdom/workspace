import java.util.Scanner;

class Uppertolower {

  static String upperToLower(String s) {

    String a = "";

    for (int i = 0; i < s.length(); i++) {

      char var = s.charAt(i);
      if (var >= 'A' && var <= 'Z') {
        a += (char) (var + 32);
      } else {
        a += var;
      }

    }

    return a;
  }

  public static void main(String[] args) {

    Scanner in = new Scanner(System.in);

    String s = in.nextLine();
    System.out.println(upperToLower(s));

  }
}
