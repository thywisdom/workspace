import java.util.HashMap;
import java.util.*;

class HashmapCount {

  public static void main(String[] args) {

    Scanner sc = new Scanner(System.in);
    HashMap<String, Integer> freq = new HashMap<>();

    String str = sc.nextLine();

    for (String var : str.split(" ")) {

      freq.put(var, freq.getOrDefault(var, 0) + 1);
    }
    System.out.println(freq);
    sc.close();
  }
}
