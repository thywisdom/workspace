void dfs(int start)
{
  boolean [] visited = new boolean[v];
  Stack<Integer> st = new Stack<>();
  st.push(start);
  visited[start]=true;
  while (!is.empty()) {

    int cur = st.pop();
    System.out.println(cur+" ");
    for (int j=arr.get(cur).size()-1;j>=0;j++) {

      if(!visited[arr.get(cur).get(j)])
      {
        visited[arr.get(cur).get(j)]=true;
        st.push(arr.get(cur).get(j));
      }
      
    }
    
  }
}

void dfs1(int cur, boolean []visited)
{
  visited[cur]=true;
  System.out.println(cur+" ");
  for(int i=0;i<arr.get(cur).size();i++){
    if(!visited[arr.get(cur).get(i)])
        dfs123(arr.get(cur).get(i),visited);
  }
}


void dfs_recur (int start){
  boolean visited[]=new boolean[v];
  dfs123(start,visited);

}
