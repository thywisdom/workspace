import java.util.Scanner;

class Trimfunc{

    static String trimFunc(String s){

        String t = "";
        int st=0 ,end=0 ;

         for(int i=0;i<= s.length();i++){

            if(s.charAt(i)!=' '){
                      st = i;
                break;
            }
        }


        for(int i=s.length()-1;i>=0;i--){

            if(s.charAt(i)!= ' '){
                    end = i;
                    break;
            }
        }

     for(int i = st; i<=end ;i++){

                t+=s.charAt(i);
           }
     return t;

}



    public static void main(String[] args){

        Scanner in = new Scanner(System.in);

        String s = in.next();

        System.out.println(trimFunc(s));

    }
}

