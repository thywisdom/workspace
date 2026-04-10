import java.util.Scanner;

class Btod{

    static double BinaryToDecimal ( int n){
      
        double dec = 0;
        int k = 1;

        /*while (n>0) {

          int digit = n % 10 ;
          dec =  (digit*k)+dec;
          n = n/10;
          k =k *2; 
        
        }*/

        String num = Integer.toString(n);
        
         
        for (int i = 0; i < num.length(); i++) {
          
          dec = Math.pow((num.charAt(num.length()-1)),i)+dec;
          
        }

        return dec;
    }

    public static void main(String args[]) {
      
      Scanner sc = new Scanner(System.in);

      int n = sc.nextInt();
      System.out.println(BinaryToDecimal(n));
    }
}
