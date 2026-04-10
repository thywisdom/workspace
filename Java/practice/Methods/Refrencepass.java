class Suman{
    static String name;
    static int age ;
    static boolean student;

    void detailModify (Suman y){
        
        y.name = "Ezhumalai";
        y.age= 52;
        y.student= false;
    }

    String Display (Suman y){
        
        return Suman.name+" "+ Suman.age+" " +" student : "+ Suman.student;
    } 
}
class Refrencepass{
    public static void main (String[] args){
        Suman a = new Suman();
        a.name= "Suman";
        a.age = 20;
        a.student = true ;
        System.out.println(a.Display(a));
        a.detailModify(a);
        System.out.println(a.Display(a));

    }
}
