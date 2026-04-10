class Valuepass {
    static String combin ( int x , String y){
        x=x+10;
        y+=" Ezhumalai";
        return x+y;
    }
    public static void main (String[] args){
        int a =10; 
        String name = " Suman";
        System.out.println(a);
        System.out.println(name);
        System.out.println(combin(a,name));
        System.out.println(a);
        System.out.println(name);
    }
}