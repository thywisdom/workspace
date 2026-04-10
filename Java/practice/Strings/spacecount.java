import java.util.Scanner;

class spacecount {

    static int  spacecountn(String s){

 int count = 0;

            for(int i=0 ; i< s.length();i++){
                 if (s.charAt(i) == ' '){
                     count++;
                 }

        }

                 return count;
}



    public static void main(String[] args) {


        Scanner in = new Scanner(System.in);

        String s= in.nextLine();
       System.out.println(spacecountn(s));


    }
}
