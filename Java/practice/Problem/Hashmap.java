import java.util.HashMap;

class Hashmap {

  public static void main(String[] args) {

    HashMap<Integer, String> map = new HashMap<>();

    map.put(0, "Suman");
    map.put(1, "Srinivas");
    map.put(2, "logesh");
    map.put(4, "Ramaneshwar");

    System.out.println(map.get(2));

  }
}
