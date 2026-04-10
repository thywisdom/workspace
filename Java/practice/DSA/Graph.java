//using Matrix

class Graph{

    int adjMatrix[][];
    Graph(int v)
    {
      adjMatrix = new int[v][v];

    }
    static void addEdge(int src , int dest)
    {
        adjMatrix[src][dest]=1;
        adjMatrix[dest][src]=1;
    }
    void printMatrix(){
      for( int i=0; i<v;i++){
        for( int j=0; j<v ; j++){

        System.out.print(adjMatrix[i][j]+" ");

        }
             System.out.println();
      } 

     }

    public static void main(String []uio) {

      Scanner sc = new Scanner(System.in);
      int vertex = s.nextInt();
      Graph g = new Graph(vertvex);
      int tot_edge=s.nextInt();
      for (int i = 0; i <tot_edge ; i++) {

        int src = s.nextInt();
        int dest= s.nextInt();
        g.addEdge(src,dest);
        
      }

      g.printMatrix();
      
    }
}
