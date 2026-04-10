import java.util.*;

class AdjList {

  ArrayList<ArrayList<Integer>> arr;

  AdjList(int v) {

    arr = new ArrayList<>();

    for (int i = 0; i < v; i++) {

      ArrayList<Integer> qwe = new ArrayList<>();
      arr.add(qwe);

    }
  }

  void addEdge(int src, int dest) {

    arr.get(src).add(dest);
    arr.get(dest).add(src);
  }

  public static void main(String[] args) {
    Scanner s = new Scanner(System.in);
    int vertex = s.nextInt();
    AdjList aj = new AdjList(vertex);
    int tot_edge = s.nextInt();

    for (int i = 0; i < tot_edge; i++) {

      int src = s.nextInt();
      int dest = s.nextInt();
      aj.addEdge(src, dest);
    }
    System.out.println(aj.arr);

    s.close();
  }

}
