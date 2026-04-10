import java.util.*;

class Equalsfunc {

    static boolean equalsTo(String s,String w){
            if(s.length()==w.length()){
            int size = (s.length()>w.length()) ? s.length():w.length();
            int count=0;
            for(int i=0 ; i< size ;i++){

               if (s.charAt(i)==w.charAt(i)){
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
    else{

        return false;
    }

}



    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        String s= in.next();
        String w= in.next();
       System.out.println(equalsTo(s,w));
   // System.out.println(c[0]);

    }
}
