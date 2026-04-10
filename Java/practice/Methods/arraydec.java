import java.util.Scanner;

class arraydec{
    public static void main (String[] args){
        Scanner in= new Scanner(System.in);

        int[] a = new int[10];
        
        System.out.println("Plz enter 10 int values:");
        for(int i=0;i<10;i++){
          
            a[i]=in.nextInt();

        }

        System.out.println("the entered 10 int values are :");
        for(int i=0;i<10;i++){
          
            System.out.print(a[i]+" ");

        }
    }
}