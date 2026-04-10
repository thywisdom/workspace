import java.util.*;

class Replacefunc{

static char[] Replace(String s,char c, String w){

            int size = w.length();
            int st=0;
            for(int i=0;i<s.length();i++){
                if(s.charAt(i)== c) {
                        st=i;
                        break;
                }
            }

            char[] arr=s.toCharArray();

            int count=0;
            for(int i=0 ; i<size ;i++){

               arr[st+i]=w.charAt(i);
        }
        return arr;
}



    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        String s= in.next();
        char c = in.next().charAt(0);
        String w= in.next();
       System.out.println(Replace(s,c,w));
   // System.out.println(c[0]);

    }
}
