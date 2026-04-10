class stringNonContext{
    public static void main(String[] args){
        String a = new String("suman");
        String b =new String("suman");

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
    }
}