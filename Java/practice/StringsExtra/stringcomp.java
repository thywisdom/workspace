class stringcomp{
    public static void main (String[] args){

        String a = "SumanE";
        String b = "SumanEzhumalai";
        int res = a.compareTo(b);
        System.out.println(res);

        if(res<0){
        System.out.println("the string is lesser ");
        System.out.println(res);
        }
        else if(res>0){
            System.out.println("the String is greater");
            System.out.println(res);
        }
        else{
         System.out.println("the String is equal");
        }
    }

}
