import java.util.Scanner;

class jaggarr{
    public static void main(String[] args){
 
        Scanner in = new Scanner(System.in);  

        int[][] arr= new int[2][];
        arr[0]=new int[2];
        arr[1]=new int[5];

        for(int i=0;i<arr.length;i++){
            for(int j=0;j<arr[i].length;j++){
            System.out.print("the "+(i+1)+" row "+(j+1)+" column "+" number : ");
            arr[i][j]=in.nextInt();
            System.out.print("\n");

            }
        }

        for(int i=0;i<arr.length;i++){
            for(int j=0;j<arr[i].length;j++){
            System.out.print("the "+(i+1)+" row "+(j+1)+" column "+" number : "+arr[i][j]);
            System.out.print("\n");
            } 
        }
    }
}