import java.util.Scanner;

class threedim{
    public static void main(String[] args){
 
        Scanner in = new Scanner(System.in);  

        int[][][] arr= new int[2][3][5];

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
            System.out.println(arr[i][j][k]);
            
                }
            } 
        }
    }
}