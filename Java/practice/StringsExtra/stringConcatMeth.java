class stringConcatMeth{
    public static void main(String[] args){
        String a = "suman";
        String b ="Suman";
        String c = a+b;
        String d = a+b;

    

        if(c==d){
            System.out.println("The ref are equal");
        }
        else{
             System.out.println("The ref are not equal");
        }
        
        String e = "demo".concat("concatenation");
        String f = "demo".concat("concatenation");
    
        
        if(e.equals(f)){
            System.out.println("The ref are equal");
        }
        else{
             System.out.println("The ref are not equal");
        }

    }
}
