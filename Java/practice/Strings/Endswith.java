import java.util.*;

class Endswith{

static boolean endsWith(String s,String w){

            int size = w.length();
            int diff = s.length()-w.length();
            int count=0;
            for(int i=size-1 ; i>=0 ;i--){

               if (s.charAt(diff+i)==w.charAt(i)){
                       count++;
            }else{
                break;
            }

        }
         if(count==size){
                return true;
            }else{
                    return false;
            }


}



    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        String s= in.next();
        String w= in.next();
       System.out.println(endsWith(s,w));
   // System.out.println(c[0]);

    }
}
