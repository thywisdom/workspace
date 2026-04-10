import java.util.*;

class Substring{

static String subString(String s,int c,int w){

            String st="";

            for(int i=c;i<s.length();i++){

                if(i==w+1){
                    break;
                }

                st+=s.charAt(i);
            }

            return st;
}



    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        String s= in.next();
        int c = in.nextInt();
        int w= in.nextInt();
       System.out.println(subString(s,c,w));
   // System.out.println(c[0]);

    }
}
