class stringConcat{
    public static void main(String[] args){
        String a = "Suman";
        String b ="Ezhumalai";
        String c ="Suman"+"ezhumalai";
        String d ="Suman"+"Ezhumalai";
        //refernce
        if(c==d){
            System.out.println("The strings are equal");
        }
        else{
             System.out.println("The strings are not equal");
        }
         
        if(c.equalsIgnoreCase(d)){
            System.out.println("The strings are equal");
        }
        else{
             System.out.println("The strings are not equal");
        }
        System.out.println("\n");

        String e = a+b;
        String f = a+b;
        //variable

         if(e==f){
            System.out.println("The strings are equal");
        }
        else{
             System.out.println("The strings are not equal");
        }
         
        if(e.equalsIgnoreCase(f)){
            System.out.println("The strings are equal");
        }
        else{
             System.out.println("The strings are not equal");
        }
    }
}
