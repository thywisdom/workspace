class function {

   void add (int a , int b ){
        int c = a+b;
        System.out.println( "the answer is "+c);

 }

void sub (int a ,int b ){
        int c = a-b;
        System.out.println( "the answer is "+c);
      }
      

   public static void main (String args[]){

      function A = new function();
      int x =10;
      int y =15;
      A.add(x,y);

     
      A.sub(x,y);

   }
  }

