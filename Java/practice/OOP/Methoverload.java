public class Methoverload {

    void methOverload(int a , int b){
        System.out.println(a+" "+b);

    }

    void methOverload(float a , float b){
        System.out.println(a+" "+b);

    }
    public static void main(String[] args) {
        
        Methoverload a = new Methoverload();

        a.methOverload(1,2);
        a.methOverload(0.1f, 0.3f);

    }
}
