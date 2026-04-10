import java.util.Scanner;

class arrlength{
    public static void main(String[] args){
 
        Scanner in = new Scanner(System.in);  

        int[] arr= new int[10];
        for(int i=0;i<arr.length;i++){
            System.out.print("Enter the "+i+" number :  ");
            arr[i]=in.nextInt();
            System.out.print("\n");
        }

        for(int i=0;i<arr.length;i++){
            System.out.print("the "+i+" number : "+arr[i]);
            System.out.print("\n");
            
        }
    }
}