import java.util.StringTokenizer;

class stringtokenc {
        public static void main(String[] args) {

        String st = " I am Suman Ezhumalai";
        StringTokenizer a = new StringTokenizer(st);


        if(a.hasMoreElements()){
            System.out.println(a.nextToken());

        }
        System.out.println("- - - - -- - - - -- ");

        while(a.hasMoreElements()){
            System.out.println(a.nextToken());

        }

        StringTokenizer b = new StringTokenizer(st,"a");


       System.out.println("- - - - -- - - - -- ");

        while(b.hasMoreElements()){
            System.out.println(b.nextToken());

        }



     }
}
