class stringIgnoreCase{
    public static void main(String[] args){
        String a = "suman";
        String b ="Suman";

        if(a==b){
            System.out.println("The strings are equal");
        }
        else{
             System.out.println("The strings are not equal");
        }
        
        if(a.equals(b)){
            System.out.println("The strings are equal");
        }
        else{
             System.out.println("The strings are not equal");
        }
          
        if(a.equalsIgnoreCase(b)){
            System.out.println("The strings are equal");
        }
        else{
             System.out.println("The strings are not equal");
        }
    }
}