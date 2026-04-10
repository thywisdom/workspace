import java.util.Scanner;

class jaggthree{
    public static void main(String[] args){
 
        Scanner in = new Scanner(System.in);  

        int[][][] arr= new int[2][][];
        arr[0]= new int[2][];
        arr[0][0]=new int[3];
        arr[0][1]=new int[1];

        arr[1]= new int[1][];
        arr[1][0]= new int[5];
        
         
        for(int i=0;i<arr.length;i++){
            for(int j=0;j<arr[i].length;j++){
                for(int k=0;k<arr[i][j].length;k++){
            System.out.print("Enter the"+(i+1)+" Block "+(j+1)+" Row "+(k+1)+" Column "+" number : ");
            arr[i][j][k]=in.nextInt();
            System.out.print("\n");
            
            }

            }
        }

        for(int i=0;i<arr.length;i++){
            for(int j=0;j<arr[i].length;j++){
                for(int k=0;k<arr[i][j].length;k++){
            System.out.print(arr[i][j][k]);
            
                }System.out.println();
            } System.out.println();
        }
    }
}