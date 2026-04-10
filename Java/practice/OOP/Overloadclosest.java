public class Overloadclosest {

    void closestMatch(int a , float b){
        System.out.println("One");
        System.out.println(a+" "+b);

    }

    void closestMatch(double a , double b){
        System.out.println("two");
        System.out.println(a+" "+b);

    }
    public static void main(String[] args) {
        
        Overloadclosest a = new Overloadclosest();

        a.closestMatch(1,2);
        a.closestMatch(0.1f, 0.3f);

    }
} 
    

