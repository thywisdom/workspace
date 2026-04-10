import java.util.Scanner;

class Lastindexoff {

    static int indexOff(String s,char var){

        for(int i=s.length()-1;i>=0;i--){

            if(s.charAt(i)==var){
                    return i;
            }
        }
        return -1;

}



    public static void main(String[] args){

        Scanner in = new Scanner(System.in);

        String s = in.nextLine();
        char var =in.next().charAt(0);

        System.out.println(indexOff(s,var));

    }
}

